
namespace Interfaz.Contrasenias
{
    partial class AgregarContrasenias
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
            this.lblSitio = new System.Windows.Forms.Label();
            this.txtSitio = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.lblNotas = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblAutogenerar = new System.Windows.Forms.Label();
            this.lblLargo = new System.Windows.Forms.Label();
            this.numLargo = new System.Windows.Forms.NumericUpDown();
            this.chkMayusculas = new System.Windows.Forms.CheckBox();
            this.chkMinusculas = new System.Windows.Forms.CheckBox();
            this.chkDigitos = new System.Windows.Forms.CheckBox();
            this.chkEspeciales = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnMostrar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.numLargo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSitio
            // 
            this.lblSitio.AutoSize = true;
            this.lblSitio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSitio.ForeColor = System.Drawing.Color.White;
            this.lblSitio.Location = new System.Drawing.Point(23, 58);
            this.lblSitio.Name = "lblSitio";
            this.lblSitio.Size = new System.Drawing.Size(129, 20);
            this.lblSitio.TabIndex = 0;
            this.lblSitio.Text = "Sitio o Aplicación";
            // 
            // txtSitio
            // 
            this.txtSitio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSitio.Location = new System.Drawing.Point(172, 55);
            this.txtSitio.Name = "txtSitio";
            this.txtSitio.Size = new System.Drawing.Size(290, 26);
            this.txtSitio.TabIndex = 1;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(172, 91);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(290, 26);
            this.txtUsuario.TabIndex = 3;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(100, 94);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 20);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(172, 127);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(290, 26);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(63, 130);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(92, 20);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtNotas
            // 
            this.txtNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotas.Location = new System.Drawing.Point(172, 165);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(290, 162);
            this.txtNotas.TabIndex = 7;
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotas.ForeColor = System.Drawing.Color.White;
            this.lblNotas.Location = new System.Drawing.Point(110, 168);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(51, 20);
            this.lblNotas.TabIndex = 6;
            this.lblNotas.Text = "Notas";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.ForeColor = System.Drawing.Color.White;
            this.lblCategoria.Location = new System.Drawing.Point(75, 23);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(78, 20);
            this.lblCategoria.TabIndex = 9;
            this.lblCategoria.Text = "Categoría";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(172, 17);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(290, 28);
            this.cmbCategoria.TabIndex = 8;
            // 
            // lblAutogenerar
            // 
            this.lblAutogenerar.AutoSize = true;
            this.lblAutogenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutogenerar.ForeColor = System.Drawing.Color.White;
            this.lblAutogenerar.Location = new System.Drawing.Point(590, 25);
            this.lblAutogenerar.Name = "lblAutogenerar";
            this.lblAutogenerar.Size = new System.Drawing.Size(98, 20);
            this.lblAutogenerar.TabIndex = 10;
            this.lblAutogenerar.Text = "Autogenerar";
            // 
            // lblLargo
            // 
            this.lblLargo.AutoSize = true;
            this.lblLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLargo.ForeColor = System.Drawing.Color.White;
            this.lblLargo.Location = new System.Drawing.Point(534, 62);
            this.lblLargo.Name = "lblLargo";
            this.lblLargo.Size = new System.Drawing.Size(50, 20);
            this.lblLargo.TabIndex = 14;
            this.lblLargo.Text = "Largo";
            // 
            // numLargo
            // 
            this.numLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLargo.Location = new System.Drawing.Point(594, 56);
            this.numLargo.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numLargo.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numLargo.Name = "numLargo";
            this.numLargo.Size = new System.Drawing.Size(120, 26);
            this.numLargo.TabIndex = 16;
            this.numLargo.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkMayusculas
            // 
            this.chkMayusculas.AutoSize = true;
            this.chkMayusculas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMayusculas.ForeColor = System.Drawing.Color.White;
            this.chkMayusculas.Location = new System.Drawing.Point(594, 87);
            this.chkMayusculas.Name = "chkMayusculas";
            this.chkMayusculas.Size = new System.Drawing.Size(182, 24);
            this.chkMayusculas.TabIndex = 17;
            this.chkMayusculas.Text = "Mayúsculas (A,B,C,...)";
            this.chkMayusculas.UseVisualStyleBackColor = true;
            // 
            // chkMinusculas
            // 
            this.chkMinusculas.AutoSize = true;
            this.chkMinusculas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMinusculas.ForeColor = System.Drawing.Color.White;
            this.chkMinusculas.Location = new System.Drawing.Point(594, 110);
            this.chkMinusculas.Name = "chkMinusculas";
            this.chkMinusculas.Size = new System.Drawing.Size(171, 24);
            this.chkMinusculas.TabIndex = 18;
            this.chkMinusculas.Text = "Minúsculas (a,b,c,...)";
            this.chkMinusculas.UseVisualStyleBackColor = true;
            // 
            // chkDigitos
            // 
            this.chkDigitos.AutoSize = true;
            this.chkDigitos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDigitos.ForeColor = System.Drawing.Color.White;
            this.chkDigitos.Location = new System.Drawing.Point(594, 133);
            this.chkDigitos.Name = "chkDigitos";
            this.chkDigitos.Size = new System.Drawing.Size(142, 24);
            this.chkDigitos.TabIndex = 19;
            this.chkDigitos.Text = "Dígitos (0,1,2,...)";
            this.chkDigitos.UseVisualStyleBackColor = true;
            // 
            // chkEspeciales
            // 
            this.chkEspeciales.AutoSize = true;
            this.chkEspeciales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEspeciales.ForeColor = System.Drawing.Color.White;
            this.chkEspeciales.Location = new System.Drawing.Point(594, 156);
            this.chkEspeciales.Name = "chkEspeciales";
            this.chkEspeciales.Size = new System.Drawing.Size(160, 24);
            this.chkEspeciales.TabIndex = 20;
            this.chkEspeciales.Text = "Especiales (!,$,[,...)";
            this.chkEspeciales.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.Location = new System.Drawing.Point(641, 330);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 33);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerar.Location = new System.Drawing.Point(663, 199);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(125, 31);
            this.btnGenerar.TabIndex = 24;
            this.btnGenerar.Text = "Autogenerar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click_1);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrar.ForeColor = System.Drawing.Color.White;
            this.btnMostrar.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnMostrar.IconColor = System.Drawing.Color.White;
            this.btnMostrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrar.IconSize = 26;
            this.btnMostrar.Location = new System.Drawing.Point(468, 127);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(30, 26);
            this.btnMostrar.TabIndex = 25;
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // AgregarContrasenias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkEspeciales);
            this.Controls.Add(this.chkDigitos);
            this.Controls.Add(this.chkMinusculas);
            this.Controls.Add(this.chkMayusculas);
            this.Controls.Add(this.numLargo);
            this.Controls.Add(this.lblLargo);
            this.Controls.Add(this.lblAutogenerar);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.lblNotas);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtSitio);
            this.Controls.Add(this.lblSitio);
            this.Name = "AgregarContrasenias";
            this.Size = new System.Drawing.Size(814, 384);
            ((System.ComponentModel.ISupportInitialize)(this.numLargo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSitio;
        private System.Windows.Forms.TextBox txtSitio;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Label lblNotas;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblAutogenerar;
        private System.Windows.Forms.Label lblLargo;
        private System.Windows.Forms.NumericUpDown numLargo;
        private System.Windows.Forms.CheckBox chkMayusculas;
        private System.Windows.Forms.CheckBox chkMinusculas;
        private System.Windows.Forms.CheckBox chkDigitos;
        private System.Windows.Forms.CheckBox chkEspeciales;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnGenerar;
        private FontAwesome.Sharp.IconButton btnMostrar;
    }
}
