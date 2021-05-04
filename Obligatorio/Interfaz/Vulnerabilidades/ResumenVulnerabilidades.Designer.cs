
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
            this.dgvVulnerabilidadesTarjetas = new System.Windows.Forms.DataGridView();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VulnerabilidadTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFuentes = new System.Windows.Forms.Label();
            this.dgvVulnerabilidadesContrasenias = new System.Windows.Forms.DataGridView();
            this.CategoriaContrasenia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vulnerabilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.chkFuenteLocal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVulnerabilidadesTarjetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVulnerabilidadesContrasenias)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVulnerabilidadesTarjetas
            // 
            this.dgvVulnerabilidadesTarjetas.AllowUserToAddRows = false;
            this.dgvVulnerabilidadesTarjetas.AllowUserToDeleteRows = false;
            this.dgvVulnerabilidadesTarjetas.AllowUserToOrderColumns = true;
            this.dgvVulnerabilidadesTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVulnerabilidadesTarjetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Categoria,
            this.Nombre,
            this.Tipo,
            this.Tarjeta,
            this.VulnerabilidadTarjeta});
            this.dgvVulnerabilidadesTarjetas.Location = new System.Drawing.Point(3, 16);
            this.dgvVulnerabilidadesTarjetas.Name = "dgvVulnerabilidadesTarjetas";
            this.dgvVulnerabilidadesTarjetas.ReadOnly = true;
            this.dgvVulnerabilidadesTarjetas.Size = new System.Drawing.Size(437, 110);
            this.dgvVulnerabilidadesTarjetas.TabIndex = 1;
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
            // VulnerabilidadTarjeta
            // 
            this.VulnerabilidadTarjeta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VulnerabilidadTarjeta.HeaderText = "Vulnerabilidad";
            this.VulnerabilidadTarjeta.Name = "VulnerabilidadTarjeta";
            this.VulnerabilidadTarjeta.ReadOnly = true;
            this.VulnerabilidadTarjeta.Width = 98;
            // 
            // lblFuentes
            // 
            this.lblFuentes.AutoSize = true;
            this.lblFuentes.Location = new System.Drawing.Point(36, 0);
            this.lblFuentes.Name = "lblFuentes";
            this.lblFuentes.Size = new System.Drawing.Size(264, 13);
            this.lblFuentes.TabIndex = 2;
            this.lblFuentes.Text = "Se han chequeado sus vulnerabilidades en 1 fuente(s)";
            // 
            // dgvVulnerabilidadesContrasenias
            // 
            this.dgvVulnerabilidadesContrasenias.AllowUserToAddRows = false;
            this.dgvVulnerabilidadesContrasenias.AllowUserToDeleteRows = false;
            this.dgvVulnerabilidadesContrasenias.AllowUserToOrderColumns = true;
            this.dgvVulnerabilidadesContrasenias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVulnerabilidadesContrasenias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoriaContrasenia,
            this.Sitio,
            this.Usuario,
            this.Password,
            this.Vulnerabilidad});
            this.dgvVulnerabilidadesContrasenias.Location = new System.Drawing.Point(3, 132);
            this.dgvVulnerabilidadesContrasenias.Name = "dgvVulnerabilidadesContrasenias";
            this.dgvVulnerabilidadesContrasenias.ReadOnly = true;
            this.dgvVulnerabilidadesContrasenias.Size = new System.Drawing.Size(437, 108);
            this.dgvVulnerabilidadesContrasenias.TabIndex = 3;
            this.dgvVulnerabilidadesContrasenias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVulnerabilidadesContrasenias_CellClick);
            // 
            // CategoriaContrasenia
            // 
            this.CategoriaContrasenia.HeaderText = "Categoría";
            this.CategoriaContrasenia.Name = "CategoriaContrasenia";
            this.CategoriaContrasenia.ReadOnly = true;
            // 
            // Sitio
            // 
            this.Sitio.HeaderText = "Sitio";
            this.Sitio.Name = "Sitio";
            this.Sitio.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.HeaderText = "Contraseña";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            // 
            // Vulnerabilidad
            // 
            this.Vulnerabilidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Vulnerabilidad.HeaderText = "Vulnerabilidad";
            this.Vulnerabilidad.Name = "Vulnerabilidad";
            this.Vulnerabilidad.ReadOnly = true;
            this.Vulnerabilidad.Width = 98;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(446, 132);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(67, 62);
            this.btnRefrescar.TabIndex = 5;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // chkFuenteLocal
            // 
            this.chkFuenteLocal.AutoSize = true;
            this.chkFuenteLocal.Location = new System.Drawing.Point(76, 269);
            this.chkFuenteLocal.Name = "chkFuenteLocal";
            this.chkFuenteLocal.Size = new System.Drawing.Size(88, 17);
            this.chkFuenteLocal.TabIndex = 6;
            this.chkFuenteLocal.Text = "Fuente Local";
            this.chkFuenteLocal.UseVisualStyleBackColor = true;
            // 
            // ResumenVulnerabilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkFuenteLocal);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.dgvVulnerabilidadesContrasenias);
            this.Controls.Add(this.lblFuentes);
            this.Controls.Add(this.dgvVulnerabilidadesTarjetas);
            this.Name = "ResumenVulnerabilidades";
            this.Size = new System.Drawing.Size(516, 332);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVulnerabilidadesTarjetas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVulnerabilidadesContrasenias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVulnerabilidadesTarjetas;
        private System.Windows.Forms.Label lblFuentes;
        private System.Windows.Forms.DataGridView dgvVulnerabilidadesContrasenias;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.CheckBox chkFuenteLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn VulnerabilidadTarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaContrasenia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vulnerabilidad;
    }
}
