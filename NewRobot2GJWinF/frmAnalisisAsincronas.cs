using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewRobot2GJWinF
{
    public partial class frmAnalisisAsincronas : Form
    {
        public frmAnalisisAsincronas()
        {
            InitializeComponent();
        }

        private void btoRun_Click(object sender, EventArgs e)
        {
            TreeNode NodoRaiz = new TreeNode("Asincronas");
            this.TVAsincronas.Nodes.Add(NodoRaiz);

            CapaSOA2GJ.AnalisisAsincronas objAnaAsin = new CapaSOA2GJ.AnalisisAsincronas();
            objAnaAsin.IniciarAnalisisAsincronas();
        }
    }
}
