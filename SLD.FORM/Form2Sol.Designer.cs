namespace SLD.FORM
{
    partial class Form2Sol
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnRegistrarProveedor = new System.Windows.Forms.Button();
            this.btnRegistrarPrecioBase = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvProductos);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(891, 379);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Productos";
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(15, 36);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(860, 326);
            this.dgvProductos.TabIndex = 2;
            // 
            // btnRegistrarProveedor
            // 
            this.btnRegistrarProveedor.Location = new System.Drawing.Point(322, 413);
            this.btnRegistrarProveedor.Name = "btnRegistrarProveedor";
            this.btnRegistrarProveedor.Size = new System.Drawing.Size(129, 30);
            this.btnRegistrarProveedor.TabIndex = 9;
            this.btnRegistrarProveedor.Text = "Registrar proveedor";
            this.btnRegistrarProveedor.UseVisualStyleBackColor = true;
            this.btnRegistrarProveedor.Click += new System.EventHandler(this.btnRegistrarProveedor_Click);
            // 
            // btnRegistrarPrecioBase
            // 
            this.btnRegistrarPrecioBase.Location = new System.Drawing.Point(188, 413);
            this.btnRegistrarPrecioBase.Name = "btnRegistrarPrecioBase";
            this.btnRegistrarPrecioBase.Size = new System.Drawing.Size(119, 30);
            this.btnRegistrarPrecioBase.TabIndex = 8;
            this.btnRegistrarPrecioBase.Text = "Registrar precio base";
            this.btnRegistrarPrecioBase.UseVisualStyleBackColor = true;
            this.btnRegistrarPrecioBase.Click += new System.EventHandler(this.btnRegistrarPrecioBase_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(62, 413);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(111, 30);
            this.btnRegistrar.TabIndex = 7;
            this.btnRegistrar.Text = "Registrar nuevo";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // Form2Sol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 458);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRegistrarProveedor);
            this.Controls.Add(this.btnRegistrarPrecioBase);
            this.Controls.Add(this.btnRegistrar);
            this.Name = "Form2Sol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnRegistrarProveedor;
        private System.Windows.Forms.Button btnRegistrarPrecioBase;
        private System.Windows.Forms.Button btnRegistrar;
    }
}