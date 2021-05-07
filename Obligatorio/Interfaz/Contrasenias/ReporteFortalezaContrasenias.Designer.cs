
namespace Interfaz.Contrasenias
{
    partial class ReporteFortalezaContrasenias
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
            this.dgvContrasenias = new System.Windows.Forms.DataGridView();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvContraseniasPorGrupo = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContrasenias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContraseniasPorGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContrasenias
            // 
            this.dgvContrasenias.AllowUserToAddRows = false;
            this.dgvContrasenias.AllowUserToDeleteRows = false;
            this.dgvContrasenias.AllowUserToOrderColumns = true;
            this.dgvContrasenias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContrasenias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grupo,
            this.Cantidad});
            this.dgvContrasenias.Location = new System.Drawing.Point(15, 14);
            this.dgvContrasenias.Name = "dgvContrasenias";
            this.dgvContrasenias.ReadOnly = true;
            this.dgvContrasenias.Size = new System.Drawing.Size(437, 256);
            this.dgvContrasenias.TabIndex = 2;
            this.dgvContrasenias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContrasenias_CellClick);
            // 
            // Grupo
            // 
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad de Contraseñas";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // dgvContraseniasPorGrupo
            // 
            this.dgvContraseniasPorGrupo.AllowUserToAddRows = false;
            this.dgvContraseniasPorGrupo.AllowUserToDeleteRows = false;
            this.dgvContraseniasPorGrupo.AllowUserToOrderColumns = true;
            this.dgvContraseniasPorGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContraseniasPorGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Categoria,
            this.Sitio,
            this.Usuario,
            this.UltimaModificacion,
            this.Password});
            this.dgvContraseniasPorGrupo.Location = new System.Drawing.Point(15, 34);
            this.dgvContraseniasPorGrupo.Name = "dgvContraseniasPorGrupo";
            this.dgvContraseniasPorGrupo.ReadOnly = true;
            this.dgvContraseniasPorGrupo.Size = new System.Drawing.Size(437, 256);
            this.dgvContraseniasPorGrupo.TabIndex = 3;
            this.dgvContraseniasPorGrupo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContraseniasPorGrupo_CellClick);
            this.dgvContraseniasPorGrupo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvContraseniasPorGrupo_CellFormatting);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(274, 296);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Sitio
            // 
            this.Sitio.HeaderText = "Sitio o Aplicación";
            this.Sitio.Name = "Sitio";
            this.Sitio.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // UltimaModificacion
            // 
            this.UltimaModificacion.HeaderText = "Última Modificación";
            this.UltimaModificacion.Name = "UltimaModificacion";
            this.UltimaModificacion.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.HeaderText = "Contraseña";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            // 
            // ReporteFortalezaContrasenias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvContraseniasPorGrupo);
            this.Controls.Add(this.dgvContrasenias);
            this.Name = "ReporteFortalezaContrasenias";
            this.Size = new System.Drawing.Size(471, 322);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContrasenias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContraseniasPorGrupo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContrasenias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridView dgvContraseniasPorGrupo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
    }
}
