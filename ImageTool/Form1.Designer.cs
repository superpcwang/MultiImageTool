namespace ImageTool
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialogImages = new System.Windows.Forms.OpenFileDialog();
            this.textFiles = new System.Windows.Forms.TextBox();
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.flowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.textLog = new System.Windows.Forms.RichTextBox();
            this.btnSaveImages = new System.Windows.Forms.Button();
            this.saveFileDialogImages = new System.Windows.Forms.SaveFileDialog();
            this.cbCutImage = new System.Windows.Forms.CheckBox();
            this.tbCutWidth = new System.Windows.Forms.TextBox();
            this.tbCutHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTestMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openFileDialogImages
            // 
            this.openFileDialogImages.FileName = "openFileDialogImages";
            this.openFileDialogImages.Multiselect = true;
            // 
            // textFiles
            // 
            this.textFiles.Location = new System.Drawing.Point(13, 13);
            this.textFiles.Name = "textFiles";
            this.textFiles.Size = new System.Drawing.Size(267, 22);
            this.textFiles.TabIndex = 0;
            // 
            // btnOpenFiles
            // 
            this.btnOpenFiles.Location = new System.Drawing.Point(287, 11);
            this.btnOpenFiles.Name = "btnOpenFiles";
            this.btnOpenFiles.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFiles.TabIndex = 1;
            this.btnOpenFiles.Text = "Open Files";
            this.btnOpenFiles.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelImages
            // 
            this.flowLayoutPanelImages.AutoScroll = true;
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(13, 154);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(464, 744);
            this.flowLayoutPanelImages.TabIndex = 2;
            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(12, 100);
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.Size = new System.Drawing.Size(465, 48);
            this.textLog.TabIndex = 3;
            this.textLog.Text = "";
            // 
            // btnSaveImages
            // 
            this.btnSaveImages.Location = new System.Drawing.Point(369, 11);
            this.btnSaveImages.Name = "btnSaveImages";
            this.btnSaveImages.Size = new System.Drawing.Size(75, 23);
            this.btnSaveImages.TabIndex = 4;
            this.btnSaveImages.Text = "Save Images";
            this.btnSaveImages.UseVisualStyleBackColor = true;
            // 
            // cbCutImage
            // 
            this.cbCutImage.AutoSize = true;
            this.cbCutImage.Location = new System.Drawing.Point(13, 42);
            this.cbCutImage.Name = "cbCutImage";
            this.cbCutImage.Size = new System.Drawing.Size(41, 16);
            this.cbCutImage.TabIndex = 5;
            this.cbCutImage.Text = "Cut";
            this.cbCutImage.UseVisualStyleBackColor = true;
            // 
            // tbCutWidth
            // 
            this.tbCutWidth.Location = new System.Drawing.Point(74, 40);
            this.tbCutWidth.Name = "tbCutWidth";
            this.tbCutWidth.Size = new System.Drawing.Size(100, 22);
            this.tbCutWidth.TabIndex = 6;
            // 
            // tbCutHeight
            // 
            this.tbCutHeight.Location = new System.Drawing.Point(74, 68);
            this.tbCutHeight.Name = "tbCutHeight";
            this.tbCutHeight.Size = new System.Drawing.Size(100, 22);
            this.tbCutHeight.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "W:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "H:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "W:";
            // 
            // cbTestMode
            // 
            this.cbTestMode.AutoSize = true;
            this.cbTestMode.Location = new System.Drawing.Point(192, 42);
            this.cbTestMode.Name = "cbTestMode";
            this.cbTestMode.Size = new System.Drawing.Size(73, 16);
            this.cbTestMode.TabIndex = 9;
            this.cbTestMode.Text = "Test Mode";
            this.cbTestMode.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 910);
            this.Controls.Add(this.cbTestMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCutHeight);
            this.Controls.Add(this.tbCutWidth);
            this.Controls.Add(this.cbCutImage);
            this.Controls.Add(this.btnSaveImages);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.flowLayoutPanelImages);
            this.Controls.Add(this.btnOpenFiles);
            this.Controls.Add(this.textFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogImages;
        private System.Windows.Forms.TextBox textFiles;
        private System.Windows.Forms.Button btnOpenFiles;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
        private System.Windows.Forms.RichTextBox textLog;
        private System.Windows.Forms.Button btnSaveImages;
        private System.Windows.Forms.SaveFileDialog saveFileDialogImages;
        private System.Windows.Forms.CheckBox cbCutImage;
        private System.Windows.Forms.TextBox tbCutWidth;
        private System.Windows.Forms.TextBox tbCutHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbTestMode;
    }
}

