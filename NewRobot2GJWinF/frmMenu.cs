﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewRobot2GJWinF
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btoReinAsinMan_Click(object sender, EventArgs e)
        {
            Form objValAsinReco = new frmReintentoAsinManual();
            objValAsinReco.Show();
        }
    }
}
