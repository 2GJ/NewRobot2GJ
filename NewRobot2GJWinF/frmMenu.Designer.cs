namespace NewRobot2GJWinF
{
    partial class frmMenu
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btoReinAsinMan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btoReinAsinMan
            // 
            this.btoReinAsinMan.Location = new System.Drawing.Point(60, 12);
            this.btoReinAsinMan.Name = "btoReinAsinMan";
            this.btoReinAsinMan.Size = new System.Drawing.Size(192, 23);
            this.btoReinAsinMan.TabIndex = 0;
            this.btoReinAsinMan.Text = "Reintento Asincronas (Manual)";
            this.btoReinAsinMan.UseVisualStyleBackColor = true;
            this.btoReinAsinMan.Click += new System.EventHandler(this.btoReinAsinMan_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 171);
            this.Controls.Add(this.btoReinAsinMan);
            this.Name = "frmMenu";
            this.Text = "New Robot 2GJ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btoReinAsinMan;
    }
}

