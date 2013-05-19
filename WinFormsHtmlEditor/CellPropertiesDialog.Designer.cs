namespace WinFormsHtmlEditor
{
    partial class CellPropertiesDialog
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
            this.lblBackground = new System.Windows.Forms.Label();
            this.btnBackgroundColor = new System.Windows.Forms.Button();
            this.lblBorder = new System.Windows.Forms.Label();
            this.btnBorderColor = new System.Windows.Forms.Button();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblBorderSize = new System.Windows.Forms.Label();
            this.txtBorderSize = new System.Windows.Forms.TextBox();
            this.lblRowspan = new System.Windows.Forms.Label();
            this.txtRowspan = new System.Windows.Forms.TextBox();
            this.txtColspan = new System.Windows.Forms.TextBox();
            this.lblColspan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.Location = new System.Drawing.Point(11, 22);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(98, 13);
            this.lblBackground.TabIndex = 0;
            this.lblBackground.Text = "Background Color: ";
            // 
            // btnBackgroundColor
            // 
            this.btnBackgroundColor.BackColor = System.Drawing.Color.White;
            this.btnBackgroundColor.Location = new System.Drawing.Point(116, 17);
            this.btnBackgroundColor.Name = "btnBackgroundColor";
            this.btnBackgroundColor.Size = new System.Drawing.Size(22, 23);
            this.btnBackgroundColor.TabIndex = 0;
            this.btnBackgroundColor.UseVisualStyleBackColor = false;
            this.btnBackgroundColor.Click += new System.EventHandler(this.btnBackgroundColor_Click);
            // 
            // lblBorder
            // 
            this.lblBorder.AutoSize = true;
            this.lblBorder.Location = new System.Drawing.Point(11, 77);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(71, 13);
            this.lblBorder.TabIndex = 11;
            this.lblBorder.Text = "Border Color: ";
            // 
            // btnBorderColor
            // 
            this.btnBorderColor.BackColor = System.Drawing.Color.Black;
            this.btnBorderColor.Location = new System.Drawing.Point(116, 72);
            this.btnBorderColor.Name = "btnBorderColor";
            this.btnBorderColor.Size = new System.Drawing.Size(22, 23);
            this.btnBorderColor.TabIndex = 1;
            this.btnBorderColor.UseVisualStyleBackColor = false;
            this.btnBorderColor.Click += new System.EventHandler(this.btnBorderColor_Click);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(195, 22);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(41, 13);
            this.lblWidth.TabIndex = 13;
            this.lblWidth.Text = "Width: ";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(242, 19);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(83, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "Default";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(195, 77);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(44, 13);
            this.lblHeight.TabIndex = 15;
            this.lblHeight.Text = "Height: ";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(242, 74);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(83, 20);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.Text = "Default";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(225, 239);
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
            this.btnOk.Location = new System.Drawing.Point(116, 240);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 25);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblBorderSize
            // 
            this.lblBorderSize.AutoSize = true;
            this.lblBorderSize.Location = new System.Drawing.Point(9, 187);
            this.lblBorderSize.Name = "lblBorderSize";
            this.lblBorderSize.Size = new System.Drawing.Size(44, 13);
            this.lblBorderSize.TabIndex = 27;
            this.lblBorderSize.Text = "Border: ";
            // 
            // txtBorderSize
            // 
            this.txtBorderSize.Location = new System.Drawing.Point(72, 184);
            this.txtBorderSize.Name = "txtBorderSize";
            this.txtBorderSize.Size = new System.Drawing.Size(83, 20);
            this.txtBorderSize.TabIndex = 6;
            this.txtBorderSize.Text = "Default";
            // 
            // lblRowspan
            // 
            this.lblRowspan.AutoSize = true;
            this.lblRowspan.Location = new System.Drawing.Point(11, 128);
            this.lblRowspan.Name = "lblRowspan";
            this.lblRowspan.Size = new System.Drawing.Size(55, 13);
            this.lblRowspan.TabIndex = 28;
            this.lblRowspan.Text = "Rowspan:";
            // 
            // txtRowspan
            // 
            this.txtRowspan.Location = new System.Drawing.Point(72, 125);
            this.txtRowspan.Name = "txtRowspan";
            this.txtRowspan.Size = new System.Drawing.Size(83, 20);
            this.txtRowspan.TabIndex = 4;
            this.txtRowspan.Text = "Default";
            // 
            // txtColspan
            // 
            this.txtColspan.Location = new System.Drawing.Point(242, 125);
            this.txtColspan.Name = "txtColspan";
            this.txtColspan.Size = new System.Drawing.Size(83, 20);
            this.txtColspan.TabIndex = 5;
            this.txtColspan.Text = "Default";
            // 
            // lblColspan
            // 
            this.lblColspan.AutoSize = true;
            this.lblColspan.Location = new System.Drawing.Point(184, 128);
            this.lblColspan.Name = "lblColspan";
            this.lblColspan.Size = new System.Drawing.Size(51, 13);
            this.lblColspan.TabIndex = 28;
            this.lblColspan.Text = "Colspan: ";
            // 
            // CellPropertiesDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 281);
            this.Controls.Add(this.lblColspan);
            this.Controls.Add(this.txtColspan);
            this.Controls.Add(this.txtRowspan);
            this.Controls.Add(this.lblRowspan);
            this.Controls.Add(this.lblBorderSize);
            this.Controls.Add(this.txtBorderSize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.btnBorderColor);
            this.Controls.Add(this.lblBorder);
            this.Controls.Add(this.btnBackgroundColor);
            this.Controls.Add(this.lblBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CellPropertiesDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cell Properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.Button btnBackgroundColor;
        private System.Windows.Forms.Label lblBorder;
        private System.Windows.Forms.Button btnBorderColor;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblBorderSize;
        private System.Windows.Forms.TextBox txtBorderSize;
        private System.Windows.Forms.Label lblRowspan;
        private System.Windows.Forms.TextBox txtRowspan;
        private System.Windows.Forms.TextBox txtColspan;
        private System.Windows.Forms.Label lblColspan;
    }
}