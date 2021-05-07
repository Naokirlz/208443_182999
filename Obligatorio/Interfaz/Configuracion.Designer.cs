
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
            this.SuspendLayout();
            // 
            // lblRepitaPassword
            // 
            this.lblRepitaPassword.AutoSize = true;
            this.lblRepitaPassword.Location = new System.Drawing.Point(89, 100);
            this.lblRepitaPassword.Name = "lblRepitaPassword";
            this.lblRepitaPassword.Size = new System.Drawing.Size(106, 13);
            this.lblRepitaPassword.TabIndex = 12;
            this.lblRepitaPassword.Text = "Repita la Contraseña";
            // 
            // txtRepetirPassword
            // 
            this.txtRepetirPassword.Location = new System.Drawing.Point(92, 116);
            this.txtRepetirPassword.Name = "txtRepetirPassword";
            this.txtRepetirPassword.PasswordChar = '*';
            this.txtRepetirPassword.Size = new System.Drawing.Size(138, 20);
            this.txtRepetirPassword.TabIndex = 11;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(89, 59);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(92, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(138, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(92, 159);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRepitaPassword);
            this.Controls.Add(this.txtRepetirPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnModificar);
            this.Name = "Configuracion";
            this.Size = new System.Drawing.Size(729, 376);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRepitaPassword;
        private System.Windows.Forms.TextBox txtRepetirPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnModificar;
    }
}
