﻿namespace NewRobot2GJWinF
{
    partial class frmActulizacionData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbExaminar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RegEjecutados = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btoReintento = new System.Windows.Forms.Button();
            this.RegTotal = new System.Windows.Forms.Label();
            this.lblRegTotal = new System.Windows.Forms.Label();
            this.btoExaminar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbResultado = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbExaminar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.RegEjecutados);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btoReintento);
            this.groupBox1.Controls.Add(this.RegTotal);
            this.groupBox1.Controls.Add(this.lblRegTotal);
            this.groupBox1.Controls.Add(this.btoExaminar);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(588, 335);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // tbExaminar
            // 
            this.tbExaminar.Location = new System.Drawing.Point(36, 51);
            this.tbExaminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbExaminar.Name = "tbExaminar";
            this.tbExaminar.Size = new System.Drawing.Size(502, 26);
            this.tbExaminar.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(502, 35);
            this.label3.TabIndex = 44;
            this.label3.Text = "Ruta de Archivo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RegEjecutados
            // 
            this.RegEjecutados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RegEjecutados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegEjecutados.Location = new System.Drawing.Point(32, 272);
            this.RegEjecutados.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegEjecutados.Name = "RegEjecutados";
            this.RegEjecutados.Size = new System.Drawing.Size(159, 38);
            this.RegEjecutados.TabIndex = 42;
            this.RegEjecutados.Text = "0";
            this.RegEjecutados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 54);
            this.label2.TabIndex = 43;
            this.label2.Text = "Registros Ejecutados";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btoReintento
            // 
            this.btoReintento.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btoReintento.Image = global::NewRobot2GJWinF.Properties.Resources.Reintento50X50;
            this.btoReintento.Location = new System.Drawing.Point(489, 234);
            this.btoReintento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btoReintento.Name = "btoReintento";
            this.btoReintento.Size = new System.Drawing.Size(90, 92);
            this.btoReintento.TabIndex = 41;
            this.btoReintento.UseVisualStyleBackColor = false;
            this.btoReintento.Click += new System.EventHandler(this.btoReintento_Click);
            // 
            // RegTotal
            // 
            this.RegTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this.RegTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegTotal.Location = new System.Drawing.Point(33, 158);
            this.RegTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegTotal.Name = "RegTotal";
            this.RegTotal.Size = new System.Drawing.Size(158, 38);
            this.RegTotal.TabIndex = 39;
            this.RegTotal.Text = "0";
            this.RegTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRegTotal
            // 
            this.lblRegTotal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblRegTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegTotal.Location = new System.Drawing.Point(33, 105);
            this.lblRegTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegTotal.Name = "lblRegTotal";
            this.lblRegTotal.Size = new System.Drawing.Size(158, 54);
            this.lblRegTotal.TabIndex = 40;
            this.lblRegTotal.Text = "Registros Archivo";
            this.lblRegTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btoExaminar
            // 
            this.btoExaminar.Location = new System.Drawing.Point(536, 49);
            this.btoExaminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btoExaminar.Name = "btoExaminar";
            this.btoExaminar.Size = new System.Drawing.Size(40, 34);
            this.btoExaminar.TabIndex = 11;
            this.btoExaminar.Text = "....";
            this.btoExaminar.UseVisualStyleBackColor = true;
            this.btoExaminar.Click += new System.EventHandler(this.btoExaminar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(610, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(568, 335);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            // 
            // rtbResultado
            // 
            this.rtbResultado.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtbResultado.ForeColor = System.Drawing.Color.Lime;
            this.rtbResultado.Location = new System.Drawing.Point(13, 359);
            this.rtbResultado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbResultado.Name = "rtbResultado";
            this.rtbResultado.Size = new System.Drawing.Size(1164, 429);
            this.rtbResultado.TabIndex = 40;
            this.rtbResultado.Text = "";
            // 
            // frmActulizacionData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 804);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rtbResultado);
            this.Name = "frmActulizacionData";
            this.Text = "Actualizar Información";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbExaminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RegEjecutados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btoReintento;
        private System.Windows.Forms.Label RegTotal;
        private System.Windows.Forms.Label lblRegTotal;
        private System.Windows.Forms.Button btoExaminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbResultado;
    }
}