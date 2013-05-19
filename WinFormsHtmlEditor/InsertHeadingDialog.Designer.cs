namespace WinFormsHtmlEditor
{
    partial class InsertHeadingDialog
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
            this.lblText = new System.Windows.Forms.Label();
            this.txtHeadingText = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtHeadingSize = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(12, 21);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(77, 13);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Heading Text: ";
            // 
            // txtHeadingText
            // 
            this.txtHeadingText.Location = new System.Drawing.Point(132, 18);
            this.txtHeadingText.Name = "txtHeadingText";
            this.txtHeadingText.Size = new System.Drawing.Size(165, 20);
            this.txtHeadingText.TabIndex = 0;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(12, 66);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(106, 13);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Heading Size (1 - 6): ";
            // 
            // txtHeadingSize
            // 
            this.txtHeadingSize.Location = new System.Drawing.Point(132, 63);
            this.txtHeadingSize.Name = "txtHeadingSize";
            this.txtHeadingSize.Size = new System.Drawing.Size(29, 20);
            this.txtHeadingSize.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(197, 112);
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
            this.btnOk.Location = new System.Drawing.Point(88, 113);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // InsertHeadingDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 156);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtHeadingSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.txtHeadingText);
            this.Controls.Add(this.lblText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertHeadingDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Heading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtHeadingText;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtHeadingSize;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}