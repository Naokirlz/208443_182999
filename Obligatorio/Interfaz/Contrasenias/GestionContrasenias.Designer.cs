﻿
namespace Interfaz.Contrasenias
{
    partial class GestionContrasenias
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
            this.btnAgregarContrasenia = new System.Windows.Forms.Button();
            this.btnModificarContrasenias = new System.Windows.Forms.Button();
            this.btnEliminarContrasenias = new System.Windows.Forms.Button();
            this.btnResumenContrasenias = new System.Windows.Forms.Button();
            this.btnReporteFortaleza = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlGestor
            // 
            this.pnlGestor.Location = new System.Drawing.Point(186, 10);
            this.pnlGestor.Name = "pnlGestor";
            this.pnlGestor.Size = new System.Drawing.Size(471, 322);
            this.pnlGestor.TabIndex = 0;
            // 
            // btnAgregarContrasenia
            // 
            this.btnAgregarContrasenia.Location = new System.Drawing.Point(0, 67);
            this.btnAgregarContrasenia.Name = "btnAgregarContrasenia";
            this.btnAgregarContrasenia.Size = new System.Drawing.Size(185, 23);
            this.btnAgregarContrasenia.TabIndex = 3;
            this.btnAgregarContrasenia.Text = "Agregar Contraseña";
            this.btnAgregarContrasenia.UseVisualStyleBackColor = true;
            this.btnAgregarContrasenia.Click += new System.EventHandler(this.btnAgregarTarjeta_Click);
            // 
            // btnModificarContrasenias
            // 
            this.btnModificarContrasenias.Location = new System.Drawing.Point(0, 96);
            this.btnModificarContrasenias.Name = "btnModificarContrasenias";
            this.btnModificarContrasenias.Size = new System.Drawing.Size(185, 23);
            this.btnModificarContrasenias.TabIndex = 4;
            this.btnModificarContrasenias.Text = "Modificar Contraseña";
            this.btnModificarContrasenias.UseVisualStyleBackColor = true;
            this.btnModificarContrasenias.Click += new System.EventHandler(this.btnModificarContrasenias_Click);
            // 
            // btnEliminarContrasenias
            // 
            this.btnEliminarContrasenias.Location = new System.Drawing.Point(0, 125);
            this.btnEliminarContrasenias.Name = "btnEliminarContrasenias";
            this.btnEliminarContrasenias.Size = new System.Drawing.Size(185, 23);
            this.btnEliminarContrasenias.TabIndex = 5;
            this.btnEliminarContrasenias.Text = "Eliminar Contraseña";
            this.btnEliminarContrasenias.UseVisualStyleBackColor = true;
            this.btnEliminarContrasenias.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnResumenContrasenias
            // 
            this.btnResumenContrasenias.Location = new System.Drawing.Point(0, 38);
            this.btnResumenContrasenias.Name = "btnResumenContrasenias";
            this.btnResumenContrasenias.Size = new System.Drawing.Size(185, 23);
            this.btnResumenContrasenias.TabIndex = 6;
            this.btnResumenContrasenias.Text = "Resumen";
            this.btnResumenContrasenias.UseVisualStyleBackColor = true;
            this.btnResumenContrasenias.Click += new System.EventHandler(this.btnResumenContrasenias_Click);
            // 
            // btnReporteFortaleza
            // 
            this.btnReporteFortaleza.Location = new System.Drawing.Point(0, 154);
            this.btnReporteFortaleza.Name = "btnReporteFortaleza";
            this.btnReporteFortaleza.Size = new System.Drawing.Size(185, 23);
            this.btnReporteFortaleza.TabIndex = 7;
            this.btnReporteFortaleza.Text = "Reporte de Fortalezas";
            this.btnReporteFortaleza.UseVisualStyleBackColor = true;
            this.btnReporteFortaleza.Click += new System.EventHandler(this.btnReporteFortaleza_Click);
            // 
            // GestionContrasenias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReporteFortaleza);
            this.Controls.Add(this.btnResumenContrasenias);
            this.Controls.Add(this.btnEliminarContrasenias);
            this.Controls.Add(this.btnModificarContrasenias);
            this.Controls.Add(this.btnAgregarContrasenia);
            this.Controls.Add(this.pnlGestor);
            this.Name = "GestionContrasenias";
            this.Size = new System.Drawing.Size(668, 346);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGestor;
        private System.Windows.Forms.Button btnAgregarContrasenia;
        private System.Windows.Forms.Button btnModificarContrasenias;
        private System.Windows.Forms.Button btnEliminarContrasenias;
        private System.Windows.Forms.Button btnResumenContrasenias;
        private System.Windows.Forms.Button btnReporteFortaleza;
    }
}
