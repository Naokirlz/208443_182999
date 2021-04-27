
namespace Interfaz.TarjetaCredito
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
            this.btnAgregarTarjeta = new System.Windows.Forms.Button();
            this.pnlGestor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnAgregarTarjeta
            // 
            this.btnAgregarTarjeta.Location = new System.Drawing.Point(3, 34);
            this.btnAgregarTarjeta.Name = "btnAgregarTarjeta";
            this.btnAgregarTarjeta.Size = new System.Drawing.Size(134, 23);
            this.btnAgregarTarjeta.TabIndex = 0;
            this.btnAgregarTarjeta.Text = "Agregar Tarjeta";
            this.btnAgregarTarjeta.UseVisualStyleBackColor = true;
            this.btnAgregarTarjeta.Click += new System.EventHandler(this.btnAgregarTarjeta_Click);
            // 
            // pnlGestor
            // 
            this.pnlGestor.Location = new System.Drawing.Point(199, 16);
            this.pnlGestor.Name = "pnlGestor";
            this.pnlGestor.Size = new System.Drawing.Size(431, 303);
            this.pnlGestor.TabIndex = 1;
            // 
            // GestionTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGestor);
            this.Controls.Add(this.btnAgregarTarjeta);
            this.Name = "GestionTarjetas";
            this.Size = new System.Drawing.Size(648, 339);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarTarjeta;
        private System.Windows.Forms.Panel pnlGestor;
    }
}
