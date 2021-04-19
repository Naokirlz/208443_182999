
namespace Interfaz
{
    partial class GestionCategorias
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
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.btnEliminarCategorias = new System.Windows.Forms.Button();
            this.btnModificarCategoria = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlGestor
            // 
            this.pnlGestor.Location = new System.Drawing.Point(200, 19);
            this.pnlGestor.Name = "pnlGestor";
            this.pnlGestor.Size = new System.Drawing.Size(431, 303);
            this.pnlGestor.TabIndex = 0;
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Location = new System.Drawing.Point(9, 44);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(185, 23);
            this.btnAgregarCategoria.TabIndex = 1;
            this.btnAgregarCategoria.Text = "Agregar Categorías";
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // btnEliminarCategorias
            // 
            this.btnEliminarCategorias.Location = new System.Drawing.Point(9, 102);
            this.btnEliminarCategorias.Name = "btnEliminarCategorias";
            this.btnEliminarCategorias.Size = new System.Drawing.Size(185, 23);
            this.btnEliminarCategorias.TabIndex = 5;
            this.btnEliminarCategorias.Text = "Eliminar Categorías";
            this.btnEliminarCategorias.UseVisualStyleBackColor = true;
            this.btnEliminarCategorias.Click += new System.EventHandler(this.btnEliminarCategorias_Click);
            // 
            // btnModificarCategoria
            // 
            this.btnModificarCategoria.Location = new System.Drawing.Point(9, 73);
            this.btnModificarCategoria.Name = "btnModificarCategoria";
            this.btnModificarCategoria.Size = new System.Drawing.Size(185, 23);
            this.btnModificarCategoria.TabIndex = 4;
            this.btnModificarCategoria.Text = "Modificar Categorías";
            this.btnModificarCategoria.UseVisualStyleBackColor = true;
            this.btnModificarCategoria.Click += new System.EventHandler(this.btnModificarCategoria_Click);
            // 
            // GestionCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEliminarCategorias);
            this.Controls.Add(this.btnModificarCategoria);
            this.Controls.Add(this.btnAgregarCategoria);
            this.Controls.Add(this.pnlGestor);
            this.Name = "GestionCategorias";
            this.Size = new System.Drawing.Size(648, 339);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGestor;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.Button btnEliminarCategorias;
        private System.Windows.Forms.Button btnModificarCategoria;
    }
}
