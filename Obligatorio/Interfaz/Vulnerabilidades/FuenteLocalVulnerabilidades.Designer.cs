
namespace Interfaz.Vulnerabilidades
{
    partial class FuenteLocalVulnerabilidades
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
            this.txtEntradaFuenteLocal = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEntradaFuenteLocal
            // 
            this.txtEntradaFuenteLocal.Location = new System.Drawing.Point(39, 41);
            this.txtEntradaFuenteLocal.Multiline = true;
            this.txtEntradaFuenteLocal.Name = "txtEntradaFuenteLocal";
            this.txtEntradaFuenteLocal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEntradaFuenteLocal.Size = new System.Drawing.Size(248, 273);
            this.txtEntradaFuenteLocal.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(346, 291);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // FuenteLocalVulnerabilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtEntradaFuenteLocal);
            this.Name = "FuenteLocalVulnerabilidades";
            this.Size = new System.Drawing.Size(516, 332);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEntradaFuenteLocal;
        private System.Windows.Forms.Button btnAgregar;
    }
}
