
namespace Interfaz
{
    partial class InicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioSesion));
            this.imgIconoCentral = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.icoPassword = new FontAwesome.Sharp.IconButton();
            this.txtIngresar = new System.Windows.Forms.TextBox();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgIconoCentral)).BeginInit();
            this.SuspendLayout();
            // 
            // imgIconoCentral
            // 
            this.imgIconoCentral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgIconoCentral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgIconoCentral.BackgroundImage")));
            this.imgIconoCentral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgIconoCentral.Location = new System.Drawing.Point(13, 444);
            this.imgIconoCentral.Name = "imgIconoCentral";
            this.imgIconoCentral.Size = new System.Drawing.Size(316, 76);
            this.imgIconoCentral.TabIndex = 2;
            this.imgIconoCentral.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(78, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inicio de Sesión";
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
            this.icoPassword.Location = new System.Drawing.Point(29, 222);
            this.icoPassword.Name = "icoPassword";
            this.icoPassword.Size = new System.Drawing.Size(47, 38);
            this.icoPassword.TabIndex = 4;
            this.icoPassword.UseVisualStyleBackColor = true;
            this.icoPassword.Click += new System.EventHandler(this.icoPassword_Click);
            this.icoPassword.MouseLeave += new System.EventHandler(this.icoPassword_MouseLeave);
            this.icoPassword.MouseHover += new System.EventHandler(this.icoPassword_MouseHover);
            // 
            // txtIngresar
            // 
            this.txtIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtIngresar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIngresar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngresar.ForeColor = System.Drawing.Color.DarkGray;
            this.txtIngresar.HideSelection = false;
            this.txtIngresar.Location = new System.Drawing.Point(85, 227);
            this.txtIngresar.Name = "txtIngresar";
            this.txtIngresar.Size = new System.Drawing.Size(205, 24);
            this.txtIngresar.TabIndex = 5;
            this.txtIngresar.TabStop = false;
            this.txtIngresar.Text = "Contraseña";
            this.txtIngresar.Click += new System.EventHandler(this.txtIngresar_Click);
            this.txtIngresar.TextChanged += new System.EventHandler(this.txtIngresar_TextChanged);
            this.txtIngresar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIngresar_KeyDown);
            this.txtIngresar.Leave += new System.EventHandler(this.txtIngresar_Leave);
            this.txtIngresar.MouseLeave += new System.EventHandler(this.txtIngresar_MouseLeave);
            this.txtIngresar.MouseHover += new System.EventHandler(this.txtIngresar_MouseHover);
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.DarkGray;
            this.pnlLinea.Location = new System.Drawing.Point(41, 254);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(262, 3);
            this.pnlLinea.TabIndex = 6;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnIngresar.Location = new System.Drawing.Point(95, 320);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(147, 46);
            this.btnIngresar.TabIndex = 7;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
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
            this.btnCerrar.Location = new System.Drawing.Point(313, 1);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(26, 23);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // InicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(340, 530);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.pnlLinea);
            this.Controls.Add(this.txtIngresar);
            this.Controls.Add(this.icoPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgIconoCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(340, 530);
            this.MinimumSize = new System.Drawing.Size(340, 530);
            this.Name = "InicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesion";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InicioSesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgIconoCentral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgIconoCentral;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton icoPassword;
        private System.Windows.Forms.TextBox txtIngresar;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Button btnIngresar;
        private FontAwesome.Sharp.IconButton btnCerrar;
    }
}