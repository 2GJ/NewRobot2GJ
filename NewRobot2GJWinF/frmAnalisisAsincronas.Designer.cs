namespace NewRobot2GJWinF
{
    partial class frmAnalisisAsincronas
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
            this.btoRun = new System.Windows.Forms.Button();
            this.TVAsincronas = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btoRun
            // 
            this.btoRun.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btoRun.Image = global::NewRobot2GJWinF.Properties.Resources.Reintento50X50;
            this.btoRun.Location = new System.Drawing.Point(674, 297);
            this.btoRun.Name = "btoRun";
            this.btoRun.Size = new System.Drawing.Size(60, 60);
            this.btoRun.TabIndex = 42;
            this.btoRun.UseVisualStyleBackColor = false;
            this.btoRun.Click += new System.EventHandler(this.btoRun_Click);
            // 
            // TVAsincronas
            // 
            this.TVAsincronas.Location = new System.Drawing.Point(12, 12);
            this.TVAsincronas.Name = "TVAsincronas";
            this.TVAsincronas.Size = new System.Drawing.Size(243, 345);
            this.TVAsincronas.TabIndex = 43;
            // 
            // frmAnalisisAsincronas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 369);
            this.Controls.Add(this.TVAsincronas);
            this.Controls.Add(this.btoRun);
            this.Name = "frmAnalisisAsincronas";
            this.Text = "Analisis de Asincronas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btoRun;
        private System.Windows.Forms.TreeView TVAsincronas;

    }
}