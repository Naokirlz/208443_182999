
namespace Interfaz.Contrasenias
{
    partial class ModificarContrasenias
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
            this.chkEspeciales = new System.Windows.Forms.CheckBox();
            this.chkDigitos = new System.Windows.Forms.CheckBox();
            this.chkMinusculas = new System.Windows.Forms.CheckBox();
            this.chkMayusculas = new System.Windows.Forms.CheckBox();
            this.numLargo = new System.Windows.Forms.NumericUpDown();
            this.lblLargo = new System.Windows.Forms.Label();
            this.lblAutogenerar = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.lblNotas = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtSitio = new System.Windows.Forms.TextBox();
            this.lblSitio = new System.Windows.Forms.Label();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.cmbContrasenia = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numLargo)).BeginInit();
            this.SuspendLayout();
            // 
            // chkEspeciales
            // 
            this.chkEspeciales.AutoSize = true;
            this.chkEspeciales.ForeColor = System.Drawing.Color.White;
            this.chkEspeciales.Location = new System.Drawing.Point(550, 218);
            this.chkEspeciales.Margin = new System.Windows.Forms.Padding(5);
            this.chkEspeciales.Name = "chkEspeciales";
            this.chkEspeciales.Size = new System.Drawing.Size(167, 25);
            this.chkEspeciales.TabIndex = 39;
            this.chkEspeciales.Text = "Especiales (!,$,[,...)";
            this.chkEspeciales.UseVisualStyleBackColor = true;
            // 
            // chkDigitos
            // 
            this.chkDigitos.AutoSize = true;
            this.chkDigitos.ForeColor = System.Drawing.Color.White;
            this.chkDigitos.Location = new System.Drawing.Point(550, 181);
            this.chkDigitos.Margin = new System.Windows.Forms.Padding(5);
            this.chkDigitos.Name = "chkDigitos";
            this.chkDigitos.Size = new System.Drawing.Size(148, 25);
            this.chkDigitos.TabIndex = 38;
            this.chkDigitos.Text = "Dígitos (0,1,2,...)";
            this.chkDigitos.UseVisualStyleBackColor = true;
            // 
            // chkMinusculas
            // 
            this.chkMinusculas.AutoSize = true;
            this.chkMinusculas.ForeColor = System.Drawing.Color.White;
            this.chkMinusculas.Location = new System.Drawing.Point(550, 144);
            this.chkMinusculas.Margin = new System.Windows.Forms.Padding(5);
            this.chkMinusculas.Name = "chkMinusculas";
            this.chkMinusculas.Size = new System.Drawing.Size(185, 25);
            this.chkMinusculas.TabIndex = 37;
            this.chkMinusculas.Text = "Minúsculas (a,b,c,...)";
            this.chkMinusculas.UseVisualStyleBackColor = true;
            // 
            // chkMayusculas
            // 
            this.chkMayusculas.AutoSize = true;
            this.chkMayusculas.ForeColor = System.Drawing.Color.White;
            this.chkMayusculas.Location = new System.Drawing.Point(550, 107);
            this.chkMayusculas.Margin = new System.Windows.Forms.Padding(5);
            this.chkMayusculas.Name = "chkMayusculas";
            this.chkMayusculas.Size = new System.Drawing.Size(194, 25);
            this.chkMayusculas.TabIndex = 36;
            this.chkMayusculas.Text = "Mayúsculas (A,B,C,...)";
            this.chkMayusculas.UseVisualStyleBackColor = true;
            // 
            // numLargo
            // 
            this.numLargo.Location = new System.Drawing.Point(660, 57);
            this.numLargo.Margin = new System.Windows.Forms.Padding(5);
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
            this.numLargo.Size = new System.Drawing.Size(42, 27);
            this.numLargo.TabIndex = 35;
            this.numLargo.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblLargo
            // 
            this.lblLargo.AutoSize = true;
            this.lblLargo.ForeColor = System.Drawing.Color.White;
            this.lblLargo.Location = new System.Drawing.Point(563, 63);
            this.lblLargo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLargo.Name = "lblLargo";
            this.lblLargo.Size = new System.Drawing.Size(54, 21);
            this.lblLargo.TabIndex = 34;
            this.lblLargo.Text = "Largo";
            // 
            // lblAutogenerar
            // 
            this.lblAutogenerar.AutoSize = true;
            this.lblAutogenerar.ForeColor = System.Drawing.Color.White;
            this.lblAutogenerar.Location = new System.Drawing.Point(578, 23);
            this.lblAutogenerar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAutogenerar.Name = "lblAutogenerar";
            this.lblAutogenerar.Size = new System.Drawing.Size(112, 21);
            this.lblAutogenerar.TabIndex = 33;
            this.lblAutogenerar.Text = "Autogenerar";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.ForeColor = System.Drawing.Color.White;
            this.lblCategoria.Location = new System.Drawing.Point(59, 57);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(91, 21);
            this.lblCategoria.TabIndex = 32;
            this.lblCategoria.Text = "Categoría";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(160, 54);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(5);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(232, 29);
            this.cmbCategoria.TabIndex = 31;
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(160, 204);
            this.txtNotas.Margin = new System.Windows.Forms.Padding(5);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(232, 163);
            this.txtNotas.TabIndex = 30;
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.ForeColor = System.Drawing.Color.White;
            this.lblNotas.Location = new System.Drawing.Point(94, 207);
            this.lblNotas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(56, 21);
            this.lblNotas.TabIndex = 29;
            this.lblNotas.Text = "Notas";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(160, 167);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(232, 27);
            this.txtPassword.TabIndex = 28;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(47, 171);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(103, 21);
            this.lblPassword.TabIndex = 27;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(160, 130);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(5);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(232, 27);
            this.txtUsuario.TabIndex = 26;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(84, 133);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(66, 21);
            this.lblUsuario.TabIndex = 25;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtSitio
            // 
            this.txtSitio.Location = new System.Drawing.Point(158, 93);
            this.txtSitio.Margin = new System.Windows.Forms.Padding(5);
            this.txtSitio.Name = "txtSitio";
            this.txtSitio.Size = new System.Drawing.Size(232, 27);
            this.txtSitio.TabIndex = 24;
            // 
            // lblSitio
            // 
            this.lblSitio.AutoSize = true;
            this.lblSitio.ForeColor = System.Drawing.Color.White;
            this.lblSitio.Location = new System.Drawing.Point(7, 99);
            this.lblSitio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSitio.Name = "lblSitio";
            this.lblSitio.Size = new System.Drawing.Size(143, 21);
            this.lblSitio.TabIndex = 23;
            this.lblSitio.Text = "Sitio o Aplicación";
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.ForeColor = System.Drawing.Color.White;
            this.lblContrasenia.Location = new System.Drawing.Point(44, 18);
            this.lblContrasenia.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(106, 21);
            this.lblContrasenia.TabIndex = 43;
            this.lblContrasenia.Text = "Contrasenia";
            // 
            // cmbContrasenia
            // 
            this.cmbContrasenia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContrasenia.FormattingEnabled = true;
            this.cmbContrasenia.Location = new System.Drawing.Point(160, 15);
            this.cmbContrasenia.Margin = new System.Windows.Forms.Padding(5);
            this.cmbContrasenia.Name = "cmbContrasenia";
            this.cmbContrasenia.Size = new System.Drawing.Size(232, 29);
            this.cmbContrasenia.TabIndex = 42;
            this.cmbContrasenia.SelectedIndexChanged += new System.EventHandler(this.cmbContrasenia_SelectedIndexChanged);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerar.Location = new System.Drawing.Point(582, 251);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(125, 31);
            this.btnGenerar.TabIndex = 44;
            this.btnGenerar.Text = "Autogenerar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.Location = new System.Drawing.Point(648, 334);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 33);
            this.btnGuardar.TabIndex = 45;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ModificarContrasenias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.lblContrasenia);
            this.Controls.Add(this.cmbContrasenia);
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
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ModificarContrasenias";
            this.Size = new System.Drawing.Size(814, 384);
            ((System.ComponentModel.ISupportInitialize)(this.numLargo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkEspeciales;
        private System.Windows.Forms.CheckBox chkDigitos;
        private System.Windows.Forms.CheckBox chkMinusculas;
        private System.Windows.Forms.CheckBox chkMayusculas;
        private System.Windows.Forms.NumericUpDown numLargo;
        private System.Windows.Forms.Label lblLargo;
        private System.Windows.Forms.Label lblAutogenerar;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Label lblNotas;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtSitio;
        private System.Windows.Forms.Label lblSitio;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.ComboBox cmbContrasenia;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
