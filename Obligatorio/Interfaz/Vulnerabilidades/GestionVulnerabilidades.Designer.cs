
namespace Interfaz.Vulnerabilidades
{
    partial class GestionVulnerabilidades
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
            this.pnlGestor = new System.Windows.Forms.Panel();
            this.btnResumen = new FontAwesome.Sharp.IconButton();
            this.btnFuenteLocal = new FontAwesome.Sharp.IconButton();
            this.btnCargarFuente = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // pnlGestor
            // 
            this.pnlGestor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGestor.Location = new System.Drawing.Point(0, 146);
            this.pnlGestor.Margin = new System.Windows.Forms.Padding(5);
            this.pnlGestor.Name = "pnlGestor";
            this.pnlGestor.Size = new System.Drawing.Size(814, 371);
            this.pnlGestor.TabIndex = 2;
            // 
            // btnResumen
            // 
            this.btnResumen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnResumen.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnResumen.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnResumen.IconColor = System.Drawing.Color.Gainsboro;
            this.btnResumen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnResumen.Location = new System.Drawing.Point(45, 32);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.Size = new System.Drawing.Size(104, 84);
            this.btnResumen.TabIndex = 13;
            this.btnResumen.Text = "Resumen";
            this.btnResumen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnResumen.UseVisualStyleBackColor = true;
            this.btnResumen.Click += new System.EventHandler(this.btnResumenVulnerabilidades_Click);
            // 
            // btnFuenteLocal
            // 
            this.btnFuenteLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFuenteLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFuenteLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuenteLocal.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFuenteLocal.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.btnFuenteLocal.IconColor = System.Drawing.Color.Gainsboro;
            this.btnFuenteLocal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFuenteLocal.Location = new System.Drawing.Point(203, 32);
            this.btnFuenteLocal.Name = "btnFuenteLocal";
            this.btnFuenteLocal.Size = new System.Drawing.Size(104, 84);
            this.btnFuenteLocal.TabIndex = 14;
            this.btnFuenteLocal.Text = "Fuente Local";
            this.btnFuenteLocal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFuenteLocal.UseVisualStyleBackColor = true;
            this.btnFuenteLocal.Click += new System.EventHandler(this.btnModificarFuenteLocal_Click);
            // 
            // btnCargarFuente
            // 
            this.btnCargarFuente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarFuente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarFuente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarFuente.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCargarFuente.IconChar = FontAwesome.Sharp.IconChar.FileAlt;
            this.btnCargarFuente.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCargarFuente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCargarFuente.Location = new System.Drawing.Point(364, 32);
            this.btnCargarFuente.Name = "btnCargarFuente";
            this.btnCargarFuente.Size = new System.Drawing.Size(104, 84);
            this.btnCargarFuente.TabIndex = 15;
            this.btnCargarFuente.Text = "Cargar Fuente";
            this.btnCargarFuente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCargarFuente.UseVisualStyleBackColor = true;
            this.btnCargarFuente.Click += new System.EventHandler(this.btnCargarFuente_Click);
            // 
            // GestionVulnerabilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.btnCargarFuente);
            this.Controls.Add(this.btnFuenteLocal);
            this.Controls.Add(this.btnResumen);
            this.Controls.Add(this.pnlGestor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "GestionVulnerabilidades";
            this.Size = new System.Drawing.Size(814, 517);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGestor;
        private FontAwesome.Sharp.IconButton btnResumen;
        private FontAwesome.Sharp.IconButton btnFuenteLocal;
        private FontAwesome.Sharp.IconButton btnCargarFuente;
    }
}
