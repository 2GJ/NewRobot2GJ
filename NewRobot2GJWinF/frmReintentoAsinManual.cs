﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NewRobot2GJWinF
{
    public partial class frmReintentoAsinManual : Form
    {
        public frmReintentoAsinManual()
        {
            InitializeComponent();
        }

        private void btoExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.txt";
            openFileDialog1.Title = "Select a Cursor File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbExaminar.Text = openFileDialog1.FileName;
            }

            //Abrir el archivo de captura.
            if (this.tbExaminar.Text == null)
                MessageBox.Show("Validacion: La ruta del archivo de carga no es valido...");

            StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);
            int y = File.ReadAllLines(this.tbExaminar.Text).Length;
            RegTotal.Text = y.ToString();
            this.Refresh();
        }

        private void btoReintento_Click(object sender, EventArgs e)
        {
            //int Contador = 0;
            
            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no es valido");

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                Int64 y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        rtbResultado.Text += strLineArzay[i] + "\t";
                    }

                    //PerformActivity
                    CapaSOA2GJ.CapaSOA2GJ objSOA = new CapaSOA2GJ.CapaSOA2GJ();
                    objSOA.PerformActivity("domain", "admon", Convert.ToInt32(strLineArzay[0]), Convert.ToInt32(strLineArzay[2]));

                    rtbResultado.Text += objSOA.CodeAnswer + ":" + objSOA.DescriptionAnswer + "\n"; 
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Exception: " + e1.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
