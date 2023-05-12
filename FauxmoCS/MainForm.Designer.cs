namespace FauxmoCS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbox_IniciarComWindows = new System.Windows.Forms.CheckBox();
            this.dgv_devices = new System.Windows.Forms.DataGridView();
            this.NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.COMANDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARGUMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECLA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TECLA2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TECLA3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bt_salvar = new System.Windows.Forms.Button();
            this.bt_descartar = new System.Windows.Forms.Button();
            this.cbox_IniciarMinimizado = new System.Windows.Forms.CheckBox();
            this.cbox_saveLogs = new System.Windows.Forms.CheckBox();
            this.bt_iniciar = new System.Windows.Forms.Button();
            this.bt_pareamento = new System.Windows.Forms.Button();
            this.lbl_tcpState = new System.Windows.Forms.Label();
            this.lbl_udpState = new System.Windows.Forms.Label();
            this.bt_abrirLogs = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_devices)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "FauxmoC# está rodando!";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "FauxmoC#";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(110, 48);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.AbrirToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.FecharToolStripMenuItem_Click);
            // 
            // cbox_IniciarComWindows
            // 
            this.cbox_IniciarComWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbox_IniciarComWindows.AutoSize = true;
            this.cbox_IniciarComWindows.ForeColor = System.Drawing.Color.White;
            this.cbox_IniciarComWindows.Location = new System.Drawing.Point(12, 234);
            this.cbox_IniciarComWindows.Name = "cbox_IniciarComWindows";
            this.cbox_IniciarComWindows.Size = new System.Drawing.Size(147, 19);
            this.cbox_IniciarComWindows.TabIndex = 1;
            this.cbox_IniciarComWindows.Text = "Iniciar com o Windows";
            this.cbox_IniciarComWindows.UseVisualStyleBackColor = true;
            this.cbox_IniciarComWindows.CheckedChanged += new System.EventHandler(this.Bb_iniciarComWindows_CheckedChanged);
            // 
            // dgv_devices
            // 
            this.dgv_devices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_devices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_devices.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.dgv_devices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_devices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_devices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOME,
            this.TIPO,
            this.COMANDO,
            this.ARGUMENTO,
            this.TECLA,
            this.TECLA2,
            this.TECLA3});
            this.dgv_devices.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgv_devices.Location = new System.Drawing.Point(12, 12);
            this.dgv_devices.Name = "dgv_devices";
            this.dgv_devices.RowHeadersWidth = 20;
            this.dgv_devices.RowTemplate.Height = 25;
            this.dgv_devices.Size = new System.Drawing.Size(709, 166);
            this.dgv_devices.TabIndex = 2;
            this.dgv_devices.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Dgv_devices_DataError);
            // 
            // NOME
            // 
            this.NOME.HeaderText = "NOME";
            this.NOME.Name = "NOME";
            // 
            // TIPO
            // 
            this.TIPO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TIPO.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.Name = "TIPO";
            this.TIPO.Width = 39;
            // 
            // COMANDO
            // 
            this.COMANDO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.COMANDO.HeaderText = "COMANDO";
            this.COMANDO.Name = "COMANDO";
            this.COMANDO.Width = 94;
            // 
            // ARGUMENTO
            // 
            this.ARGUMENTO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ARGUMENTO.HeaderText = "ARGUMENTO";
            this.ARGUMENTO.Name = "ARGUMENTO";
            this.ARGUMENTO.Width = 103;
            // 
            // TECLA
            // 
            this.TECLA.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.TECLA.HeaderText = "TECLA";
            this.TECLA.Name = "TECLA";
            // 
            // TECLA2
            // 
            this.TECLA2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.TECLA2.HeaderText = "TECLA2";
            this.TECLA2.Name = "TECLA2";
            this.TECLA2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TECLA2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TECLA3
            // 
            this.TECLA3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.TECLA3.HeaderText = "TECLA3";
            this.TECLA3.Name = "TECLA3";
            this.TECLA3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TECLA3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // bt_salvar
            // 
            this.bt_salvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_salvar.Location = new System.Drawing.Point(646, 184);
            this.bt_salvar.Name = "bt_salvar";
            this.bt_salvar.Size = new System.Drawing.Size(75, 23);
            this.bt_salvar.TabIndex = 3;
            this.bt_salvar.Text = "Salvar";
            this.bt_salvar.UseVisualStyleBackColor = true;
            this.bt_salvar.Click += new System.EventHandler(this.Bt_salvar_Click);
            // 
            // bt_descartar
            // 
            this.bt_descartar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_descartar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_descartar.ForeColor = System.Drawing.Color.Black;
            this.bt_descartar.Location = new System.Drawing.Point(565, 184);
            this.bt_descartar.Name = "bt_descartar";
            this.bt_descartar.Size = new System.Drawing.Size(75, 23);
            this.bt_descartar.TabIndex = 4;
            this.bt_descartar.Text = "Descartar";
            this.bt_descartar.UseVisualStyleBackColor = true;
            this.bt_descartar.Click += new System.EventHandler(this.Bt_descartar_Click);
            // 
            // cbox_IniciarMinimizado
            // 
            this.cbox_IniciarMinimizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbox_IniciarMinimizado.AutoSize = true;
            this.cbox_IniciarMinimizado.ForeColor = System.Drawing.Color.White;
            this.cbox_IniciarMinimizado.Location = new System.Drawing.Point(12, 209);
            this.cbox_IniciarMinimizado.Name = "cbox_IniciarMinimizado";
            this.cbox_IniciarMinimizado.Size = new System.Drawing.Size(124, 19);
            this.cbox_IniciarMinimizado.TabIndex = 5;
            this.cbox_IniciarMinimizado.Text = "Iniciar Minimizado";
            this.cbox_IniciarMinimizado.UseVisualStyleBackColor = true;
            this.cbox_IniciarMinimizado.CheckedChanged += new System.EventHandler(this.Cbox_iniciarMinimizado_CheckedChanged);
            // 
            // cbox_saveLogs
            // 
            this.cbox_saveLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbox_saveLogs.AutoSize = true;
            this.cbox_saveLogs.ForeColor = System.Drawing.Color.White;
            this.cbox_saveLogs.Location = new System.Drawing.Point(12, 184);
            this.cbox_saveLogs.Name = "cbox_saveLogs";
            this.cbox_saveLogs.Size = new System.Drawing.Size(88, 19);
            this.cbox_saveLogs.TabIndex = 8;
            this.cbox_saveLogs.Text = "Gravar Logs";
            this.cbox_saveLogs.UseVisualStyleBackColor = true;
            this.cbox_saveLogs.CheckedChanged += new System.EventHandler(this.Cbox_saveLogs_CheckedChanged);
            // 
            // bt_iniciar
            // 
            this.bt_iniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_iniciar.BackColor = System.Drawing.Color.Red;
            this.bt_iniciar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_iniciar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_iniciar.Location = new System.Drawing.Point(467, 184);
            this.bt_iniciar.Name = "bt_iniciar";
            this.bt_iniciar.Size = new System.Drawing.Size(79, 23);
            this.bt_iniciar.TabIndex = 11;
            this.bt_iniciar.Text = "Iniciar";
            this.bt_iniciar.UseVisualStyleBackColor = true;
            this.bt_iniciar.Click += new System.EventHandler(this.Bt_iniciar_Click);
            // 
            // bt_pareamento
            // 
            this.bt_pareamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_pareamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_pareamento.Location = new System.Drawing.Point(381, 184);
            this.bt_pareamento.Name = "bt_pareamento";
            this.bt_pareamento.Size = new System.Drawing.Size(79, 23);
            this.bt_pareamento.TabIndex = 12;
            this.bt_pareamento.Text = "Pareamento";
            this.bt_pareamento.UseVisualStyleBackColor = true;
            this.bt_pareamento.Click += new System.EventHandler(this.Bt_pareamento_Click);
            // 
            // lbl_tcpState
            // 
            this.lbl_tcpState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_tcpState.Location = new System.Drawing.Point(523, 238);
            this.lbl_tcpState.Name = "lbl_tcpState";
            this.lbl_tcpState.Size = new System.Drawing.Size(198, 15);
            this.lbl_tcpState.TabIndex = 13;
            this.lbl_tcpState.Text = "lbl_tcpState";
            this.lbl_tcpState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_udpState
            // 
            this.lbl_udpState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_udpState.ForeColor = System.Drawing.Color.Lime;
            this.lbl_udpState.Location = new System.Drawing.Point(479, 254);
            this.lbl_udpState.Name = "lbl_udpState";
            this.lbl_udpState.Size = new System.Drawing.Size(242, 15);
            this.lbl_udpState.TabIndex = 14;
            this.lbl_udpState.Text = "lbl_udpState";
            this.lbl_udpState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bt_abrirLogs
            // 
            this.bt_abrirLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_abrirLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_abrirLogs.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.bt_abrirLogs.Image = global::FauxmoCS.Properties.Resources.Search;
            this.bt_abrirLogs.Location = new System.Drawing.Point(101, 184);
            this.bt_abrirLogs.Name = "bt_abrirLogs";
            this.bt_abrirLogs.Size = new System.Drawing.Size(19, 19);
            this.bt_abrirLogs.TabIndex = 15;
            this.bt_abrirLogs.UseVisualStyleBackColor = true;
            this.bt_abrirLogs.Click += new System.EventHandler(this.Bt_abrirLogs_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(3, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 19);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(733, 276);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_abrirLogs);
            this.Controls.Add(this.lbl_udpState);
            this.Controls.Add(this.lbl_tcpState);
            this.Controls.Add(this.bt_pareamento);
            this.Controls.Add(this.bt_iniciar);
            this.Controls.Add(this.cbox_saveLogs);
            this.Controls.Add(this.cbox_IniciarMinimizado);
            this.Controls.Add(this.bt_descartar);
            this.Controls.Add(this.bt_salvar);
            this.Controls.Add(this.dgv_devices);
            this.Controls.Add(this.cbox_IniciarComWindows);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "AlexaC#";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_devices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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