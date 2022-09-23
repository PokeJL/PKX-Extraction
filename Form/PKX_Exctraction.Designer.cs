
namespace PKX_Extraction
{
    partial class PKX_Exctraction
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectGameCB = new System.Windows.Forms.ComboBox();
            this.pkmSelect = new System.Windows.Forms.ComboBox();
            this.OpenFileBTN = new System.Windows.Forms.Button();
            this.extractBTN = new System.Windows.Forms.Button();
            this.saveBTN = new System.Windows.Forms.Button();
            this.OpenFileTXB = new System.Windows.Forms.TextBox();
            this.RipProgressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Icon = new System.Windows.Forms.PictureBox();
            this.pokemonInfoTXB = new System.Windows.Forms.TextBox();
            this.Info = new System.Windows.Forms.TextBox();
            this.mainGameRBT = new System.Windows.Forms.RadioButton();
            this.spinOffRBT = new System.Windows.Forms.RadioButton();
            this.selectGameGB = new System.Windows.Forms.GroupBox();
            this.AppInfoLinkLBL = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
            this.selectGameGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectGameCB
            // 
            this.selectGameCB.Enabled = false;
            this.selectGameCB.FormattingEnabled = true;
            this.selectGameCB.Location = new System.Drawing.Point(6, 72);
            this.selectGameCB.Name = "selectGameCB";
            this.selectGameCB.Size = new System.Drawing.Size(121, 23);
            this.selectGameCB.TabIndex = 0;
            this.selectGameCB.SelectedIndexChanged += new System.EventHandler(this.selectGameCB_SelectedIndexChanged);
            // 
            // pkmSelect
            // 
            this.pkmSelect.Enabled = false;
            this.pkmSelect.FormattingEnabled = true;
            this.pkmSelect.Location = new System.Drawing.Point(246, 84);
            this.pkmSelect.Name = "pkmSelect";
            this.pkmSelect.Size = new System.Drawing.Size(138, 23);
            this.pkmSelect.TabIndex = 1;
            this.pkmSelect.SelectedIndexChanged += new System.EventHandler(this.pkmSelect_SelectedIndexChanged);
            // 
            // OpenFileBTN
            // 
            this.OpenFileBTN.Enabled = false;
            this.OpenFileBTN.Location = new System.Drawing.Point(159, 26);
            this.OpenFileBTN.Name = "OpenFileBTN";
            this.OpenFileBTN.Size = new System.Drawing.Size(81, 23);
            this.OpenFileBTN.TabIndex = 3;
            this.OpenFileBTN.Text = "Open File";
            this.OpenFileBTN.UseVisualStyleBackColor = true;
            this.OpenFileBTN.Click += new System.EventHandler(this.OpenFileBTN_Click);
            // 
            // extractBTN
            // 
            this.extractBTN.Enabled = false;
            this.extractBTN.Location = new System.Drawing.Point(159, 55);
            this.extractBTN.Name = "extractBTN";
            this.extractBTN.Size = new System.Drawing.Size(81, 23);
            this.extractBTN.TabIndex = 4;
            this.extractBTN.Text = "Extract";
            this.extractBTN.UseVisualStyleBackColor = true;
            this.extractBTN.Click += new System.EventHandler(this.extractBTN_Click);
            // 
            // saveBTN
            // 
            this.saveBTN.Enabled = false;
            this.saveBTN.Location = new System.Drawing.Point(159, 84);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(81, 23);
            this.saveBTN.TabIndex = 5;
            this.saveBTN.Text = "Save PKMN";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // OpenFileTXB
            // 
            this.OpenFileTXB.Enabled = false;
            this.OpenFileTXB.Location = new System.Drawing.Point(246, 26);
            this.OpenFileTXB.Name = "OpenFileTXB";
            this.OpenFileTXB.Size = new System.Drawing.Size(138, 23);
            this.OpenFileTXB.TabIndex = 6;
            // 
            // RipProgressBar
            // 
            this.RipProgressBar.Location = new System.Drawing.Point(246, 55);
            this.RipProgressBar.Name = "RipProgressBar";
            this.RipProgressBar.Size = new System.Drawing.Size(138, 23);
            this.RipProgressBar.TabIndex = 7;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Icon
            // 
            this.Icon.Image = global::PKX_Extraction.Properties.Resources.b_0;
            this.Icon.Location = new System.Drawing.Point(12, 124);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(68, 56);
            this.Icon.TabIndex = 8;
            this.Icon.TabStop = false;
            // 
            // pokemonInfoTXB
            // 
            this.pokemonInfoTXB.Location = new System.Drawing.Point(12, 186);
            this.pokemonInfoTXB.Multiline = true;
            this.pokemonInfoTXB.Name = "pokemonInfoTXB";
            this.pokemonInfoTXB.ReadOnly = true;
            this.pokemonInfoTXB.Size = new System.Drawing.Size(141, 126);
            this.pokemonInfoTXB.TabIndex = 9;
            this.pokemonInfoTXB.Text = "Pokemon Info:\r\nCurrently none.";
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(159, 124);
            this.Info.Multiline = true;
            this.Info.Name = "Info";
            this.Info.ReadOnly = true;
            this.Info.Size = new System.Drawing.Size(225, 188);
            this.Info.TabIndex = 10;
            this.Info.Text = "Note:";
            // 
            // mainGameRBT
            // 
            this.mainGameRBT.AutoSize = true;
            this.mainGameRBT.Location = new System.Drawing.Point(6, 22);
            this.mainGameRBT.Name = "mainGameRBT";
            this.mainGameRBT.Size = new System.Drawing.Size(116, 19);
            this.mainGameRBT.TabIndex = 11;
            this.mainGameRBT.Text = "Main Line Games";
            this.mainGameRBT.UseVisualStyleBackColor = true;
            this.mainGameRBT.CheckedChanged += new System.EventHandler(this.mainGameRBT_CheckedChanged);
            // 
            // spinOffRBT
            // 
            this.spinOffRBT.AutoSize = true;
            this.spinOffRBT.Location = new System.Drawing.Point(6, 47);
            this.spinOffRBT.Name = "spinOffRBT";
            this.spinOffRBT.Size = new System.Drawing.Size(107, 19);
            this.spinOffRBT.TabIndex = 12;
            this.spinOffRBT.Text = "Spin Off Games";
            this.spinOffRBT.UseVisualStyleBackColor = true;
            this.spinOffRBT.CheckedChanged += new System.EventHandler(this.spinOffRBT_CheckedChanged);
            // 
            // selectGameGB
            // 
            this.selectGameGB.Controls.Add(this.mainGameRBT);
            this.selectGameGB.Controls.Add(this.spinOffRBT);
            this.selectGameGB.Controls.Add(this.selectGameCB);
            this.selectGameGB.Location = new System.Drawing.Point(12, 12);
            this.selectGameGB.Name = "selectGameGB";
            this.selectGameGB.Size = new System.Drawing.Size(141, 106);
            this.selectGameGB.TabIndex = 13;
            this.selectGameGB.TabStop = false;
            this.selectGameGB.Text = "Select Game Type:";
            // 
            // AppInfoLinkLBL
            // 
            this.AppInfoLinkLBL.AutoSize = true;
            this.AppInfoLinkLBL.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AppInfoLinkLBL.Location = new System.Drawing.Point(291, 312);
            this.AppInfoLinkLBL.Name = "AppInfoLinkLBL";
            this.AppInfoLinkLBL.Size = new System.Drawing.Size(93, 11);
            this.AppInfoLinkLBL.TabIndex = 15;
            this.AppInfoLinkLBL.TabStop = true;
            this.AppInfoLinkLBL.Text = "Application Information";
            this.AppInfoLinkLBL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AppInfoLinkLBL_LinkClicked);
            // 
            // PKX_Exctraction
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 322);
            this.Controls.Add(this.AppInfoLinkLBL);
            this.Controls.Add(this.selectGameGB);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.pokemonInfoTXB);
            this.Controls.Add(this.Icon);
            this.Controls.Add(this.RipProgressBar);
            this.Controls.Add(this.OpenFileTXB);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.extractBTN);
            this.Controls.Add(this.OpenFileBTN);
            this.Controls.Add(this.pkmSelect);
            this.MaximumSize = new System.Drawing.Size(410, 361);
            this.MinimumSize = new System.Drawing.Size(410, 361);
            this.Name = "PKX_Exctraction";
            this.Text = "PKX Extraction";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PKX_ExtractionDragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.PKX_ExtractionDragOver);
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
            this.selectGameGB.ResumeLayout(false);
            this.selectGameGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectGameCB;
        private System.Windows.Forms.ComboBox pkmSelect;
        private System.Windows.Forms.Button OpenFileBTN;
        private System.Windows.Forms.Button extractBTN;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.TextBox OpenFileTXB;
        private System.Windows.Forms.ProgressBar RipProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox Icon;
        private System.Windows.Forms.TextBox pokemonInfoTXB;
        private System.Windows.Forms.TextBox Info;
        private System.Windows.Forms.RadioButton mainGameRBT;
        private System.Windows.Forms.RadioButton spinOffRBT;
        private System.Windows.Forms.GroupBox selectGameGB;
        private System.Windows.Forms.LinkLabel AppInfoLinkLBL;
    }
}

