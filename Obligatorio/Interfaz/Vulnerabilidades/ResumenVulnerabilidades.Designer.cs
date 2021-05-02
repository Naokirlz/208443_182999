
namespace Interfaz.Vulnerabilidades
{
    partial class ResumenVulnerabilidades
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
            this.dgvVulnerabilidades = new System.Windows.Forms.DataGridView();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFuentes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVulnerabilidades)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVulnerabilidades
            // 
            this.dgvVulnerabilidades.AllowUserToAddRows = false;
            this.dgvVulnerabilidades.AllowUserToDeleteRows = false;
            this.dgvVulnerabilidades.AllowUserToOrderColumns = true;
            this.dgvVulnerabilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVulnerabilidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Categoria,
            this.Nombre,
            this.Tipo,
            this.Tarjeta,
            this.Vencimiento});
            this.dgvVulnerabilidades.Location = new System.Drawing.Point(39, 52);
            this.dgvVulnerabilidades.Name = "dgvVulnerabilidades";
            this.dgvVulnerabilidades.ReadOnly = true;
            this.dgvVulnerabilidades.Size = new System.Drawing.Size(437, 256);
            this.dgvVulnerabilidades.TabIndex = 1;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Tarjeta
            // 
            this.Tarjeta.HeaderText = "Tarjeta";
            this.Tarjeta.Name = "Tarjeta";
            this.Tarjeta.ReadOnly = true;
            // 
            // Vencimiento
            // 
            this.Vencimiento.HeaderText = "Vencimiento";
            this.Vencimiento.Name = "Vencimiento";
            this.Vencimiento.ReadOnly = true;
            // 
            // lblFuentes
            // 
            this.lblFuentes.AutoSize = true;
            this.lblFuentes.Location = new System.Drawing.Point(36, 21);
            this.lblFuentes.Name = "lblFuentes";
            this.lblFuentes.Size = new System.Drawing.Size(264, 13);
            this.lblFuentes.TabIndex = 2;
            this.lblFuentes.Text = "Se han chequeado sus vulnerabilidades en 1 fuente(s)";
            // 
            // ResumenVulnerabilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFuentes);
            this.Controls.Add(this.dgvVulnerabilidades);
            this.Name = "ResumenVulnerabilidades";
            this.Size = new System.Drawing.Size(516, 332);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVulnerabilidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVulnerabilidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vencimiento;
        private System.Windows.Forms.Label lblFuentes;
    }
}
