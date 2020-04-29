namespace LectorFacturasXML
{
    partial class Factura
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtExcelFile = new System.Windows.Forms.TextBox();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnExcelFile = new System.Windows.Forms.Button();
            this.btnDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Procesar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtExcelFile
            // 
            this.txtExcelFile.Location = new System.Drawing.Point(29, 12);
            this.txtExcelFile.Name = "txtExcelFile";
            this.txtExcelFile.Size = new System.Drawing.Size(100, 20);
            this.txtExcelFile.TabIndex = 1;
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(29, 47);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(100, 20);
            this.txtDirectory.TabIndex = 2;
            // 
            // btnExcelFile
            // 
            this.btnExcelFile.Location = new System.Drawing.Point(135, 9);
            this.btnExcelFile.Name = "btnExcelFile";
            this.btnExcelFile.Size = new System.Drawing.Size(108, 23);
            this.btnExcelFile.TabIndex = 3;
            this.btnExcelFile.Text = "Seleccione Excel";
            this.btnExcelFile.UseVisualStyleBackColor = true;
            this.btnExcelFile.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDirectory
            // 
            this.btnDirectory.Location = new System.Drawing.Point(135, 45);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(108, 23);
            this.btnDirectory.TabIndex = 4;
            this.btnDirectory.Text = "Seleccione Carpeta";
            this.btnDirectory.UseVisualStyleBackColor = true;
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 132);
            this.Controls.Add(this.btnDirectory);
            this.Controls.Add(this.btnExcelFile);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.txtExcelFile);
            this.Controls.Add(this.button1);
            this.Name = "Factura";
            this.Text = "Factura";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtExcelFile;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnExcelFile;
        private System.Windows.Forms.Button btnDirectory;
    }
}