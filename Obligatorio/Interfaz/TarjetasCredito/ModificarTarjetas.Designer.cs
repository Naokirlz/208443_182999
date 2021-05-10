
namespace Interfaz.TarjetasCredito
{
    partial class ModificarTarjetas
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
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.lblNotas = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.RichTextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.cmbTarjetas = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.MaskedTextBox();
            this.txtNumero = new System.Windows.Forms.MaskedTextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.CustomFormat = "MM/yy";
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVencimiento.Location = new System.Drawing.Point(464, 67);
            this.dtpVencimiento.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(304, 27);
            this.dtpVencimiento.TabIndex = 34;
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.ForeColor = System.Drawing.Color.White;
            this.lblVencimiento.Location = new System.Drawing.Point(565, 29);
            this.lblVencimiento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(109, 21);
            this.lblVencimiento.TabIndex = 32;
            this.lblVencimiento.Text = "Vencimiento";
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.ForeColor = System.Drawing.Color.White;
            this.lblNotas.Location = new System.Drawing.Point(601, 117);
            this.lblNotas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(56, 21);
            this.lblNotas.TabIndex = 31;
            this.lblNotas.Text = "Notas";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(464, 156);
            this.txtNotas.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(304, 117);
            this.txtNotas.TabIndex = 30;
            this.txtNotas.Text = "";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.ForeColor = System.Drawing.Color.White;
            this.lblCodigo.Location = new System.Drawing.Point(25, 207);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(68, 21);
            this.lblCodigo.TabIndex = 29;
            this.lblCodigo.Text = "Código";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.ForeColor = System.Drawing.Color.White;
            this.lblNumero.Location = new System.Drawing.Point(21, 249);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(72, 21);
            this.lblNumero.TabIndex = 26;
            this.lblNumero.Text = "Número";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(103, 156);
            this.txtTipo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(326, 27);
            this.txtTipo.TabIndex = 25;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.ForeColor = System.Drawing.Color.White;
            this.lblTipo.Location = new System.Drawing.Point(51, 159);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(42, 21);
            this.lblTipo.TabIndex = 24;
            this.lblTipo.Text = "Tipo";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(103, 114);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(326, 27);
            this.txtNombre.TabIndex = 23;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(20, 117);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(73, 21);
            this.lblNombre.TabIndex = 22;
            this.lblNombre.Text = "Nombre";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.ForeColor = System.Drawing.Color.White;
            this.lblCategoria.Location = new System.Drawing.Point(2, 73);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(91, 21);
            this.lblCategoria.TabIndex = 21;
            this.lblCategoria.Text = "Categoría";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(103, 70);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(326, 29);
            this.cmbCategoria.TabIndex = 20;
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.ForeColor = System.Drawing.Color.White;
            this.lblTarjeta.Location = new System.Drawing.Point(24, 29);
            this.lblTarjeta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(69, 21);
            this.lblTarjeta.TabIndex = 36;
            this.lblTarjeta.Text = "Tarjeta ";
            // 
            // cmbTarjetas
            // 
            this.cmbTarjetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarjetas.FormattingEnabled = true;
            this.cmbTarjetas.Location = new System.Drawing.Point(103, 26);
            this.cmbTarjetas.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbTarjetas.Name = "cmbTarjetas";
            this.cmbTarjetas.Size = new System.Drawing.Size(326, 29);
            this.cmbTarjetas.TabIndex = 35;
            this.cmbTarjetas.SelectedIndexChanged += new System.EventHandler(this.cmbContrasenias_SelectedIndexChanged);
            this.cmbTarjetas.SelectionChangeCommitted += new System.EventHandler(this.cmbTarjeta_SelectionChangeCommitted);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(103, 204);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtCodigo.Mask = "999";
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(326, 27);
            this.txtCodigo.TabIndex = 38;
            this.txtCodigo.ValidatingType = typeof(int);
            this.txtCodigo.Click += new System.EventHandler(this.txtCodigo_Click);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(103, 246);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtNumero.Mask = "0000 0000 0000 0000";
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(326, 27);
            this.txtNumero.TabIndex = 37;
            this.txtNumero.Click += new System.EventHandler(this.txtNumero_Click);
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.Location = new System.Drawing.Point(646, 326);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 33);
            this.btnGuardar.TabIndex = 39;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ModificarTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.cmbTarjetas);
            this.Controls.Add(this.dtpVencimiento);
            this.Controls.Add(this.lblVencimiento);
            this.Controls.Add(this.lblNotas);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cmbCategoria);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ModificarTarjetas";
            this.Size = new System.Drawing.Size(814, 384);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.Label lblNotas;
        private System.Windows.Forms.RichTextBox txtNotas;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.ComboBox cmbTarjetas;
        private System.Windows.Forms.MaskedTextBox txtCodigo;
        private System.Windows.Forms.MaskedTextBox txtNumero;
        private System.Windows.Forms.Button btnGuardar;
    }
}
