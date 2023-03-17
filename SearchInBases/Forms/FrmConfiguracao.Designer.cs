namespace SearchInBases.Formularios
{
    partial class FrmConfiguracao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracao));
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tpConexoes = new System.Windows.Forms.TabPage();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lvConexoes = new System.Windows.Forms.ListView();
            this.lblConexoes = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGeral = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbResultado = new System.Windows.Forms.GroupBox();
            this.rbResultadoSemOcorre = new System.Windows.Forms.RadioButton();
            this.rbResultadoComOcorre = new System.Windows.Forms.RadioButton();
            this.rbResultadoAmbos = new System.Windows.Forms.RadioButton();
            this.gbBasesAtivas = new System.Windows.Forms.GroupBox();
            this.rbAmbasAtiva = new System.Windows.Forms.RadioButton();
            this.rbInativa = new System.Windows.Forms.RadioButton();
            this.rbAtiva = new System.Windows.Forms.RadioButton();
            this.gbAmbiente = new System.Windows.Forms.GroupBox();
            this.rbAmbosAmbiente = new System.Windows.Forms.RadioButton();
            this.rbProducao = new System.Windows.Forms.RadioButton();
            this.rbInterno = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKeySQL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbImprimirCabecalho = new System.Windows.Forms.CheckBox();
            this.toolBar.SuspendLayout();
            this.tpConexoes.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpGeral.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbResultado.SuspendLayout();
            this.gbBasesAtivas.SuspendLayout();
            this.gbAmbiente.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.SystemColors.Control;
            this.toolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalvar,
            this.btnCancelar});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(574, 43);
            this.toolBar.TabIndex = 5;
            this.toolBar.Text = "toolStrip1";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(42, 39);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(57, 39);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "base.png");
            // 
            // tpConexoes
            // 
            this.tpConexoes.Controls.Add(this.btnAdicionar);
            this.tpConexoes.Controls.Add(this.btnRemover);
            this.tpConexoes.Controls.Add(this.label8);
            this.tpConexoes.Controls.Add(this.txtSenha);
            this.tpConexoes.Controls.Add(this.txtUser);
            this.tpConexoes.Controls.Add(this.txtServer);
            this.tpConexoes.Controls.Add(this.txtNome);
            this.tpConexoes.Controls.Add(this.label7);
            this.tpConexoes.Controls.Add(this.label6);
            this.tpConexoes.Controls.Add(this.lblNome);
            this.tpConexoes.Controls.Add(this.lvConexoes);
            this.tpConexoes.Controls.Add(this.lblConexoes);
            this.tpConexoes.Location = new System.Drawing.Point(4, 24);
            this.tpConexoes.Name = "tpConexoes";
            this.tpConexoes.Padding = new System.Windows.Forms.Padding(3);
            this.tpConexoes.Size = new System.Drawing.Size(566, 335);
            this.tpConexoes.TabIndex = 1;
            this.tpConexoes.Text = "Conexões";
            this.tpConexoes.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.Transparent;
            this.btnAdicionar.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAdicionar.Location = new System.Drawing.Point(193, 279);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(158, 23);
            this.btnAdicionar.TabIndex = 24;
            this.btnAdicionar.Text = "Adicionar Conexão";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.Transparent;
            this.btnRemover.ForeColor = System.Drawing.Color.Red;
            this.btnRemover.Location = new System.Drawing.Point(8, 279);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(158, 23);
            this.btnRemover.TabIndex = 23;
            this.btnRemover.Text = "Remover Selecionados";
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(193, 183);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(347, 23);
            this.txtSenha.TabIndex = 21;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(193, 132);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(347, 23);
            this.txtUser.TabIndex = 19;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(193, 80);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(347, 23);
            this.txtServer.TabIndex = 17;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(193, 33);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(347, 23);
            this.txtNome.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "Usuário";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Servidor";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(193, 15);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(40, 15);
            this.lblNome.TabIndex = 14;
            this.lblNome.Text = "Nome";
            // 
            // lvConexoes
            // 
            this.lvConexoes.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvConexoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvConexoes.CheckBoxes = true;
            this.lvConexoes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvConexoes.HideSelection = false;
            this.lvConexoes.Location = new System.Drawing.Point(8, 33);
            this.lvConexoes.MultiSelect = false;
            this.lvConexoes.Name = "lvConexoes";
            this.lvConexoes.Size = new System.Drawing.Size(158, 227);
            this.lvConexoes.SmallImageList = this.imageList1;
            this.lvConexoes.TabIndex = 12;
            this.lvConexoes.UseCompatibleStateImageBehavior = false;
            this.lvConexoes.View = System.Windows.Forms.View.List;
            this.lvConexoes.SelectedIndexChanged += new System.EventHandler(this.lvConexoes_SelectedIndexChanged);
            // 
            // lblConexoes
            // 
            this.lblConexoes.AutoSize = true;
            this.lblConexoes.Location = new System.Drawing.Point(8, 15);
            this.lblConexoes.Name = "lblConexoes";
            this.lblConexoes.Size = new System.Drawing.Size(59, 15);
            this.lblConexoes.TabIndex = 11;
            this.lblConexoes.Text = "Conexões";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpGeral);
            this.tabControl1.Controls.Add(this.tpConexoes);
            this.tabControl1.Location = new System.Drawing.Point(0, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(574, 363);
            this.tabControl1.TabIndex = 6;
            // 
            // tpGeral
            // 
            this.tpGeral.Controls.Add(this.cbImprimirCabecalho);
            this.tpGeral.Controls.Add(this.groupBox2);
            this.tpGeral.Controls.Add(this.groupBox1);
            this.tpGeral.Location = new System.Drawing.Point(4, 24);
            this.tpGeral.Name = "tpGeral";
            this.tpGeral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeral.Size = new System.Drawing.Size(566, 335);
            this.tpGeral.TabIndex = 2;
            this.tpGeral.Text = "Geral";
            this.tpGeral.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbResultado);
            this.groupBox2.Controls.Add(this.gbBasesAtivas);
            this.groupBox2.Controls.Add(this.gbAmbiente);
            this.groupBox2.Location = new System.Drawing.Point(8, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 136);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro Padrão";
            // 
            // gbResultado
            // 
            this.gbResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultado.Controls.Add(this.rbResultadoSemOcorre);
            this.gbResultado.Controls.Add(this.rbResultadoComOcorre);
            this.gbResultado.Controls.Add(this.rbResultadoAmbos);
            this.gbResultado.Location = new System.Drawing.Point(17, 22);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(172, 99);
            this.gbResultado.TabIndex = 25;
            this.gbResultado.TabStop = false;
            this.gbResultado.Text = "Resultado Esperado";
            // 
            // rbResultadoSemOcorre
            // 
            this.rbResultadoSemOcorre.AutoSize = true;
            this.rbResultadoSemOcorre.Location = new System.Drawing.Point(25, 68);
            this.rbResultadoSemOcorre.Name = "rbResultadoSemOcorre";
            this.rbResultadoSemOcorre.Size = new System.Drawing.Size(109, 19);
            this.rbResultadoSemOcorre.TabIndex = 5;
            this.rbResultadoSemOcorre.Text = "Sem Ocorrência";
            this.rbResultadoSemOcorre.UseVisualStyleBackColor = true;
            // 
            // rbResultadoComOcorre
            // 
            this.rbResultadoComOcorre.AutoSize = true;
            this.rbResultadoComOcorre.Checked = true;
            this.rbResultadoComOcorre.Location = new System.Drawing.Point(25, 45);
            this.rbResultadoComOcorre.Name = "rbResultadoComOcorre";
            this.rbResultadoComOcorre.Size = new System.Drawing.Size(112, 19);
            this.rbResultadoComOcorre.TabIndex = 4;
            this.rbResultadoComOcorre.TabStop = true;
            this.rbResultadoComOcorre.Text = "Com Ocorrência";
            this.rbResultadoComOcorre.UseVisualStyleBackColor = true;
            // 
            // rbResultadoAmbos
            // 
            this.rbResultadoAmbos.AutoSize = true;
            this.rbResultadoAmbos.Location = new System.Drawing.Point(25, 22);
            this.rbResultadoAmbos.Name = "rbResultadoAmbos";
            this.rbResultadoAmbos.Size = new System.Drawing.Size(63, 19);
            this.rbResultadoAmbos.TabIndex = 3;
            this.rbResultadoAmbos.Text = "Ambos";
            this.rbResultadoAmbos.UseVisualStyleBackColor = true;
            // 
            // gbBasesAtivas
            // 
            this.gbBasesAtivas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBasesAtivas.Controls.Add(this.rbAmbasAtiva);
            this.gbBasesAtivas.Controls.Add(this.rbInativa);
            this.gbBasesAtivas.Controls.Add(this.rbAtiva);
            this.gbBasesAtivas.Location = new System.Drawing.Point(325, 22);
            this.gbBasesAtivas.Name = "gbBasesAtivas";
            this.gbBasesAtivas.Size = new System.Drawing.Size(126, 99);
            this.gbBasesAtivas.TabIndex = 23;
            this.gbBasesAtivas.TabStop = false;
            this.gbBasesAtivas.Text = "Bases";
            // 
            // rbAmbasAtiva
            // 
            this.rbAmbasAtiva.AutoSize = true;
            this.rbAmbasAtiva.Location = new System.Drawing.Point(22, 21);
            this.rbAmbasAtiva.Name = "rbAmbasAtiva";
            this.rbAmbasAtiva.Size = new System.Drawing.Size(63, 19);
            this.rbAmbasAtiva.TabIndex = 2;
            this.rbAmbasAtiva.Text = "Ambos";
            this.rbAmbasAtiva.UseVisualStyleBackColor = true;
            // 
            // rbInativa
            // 
            this.rbInativa.AutoSize = true;
            this.rbInativa.Location = new System.Drawing.Point(22, 67);
            this.rbInativa.Name = "rbInativa";
            this.rbInativa.Size = new System.Drawing.Size(60, 19);
            this.rbInativa.TabIndex = 1;
            this.rbInativa.Text = "Inativa";
            this.rbInativa.UseVisualStyleBackColor = true;
            // 
            // rbAtiva
            // 
            this.rbAtiva.AutoSize = true;
            this.rbAtiva.Checked = true;
            this.rbAtiva.Location = new System.Drawing.Point(22, 45);
            this.rbAtiva.Name = "rbAtiva";
            this.rbAtiva.Size = new System.Drawing.Size(52, 19);
            this.rbAtiva.TabIndex = 0;
            this.rbAtiva.TabStop = true;
            this.rbAtiva.Text = "Ativa";
            this.rbAtiva.UseVisualStyleBackColor = true;
            // 
            // gbAmbiente
            // 
            this.gbAmbiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAmbiente.Controls.Add(this.rbAmbosAmbiente);
            this.gbAmbiente.Controls.Add(this.rbProducao);
            this.gbAmbiente.Controls.Add(this.rbInterno);
            this.gbAmbiente.Location = new System.Drawing.Point(195, 22);
            this.gbAmbiente.Name = "gbAmbiente";
            this.gbAmbiente.Size = new System.Drawing.Size(124, 99);
            this.gbAmbiente.TabIndex = 24;
            this.gbAmbiente.TabStop = false;
            this.gbAmbiente.Text = "Ambiente";
            // 
            // rbAmbosAmbiente
            // 
            this.rbAmbosAmbiente.AutoSize = true;
            this.rbAmbosAmbiente.Checked = true;
            this.rbAmbosAmbiente.Location = new System.Drawing.Point(17, 21);
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
            this.rbProducao.Location = new System.Drawing.Point(17, 67);
            this.rbProducao.Name = "rbProducao";
            this.rbProducao.Size = new System.Drawing.Size(76, 19);
            this.rbProducao.TabIndex = 4;
            this.rbProducao.Text = "Produção";
            this.rbProducao.UseVisualStyleBackColor = true;
            // 
            // rbInterno
            // 
            this.rbInterno.AutoSize = true;
            this.rbInterno.Location = new System.Drawing.Point(17, 45);
            this.rbInterno.Name = "rbInterno";
            this.rbInterno.Size = new System.Drawing.Size(63, 19);
            this.rbInterno.TabIndex = 3;
            this.rbInterno.Text = "Interno";
            this.rbInterno.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKeySQL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 89);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Segurança";
            // 
            // txtKeySQL
            // 
            this.txtKeySQL.Location = new System.Drawing.Point(29, 47);
            this.txtKeySQL.Name = "txtKeySQL";
            this.txtKeySQL.Size = new System.Drawing.Size(490, 23);
            this.txtKeySQL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chave de descriptografia do banco";
            // 
            // cbImprimirCabecalho
            // 
            this.cbImprimirCabecalho.AutoSize = true;
            this.cbImprimirCabecalho.Location = new System.Drawing.Point(25, 276);
            this.cbImprimirCabecalho.Name = "cbImprimirCabecalho";
            this.cbImprimirCabecalho.Size = new System.Drawing.Size(242, 19);
            this.cbImprimirCabecalho.TabIndex = 24;
            this.cbImprimirCabecalho.Text = "Imprimir cabeçalho na consulta ou script";
            this.cbImprimirCabecalho.UseVisualStyleBackColor = true;
            // 
            // FrmConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(574, 418);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração";
            this.Load += new System.EventHandler(this.FrmConfiguracao_Load);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.tpConexoes.ResumeLayout(false);
            this.tpConexoes.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpGeral.ResumeLayout(false);
            this.tpGeral.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbResultado.ResumeLayout(false);
            this.gbResultado.PerformLayout();
            this.gbBasesAtivas.ResumeLayout(false);
            this.gbBasesAtivas.PerformLayout();
            this.gbAmbiente.ResumeLayout(false);
            this.gbAmbiente.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tpConexoes;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.ListView lvConexoes;
        private System.Windows.Forms.Label lblConexoes;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpGeral;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKeySQL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbResultado;
        private System.Windows.Forms.RadioButton rbResultadoSemOcorre;
        private System.Windows.Forms.RadioButton rbResultadoComOcorre;
        private System.Windows.Forms.RadioButton rbResultadoAmbos;
        private System.Windows.Forms.GroupBox gbBasesAtivas;
        private System.Windows.Forms.RadioButton rbAmbasAtiva;
        private System.Windows.Forms.RadioButton rbInativa;
        private System.Windows.Forms.RadioButton rbAtiva;
        private System.Windows.Forms.GroupBox gbAmbiente;
        private System.Windows.Forms.RadioButton rbAmbosAmbiente;
        private System.Windows.Forms.RadioButton rbProducao;
        private System.Windows.Forms.RadioButton rbInterno;
        private System.Windows.Forms.CheckBox cbImprimirCabecalho;
    }
}