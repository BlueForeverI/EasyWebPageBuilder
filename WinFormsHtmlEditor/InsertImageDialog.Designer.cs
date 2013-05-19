namespace WinFormsHtmlEditor
{
    partial class InsertImageDialog
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
            this.lblImageLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblBorder = new System.Windows.Forms.Label();
            this.txtBorder = new System.Windows.Forms.TextBox();
            this.lblAlt = new System.Windows.Forms.Label();
            this.txtAlt = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblImageLocation
            // 
            this.lblImageLocation.AutoSize = true;
            this.lblImageLocation.Location = new System.Drawing.Point(12, 33);
            this.lblImageLocation.Name = "lblImageLocation";
            this.lblImageLocation.Size = new System.Drawing.Size(86, 13);
            this.lblImageLocation.TabIndex = 0;
            this.lblImageLocation.Text = "Image Location: ";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(104, 30);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(185, 20);
            this.txtLocation.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(295, 27);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 25);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 89);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(56, 13);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "Image ID: ";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(74, 86);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(83, 20);
            this.txtId.TabIndex = 2;
            // 
            // lblBorder
            // 
            this.lblBorder.AutoSize = true;
            this.lblBorder.Location = new System.Drawing.Point(222, 152);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(67, 13);
            this.lblBorder.TabIndex = 5;
            this.lblBorder.Text = "Border Size: ";
            // 
            // txtBorder
            // 
            this.txtBorder.Location = new System.Drawing.Point(295, 149);
            this.txtBorder.Name = "txtBorder";
            this.txtBorder.Size = new System.Drawing.Size(41, 20);
            this.txtBorder.TabIndex = 6;
            // 
            // lblAlt
            // 
            this.lblAlt.AutoSize = true;
            this.lblAlt.Location = new System.Drawing.Point(176, 89);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Size = new System.Drawing.Size(87, 13);
            this.lblAlt.TabIndex = 7;
            this.lblAlt.Text = "Alternative Text: ";
            // 
            // txtAlt
            // 
            this.txtAlt.Location = new System.Drawing.Point(269, 86);
            this.txtAlt.Name = "txtAlt";
            this.txtAlt.Size = new System.Drawing.Size(126, 20);
            this.txtAlt.TabIndex = 3;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(15, 152);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(41, 13);
            this.lblWidth.TabIndex = 9;
            this.lblWidth.Text = "Width: ";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(15, 206);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(44, 13);
            this.lblHeight.TabIndex = 10;
            this.lblHeight.Text = "Height: ";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(74, 149);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 4;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(74, 203);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(295, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(189, 200);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 25);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // InsertImageDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 252);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.txtAlt);
            this.Controls.Add(this.lblAlt);
            this.Controls.Add(this.txtBorder);
            this.Controls.Add(this.lblBorder);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblImageLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertImageDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Image";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImageLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblBorder;
        private System.Windows.Forms.TextBox txtBorder;
        private System.Windows.Forms.Label lblAlt;
        private System.Windows.Forms.TextBox txtAlt;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}