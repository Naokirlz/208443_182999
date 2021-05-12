
namespace Interfaz
{
    partial class Configuracion
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
            this.lblRepitaPassword = new System.Windows.Forms.Label();
            this.txtRepetirPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCargarDatosPrueba = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarDatos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRepitaPassword
            // 
            this.lblRepitaPassword.AutoSize = true;
            this.lblRepitaPassword.ForeColor = System.Drawing.Color.White;
            this.lblRepitaPassword.Location = new System.Drawing.Point(38, 113);
            this.lblRepitaPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRepitaPassword.Name = "lblRepitaPassword";
            this.lblRepitaPassword.Size = new System.Drawing.Size(177, 21);
            this.lblRepitaPassword.TabIndex = 12;
            this.lblRepitaPassword.Text = "Repita la Contraseña";
            // 
            // txtRepetirPassword
            // 
            this.txtRepetirPassword.Location = new System.Drawing.Point(43, 138);
            this.txtRepetirPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtRepetirPassword.Name = "txtRepetirPassword";
            this.txtRepetirPassword.PasswordChar = '•';
            this.txtRepetirPassword.Size = new System.Drawing.Size(227, 27);
            this.txtRepetirPassword.TabIndex = 11;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(38, 46);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(103, 21);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(43, 72);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(227, 27);
            this.txtPassword.TabIndex = 9;
            // 
            // btnModificar
            // 
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnModificar.Location = new System.Drawing.Point(123, 201);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(147, 33);
            this.btnModificar.TabIndex = 45;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.lblRepitaPassword);
            this.groupBox1.Controls.Add(this.txtRepetirPassword);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(49, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 271);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cambio de Contraseña Maestra";
            // 
            // btnCargarDatosPrueba
            // 
            this.btnCargarDatosPrueba.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarDatosPrueba.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarDatosPrueba.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarDatosPrueba.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCargarDatosPrueba.Location = new System.Drawing.Point(86, 69);
            this.btnCargarDatosPrueba.Name = "btnCargarDatosPrueba";
            this.btnCargarDatosPrueba.Size = new System.Drawing.Size(147, 33);
            this.btnCargarDatosPrueba.TabIndex = 46;
            this.btnCargarDatosPrueba.Text = "Cargar";
            this.btnCargarDatosPrueba.UseVisualStyleBackColor = true;
            this.btnCargarDatosPrueba.Click += new System.EventHandler(this.btnCargarDatosPrueba_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminarDatos);
            this.groupBox2.Controls.Add(this.btnCargarDatosPrueba);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(452, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 270);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Prueba";
            // 
            // btnEliminarDatos
            // 
            this.btnEliminarDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDatos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarDatos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnEliminarDatos.Location = new System.Drawing.Point(86, 122);
            this.btnEliminarDatos.Name = "btnEliminarDatos";
            this.btnEliminarDatos.Size = new System.Drawing.Size(147, 33);
            this.btnEliminarDatos.TabIndex = 47;
            this.btnEliminarDatos.Text = "Eliminar Datos";
            this.btnEliminarDatos.UseVisualStyleBackColor = true;
            this.btnEliminarDatos.Click += new System.EventHandler(this.btnEliminarDatos_Click);
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Configuracion";
            this.Size = new System.Drawing.Size(814, 517);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRepitaPassword;
        private System.Windows.Forms.TextBox txtRepetirPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCargarDatosPrueba;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminarDatos;
    }
}
