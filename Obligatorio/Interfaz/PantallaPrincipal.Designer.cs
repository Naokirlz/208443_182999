
namespace Interfaz
{
    partial class PantallaPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGestionCategoria = new System.Windows.Forms.Button();
            this.pnlPanelPrincipal = new System.Windows.Forms.Panel();
            this.btnGestionContrasenia = new System.Windows.Forms.Button();
            this.btnGestionTarjetaCredito = new System.Windows.Forms.Button();
            this.btnVerificarVulnerabilidad = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGestionCategoria
            // 
            this.btnGestionCategoria.Location = new System.Drawing.Point(12, 69);
            this.btnGestionCategoria.Name = "btnGestionCategoria";
            this.btnGestionCategoria.Size = new System.Drawing.Size(185, 23);
            this.btnGestionCategoria.TabIndex = 0;
            this.btnGestionCategoria.Text = "Gestionar Categorías";
            this.btnGestionCategoria.UseVisualStyleBackColor = true;
            this.btnGestionCategoria.Click += new System.EventHandler(this.btnGestionCategoria_Click);
            // 
            // pnlPanelPrincipal
            // 
            this.pnlPanelPrincipal.Location = new System.Drawing.Point(228, 31);
            this.pnlPanelPrincipal.Name = "pnlPanelPrincipal";
            this.pnlPanelPrincipal.Size = new System.Drawing.Size(729, 376);
            this.pnlPanelPrincipal.TabIndex = 1;
            // 
            // btnGestionContrasenia
            // 
            this.btnGestionContrasenia.Location = new System.Drawing.Point(12, 98);
            this.btnGestionContrasenia.Name = "btnGestionContrasenia";
            this.btnGestionContrasenia.Size = new System.Drawing.Size(185, 23);
            this.btnGestionContrasenia.TabIndex = 2;
            this.btnGestionContrasenia.Text = "Gestionar Contraseñas";
            this.btnGestionContrasenia.UseVisualStyleBackColor = true;
            this.btnGestionContrasenia.Click += new System.EventHandler(this.btnGestionContrasenia_Click);
            // 
            // btnGestionTarjetaCredito
            // 
            this.btnGestionTarjetaCredito.Location = new System.Drawing.Point(12, 127);
            this.btnGestionTarjetaCredito.Name = "btnGestionTarjetaCredito";
            this.btnGestionTarjetaCredito.Size = new System.Drawing.Size(185, 23);
            this.btnGestionTarjetaCredito.TabIndex = 3;
            this.btnGestionTarjetaCredito.Text = "Tarjeras de Crédito";
            this.btnGestionTarjetaCredito.UseVisualStyleBackColor = true;
            this.btnGestionTarjetaCredito.Click += new System.EventHandler(this.btnGestionTarjetaCredito_Click);
            // 
            // btnVerificarVulnerabilidad
            // 
            this.btnVerificarVulnerabilidad.Location = new System.Drawing.Point(12, 156);
            this.btnVerificarVulnerabilidad.Name = "btnVerificarVulnerabilidad";
            this.btnVerificarVulnerabilidad.Size = new System.Drawing.Size(185, 23);
            this.btnVerificarVulnerabilidad.TabIndex = 4;
            this.btnVerificarVulnerabilidad.Text = "Verificar Vulnerabilidades";
            this.btnVerificarVulnerabilidad.UseVisualStyleBackColor = true;
            this.btnVerificarVulnerabilidad.Click += new System.EventHandler(this.btnVerificarVulnerabilidad_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 269);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(185, 23);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 419);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnVerificarVulnerabilidad);
            this.Controls.Add(this.btnGestionTarjetaCredito);
            this.Controls.Add(this.btnGestionContrasenia);
            this.Controls.Add(this.pnlPanelPrincipal);
            this.Controls.Add(this.btnGestionCategoria);
            this.Name = "PantallaPrincipal";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PantallaPrincipal_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionCategoria;
        private System.Windows.Forms.Panel pnlPanelPrincipal;
        private System.Windows.Forms.Button btnGestionContrasenia;
        private System.Windows.Forms.Button btnGestionTarjetaCredito;
        private System.Windows.Forms.Button btnVerificarVulnerabilidad;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}

