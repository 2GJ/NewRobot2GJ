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
            this.rtbResultado = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btoReintento = new System.Windows.Forms.Button();
            this.RegTotal = new System.Windows.Forms.Label();
            this.lblRegTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbPerform = new System.Windows.Forms.RadioButton();
            this.rbRetryAsy = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRetryAsy);
            this.groupBox1.Controls.Add(this.rbPerform);
            this.groupBox1.Controls.Add(this.tbExaminar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btoReintento);
            this.groupBox1.Controls.Add(this.RegTotal);
            this.groupBox1.Controls.Add(this.lblRegTotal);
            this.groupBox1.Controls.Add(this.btoExaminar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 218);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // btoExaminar
            // 
            this.btoExaminar.Location = new System.Drawing.Point(357, 32);
            this.btoExaminar.Name = "btoExaminar";
            this.btoExaminar.Size = new System.Drawing.Size(27, 22);
            this.btoExaminar.TabIndex = 11;
            this.btoExaminar.Text = "....";
            this.btoExaminar.UseVisualStyleBackColor = true;
            this.btoExaminar.Click += new System.EventHandler(this.btoExaminar_Click);
            // 
            // tbExaminar
            // 
            this.tbExaminar.Location = new System.Drawing.Point(24, 33);
            this.tbExaminar.Name = "tbExaminar";
            this.tbExaminar.Size = new System.Drawing.Size(336, 20);
            this.tbExaminar.TabIndex = 10;
            // 
            // rtbResultado
            // 
            this.rtbResultado.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtbResultado.ForeColor = System.Drawing.Color.Lime;
            this.rtbResultado.Location = new System.Drawing.Point(12, 236);
            this.rtbResultado.Name = "rtbResultado";
            this.rtbResultado.Size = new System.Drawing.Size(777, 280);
            this.rtbResultado.TabIndex = 37;
            this.rtbResultado.Text = "";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 42;
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 35);
            this.label2.TabIndex = 43;
            this.label2.Text = "Registros Ejecutados";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btoReintento
            // 
            this.btoReintento.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btoReintento.Image = global::NewRobot2GJWinF.Properties.Resources.Reintento50X50;
            this.btoReintento.Location = new System.Drawing.Point(326, 152);
            this.btoReintento.Name = "btoReintento";
            this.btoReintento.Size = new System.Drawing.Size(60, 60);
            this.btoReintento.TabIndex = 41;
            this.btoReintento.UseVisualStyleBackColor = false;
            this.btoReintento.Click += new System.EventHandler(this.btoReintento_Click);
            // 
            // RegTotal
            // 
            this.RegTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this.RegTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegTotal.Location = new System.Drawing.Point(22, 103);
            this.RegTotal.Name = "RegTotal";
            this.RegTotal.Size = new System.Drawing.Size(113, 25);
            this.RegTotal.TabIndex = 39;
            this.RegTotal.Text = "0";
            this.RegTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRegTotal
            // 
            this.lblRegTotal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblRegTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegTotal.Location = new System.Drawing.Point(22, 68);
            this.lblRegTotal.Name = "lblRegTotal";
            this.lblRegTotal.Size = new System.Drawing.Size(113, 35);
            this.lblRegTotal.TabIndex = 40;
            this.lblRegTotal.Text = "Registros Archivo";
            this.lblRegTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 23);
            this.label3.TabIndex = 44;
            this.label3.Text = "Ruta de Archivo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(410, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 218);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // rbPerform
            // 
            this.rbPerform.AutoSize = true;
            this.rbPerform.Location = new System.Drawing.Point(156, 77);
            this.rbPerform.Name = "rbPerform";
            this.rbPerform.Size = new System.Drawing.Size(120, 17);
            this.rbPerform.TabIndex = 45;
            this.rbPerform.TabStop = true;
            this.rbPerform.Text = "Por [PerformActivity]";
            this.rbPerform.UseVisualStyleBackColor = true;
            // 
            // rbRetryAsy
            // 
            this.rbRetryAsy.AutoSize = true;
            this.rbRetryAsy.Location = new System.Drawing.Point(156, 103);
            this.rbRetryAsy.Name = "rbRetryAsy";
            this.rbRetryAsy.Size = new System.Drawing.Size(107, 17);
            this.rbRetryAsy.TabIndex = 46;
            this.rbRetryAsy.TabStop = true;
            this.rbRetryAsy.Text = "Por [RetryAsinch]";
            this.rbRetryAsy.UseVisualStyleBackColor = true;
            this.rbRetryAsy.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // frmReintentoAsinManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(801, 528);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rtbResultado);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReintentoAsinManual";
            this.Text = "Reintento Manual Asincronas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btoExaminar;
        private System.Windows.Forms.TextBox tbExaminar;
        private System.Windows.Forms.RichTextBox rtbResultado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btoReintento;
        private System.Windows.Forms.Label RegTotal;
        private System.Windows.Forms.Label lblRegTotal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbRetryAsy;
        private System.Windows.Forms.RadioButton rbPerform;
    }
}