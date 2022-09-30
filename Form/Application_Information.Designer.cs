namespace PKX_Extraction.Core
{
    partial class Application_Information
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
            this.ReleaseLBL = new System.Windows.Forms.Label();
            this.DevelopedLBL = new System.Windows.Forms.Label();
            this.EncryptionSourceLBL = new System.Windows.Forms.Label();
            this.DataSizeLBL = new System.Windows.Forms.Label();
            this.PKHeXLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReleaseLBL
            // 
            this.ReleaseLBL.AutoSize = true;
            this.ReleaseLBL.Location = new System.Drawing.Point(12, 23);
            this.ReleaseLBL.Name = "ReleaseLBL";
            this.ReleaseLBL.Size = new System.Drawing.Size(111, 15);
            this.ReleaseLBL.TabIndex = 0;
            this.ReleaseLBL.Text = "Release: 20220930";
            // 
            // DevelopedLBL
            // 
            this.DevelopedLBL.AutoSize = true;
            this.DevelopedLBL.Location = new System.Drawing.Point(12, 38);
            this.DevelopedLBL.Name = "DevelopedLBL";
            this.DevelopedLBL.Size = new System.Drawing.Size(118, 15);
            this.DevelopedLBL.TabIndex = 1;
            this.DevelopedLBL.Text = "Developed by: Poke J";
            // 
            // EncryptionSourceLBL
            // 
            this.EncryptionSourceLBL.AutoSize = true;
            this.EncryptionSourceLBL.Location = new System.Drawing.Point(12, 53);
            this.EncryptionSourceLBL.Name = "EncryptionSourceLBL";
            this.EncryptionSourceLBL.Size = new System.Drawing.Size(173, 15);
            this.EncryptionSourceLBL.TabIndex = 2;
            this.EncryptionSourceLBL.Text = "Encryption code source: PKHeX";
            // 
            // DataSizeLBL
            // 
            this.DataSizeLBL.AutoSize = true;
            this.DataSizeLBL.Location = new System.Drawing.Point(12, 68);
            this.DataSizeLBL.Name = "DataSizeLBL";
            this.DataSizeLBL.Size = new System.Drawing.Size(131, 15);
            this.DataSizeLBL.TabIndex = 3;
            this.DataSizeLBL.Text = "Data size values: PKHeX";
            // 
            // PKHeXLBL
            // 
            this.PKHeXLBL.AutoSize = true;
            this.PKHeXLBL.Location = new System.Drawing.Point(12, 83);
            this.PKHeXLBL.Name = "PKHeXLBL";
            this.PKHeXLBL.Size = new System.Drawing.Size(141, 15);
            this.PKHeXLBL.TabIndex = 4;
            this.PKHeXLBL.Text = "PKHeX creator: Kaphotics";
            // 
            // Application_Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 113);
            this.Controls.Add(this.PKHeXLBL);
            this.Controls.Add(this.DataSizeLBL);
            this.Controls.Add(this.EncryptionSourceLBL);
            this.Controls.Add(this.DevelopedLBL);
            this.Controls.Add(this.ReleaseLBL);
            this.MaximumSize = new System.Drawing.Size(338, 152);
            this.MinimumSize = new System.Drawing.Size(338, 152);
            this.Name = "Application_Information";
            this.Text = "Application Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ReleaseLBL;
        private System.Windows.Forms.Label DevelopedLBL;
        private System.Windows.Forms.Label EncryptionSourceLBL;
        private System.Windows.Forms.Label DataSizeLBL;
        private System.Windows.Forms.Label PKHeXLBL;
    }
}