namespace SLD.FORM
{
    partial class frmBase
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
            this.btnEjemploProblema = new System.Windows.Forms.Button();
            this.btnEjemploSolucion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEjemploProblema
            // 
            this.btnEjemploProblema.Location = new System.Drawing.Point(19, 36);
            this.btnEjemploProblema.Name = "btnEjemploProblema";
            this.btnEjemploProblema.Size = new System.Drawing.Size(140, 48);
            this.btnEjemploProblema.TabIndex = 0;
            this.btnEjemploProblema.Text = "Ejemplo problema";
            this.btnEjemploProblema.UseVisualStyleBackColor = true;
            this.btnEjemploProblema.Click += new System.EventHandler(this.btnEjemploProblema_Click);
            // 
            // btnEjemploSolucion
            // 
            this.btnEjemploSolucion.Location = new System.Drawing.Point(208, 36);
            this.btnEjemploSolucion.Name = "btnEjemploSolucion";
            this.btnEjemploSolucion.Size = new System.Drawing.Size(140, 48);
            this.btnEjemploSolucion.TabIndex = 1;
            this.btnEjemploSolucion.Text = "ejemplo solucion";
            this.btnEjemploSolucion.UseVisualStyleBackColor = true;
            this.btnEjemploSolucion.Click += new System.EventHandler(this.btnEjemploSolucion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEjemploProblema);
            this.groupBox1.Controls.Add(this.btnEjemploSolucion);
            this.groupBox1.Location = new System.Drawing.Point(22, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 132);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ejemplos SOLID \"ABIERTO/CERRADO\"";
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 191);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBase";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEjemploProblema;
        private System.Windows.Forms.Button btnEjemploSolucion;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}