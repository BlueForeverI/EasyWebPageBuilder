namespace WinFormsHtmlEditor
{
    partial class TablePropertiesDialog
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
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.btnBorderColor = new System.Windows.Forms.Button();
            this.lblBorder = new System.Windows.Forms.Label();
            this.btnBackgroundColor = new System.Windows.Forms.Button();
            this.lblBackground = new System.Windows.Forms.Label();
            this.lblBorderSize = new System.Windows.Forms.Label();
            this.txtBorderSize = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblSpacing = new System.Windows.Forms.Label();
            this.txtCellSpacing = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(236, 74);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(83, 20);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.Text = "Default";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(189, 77);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(44, 13);
            this.lblHeight.TabIndex = 23;
            this.lblHeight.Text = "Height: ";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(236, 19);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(83, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "Default";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(189, 22);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(41, 13);
            this.lblWidth.TabIndex = 22;
            this.lblWidth.Text = "Width: ";
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
            // lblBorder
            // 
            this.lblBorder.AutoSize = true;
            this.lblBorder.Location = new System.Drawing.Point(11, 77);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(71, 13);
            this.lblBorder.TabIndex = 21;
            this.lblBorder.Text = "Border Color: ";
            // 
            // btnBackgroundColor
            // 
            this.btnBackgroundColor.BackColor = System.Drawing.Color.White;
            this.btnBackgroundColor.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBackgroundColor.Location = new System.Drawing.Point(116, 17);
            this.btnBackgroundColor.Name = "btnBackgroundColor";
            this.btnBackgroundColor.Size = new System.Drawing.Size(22, 23);
            this.btnBackgroundColor.TabIndex = 0;
            this.btnBackgroundColor.UseVisualStyleBackColor = false;
            this.btnBackgroundColor.Click += new System.EventHandler(this.btnBackgroundColor_Click);
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.Location = new System.Drawing.Point(11, 22);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(98, 13);
            this.lblBackground.TabIndex = 17;
            this.lblBackground.Text = "Background Color: ";
            // 
            // lblBorderSize
            // 
            this.lblBorderSize.AutoSize = true;
            this.lblBorderSize.Location = new System.Drawing.Point(11, 130);
            this.lblBorderSize.Name = "lblBorderSize";
            this.lblBorderSize.Size = new System.Drawing.Size(96, 13);
            this.lblBorderSize.TabIndex = 25;
            this.lblBorderSize.Text = "Border Thickness: ";
            // 
            // txtBorderSize
            // 
            this.txtBorderSize.Location = new System.Drawing.Point(118, 127);
            this.txtBorderSize.Name = "txtBorderSize";
            this.txtBorderSize.Size = new System.Drawing.Size(83, 20);
            this.txtBorderSize.TabIndex = 4;
            this.txtBorderSize.Text = "Default";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(222, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(113, 227);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 25);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblSpacing
            // 
            this.lblSpacing.AutoSize = true;
            this.lblSpacing.Location = new System.Drawing.Point(11, 179);
            this.lblSpacing.Name = "lblSpacing";
            this.lblSpacing.Size = new System.Drawing.Size(72, 13);
            this.lblSpacing.TabIndex = 26;
            this.lblSpacing.Text = "Cell Spacing: ";
            // 
            // txtCellSpacing
            // 
            this.txtCellSpacing.Location = new System.Drawing.Point(118, 176);
            this.txtCellSpacing.Name = "txtCellSpacing";
            this.txtCellSpacing.Size = new System.Drawing.Size(83, 20);
            this.txtCellSpacing.TabIndex = 5;
            this.txtCellSpacing.Text = "Default";
            // 
            // TablePropertiesDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 264);
            this.Controls.Add(this.lblSpacing);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblBorderSize);
            this.Controls.Add(this.txtCellSpacing);
            this.Controls.Add(this.txtBorderSize);
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
            this.Name = "TablePropertiesDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Table Properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Button btnBorderColor;
        private System.Windows.Forms.Label lblBorder;
        private System.Windows.Forms.Button btnBackgroundColor;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.Label lblBorderSize;
        private System.Windows.Forms.TextBox txtBorderSize;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblSpacing;
        private System.Windows.Forms.TextBox txtCellSpacing;
    }
}