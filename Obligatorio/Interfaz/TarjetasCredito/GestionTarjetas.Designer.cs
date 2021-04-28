
namespace Interfaz.TarjetasCredito
{
    partial class GestionTarjetas
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
            this.pnlGestor = new System.Windows.Forms.Panel();
            this.btnAgregarTarjeta = new System.Windows.Forms.Button();
            this.btnModificarTarjeta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlGestor
            // 
            this.pnlGestor.Location = new System.Drawing.Point(194, 24);
            this.pnlGestor.Name = "pnlGestor";
            this.pnlGestor.Size = new System.Drawing.Size(516, 332);
            this.pnlGestor.TabIndex = 1;
            // 
            // btnAgregarTarjeta
            // 
            this.btnAgregarTarjeta.Location = new System.Drawing.Point(3, 61);
            this.btnAgregarTarjeta.Name = "btnAgregarTarjeta";
            this.btnAgregarTarjeta.Size = new System.Drawing.Size(185, 23);
            this.btnAgregarTarjeta.TabIndex = 2;
            this.btnAgregarTarjeta.Text = "Agregar Tarjeta";
            this.btnAgregarTarjeta.UseVisualStyleBackColor = true;
            this.btnAgregarTarjeta.Click += new System.EventHandler(this.btnAgregarTarjeta_Click);
            // 
            // btnModificarTarjeta
            // 
            this.btnModificarTarjeta.Location = new System.Drawing.Point(3, 90);
            this.btnModificarTarjeta.Name = "btnModificarTarjeta";
            this.btnModificarTarjeta.Size = new System.Drawing.Size(185, 23);
            this.btnModificarTarjeta.TabIndex = 3;
            this.btnModificarTarjeta.Text = "Modificar Tarjeta";
            this.btnModificarTarjeta.UseVisualStyleBackColor = true;
            this.btnModificarTarjeta.Click += new System.EventHandler(this.btnModificarTarjeta_Click);
            // 
            // GestionTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnModificarTarjeta);
            this.Controls.Add(this.btnAgregarTarjeta);
            this.Controls.Add(this.pnlGestor);
            this.Name = "GestionTarjetas";
            this.Size = new System.Drawing.Size(729, 376);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGestor;
        private System.Windows.Forms.Button btnAgregarTarjeta;
        private System.Windows.Forms.Button btnModificarTarjeta;
    }
}
