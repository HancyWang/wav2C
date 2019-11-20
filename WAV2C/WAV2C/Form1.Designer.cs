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
            this.label1 = new System.Windows.Forms.Label();
            this.label_music_type = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_layer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_bit_rate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_sample_rate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_CRC = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_extra_one_byte = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_channel_mode = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_extar_channel_mode = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_import_file
            // 
            this.button_import_file.Location = new System.Drawing.Point(35, 34);
            this.button_import_file.Name = "button_import_file";
            this.button_import_file.Size = new System.Drawing.Size(107, 54);
            this.button_import_file.TabIndex = 0;
            this.button_import_file.Text = "导入WAV/MP3文件";
            this.button_import_file.UseVisualStyleBackColor = true;
            this.button_import_file.Click += new System.EventHandler(this.button_import_file_Click);
            // 
            // button_generate_C_file
            // 
            this.button_generate_C_file.Location = new System.Drawing.Point(176, 32);
            this.button_generate_C_file.Name = "button_generate_C_file";
            this.button_generate_C_file.Size = new System.Drawing.Size(107, 56);
            this.button_generate_C_file.TabIndex = 1;
            this.button_generate_C_file.Text = "生成C文件";
            this.button_generate_C_file.UseVisualStyleBackColor = true;
            this.button_generate_C_file.Click += new System.EventHandler(this.button_generate_C_file_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "MP3 File(*.mp3)|*.mp3|All Files(*.*)|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type:";
            // 
            // label_music_type
            // 
            this.label_music_type.AutoSize = true;
            this.label_music_type.Location = new System.Drawing.Point(195, 113);
            this.label_music_type.Name = "label_music_type";
            this.label_music_type.Size = new System.Drawing.Size(15, 15);
            this.label_music_type.TabIndex = 3;
            this.label_music_type.Text = "/";
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(195, 142);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(15, 15);
            this.label_version.TabIndex = 5;
            this.label_version.Text = "/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Version:";
            // 
            // label_layer
            // 
            this.label_layer.AutoSize = true;
            this.label_layer.Location = new System.Drawing.Point(195, 169);
            this.label_layer.Name = "label_layer";
            this.label_layer.Size = new System.Drawing.Size(15, 15);
            this.label_layer.TabIndex = 7;
            this.label_layer.Text = "/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Layer:";
            // 
            // label_bit_rate
            // 
            this.label_bit_rate.AutoSize = true;
            this.label_bit_rate.Location = new System.Drawing.Point(195, 229);
            this.label_bit_rate.Name = "label_bit_rate";
            this.label_bit_rate.Size = new System.Drawing.Size(15, 15);
            this.label_bit_rate.TabIndex = 9;
            this.label_bit_rate.Text = "/";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bit Rate:";
            // 
            // label_sample_rate
            // 
            this.label_sample_rate.AutoSize = true;
            this.label_sample_rate.Location = new System.Drawing.Point(195, 257);
            this.label_sample_rate.Name = "label_sample_rate";
            this.label_sample_rate.Size = new System.Drawing.Size(15, 15);
            this.label_sample_rate.TabIndex = 11;
            this.label_sample_rate.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Sample Rate:";
            // 
            // label_CRC
            // 
            this.label_CRC.AutoSize = true;
            this.label_CRC.Location = new System.Drawing.Point(195, 200);
            this.label_CRC.Name = "label_CRC";
            this.label_CRC.Size = new System.Drawing.Size(15, 15);
            this.label_CRC.TabIndex = 13;
            this.label_CRC.Text = "/";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "CRC:";
            // 
            // label_extra_one_byte
            // 
            this.label_extra_one_byte.AutoSize = true;
            this.label_extra_one_byte.Location = new System.Drawing.Point(194, 288);
            this.label_extra_one_byte.Name = "label_extra_one_byte";
            this.label_extra_one_byte.Size = new System.Drawing.Size(15, 15);
            this.label_extra_one_byte.TabIndex = 16;
            this.label_extra_one_byte.Text = "/";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Extra one byte:";
            // 
            // label_channel_mode
            // 
            this.label_channel_mode.AutoSize = true;
            this.label_channel_mode.Location = new System.Drawing.Point(194, 316);
            this.label_channel_mode.Name = "label_channel_mode";
            this.label_channel_mode.Size = new System.Drawing.Size(15, 15);
            this.label_channel_mode.TabIndex = 18;
            this.label_channel_mode.Text = "/";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Channel mode:";
            // 
            // label_extar_channel_mode
            // 
            this.label_extar_channel_mode.AutoSize = true;
            this.label_extar_channel_mode.Location = new System.Drawing.Point(194, 347);
            this.label_extar_channel_mode.Name = "label_extar_channel_mode";
            this.label_extar_channel_mode.Size = new System.Drawing.Size(15, 15);
            this.label_extar_channel_mode.TabIndex = 20;
            this.label_extar_channel_mode.Text = "/";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "Extra channel mode:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 430);
            this.Controls.Add(this.label_extar_channel_mode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_channel_mode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label_extra_one_byte);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_CRC);
            this.Controls.Add(this.label_sample_rate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_bit_rate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_layer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_music_type);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_generate_C_file);
            this.Controls.Add(this.button_import_file);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MUSIC_TRANSFER_2C";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_import_file;
        private System.Windows.Forms.Button button_generate_C_file;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_music_type;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_layer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_bit_rate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_sample_rate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_CRC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_extra_one_byte;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_channel_mode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_extar_channel_mode;
        private System.Windows.Forms.Label label10;
    }
}

