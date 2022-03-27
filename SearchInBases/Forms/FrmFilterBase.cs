﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SearchInBases.Forms
{
    public partial class FrmFilterBase : Form
    {
        public FrmFilterBase()
        {
            InitializeComponent();
        }

        private void FrmFilterBase_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(400, 500);

            if(Vars.basesFiltradas.Count > 0)
            {
                Vars.basesFiltradas.ForEach(b => txtFilter.AppendText(b + Environment.NewLine));
            }
        }

        private void btnUtilizar_Click(object sender, EventArgs e)
        {  
            Vars.basesFiltradas.Clear();

            TratarBasesFiltradas();

            this.Close();
        }

        private void TratarBasesFiltradas()
        {
            if (String.IsNullOrEmpty(txtFilter.Text.Trim()))
                return;

            List<string> bases = new List<string>();
            txtFilter.Text = txtFilter.Text.Replace(" ", "_");
            bases.AddRange(txtFilter.Text.Trim().Split(Environment.NewLine));            
            
            Vars.basesFiltradas.AddRange(bases);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtFilter.Clear();
        }
    }
}