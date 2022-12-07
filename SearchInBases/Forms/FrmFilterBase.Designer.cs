namespace SearchInBases.Forms
{
    partial class FrmFilterBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFilterBase));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.gbUltimaConsulta = new System.Windows.Forms.GroupBox();
            this.rbSemOcorre = new System.Windows.Forms.RadioButton();
            this.rbComOcorre = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.btnImportarAgenciasTT = new System.Windows.Forms.Button();
            this.lblPesquisando = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).BeginInit();
            this.gbUltimaConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informe o Nome da Base ou a Instancia do cliente";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.AutoCompleteBracketsList = new char[] {
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
            this.txtFilter.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.txtFilter.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.txtFilter.BackBrush = null;
            this.txtFilter.CharHeight = 14;
            this.txtFilter.CharWidth = 8;
            this.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilter.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtFilter.IsReplaceMode = false;
            this.txtFilter.Location = new System.Drawing.Point(21, 94);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Paddings = new System.Windows.Forms.Padding(0);
            this.txtFilter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtFilter.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtFilter.ServiceColors")));
            this.txtFilter.Size = new System.Drawing.Size(465, 383);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.Zoom = 100;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.Location = new System.Drawing.Point(492, 94);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(30, 27);
            this.btnLimpar.TabIndex = 14;
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.Location = new System.Drawing.Point(39, 492);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnConfirmar.Size = new System.Drawing.Size(91, 32);
            this.btnConfirmar.TabIndex = 15;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnUtilizar_Click);
            // 
            // gbUltimaConsulta
            // 
            this.gbUltimaConsulta.Controls.Add(this.rbSemOcorre);
            this.gbUltimaConsulta.Controls.Add(this.rbComOcorre);
            this.gbUltimaConsulta.Controls.Add(this.rbTodos);
            this.gbUltimaConsulta.Location = new System.Drawing.Point(21, 12);
            this.gbUltimaConsulta.Name = "gbUltimaConsulta";
            this.gbUltimaConsulta.Size = new System.Drawing.Size(333, 52);
            this.gbUltimaConsulta.TabIndex = 16;
            this.gbUltimaConsulta.TabStop = false;
            this.gbUltimaConsulta.Text = "Importar da ultima consulta";
            // 
            // rbSemOcorre
            // 
            this.rbSemOcorre.AutoSize = true;
            this.rbSemOcorre.Location = new System.Drawing.Point(213, 22);
            this.rbSemOcorre.Name = "rbSemOcorre";
            this.rbSemOcorre.Size = new System.Drawing.Size(107, 19);
            this.rbSemOcorre.TabIndex = 2;
            this.rbSemOcorre.Text = "Sem ocorrência";
            this.rbSemOcorre.UseVisualStyleBackColor = true;
            this.rbSemOcorre.Click += new System.EventHandler(this.rbSemOcorre_Click);
            // 
            // rbComOcorre
            // 
            this.rbComOcorre.AutoSize = true;
            this.rbComOcorre.Location = new System.Drawing.Point(97, 22);
            this.rbComOcorre.Name = "rbComOcorre";
            this.rbComOcorre.Size = new System.Drawing.Size(110, 19);
            this.rbComOcorre.TabIndex = 1;
            this.rbComOcorre.Text = "Com ocorrência";
            this.rbComOcorre.UseVisualStyleBackColor = true;
            this.rbComOcorre.Click += new System.EventHandler(this.rbComOcorre_Click);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(18, 22);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(56, 19);
            this.rbTodos.TabIndex = 0;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.Click += new System.EventHandler(this.rbTodos_Click);
            // 
            // btnImportarAgenciasTT
            // 
            this.btnImportarAgenciasTT.Image = ((System.Drawing.Image)(resources.GetObject("btnImportarAgenciasTT.Image")));
            this.btnImportarAgenciasTT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportarAgenciasTT.Location = new System.Drawing.Point(360, 19);
            this.btnImportarAgenciasTT.Name = "btnImportarAgenciasTT";
            this.btnImportarAgenciasTT.Size = new System.Drawing.Size(126, 43);
            this.btnImportarAgenciasTT.TabIndex = 17;
            this.btnImportarAgenciasTT.TabStop = false;
            this.btnImportarAgenciasTT.Text = "Clientes TT";
            this.btnImportarAgenciasTT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportarAgenciasTT.UseVisualStyleBackColor = true;
            this.btnImportarAgenciasTT.Click += new System.EventHandler(this.btnImportarAgenciasTT_Click);    
            // 
            // lblPesquisando
            // 
            this.lblPesquisando.AutoSize = true;
            this.lblPesquisando.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPesquisando.ForeColor = System.Drawing.Color.Red;
            this.lblPesquisando.Location = new System.Drawing.Point(360, 65);
            this.lblPesquisando.Name = "lblPesquisando";
            this.lblPesquisando.Size = new System.Drawing.Size(95, 17);
            this.lblPesquisando.TabIndex = 18;
            this.lblPesquisando.Text = "Pesquisando... ";
            // 
            // FrmFilterBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 536);
            this.Controls.Add(this.lblPesquisando);
            this.Controls.Add(this.btnImportarAgenciasTT);
            this.Controls.Add(this.gbUltimaConsulta);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFilterBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtrar Bases";
            this.Load += new System.EventHandler(this.FrmFilterBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).EndInit();
            this.gbUltimaConsulta.ResumeLayout(false);
            this.gbUltimaConsulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FastColoredTextBoxNS.FastColoredTextBox txtFilter;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.GroupBox gbUltimaConsulta;
        private System.Windows.Forms.RadioButton rbSemOcorre;
        private System.Windows.Forms.RadioButton rbComOcorre;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.Button btnImportarAgenciasTT;
        private System.Windows.Forms.Label lblPesquisando;
    }
}