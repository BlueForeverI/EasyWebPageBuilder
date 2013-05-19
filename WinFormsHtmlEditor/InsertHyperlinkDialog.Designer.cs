namespace WinFormsHtmlEditor
{
    partial class InsertHyperlinkDialog
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
            this.lblHyperlinkText = new System.Windows.Forms.Label();
            this.txtHyperlinkText = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtHyperlinkUrl = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHyperlinkText
            // 
            this.lblHyperlinkText.AutoSize = true;
            this.lblHyperlinkText.Location = new System.Drawing.Point(12, 24);
            this.lblHyperlinkText.Name = "lblHyperlinkText";
            this.lblHyperlinkText.Size = new System.Drawing.Size(81, 13);
            this.lblHyperlinkText.TabIndex = 0;
            this.lblHyperlinkText.Text = "Hyperlink Text: ";
            // 
            // txtHyperlinkText
            // 
            this.txtHyperlinkText.Location = new System.Drawing.Point(99, 21);
            this.txtHyperlinkText.Name = "txtHyperlinkText";
            this.txtHyperlinkText.Size = new System.Drawing.Size(178, 20);
            this.txtHyperlinkText.TabIndex = 0;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 73);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(35, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "URL: ";
            // 
            // txtHyperlinkUrl
            // 
            this.txtHyperlinkUrl.Location = new System.Drawing.Point(99, 70);
            this.txtHyperlinkUrl.Name = "txtHyperlinkUrl";
            this.txtHyperlinkUrl.Size = new System.Drawing.Size(178, 20);
            this.txtHyperlinkUrl.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(177, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(68, 128);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // InsertHyperlinkDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 170);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtHyperlinkUrl);
            this.Controls.Add(this.txtHyperlinkText);
            this.Controls.Add(this.lblHyperlinkText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertHyperlinkDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Hyperlink";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHyperlinkText;
        private System.Windows.Forms.TextBox txtHyperlinkText;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtHyperlinkUrl;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}