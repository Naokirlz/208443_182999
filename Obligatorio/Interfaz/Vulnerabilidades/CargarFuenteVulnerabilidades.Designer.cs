
namespace Interfaz.Vulnerabilidades
{
    partial class CargarFuenteVulnerabilidades
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
            this.ofdSeleccionarArchivo = new System.Windows.Forms.OpenFileDialog();
            this.btnAbrir = new FontAwesome.Sharp.IconButton();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.btnSeleccionarArchivo = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // ofdSeleccionarArchivo
            // 
            this.ofdSeleccionarArchivo.FileName = "ArchivoSeleccionado";
            this.ofdSeleccionarArchivo.Filter = "Archivos de texto (*.txt)|*.txt";
            // 
            // btnAbrir
            // 
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrir.ForeColor = System.Drawing.Color.White;
            this.btnAbrir.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnAbrir.IconColor = System.Drawing.Color.White;
            this.btnAbrir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAbrir.IconSize = 30;
            this.btnAbrir.Location = new System.Drawing.Point(589, 313);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(185, 41);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Subir Archivo";
            this.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Location = new System.Drawing.Point(79, 78);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(662, 26);
            this.txtRutaArchivo.TabIndex = 1;
            // 
            // btnSeleccionarArchivo
            // 
            this.btnSeleccionarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarArchivo.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarArchivo.IconChar = FontAwesome.Sharp.IconChar.FileAlt;
            this.btnSeleccionarArchivo.IconColor = System.Drawing.Color.White;
            this.btnSeleccionarArchivo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSeleccionarArchivo.IconSize = 25;
            this.btnSeleccionarArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarArchivo.Location = new System.Drawing.Point(608, 110);
            this.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            this.btnSeleccionarArchivo.Size = new System.Drawing.Size(133, 38);
            this.btnSeleccionarArchivo.TabIndex = 2;
            this.btnSeleccionarArchivo.Text = "Seleccionar";
            this.btnSeleccionarArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.btnSeleccionarArchivo.Click += new System.EventHandler(this.btnSeleccionarArchivo_Click);
            // 
            // CargarFuenteVulnerabilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.btnSeleccionarArchivo);
            this.Controls.Add(this.txtRutaArchivo);
            this.Controls.Add(this.btnAbrir);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CargarFuenteVulnerabilidades";
            this.Size = new System.Drawing.Size(814, 387);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdSeleccionarArchivo;
        private FontAwesome.Sharp.IconButton btnAbrir;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private FontAwesome.Sharp.IconButton btnSeleccionarArchivo;
    }
}
