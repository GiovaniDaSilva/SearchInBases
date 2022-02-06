
namespace SearchInBases.Forms
{
    partial class FrmPesquisa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisa));
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFormater = new System.Windows.Forms.Button();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.gbAmbiente = new System.Windows.Forms.GroupBox();
            this.rbAmbosAmbiente = new System.Windows.Forms.RadioButton();
            this.rbProducao = new System.Windows.Forms.RadioButton();
            this.rbInterno = new System.Windows.Forms.RadioButton();
            this.gbBasesAtivas = new System.Windows.Forms.GroupBox();
            this.rbAmbasAtiva = new System.Windows.Forms.RadioButton();
            this.rbInativa = new System.Windows.Forms.RadioButton();
            this.rbAtiva = new System.Windows.Forms.RadioButton();
            this.lvConexoes = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtSQL = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblSQL = new System.Windows.Forms.Label();
            this.lblConexoes = new System.Windows.Forms.Label();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.btnConfig = new System.Windows.Forms.ToolStripButton();
            this.btnResultados = new System.Windows.Forms.ToolStripButton();
            this.btnLog = new System.Windows.Forms.ToolStripButton();
            this.btnSobre = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.ttHistorico = new System.Windows.Forms.ToolTip(this.components);
            this.lblBasesFiltradas = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbAmbiente.SuspendLayout();
            this.gbBasesAtivas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQL)).BeginInit();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 642);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 25);
            this.panel1.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(594, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(390, 20);
            this.progressBar.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(4, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(104, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status da pesquisa";
            // 
            // splitContainer1
            // 
            this.splitContainer1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtConsole);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(994, 642);
            this.splitContainer1.SplitterDistance = 436;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblBasesFiltradas);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnFormater);
            this.panel2.Controls.Add(this.btnHistorico);
            this.panel2.Controls.Add(this.gbAmbiente);
            this.panel2.Controls.Add(this.gbBasesAtivas);
            this.panel2.Controls.Add(this.lvConexoes);
            this.panel2.Controls.Add(this.txtSQL);
            this.panel2.Controls.Add(this.btnPesquisar);
            this.panel2.Controls.Add(this.lblSQL);
            this.panel2.Controls.Add(this.lblConexoes);
            this.panel2.Controls.Add(this.toolBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 434);
            this.panel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(285, 42);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(158, 59);
            this.button1.TabIndex = 15;
            this.button1.Text = "Filtrar Bases";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFormater
            // 
            this.btnFormater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFormater.BackColor = System.Drawing.SystemColors.Control;
            this.btnFormater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFormater.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFormater.Image = ((System.Drawing.Image)(resources.GetObject("btnFormater.Image")));
            this.btnFormater.Location = new System.Drawing.Point(953, 180);
            this.btnFormater.Name = "btnFormater";
            this.btnFormater.Size = new System.Drawing.Size(30, 27);
            this.btnFormater.TabIndex = 14;
            this.btnFormater.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttHistorico.SetToolTip(this.btnFormater, "Formatador");
            this.btnFormater.UseVisualStyleBackColor = false;
            this.btnFormater.Click += new System.EventHandler(this.btnFormater_Click);
            // 
            // btnHistorico
            // 
            this.btnHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorico.BackColor = System.Drawing.SystemColors.Control;
            this.btnHistorico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHistorico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorico.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorico.Image")));
            this.btnHistorico.Location = new System.Drawing.Point(953, 147);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(30, 27);
            this.btnHistorico.TabIndex = 13;
            this.btnHistorico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttHistorico.SetToolTip(this.btnHistorico, "Histórico");
            this.btnHistorico.UseVisualStyleBackColor = false;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // gbAmbiente
            // 
            this.gbAmbiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAmbiente.Controls.Add(this.rbAmbosAmbiente);
            this.gbAmbiente.Controls.Add(this.rbProducao);
            this.gbAmbiente.Controls.Add(this.rbInterno);
            this.gbAmbiente.Location = new System.Drawing.Point(449, 42);
            this.gbAmbiente.Name = "gbAmbiente";
            this.gbAmbiente.Size = new System.Drawing.Size(252, 59);
            this.gbAmbiente.TabIndex = 12;
            this.gbAmbiente.TabStop = false;
            this.gbAmbiente.Text = "Ambiente";
            // 
            // rbAmbosAmbiente
            // 
            this.rbAmbosAmbiente.AutoSize = true;
            this.rbAmbosAmbiente.Checked = true;
            this.rbAmbosAmbiente.Location = new System.Drawing.Point(180, 22);
            this.rbAmbosAmbiente.Name = "rbAmbosAmbiente";
            this.rbAmbosAmbiente.Size = new System.Drawing.Size(63, 19);
            this.rbAmbosAmbiente.TabIndex = 5;
            this.rbAmbosAmbiente.TabStop = true;
            this.rbAmbosAmbiente.Text = "Ambos";
            this.rbAmbosAmbiente.UseVisualStyleBackColor = true;
            // 
            // rbProducao
            // 
            this.rbProducao.AutoSize = true;
            this.rbProducao.Location = new System.Drawing.Point(98, 22);
            this.rbProducao.Name = "rbProducao";
            this.rbProducao.Size = new System.Drawing.Size(76, 19);
            this.rbProducao.TabIndex = 4;
            this.rbProducao.Text = "Produção";
            this.rbProducao.UseVisualStyleBackColor = true;
            // 
            // rbInterno
            // 
            this.rbInterno.AutoSize = true;
            this.rbInterno.Location = new System.Drawing.Point(25, 22);
            this.rbInterno.Name = "rbInterno";
            this.rbInterno.Size = new System.Drawing.Size(67, 19);
            this.rbInterno.TabIndex = 3;
            this.rbInterno.Text = "Internas";
            this.rbInterno.UseVisualStyleBackColor = true;
            // 
            // gbBasesAtivas
            // 
            this.gbBasesAtivas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBasesAtivas.Controls.Add(this.rbAmbasAtiva);
            this.gbBasesAtivas.Controls.Add(this.rbInativa);
            this.gbBasesAtivas.Controls.Add(this.rbAtiva);
            this.gbBasesAtivas.Location = new System.Drawing.Point(720, 42);
            this.gbBasesAtivas.Name = "gbBasesAtivas";
            this.gbBasesAtivas.Size = new System.Drawing.Size(227, 59);
            this.gbBasesAtivas.TabIndex = 11;
            this.gbBasesAtivas.TabStop = false;
            this.gbBasesAtivas.Text = "Bases Ativas";
            // 
            // rbAmbasAtiva
            // 
            this.rbAmbasAtiva.AutoSize = true;
            this.rbAmbasAtiva.Checked = true;
            this.rbAmbasAtiva.Location = new System.Drawing.Point(156, 22);
            this.rbAmbasAtiva.Name = "rbAmbasAtiva";
            this.rbAmbasAtiva.Size = new System.Drawing.Size(63, 19);
            this.rbAmbasAtiva.TabIndex = 2;
            this.rbAmbasAtiva.TabStop = true;
            this.rbAmbasAtiva.Text = "Ambos";
            this.rbAmbasAtiva.UseVisualStyleBackColor = true;
            // 
            // rbInativa
            // 
            this.rbInativa.AutoSize = true;
            this.rbInativa.Location = new System.Drawing.Point(85, 22);
            this.rbInativa.Name = "rbInativa";
            this.rbInativa.Size = new System.Drawing.Size(65, 19);
            this.rbInativa.TabIndex = 1;
            this.rbInativa.Text = "Inativas";
            this.rbInativa.UseVisualStyleBackColor = true;
            // 
            // rbAtiva
            // 
            this.rbAtiva.AutoSize = true;
            this.rbAtiva.Location = new System.Drawing.Point(22, 22);
            this.rbAtiva.Name = "rbAtiva";
            this.rbAtiva.Size = new System.Drawing.Size(57, 19);
            this.rbAtiva.TabIndex = 0;
            this.rbAtiva.Text = "Ativas";
            this.rbAtiva.UseVisualStyleBackColor = true;
            // 
            // lvConexoes
            // 
            this.lvConexoes.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvConexoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvConexoes.CheckBoxes = true;
            this.lvConexoes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvConexoes.HideSelection = false;
            this.lvConexoes.Location = new System.Drawing.Point(12, 147);
            this.lvConexoes.MultiSelect = false;
            this.lvConexoes.Name = "lvConexoes";
            this.lvConexoes.Size = new System.Drawing.Size(158, 279);
            this.lvConexoes.SmallImageList = this.imageList1;
            this.lvConexoes.TabIndex = 10;
            this.lvConexoes.UseCompatibleStateImageBehavior = false;
            this.lvConexoes.View = System.Windows.Forms.View.List;
            this.lvConexoes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvConexoes_ItemChecked);
            this.lvConexoes.SelectedIndexChanged += new System.EventHandler(this.lvConexoes_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "base.png");
            // 
            // txtSQL
            // 
            this.txtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQL.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtSQL.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.txtSQL.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtSQL.BackBrush = null;
            this.txtSQL.CharHeight = 14;
            this.txtSQL.CharWidth = 8;
            this.txtSQL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSQL.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSQL.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSQL.IsReplaceMode = false;
            this.txtSQL.Location = new System.Drawing.Point(200, 147);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Paddings = new System.Windows.Forms.Padding(0);
            this.txtSQL.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtSQL.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtSQL.ServiceColors")));
            this.txtSQL.Size = new System.Drawing.Size(747, 279);
            this.txtSQL.TabIndex = 9;
            this.txtSQL.Zoom = 100;
            this.txtSQL.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtSQL_TextChanged);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.SystemColors.Control;
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(12, 42);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPesquisar.Size = new System.Drawing.Size(158, 74);
            this.btnPesquisar.TabIndex = 8;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lblSQL
            // 
            this.lblSQL.AutoSize = true;
            this.lblSQL.Location = new System.Drawing.Point(220, 129);
            this.lblSQL.Name = "lblSQL";
            this.lblSQL.Size = new System.Drawing.Size(28, 15);
            this.lblSQL.TabIndex = 7;
            this.lblSQL.Text = "SQL";
            // 
            // lblConexoes
            // 
            this.lblConexoes.AutoSize = true;
            this.lblConexoes.Location = new System.Drawing.Point(12, 129);
            this.lblConexoes.Name = "lblConexoes";
            this.lblConexoes.Size = new System.Drawing.Size(59, 15);
            this.lblConexoes.TabIndex = 6;
            this.lblConexoes.Text = "Conexões";
            // 
            // toolBar
            // 
            this.toolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConfig,
            this.btnResultados,
            this.btnLog,
            this.btnSobre,
            this.btnClear});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(992, 39);
            this.toolBar.TabIndex = 3;
            this.toolBar.Text = "toolStrip1";
            // 
            // btnConfig
            // 
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(115, 36);
            this.btnConfig.Text = "Configuração";
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnResultados
            // 
            this.btnResultados.Image = ((System.Drawing.Image)(resources.GetObject("btnResultados.Image")));
            this.btnResultados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnResultados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResultados.Name = "btnResultados";
            this.btnResultados.Size = new System.Drawing.Size(100, 36);
            this.btnResultados.Text = "Resultados";
            this.btnResultados.Click += new System.EventHandler(this.btnResultados_Click);
            // 
            // btnLog
            // 
            this.btnLog.Image = ((System.Drawing.Image)(resources.GetObject("btnLog.Image")));
            this.btnLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(63, 36);
            this.btnLog.Text = "Log";
            this.btnLog.ToolTipText = "Logs";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnSobre
            // 
            this.btnSobre.Image = ((System.Drawing.Image)(resources.GetObject("btnSobre.Image")));
            this.btnSobre.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSobre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSobre.Name = "btnSobre";
            this.btnSobre.Size = new System.Drawing.Size(73, 36);
            this.btnSobre.Text = "Sobre";
            this.btnSobre.Click += new System.EventHandler(this.btnSobre_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 36);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(9, 4);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(974, 194);
            this.txtConsole.TabIndex = 2;
            this.txtConsole.Text = "";
            // 
            // lblBasesFiltradas
            // 
            this.lblBasesFiltradas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBasesFiltradas.AutoSize = true;
            this.lblBasesFiltradas.ForeColor = System.Drawing.Color.Firebrick;
            this.lblBasesFiltradas.Location = new System.Drawing.Point(285, 101);
            this.lblBasesFiltradas.Name = "lblBasesFiltradas";
            this.lblBasesFiltradas.Size = new System.Drawing.Size(118, 15);
            this.lblBasesFiltradas.TabIndex = 16;
            this.lblBasesFiltradas.Text = "Possui bases filtradas";
            // 
            // FrmPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 667);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPesquisa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search In Bases";
            this.Load += new System.EventHandler(this.FrmPesquisa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbAmbiente.ResumeLayout(false);
            this.gbAmbiente.PerformLayout();
            this.gbBasesAtivas.ResumeLayout(false);
            this.gbBasesAtivas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQL)).EndInit();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;        
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton btnConfig;
        private System.Windows.Forms.Label lblConexoes;
        private System.Windows.Forms.Label lblSQL;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripButton btnResultados;
        private System.Windows.Forms.ToolStripButton btnClear;
        private FastColoredTextBoxNS.FastColoredTextBox txtSQL;
        private System.Windows.Forms.ToolStripButton btnLog;
        private System.Windows.Forms.ListView lvConexoes;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox gbBasesAtivas;
        private System.Windows.Forms.RadioButton rbAmbasAtiva;
        private System.Windows.Forms.RadioButton rbInativa;
        private System.Windows.Forms.RadioButton rbAtiva;
        private System.Windows.Forms.GroupBox gbAmbiente;
        private System.Windows.Forms.RadioButton rbAmbosAmbiente;
        private System.Windows.Forms.RadioButton rbProducao;
        private System.Windows.Forms.RadioButton rbInterno;
        private System.Windows.Forms.ToolStripButton btnSobre;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.ToolTip ttHistorico;
        private System.Windows.Forms.Button btnFormater;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblBasesFiltradas;
    }
}