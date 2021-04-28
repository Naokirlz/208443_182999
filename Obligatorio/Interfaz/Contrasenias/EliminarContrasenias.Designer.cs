
namespace Interfaz.Contrasenias
{
    partial class EliminarContrasenias
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.cmbContrasenia = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(360, 172);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(98, 26);
            this.btnEliminar.TabIndex = 42;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Location = new System.Drawing.Point(47, 102);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(61, 13);
            this.lblContrasenia.TabIndex = 41;
            this.lblContrasenia.Text = "Contraseña";
            // 
            // cmbContrasenia
            // 
            this.cmbContrasenia.FormattingEnabled = true;
            this.cmbContrasenia.Location = new System.Drawing.Point(129, 94);
            this.cmbContrasenia.Name = "cmbContrasenia";
            this.cmbContrasenia.Size = new System.Drawing.Size(168, 21);
            this.cmbContrasenia.TabIndex = 40;
            // 
            // EliminarContrasenias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblContrasenia);
            this.Controls.Add(this.cmbContrasenia);
            this.Name = "EliminarContrasenias";
            this.Size = new System.Drawing.Size(516, 332);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.ComboBox cmbContrasenia;
    }
}
