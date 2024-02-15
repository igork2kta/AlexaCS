namespace AlexaCS
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            abrirToolStripMenuItem = new ToolStripMenuItem();
            fecharToolStripMenuItem = new ToolStripMenuItem();
            cbox_IniciarComWindows = new CheckBox();
            dgv_devices = new DataGridView();
            NOME = new DataGridViewTextBoxColumn();
            TIPO = new DataGridViewComboBoxColumn();
            COMANDO = new DataGridViewTextBoxColumn();
            ARGUMENTO = new DataGridViewTextBoxColumn();
            TECLA = new DataGridViewComboBoxColumn();
            TECLA2 = new DataGridViewComboBoxColumn();
            TECLA3 = new DataGridViewComboBoxColumn();
            bt_salvar = new Button();
            bt_descartar = new Button();
            cbox_IniciarMinimizado = new CheckBox();
            cbox_saveLogs = new CheckBox();
            bt_iniciar = new Button();
            bt_pareamento = new Button();
            lbl_tcpState = new Label();
            lbl_udpState = new Label();
            bt_abrirLogs = new Button();
            button1 = new Button();
            contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_devices).BeginInit();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipText = "FauxmoC# está rodando!";
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "FauxmoC#";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { abrirToolStripMenuItem, fecharToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(110, 48);
            // 
            // abrirToolStripMenuItem
            // 
            abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            abrirToolStripMenuItem.Size = new Size(109, 22);
            abrirToolStripMenuItem.Text = "Abrir";
            abrirToolStripMenuItem.Click += AbrirToolStripMenuItem_Click;
            // 
            // fecharToolStripMenuItem
            // 
            fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            fecharToolStripMenuItem.Size = new Size(109, 22);
            fecharToolStripMenuItem.Text = "Fechar";
            fecharToolStripMenuItem.Click += FecharToolStripMenuItem_Click;
            // 
            // cbox_IniciarComWindows
            // 
            cbox_IniciarComWindows.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbox_IniciarComWindows.AutoSize = true;
            cbox_IniciarComWindows.ForeColor = Color.White;
            cbox_IniciarComWindows.Location = new Point(12, 234);
            cbox_IniciarComWindows.Name = "cbox_IniciarComWindows";
            cbox_IniciarComWindows.Size = new Size(147, 19);
            cbox_IniciarComWindows.TabIndex = 1;
            cbox_IniciarComWindows.Text = "Iniciar com o Windows";
            cbox_IniciarComWindows.UseVisualStyleBackColor = true;
            cbox_IniciarComWindows.CheckedChanged += Bb_iniciarComWindows_CheckedChanged;
            // 
            // dgv_devices
            // 
            dgv_devices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_devices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_devices.BackgroundColor = SystemColors.MenuHighlight;
            dgv_devices.BorderStyle = BorderStyle.None;
            dgv_devices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_devices.Columns.AddRange(new DataGridViewColumn[] { NOME, TIPO, COMANDO, ARGUMENTO, TECLA, TECLA2, TECLA3 });
            dgv_devices.GridColor = SystemColors.ActiveBorder;
            dgv_devices.Location = new Point(12, 12);
            dgv_devices.Name = "dgv_devices";
            dgv_devices.RowHeadersWidth = 20;
            dgv_devices.RowTemplate.Height = 25;
            dgv_devices.Size = new Size(709, 166);
            dgv_devices.TabIndex = 2;
            dgv_devices.DataError += Dgv_devices_DataError;
            // 
            // NOME
            // 
            NOME.HeaderText = "NOME";
            NOME.Name = "NOME";
            // 
            // TIPO
            // 
            TIPO.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            TIPO.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            TIPO.HeaderText = "TIPO";
            TIPO.Name = "TIPO";
            TIPO.Width = 39;
            // 
            // COMANDO
            // 
            COMANDO.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            COMANDO.HeaderText = "COMANDO";
            COMANDO.Name = "COMANDO";
            COMANDO.Width = 94;
            // 
            // ARGUMENTO
            // 
            ARGUMENTO.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ARGUMENTO.HeaderText = "ARGUMENTO";
            ARGUMENTO.Name = "ARGUMENTO";
            ARGUMENTO.Width = 103;
            // 
            // TECLA
            // 
            TECLA.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            TECLA.HeaderText = "TECLA";
            TECLA.Name = "TECLA";
            // 
            // TECLA2
            // 
            TECLA2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            TECLA2.HeaderText = "TECLA2";
            TECLA2.Name = "TECLA2";
            TECLA2.Resizable = DataGridViewTriState.True;
            TECLA2.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // TECLA3
            // 
            TECLA3.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            TECLA3.HeaderText = "TECLA3";
            TECLA3.Name = "TECLA3";
            TECLA3.Resizable = DataGridViewTriState.True;
            TECLA3.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // bt_salvar
            // 
            bt_salvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_salvar.Location = new Point(646, 184);
            bt_salvar.Name = "bt_salvar";
            bt_salvar.Size = new Size(75, 23);
            bt_salvar.TabIndex = 3;
            bt_salvar.Text = "Salvar";
            bt_salvar.UseVisualStyleBackColor = true;
            bt_salvar.Click += Bt_salvar_Click;
            // 
            // bt_descartar
            // 
            bt_descartar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_descartar.BackColor = SystemColors.ControlLight;
            bt_descartar.ForeColor = Color.Black;
            bt_descartar.Location = new Point(565, 184);
            bt_descartar.Name = "bt_descartar";
            bt_descartar.Size = new Size(75, 23);
            bt_descartar.TabIndex = 4;
            bt_descartar.Text = "Descartar";
            bt_descartar.UseVisualStyleBackColor = true;
            bt_descartar.Click += Bt_descartar_Click;
            // 
            // cbox_IniciarMinimizado
            // 
            cbox_IniciarMinimizado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbox_IniciarMinimizado.AutoSize = true;
            cbox_IniciarMinimizado.ForeColor = Color.White;
            cbox_IniciarMinimizado.Location = new Point(12, 209);
            cbox_IniciarMinimizado.Name = "cbox_IniciarMinimizado";
            cbox_IniciarMinimizado.Size = new Size(124, 19);
            cbox_IniciarMinimizado.TabIndex = 5;
            cbox_IniciarMinimizado.Text = "Iniciar Minimizado";
            cbox_IniciarMinimizado.UseVisualStyleBackColor = true;
            cbox_IniciarMinimizado.CheckedChanged += Cbox_iniciarMinimizado_CheckedChanged;
            // 
            // cbox_saveLogs
            // 
            cbox_saveLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbox_saveLogs.AutoSize = true;
            cbox_saveLogs.ForeColor = Color.White;
            cbox_saveLogs.Location = new Point(12, 184);
            cbox_saveLogs.Name = "cbox_saveLogs";
            cbox_saveLogs.Size = new Size(88, 19);
            cbox_saveLogs.TabIndex = 8;
            cbox_saveLogs.Text = "Gravar Logs";
            cbox_saveLogs.UseVisualStyleBackColor = true;
            cbox_saveLogs.CheckedChanged += Cbox_saveLogs_CheckedChanged;
            // 
            // bt_iniciar
            // 
            bt_iniciar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_iniciar.BackColor = Color.Red;
            bt_iniciar.FlatStyle = FlatStyle.Popup;
            bt_iniciar.ForeColor = SystemColors.ControlText;
            bt_iniciar.Location = new Point(467, 184);
            bt_iniciar.Name = "bt_iniciar";
            bt_iniciar.Size = new Size(79, 23);
            bt_iniciar.TabIndex = 11;
            bt_iniciar.Text = "Iniciar";
            bt_iniciar.UseVisualStyleBackColor = true;
            bt_iniciar.Click += Bt_iniciar_Click;
            // 
            // bt_pareamento
            // 
            bt_pareamento.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_pareamento.FlatStyle = FlatStyle.Popup;
            bt_pareamento.Location = new Point(381, 184);
            bt_pareamento.Name = "bt_pareamento";
            bt_pareamento.Size = new Size(79, 23);
            bt_pareamento.TabIndex = 12;
            bt_pareamento.Text = "Pareamento";
            bt_pareamento.UseVisualStyleBackColor = true;
            bt_pareamento.Click += Bt_pareamento_Click;
            // 
            // lbl_tcpState
            // 
            lbl_tcpState.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_tcpState.Location = new Point(523, 238);
            lbl_tcpState.Name = "lbl_tcpState";
            lbl_tcpState.Size = new Size(198, 15);
            lbl_tcpState.TabIndex = 13;
            lbl_tcpState.Text = "lbl_tcpState";
            lbl_tcpState.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_udpState
            // 
            lbl_udpState.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_udpState.ForeColor = Color.Lime;
            lbl_udpState.Location = new Point(479, 254);
            lbl_udpState.Name = "lbl_udpState";
            lbl_udpState.Size = new Size(242, 15);
            lbl_udpState.TabIndex = 14;
            lbl_udpState.Text = "lbl_udpState";
            lbl_udpState.TextAlign = ContentAlignment.MiddleRight;
            // 
            // bt_abrirLogs
            // 
            bt_abrirLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bt_abrirLogs.FlatStyle = FlatStyle.Flat;
            bt_abrirLogs.ForeColor = SystemColors.MenuHighlight;
            bt_abrirLogs.Image = Properties.Resources.Search;
            bt_abrirLogs.Location = new Point(101, 184);
            bt_abrirLogs.Name = "bt_abrirLogs";
            bt_abrirLogs.Size = new Size(19, 19);
            bt_abrirLogs.TabIndex = 15;
            bt_abrirLogs.UseVisualStyleBackColor = true;
            bt_abrirLogs.Click += Bt_abrirLogs_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.MenuHighlight;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(3, 255);
            button1.Name = "button1";
            button1.Size = new Size(18, 19);
            button1.TabIndex = 16;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            ClientSize = new Size(733, 276);
            Controls.Add(button1);
            Controls.Add(bt_abrirLogs);
            Controls.Add(lbl_udpState);
            Controls.Add(lbl_tcpState);
            Controls.Add(bt_pareamento);
            Controls.Add(bt_iniciar);
            Controls.Add(cbox_saveLogs);
            Controls.Add(cbox_IniciarMinimizado);
            Controls.Add(bt_descartar);
            Controls.Add(bt_salvar);
            Controls.Add(dgv_devices);
            Controls.Add(cbox_IniciarComWindows);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "AlexaC#";
            FormClosed += MainForm_FormClosed;
            Load += Form1_Load;
            SizeChanged += MainForm_SizeChanged;
            contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_devices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem fecharToolStripMenuItem;
        private CheckBox cbox_IniciarComWindows;
        private DataGridView dgv_devices;
        private Button bt_salvar;
        private Button bt_descartar;
        private CheckBox cbox_IniciarMinimizado;
        private CheckBox cbox_saveLogs;
        private Button bt_iniciar;
        private Button bt_pareamento;
        private Label lbl_tcpState;
        private Label lbl_udpState;
        private DataGridViewTextBoxColumn NOME;
        private DataGridViewComboBoxColumn TIPO;
        private DataGridViewTextBoxColumn COMANDO;
        private DataGridViewTextBoxColumn ARGUMENTO;
        private DataGridViewComboBoxColumn TECLA;
        private DataGridViewComboBoxColumn TECLA2;
        private DataGridViewComboBoxColumn TECLA3;
        private Button bt_abrirLogs;
        private Button button1;
    }
}