
namespace Interfaz.Vulnerabilidades
{
    partial class GestionVulnerabilidades
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
            this.btnResumenVulnerabilidades = new System.Windows.Forms.Button();
            this.btnModificarFuenteLocal = new System.Windows.Forms.Button();
            this.btnModificarTarjeta = new System.Windows.Forms.Button();
            this.btnAgregarTarjeta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlGestor
            // 
            this.pnlGestor.Location = new System.Drawing.Point(193, 22);
            this.pnlGestor.Name = "pnlGestor";
            this.pnlGestor.Size = new System.Drawing.Size(516, 332);
            this.pnlGestor.TabIndex = 2;
            // 
            // btnResumenVulnerabilidades
            // 
            this.btnResumenVulnerabilidades.Location = new System.Drawing.Point(3, 90);
            this.btnResumenVulnerabilidades.Name = "btnResumenVulnerabilidades";
            this.btnResumenVulnerabilidades.Size = new System.Drawing.Size(185, 23);
            this.btnResumenVulnerabilidades.TabIndex = 9;
            this.btnResumenVulnerabilidades.Text = "Resumen";
            this.btnResumenVulnerabilidades.UseVisualStyleBackColor = true;
            this.btnResumenVulnerabilidades.Click += new System.EventHandler(this.btnResumenVulnerabilidades_Click);
            // 
            // btnModificarFuenteLocal
            // 
            this.btnModificarFuenteLocal.Location = new System.Drawing.Point(3, 177);
            this.btnModificarFuenteLocal.Name = "btnModificarFuenteLocal";
            this.btnModificarFuenteLocal.Size = new System.Drawing.Size(185, 23);
            this.btnModificarFuenteLocal.TabIndex = 8;
            this.btnModificarFuenteLocal.Text = "Fuente Local";
            this.btnModificarFuenteLocal.UseVisualStyleBackColor = true;
            this.btnModificarFuenteLocal.Click += new System.EventHandler(this.btnModificarFuenteLocal_Click);
            // 
            // btnModificarTarjeta
            // 
            this.btnModificarTarjeta.Location = new System.Drawing.Point(3, 148);
            this.btnModificarTarjeta.Name = "btnModificarTarjeta";
            this.btnModificarTarjeta.Size = new System.Drawing.Size(185, 23);
            this.btnModificarTarjeta.TabIndex = 7;
            this.btnModificarTarjeta.Text = "Modificar Tarjeta";
            this.btnModificarTarjeta.UseVisualStyleBackColor = true;
            // 
            // btnAgregarTarjeta
            // 
            this.btnAgregarTarjeta.Location = new System.Drawing.Point(3, 119);
            this.btnAgregarTarjeta.Name = "btnAgregarTarjeta";
            this.btnAgregarTarjeta.Size = new System.Drawing.Size(185, 23);
            this.btnAgregarTarjeta.TabIndex = 6;
            this.btnAgregarTarjeta.Text = "Agregar Tarjeta";
            this.btnAgregarTarjeta.UseVisualStyleBackColor = true;
            // 
            // GestionVulnerabilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnResumenVulnerabilidades);
            this.Controls.Add(this.btnModificarFuenteLocal);
            this.Controls.Add(this.btnModificarTarjeta);
            this.Controls.Add(this.btnAgregarTarjeta);
            this.Controls.Add(this.pnlGestor);
            this.Name = "GestionVulnerabilidades";
            this.Size = new System.Drawing.Size(729, 376);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGestor;
        private System.Windows.Forms.Button btnResumenVulnerabilidades;
        private System.Windows.Forms.Button btnModificarFuenteLocal;
        private System.Windows.Forms.Button btnModificarTarjeta;
        private System.Windows.Forms.Button btnAgregarTarjeta;
    }
}
