namespace NewRobot2GJWinF
{
    partial class frmReintentoAsinManual
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
            this.btoExaminar = new System.Windows.Forms.Button();
            this.tbExaminar = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRegTotal = new System.Windows.Forms.Label();
            this.RegTotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btoExaminar);
            this.groupBox1.Controls.Add(this.tbExaminar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 50);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // btoExaminar
            // 
            this.btoExaminar.Location = new System.Drawing.Point(7, 14);
            this.btoExaminar.Name = "btoExaminar";
            this.btoExaminar.Size = new System.Drawing.Size(100, 23);
            this.btoExaminar.TabIndex = 11;
            this.btoExaminar.Text = "Examinar";
            this.btoExaminar.UseVisualStyleBackColor = true;
            this.btoExaminar.Click += new System.EventHandler(this.btoExaminar_Click);
            // 
            // tbExaminar
            // 
            this.tbExaminar.Location = new System.Drawing.Point(113, 16);
            this.tbExaminar.Name = "tbExaminar";
            this.tbExaminar.Size = new System.Drawing.Size(603, 20);
            this.tbExaminar.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RegTotal);
            this.groupBox2.Controls.Add(this.lblRegTotal);
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(722, 86);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            // 
            // lblRegTotal
            // 
            this.lblRegTotal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblRegTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegTotal.Location = new System.Drawing.Point(6, 16);
            this.lblRegTotal.Name = "lblRegTotal";
            this.lblRegTotal.Size = new System.Drawing.Size(101, 35);
            this.lblRegTotal.TabIndex = 35;
            this.lblRegTotal.Text = "Registros Archivo";
            this.lblRegTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RegTotal
            // 
            this.RegTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this.RegTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegTotal.Location = new System.Drawing.Point(6, 51);
            this.RegTotal.Name = "RegTotal";
            this.RegTotal.Size = new System.Drawing.Size(101, 25);
            this.RegTotal.TabIndex = 34;
            this.RegTotal.Text = "0";
            this.RegTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmReintentoAsinManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 528);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReintentoAsinManual";
            this.Text = "Reintento Manual Asincronas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btoExaminar;
        private System.Windows.Forms.TextBox tbExaminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblRegTotal;
        private System.Windows.Forms.Label RegTotal;
    }
}