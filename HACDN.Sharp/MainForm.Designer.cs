namespace HACDN.Sharp
{
    partial class MainForm
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
            this.btnDownload = new System.Windows.Forms.Button();
            this.tbDeviceId = new System.Windows.Forms.TextBox();
            this.lblTitleId = new System.Windows.Forms.Label();
            this.tbTitleId = new System.Windows.Forms.TextBox();
            this.lblDeviceId = new System.Windows.Forms.Label();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.stripDownloadInfo = new System.Windows.Forms.StatusStrip();
            this.pbDownloadProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblCurrentBytes = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalBytes = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSlash = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripDownloadInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(283, 31);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(142, 26);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            // 
            // tbDeviceId
            // 
            this.tbDeviceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDeviceId.Location = new System.Drawing.Point(85, 33);
            this.tbDeviceId.Name = "tbDeviceId";
            this.tbDeviceId.Size = new System.Drawing.Size(192, 21);
            this.tbDeviceId.TabIndex = 1;
            // 
            // lblTitleId
            // 
            this.lblTitleId.AutoSize = true;
            this.lblTitleId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleId.Location = new System.Drawing.Point(12, 9);
            this.lblTitleId.Name = "lblTitleId";
            this.lblTitleId.Size = new System.Drawing.Size(53, 16);
            this.lblTitleId.TabIndex = 2;
            this.lblTitleId.Text = "Title ID:";
            // 
            // tbTitleId
            // 
            this.tbTitleId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitleId.Location = new System.Drawing.Point(85, 6);
            this.tbTitleId.Name = "tbTitleId";
            this.tbTitleId.Size = new System.Drawing.Size(192, 21);
            this.tbTitleId.TabIndex = 1;
            // 
            // lblDeviceId
            // 
            this.lblDeviceId.AutoSize = true;
            this.lblDeviceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceId.Location = new System.Drawing.Point(12, 36);
            this.lblDeviceId.Name = "lblDeviceId";
            this.lblDeviceId.Size = new System.Drawing.Size(70, 16);
            this.lblDeviceId.TabIndex = 2;
            this.lblDeviceId.Text = "Device ID:";
            // 
            // tbVersion
            // 
            this.tbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVersion.Location = new System.Drawing.Point(353, 6);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(72, 22);
            this.tbVersion.TabIndex = 3;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(283, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(57, 16);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version:";
            // 
            // stripDownloadInfo
            // 
            this.stripDownloadInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDownloadProgress,
            this.lblCurrentBytes,
            this.lblSlash,
            this.lblTotalBytes});
            this.stripDownloadInfo.Location = new System.Drawing.Point(0, 60);
            this.stripDownloadInfo.Name = "stripDownloadInfo";
            this.stripDownloadInfo.Size = new System.Drawing.Size(460, 22);
            this.stripDownloadInfo.TabIndex = 4;
            this.stripDownloadInfo.Text = "Download Status";
            // 
            // pbDownloadProgress
            // 
            this.pbDownloadProgress.Name = "pbDownloadProgress";
            this.pbDownloadProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // lblCurrentBytes
            // 
            this.lblCurrentBytes.Name = "lblCurrentBytes";
            this.lblCurrentBytes.Size = new System.Drawing.Size(43, 17);
            this.lblCurrentBytes.Text = "0.0 MB";
            // 
            // lblTotalBytes
            // 
            this.lblTotalBytes.Name = "lblTotalBytes";
            this.lblTotalBytes.Size = new System.Drawing.Size(43, 17);
            this.lblTotalBytes.Text = "0.0 MB";
            // 
            // lblSlash
            // 
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(12, 17);
            this.lblSlash.Text = "/";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 82);
            this.Controls.Add(this.stripDownloadInfo);
            this.Controls.Add(this.tbVersion);
            this.Controls.Add(this.lblDeviceId);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblTitleId);
            this.Controls.Add(this.tbTitleId);
            this.Controls.Add(this.tbDeviceId);
            this.Controls.Add(this.btnDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "HACDN Sharp";
            this.stripDownloadInfo.ResumeLayout(false);
            this.stripDownloadInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox tbDeviceId;
        private System.Windows.Forms.Label lblTitleId;
        private System.Windows.Forms.TextBox tbTitleId;
        private System.Windows.Forms.Label lblDeviceId;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.StatusStrip stripDownloadInfo;
        private System.Windows.Forms.ToolStripProgressBar pbDownloadProgress;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentBytes;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalBytes;
        private System.Windows.Forms.ToolStripStatusLabel lblSlash;
    }
}

