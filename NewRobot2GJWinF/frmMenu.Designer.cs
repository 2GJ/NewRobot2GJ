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
            this.btoAnalisisAsincronas = new System.Windows.Forms.Button();
            this.btoActInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btoReinAsinMan
            // 
            this.btoReinAsinMan.Location = new System.Drawing.Point(90, 18);
            this.btoReinAsinMan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btoReinAsinMan.Name = "btoReinAsinMan";
            this.btoReinAsinMan.Size = new System.Drawing.Size(288, 35);
            this.btoReinAsinMan.TabIndex = 0;
            this.btoReinAsinMan.Text = "Reintento Asincronas (Manual)";
            this.btoReinAsinMan.UseVisualStyleBackColor = true;
            this.btoReinAsinMan.Click += new System.EventHandler(this.btoReinAsinMan_Click);
            // 
            // btoAnalisisAsincronas
            // 
            this.btoAnalisisAsincronas.Enabled = false;
            this.btoAnalisisAsincronas.Location = new System.Drawing.Point(90, 108);
            this.btoAnalisisAsincronas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btoAnalisisAsincronas.Name = "btoAnalisisAsincronas";
            this.btoAnalisisAsincronas.Size = new System.Drawing.Size(288, 35);
            this.btoAnalisisAsincronas.TabIndex = 1;
            this.btoAnalisisAsincronas.Text = "Analisis de Asincronas";
            this.btoAnalisisAsincronas.UseVisualStyleBackColor = true;
            this.btoAnalisisAsincronas.Click += new System.EventHandler(this.button1_Click);
            // 
            // btoActInfo
            // 
            this.btoActInfo.Location = new System.Drawing.Point(90, 63);
            this.btoActInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btoActInfo.Name = "btoActInfo";
            this.btoActInfo.Size = new System.Drawing.Size(288, 35);
            this.btoActInfo.TabIndex = 2;
            this.btoActInfo.Text = "Actualizacion Informacion (Manual)";
            this.btoActInfo.UseVisualStyleBackColor = true;
            this.btoActInfo.Click += new System.EventHandler(this.btoActInfo_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 263);
            this.Controls.Add(this.btoActInfo);
            this.Controls.Add(this.btoAnalisisAsincronas);
            this.Controls.Add(this.btoReinAsinMan);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMenu";
            this.Text = "New Robot 2GJ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btoReinAsinMan;
        private System.Windows.Forms.Button btoAnalisisAsincronas;
        private System.Windows.Forms.Button btoActInfo;
    }
}

