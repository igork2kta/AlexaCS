using AlexaCS.Devices;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using WindowsInput.Native;

namespace AlexaCS
{
    public partial class MainForm : Form
    {
        Device[] devices;
        bool tcpRunning, udpRunning;

        CancellationTokenSource tokenUdp = new();
        CancellationToken ctUdp;
        CancellationTokenSource tokenTcp = new();
        CancellationToken ctTcp;
        TCPListener? listener;
        public bool TcpRunning
        {
            get => tcpRunning;
            set
            {
                tcpRunning = value;
                if (!value)
                {
                    bt_iniciar.Text = "Iniciar";
                    bt_iniciar.ForeColor = Color.White;
                    bt_iniciar.BackColor = Color.Red;
                    lbl_tcpState.ForeColor = Color.Red;
                    lbl_tcpState.Text = "O servidor est� desativado!";
                }
                else
                {
                    bt_iniciar.ForeColor = Color.Black;
                    bt_iniciar.BackColor = Color.LightGreen;
                    lbl_tcpState.ForeColor = Color.Lime;
                    bt_iniciar.Text = "Parar";
                    lbl_tcpState.Text = "O servidor est� ativado!";
                }
            }
        }
        public bool UdpRunning
        {
            get => udpRunning;
            set
            {
                udpRunning = value;
                if (!value)
                {
                    bt_pareamento.ForeColor = Color.White;
                    bt_pareamento.BackColor = Color.Red;
                    lbl_udpState.Text = "";
                }
                else
                {
                    bt_pareamento.ForeColor = Color.Black;
                    bt_pareamento.BackColor = Color.LightGreen;
                    lbl_udpState.Text = "O modo de pareamento est� ativado!";
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            cbox_IniciarComWindows.Checked = Properties.Settings.Default.AutoStart;
            cbox_saveLogs.Checked = Properties.Settings.Default.cbSaveLogs;
            cbox_IniciarMinimizado.Checked = Properties.Settings.Default.cbStartMinimized;
        }

        #region FormEvents
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt_tipo = new();
            dt_tipo.Columns.Add("TIPO", typeof(string));
            dt_tipo.Rows.Add("COMANDO");
            dt_tipo.Rows.Add("TECLA");
            dt_tipo.Rows.Add("VOLUME");
            TIPO.DataSource = dt_tipo;
            TIPO.ValueMember = "TIPO";
            TECLA.DataSource = Enum.GetNames(typeof(VirtualKeyCode));
            TECLA2.DataSource = TECLA.DataSource;
            TECLA3.DataSource = TECLA.DataSource;

            if (Properties.Settings.Default.cbStartMinimized) WindowState = FormWindowState.Minimized;

            if (CarregarComandos())
            {
                ctTcp = tokenTcp.Token;
                listener = new(ref devices, GetLocalIp());

                Task.Run(() => listener.Run(ctTcp));
                TcpRunning = true;
            }
            else
                TcpRunning = false;

            UdpRunning = false;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                ShowInTaskbar = false;
                //Esconde do gerenciador de tarefas quando a aplica��o � minimizada
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }
        }
        private void Dgv_devices_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 4) e.Cancel = true;
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exit();
        }

        #endregion

        #region TrayIcon
        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void FecharToolStripMenuItem_Click(object sender, EventArgs e) => Exit();
        
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            //Mostra no gerenciador de tarefas novamente
            FormBorderStyle = FormBorderStyle.Sizable;
        }
        #endregion

        #region ApplicationOptions
        private void Bt_salvar_Click(object sender, EventArgs e) => SalvarComandos();
        private void Bt_descartar_Click(object sender, EventArgs e)
        {
            dgv_devices.Rows.Clear();
            CarregarComandos();
        }
        private void Bt_iniciar_Click(object sender, EventArgs e)
        {
            if (!TcpRunning)
            {
                tokenTcp = new CancellationTokenSource();
                ctTcp = tokenTcp.Token;

                listener = new(ref devices, GetLocalIp());

                Task.Run(() => listener.Run(ctTcp));
                TcpRunning = true;
            }
            else
            {
                tokenTcp.Cancel();
                TcpRunning = false;
                listener?.Stop();
            }
        }
        private void Bt_pareamento_Click(object sender, EventArgs e)
        {
            if (!UdpRunning)
            {
                tokenUdp = new CancellationTokenSource();
                ctUdp = tokenUdp.Token;
                Task.Run(() => UDPListener.StartListener(GetLocalIp(), ctUdp));
                UdpRunning = true;
            }
            else
            {
                tokenUdp.Cancel();
                UdpRunning = false;
            }
        }

        private void Bt_abrirLogs_Click(object sender, EventArgs e)
            => Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory + "Logs");

        private void Bb_iniciarComWindows_CheckedChanged(object sender, EventArgs e)
        {
            AutoStartManager.SetAutoStart(cbox_IniciarComWindows.Checked);
        }

        private void Cbox_iniciarMinimizado_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.cbStartMinimized = cbox_IniciarMinimizado.Checked;
            Properties.Settings.Default.Save();
        }

        private void Cbox_saveLogs_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.cbSaveLogs = cbox_saveLogs.Checked;
            Properties.Settings.Default.Save();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            About about = new();
            about.ShowDialog();
        }
        #endregion

        #region FormFunctions
        public bool CarregarComandos()
        {
            List<DeviceCreator>? creator;

            dgv_devices.Rows.Clear();
            try
            {
                string json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\comandos.json");
                creator = JsonConvert.DeserializeObject<List<DeviceCreator>>(json);
            }
            catch (FileNotFoundException)
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\comandos.json", "[]");
                return false;
            }

            if (creator == null || creator.Count <= 0) return false;

            devices = DeviceCreator.CreateDeviceList(creator);

            foreach (DeviceCreator device in creator)
                dgv_devices.Rows.Add(device.nome, device.tipo, device.comando, device.argumento, device.tecla, device.tecla2, device.tecla3);

            return true;
        }

        
        public void SalvarComandos()
        {
            List<DeviceCreator> creator = new();

            string? deviceName, deviceType, command, argument, key, key2, key3;

            for (byte i = 0; i < dgv_devices.RowCount; i++)
            {
                if (dgv_devices.Rows[i].Index == (dgv_devices.Rows.Count - 1)) continue;

                deviceName = Convert.ToString(dgv_devices.Rows[i].Cells[0].Value);
                deviceType = Convert.ToString(dgv_devices.Rows[i].Cells[1].Value);
                command =   Convert.ToString(dgv_devices.Rows[i].Cells[2].Value);
                argument = Convert.ToString(dgv_devices.Rows[i].Cells[3].Value);
                key = Convert.ToString(dgv_devices.Rows[i].Cells[4].Value);
                key2 = Convert.ToString(dgv_devices.Rows[i].Cells[5].Value);
                key3 = Convert.ToString(dgv_devices.Rows[i].Cells[6].Value);

                if (String.IsNullOrEmpty(deviceType))
                {
                    MessageBox.Show("O tipo de dispositivo precisa ser selecionado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (deviceName == null || deviceType == null) continue;
                creator.Add(new(deviceName, deviceType, command, argument, key, key2, key3));

            }

            var json_serializado = JsonConvert.SerializeObject(creator);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\comandos.json", json_serializado);
            CarregarComandos();

            MessageBox.Show("Salvo com sucesso!", "Sucesso!");
        }

        private static string GetLocalIp()
        {
            using Socket socket = new(AddressFamily.InterNetwork, SocketType.Dgram, 0);
            socket.Connect("8.8.8.8", 65530);
            if (socket.LocalEndPoint is IPEndPoint endPoint) return endPoint.Address.ToString();

            else throw new Exception("Falha ao obter endere�o de IP local");
        }

        private void Exit()
        {
            tokenTcp.Cancel();
            tokenUdp.Cancel();
            Application.Exit();
        }
        #endregion
    }
}