namespace SearchInBases.Forms
{
    partial class FrmHistorico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHistorico));
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sql = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUtilizar = new System.Windows.Forms.Button();
            this.txtSQL = new FastColoredTextBoxNS.FastColoredTextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQL)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AllowUserToDeleteRows = false;
            this.dgvHistorico.AllowUserToResizeColumns = false;
            this.dgvHistorico.AllowUserToResizeRows = false;
            this.dgvHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.data,
            this.sql});
            this.dgvHistorico.Location = new System.Drawing.Point(30, 60);
            this.dgvHistorico.MultiSelect = false;
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.ReadOnly = true;
            this.dgvHistorico.RowHeadersVisible = false;
            this.dgvHistorico.RowTemplate.Height = 25;
            this.dgvHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorico.Size = new System.Drawing.Size(856, 214);
            this.dgvHistorico.TabIndex = 0;
            this.dgvHistorico.Click += new System.EventHandler(this.dgvHistorico_Click);
            // 
            // data
            // 
            this.data.DataPropertyName = "data";
            this.data.HeaderText = "Data";
            this.data.Name = "data";
            this.data.ReadOnly = true;
            // 
            // sql
            // 
            this.sql.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sql.DataPropertyName = "sql";
            this.sql.HeaderText = "SQL";
            this.sql.Name = "sql";
            this.sql.ReadOnly = true;
            // 
            // btnUtilizar
            // 
            this.btnUtilizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUtilizar.Image = ((System.Drawing.Image)(resources.GetObject("btnUtilizar.Image")));
            this.btnUtilizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUtilizar.Location = new System.Drawing.Point(30, 498);
            this.btnUtilizar.Name = "btnUtilizar";
            this.btnUtilizar.Size = new System.Drawing.Size(93, 32);
            this.btnUtilizar.TabIndex = 2;
            this.btnUtilizar.Text = "Utilizar SQL";
            this.btnUtilizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUtilizar.UseVisualStyleBackColor = true;
            this.btnUtilizar.Click += new System.EventHandler(this.btnUtilizar_Click);
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
            this.txtSQL.AutoIndentCharsPatterns = "";
            this.txtSQL.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtSQL.BackBrush = null;
            this.txtSQL.CharHeight = 14;
            this.txtSQL.CharWidth = 8;
            this.txtSQL.CommentPrefix = "--";
            this.txtSQL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSQL.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSQL.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSQL.IsReplaceMode = false;
            this.txtSQL.Language = FastColoredTextBoxNS.Language.SQL;
            this.txtSQL.LeftBracket = '(';
            this.txtSQL.Location = new System.Drawing.Point(12, 290);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Paddings = new System.Windows.Forms.Padding(0);
            this.txtSQL.ReadOnly = true;
            this.txtSQL.RightBracket = ')';
            this.txtSQL.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtSQL.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtSQL.ServiceColors")));
            this.txtSQL.Size = new System.Drawing.Size(874, 202);
            this.txtSQL.TabIndex = 10;
            this.txtSQL.Zoom = 100;
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPesquisar.Location = new System.Drawing.Point(30, 13);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(59, 15);
            this.lblPesquisar.TabIndex = 12;
            this.lblPesquisar.Text = "Pesquisar";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisar.Location = new System.Drawing.Point(30, 31);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(856, 23);
            this.txtPesquisar.TabIndex = 11;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // FrmHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 533);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.btnUtilizar);
            this.Controls.Add(this.dgvHistorico);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histórico";
            this.Load += new System.EventHandler(this.FrmHistorico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn sql;
        private System.Windows.Forms.Button btnUtilizar;
        private FastColoredTextBoxNS.FastColoredTextBox txtSQL;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.TextBox txtPesquisar;
    }
}