
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
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 419);
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
    }
}

