
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
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numLargo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSitio
            // 
            this.lblSitio.AutoSize = true;
            this.lblSitio.Location = new System.Drawing.Point(23, 85);
            this.lblSitio.Name = "lblSitio";
            this.lblSitio.Size = new System.Drawing.Size(27, 13);
            this.lblSitio.TabIndex = 0;
            this.lblSitio.Text = "Sitio";
            // 
            // txtSitio
            // 
            this.txtSitio.Location = new System.Drawing.Point(95, 78);
            this.txtSitio.Name = "txtSitio";
            this.txtSitio.Size = new System.Drawing.Size(141, 20);
            this.txtSitio.TabIndex = 1;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(95, 104);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(141, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(23, 111);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(327, 51);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(141, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(255, 58);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(95, 130);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(141, 113);
            this.txtNotas.TabIndex = 7;
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.Location = new System.Drawing.Point(23, 137);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(35, 13);
            this.lblNotas.TabIndex = 6;
            this.lblNotas.Text = "Notas";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(23, 59);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(54, 13);
            this.lblCategoria.TabIndex = 9;
            this.lblCategoria.Text = "Categoría";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(95, 51);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(141, 21);
            this.cmbCategoria.TabIndex = 8;
            // 
            // lblAutogenerar
            // 
            this.lblAutogenerar.AutoSize = true;
            this.lblAutogenerar.Location = new System.Drawing.Point(324, 81);
            this.lblAutogenerar.Name = "lblAutogenerar";
            this.lblAutogenerar.Size = new System.Drawing.Size(65, 13);
            this.lblAutogenerar.TabIndex = 10;
            this.lblAutogenerar.Text = "Autogenerar";
            // 
            // lblLargo
            // 
            this.lblLargo.AutoSize = true;
            this.lblLargo.Location = new System.Drawing.Point(256, 103);
            this.lblLargo.Name = "lblLargo";
            this.lblLargo.Size = new System.Drawing.Size(34, 13);
            this.lblLargo.TabIndex = 14;
            this.lblLargo.Text = "Largo";
            // 
            // numLargo
            // 
            this.numLargo.Location = new System.Drawing.Point(313, 99);
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
            this.numLargo.Size = new System.Drawing.Size(120, 20);
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
            this.chkMayusculas.Location = new System.Drawing.Point(281, 125);
            this.chkMayusculas.Name = "chkMayusculas";
            this.chkMayusculas.Size = new System.Drawing.Size(130, 17);
            this.chkMayusculas.TabIndex = 17;
            this.chkMayusculas.Text = "Mayúsculas (A,B,C,...)";
            this.chkMayusculas.UseVisualStyleBackColor = true;
            // 
            // chkMinusculas
            // 
            this.chkMinusculas.AutoSize = true;
            this.chkMinusculas.Location = new System.Drawing.Point(281, 148);
            this.chkMinusculas.Name = "chkMinusculas";
            this.chkMinusculas.Size = new System.Drawing.Size(124, 17);
            this.chkMinusculas.TabIndex = 18;
            this.chkMinusculas.Text = "Minúsculas (a,b,c,...)";
            this.chkMinusculas.UseVisualStyleBackColor = true;
            // 
            // chkDigitos
            // 
            this.chkDigitos.AutoSize = true;
            this.chkDigitos.Location = new System.Drawing.Point(281, 171);
            this.chkDigitos.Name = "chkDigitos";
            this.chkDigitos.Size = new System.Drawing.Size(105, 17);
            this.chkDigitos.TabIndex = 19;
            this.chkDigitos.Text = "Dígitos (0,1,2,...)";
            this.chkDigitos.UseVisualStyleBackColor = true;
            // 
            // chkEspeciales
            // 
            this.chkEspeciales.AutoSize = true;
            this.chkEspeciales.Location = new System.Drawing.Point(281, 194);
            this.chkEspeciales.Name = "chkEspeciales";
            this.chkEspeciales.Size = new System.Drawing.Size(116, 17);
            this.chkEspeciales.TabIndex = 20;
            this.chkEspeciales.Text = "Especiales (!,$,[,...)";
            this.chkEspeciales.UseVisualStyleBackColor = true;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(380, 220);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 21;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(358, 279);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // AgregarContrasenias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnGenerar);
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
            this.Size = new System.Drawing.Size(471, 322);
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
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
