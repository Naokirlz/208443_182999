
namespace Interfaz.Login
{
    partial class RegistroPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroPassword));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.imgIconoCentral = new System.Windows.Forms.PictureBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.icoPassword = new FontAwesome.Sharp.IconButton();
            this.pnlRepetirPassword = new System.Windows.Forms.Panel();
            this.txtRepetirPassword = new System.Windows.Forms.TextBox();
            this.icoRepetirPassword = new FontAwesome.Sharp.IconButton();
            this.lblVolver = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgIconoCentral)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(15, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Registrar Contraseña Maestra";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCerrar.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 15;
            this.btnCerrar.Location = new System.Drawing.Point(312, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(26, 23);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // imgIconoCentral
            // 
            this.imgIconoCentral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgIconoCentral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgIconoCentral.BackgroundImage")));
            this.imgIconoCentral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgIconoCentral.Location = new System.Drawing.Point(12, 444);
            this.imgIconoCentral.Name = "imgIconoCentral";
            this.imgIconoCentral.Size = new System.Drawing.Size(316, 76);
            this.imgIconoCentral.TabIndex = 10;
            this.imgIconoCentral.TabStop = false;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegistrar.Location = new System.Drawing.Point(89, 325);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(147, 46);
            this.btnRegistrar.TabIndex = 11;
            this.btnRegistrar.Text = "Guardar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.DarkGray;
            this.pnlLinea.Location = new System.Drawing.Point(39, 184);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(262, 3);
            this.pnlLinea.TabIndex = 14;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPassword.HideSelection = false;
            this.txtPassword.Location = new System.Drawing.Point(83, 157);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(205, 22);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.Text = "Contraseña";
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            this.txtPassword.MouseLeave += new System.EventHandler(this.txtPassword_MouseLeave);
            this.txtPassword.MouseHover += new System.EventHandler(this.txtPassword_MouseHover);
            // 
            // icoPassword
            // 
            this.icoPassword.FlatAppearance.BorderSize = 0;
            this.icoPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icoPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.icoPassword.IconChar = FontAwesome.Sharp.IconChar.UnlockAlt;
            this.icoPassword.IconColor = System.Drawing.Color.DarkGray;
            this.icoPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoPassword.IconSize = 30;
            this.icoPassword.Location = new System.Drawing.Point(27, 152);
            this.icoPassword.Name = "icoPassword";
            this.icoPassword.Size = new System.Drawing.Size(47, 38);
            this.icoPassword.TabIndex = 12;
            this.icoPassword.TabStop = false;
            this.icoPassword.UseVisualStyleBackColor = true;
            this.icoPassword.Click += new System.EventHandler(this.icoPassword_Click);
            this.icoPassword.MouseLeave += new System.EventHandler(this.icoPassword_MouseLeave);
            this.icoPassword.MouseHover += new System.EventHandler(this.icoPassword_MouseHover);
            // 
            // pnlRepetirPassword
            // 
            this.pnlRepetirPassword.BackColor = System.Drawing.Color.DarkGray;
            this.pnlRepetirPassword.Location = new System.Drawing.Point(38, 251);
            this.pnlRepetirPassword.Name = "pnlRepetirPassword";
            this.pnlRepetirPassword.Size = new System.Drawing.Size(262, 3);
            this.pnlRepetirPassword.TabIndex = 17;
            // 
            // txtRepetirPassword
            // 
            this.txtRepetirPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.txtRepetirPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepetirPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepetirPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.txtRepetirPassword.HideSelection = false;
            this.txtRepetirPassword.Location = new System.Drawing.Point(82, 224);
            this.txtRepetirPassword.Name = "txtRepetirPassword";
            this.txtRepetirPassword.Size = new System.Drawing.Size(205, 22);
            this.txtRepetirPassword.TabIndex = 16;
            this.txtRepetirPassword.Text = "Repetir Contraseña";
            this.txtRepetirPassword.Click += new System.EventHandler(this.txtRepetirPassword_Click);
            this.txtRepetirPassword.TextChanged += new System.EventHandler(this.txtRepetirPassword_TextChanged);
            this.txtRepetirPassword.Enter += new System.EventHandler(this.txtRepetirPassword_Enter);
            this.txtRepetirPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepetirPassword_KeyDown);
            this.txtRepetirPassword.Leave += new System.EventHandler(this.txtRepetirPassword_Leave);
            this.txtRepetirPassword.MouseLeave += new System.EventHandler(this.txtRepetirPassword_MouseLeave);
            this.txtRepetirPassword.MouseHover += new System.EventHandler(this.txtRepetirPassword_MouseHover);
            // 
            // icoRepetirPassword
            // 
            this.icoRepetirPassword.FlatAppearance.BorderSize = 0;
            this.icoRepetirPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icoRepetirPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.icoRepetirPassword.IconChar = FontAwesome.Sharp.IconChar.UnlockAlt;
            this.icoRepetirPassword.IconColor = System.Drawing.Color.DarkGray;
            this.icoRepetirPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoRepetirPassword.IconSize = 30;
            this.icoRepetirPassword.Location = new System.Drawing.Point(26, 219);
            this.icoRepetirPassword.Name = "icoRepetirPassword";
            this.icoRepetirPassword.Size = new System.Drawing.Size(47, 38);
            this.icoRepetirPassword.TabIndex = 15;
            this.icoRepetirPassword.TabStop = false;
            this.icoRepetirPassword.UseVisualStyleBackColor = true;
            this.icoRepetirPassword.Click += new System.EventHandler(this.icoRepetirPassword_Click);
            this.icoRepetirPassword.MouseLeave += new System.EventHandler(this.icoRepetirPassword_MouseLeave);
            this.icoRepetirPassword.MouseHover += new System.EventHandler(this.icoRepetirPassword_MouseHover);
            // 
            // lblVolver
            // 
            this.lblVolver.AutoSize = true;
            this.lblVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblVolver.ForeColor = System.Drawing.Color.White;
            this.lblVolver.Location = new System.Drawing.Point(130, 384);
            this.lblVolver.Name = "lblVolver";
            this.lblVolver.Size = new System.Drawing.Size(53, 20);
            this.lblVolver.TabIndex = 18;
            this.lblVolver.Text = "Volver";
            this.lblVolver.Click += new System.EventHandler(this.lblVolver_Click);
            // 
            // RegistroPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(340, 530);
            this.Controls.Add(this.lblVolver);
            this.Controls.Add(this.pnlRepetirPassword);
            this.Controls.Add(this.txtRepetirPassword);
            this.Controls.Add(this.icoRepetirPassword);
            this.Controls.Add(this.pnlLinea);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.icoPassword);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.imgIconoCentral);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(340, 530);
            this.MinimumSize = new System.Drawing.Size(340, 530);
            this.Name = "RegistroPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registo de Contraseña";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.imgIconoCentral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.PictureBox imgIconoCentral;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.TextBox txtPassword;
        private FontAwesome.Sharp.IconButton icoPassword;
        private System.Windows.Forms.Panel pnlRepetirPassword;
        private System.Windows.Forms.TextBox txtRepetirPassword;
        private FontAwesome.Sharp.IconButton icoRepetirPassword;
        private System.Windows.Forms.Label lblVolver;
    }
}