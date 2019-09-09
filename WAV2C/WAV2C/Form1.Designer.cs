namespace WAV2C
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_import_file = new System.Windows.Forms.Button();
            this.button_generate_C_file = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // button_import_file
            // 
            this.button_import_file.Location = new System.Drawing.Point(35, 34);
            this.button_import_file.Name = "button_import_file";
            this.button_import_file.Size = new System.Drawing.Size(107, 37);
            this.button_import_file.TabIndex = 0;
            this.button_import_file.Text = "导入WAV文件";
            this.button_import_file.UseVisualStyleBackColor = true;
            this.button_import_file.Click += new System.EventHandler(this.button_import_file_Click);
            // 
            // button_generate_C_file
            // 
            this.button_generate_C_file.Location = new System.Drawing.Point(35, 93);
            this.button_generate_C_file.Name = "button_generate_C_file";
            this.button_generate_C_file.Size = new System.Drawing.Size(107, 40);
            this.button_generate_C_file.TabIndex = 1;
            this.button_generate_C_file.Text = "生成C文件";
            this.button_generate_C_file.UseVisualStyleBackColor = true;
            this.button_generate_C_file.Click += new System.EventHandler(this.button_generate_C_file_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "WAV File(*.wav)|*.wav|All Files(*.*)|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 430);
            this.Controls.Add(this.button_generate_C_file);
            this.Controls.Add(this.button_import_file);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "WAV2C";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_import_file;
        private System.Windows.Forms.Button button_generate_C_file;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

