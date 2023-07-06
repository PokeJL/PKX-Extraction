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
            ReleaseLBL = new System.Windows.Forms.Label();
            DevelopedLBL = new System.Windows.Forms.Label();
            EncryptionSourceLBL = new System.Windows.Forms.Label();
            DataSizeLBL = new System.Windows.Forms.Label();
            PKHeXLBL = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // ReleaseLBL
            // 
            ReleaseLBL.AutoSize = true;
            ReleaseLBL.Location = new System.Drawing.Point(12, 23);
            ReleaseLBL.Name = "ReleaseLBL";
            ReleaseLBL.Size = new System.Drawing.Size(100, 15);
            ReleaseLBL.TabIndex = 0;
            ReleaseLBL.Text = "Release: 20230705";
            // 
            // DevelopedLBL
            // 
            DevelopedLBL.AutoSize = true;
            DevelopedLBL.Location = new System.Drawing.Point(12, 38);
            DevelopedLBL.Name = "DevelopedLBL";
            DevelopedLBL.Size = new System.Drawing.Size(118, 15);
            DevelopedLBL.TabIndex = 1;
            DevelopedLBL.Text = "Developed by: Poke J";
            // 
            // EncryptionSourceLBL
            // 
            EncryptionSourceLBL.AutoSize = true;
            EncryptionSourceLBL.Location = new System.Drawing.Point(12, 53);
            EncryptionSourceLBL.Name = "EncryptionSourceLBL";
            EncryptionSourceLBL.Size = new System.Drawing.Size(173, 15);
            EncryptionSourceLBL.TabIndex = 2;
            EncryptionSourceLBL.Text = "Encryption code source: PKHeX";
            // 
            // DataSizeLBL
            // 
            DataSizeLBL.AutoSize = true;
            DataSizeLBL.Location = new System.Drawing.Point(12, 68);
            DataSizeLBL.Name = "DataSizeLBL";
            DataSizeLBL.Size = new System.Drawing.Size(131, 15);
            DataSizeLBL.TabIndex = 3;
            DataSizeLBL.Text = "Data size values: PKHeX";
            // 
            // PKHeXLBL
            // 
            PKHeXLBL.AutoSize = true;
            PKHeXLBL.Location = new System.Drawing.Point(12, 83);
            PKHeXLBL.Name = "PKHeXLBL";
            PKHeXLBL.Size = new System.Drawing.Size(141, 15);
            PKHeXLBL.TabIndex = 4;
            PKHeXLBL.Text = "PKHeX creator: Kaphotics";
            // 
            // Application_Information
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(322, 113);
            Controls.Add(PKHeXLBL);
            Controls.Add(DataSizeLBL);
            Controls.Add(EncryptionSourceLBL);
            Controls.Add(DevelopedLBL);
            Controls.Add(ReleaseLBL);
            MaximumSize = new System.Drawing.Size(338, 152);
            MinimumSize = new System.Drawing.Size(338, 152);
            Name = "Application_Information";
            Text = "Application Information";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label ReleaseLBL;
        private System.Windows.Forms.Label DevelopedLBL;
        private System.Windows.Forms.Label EncryptionSourceLBL;
        private System.Windows.Forms.Label DataSizeLBL;
        private System.Windows.Forms.Label PKHeXLBL;
    }
}