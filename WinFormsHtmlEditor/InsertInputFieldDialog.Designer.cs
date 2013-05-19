namespace WinFormsHtmlEditor
{
    partial class InsertInputFieldDialog
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
            this.lblFormName = new System.Windows.Forms.Label();
            this.comboBoxFormNames = new System.Windows.Forms.ComboBox();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.lblInputType = new System.Windows.Forms.Label();
            this.comboBoxInputType = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtFieldValue = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFormName
            // 
            this.lblFormName.AutoSize = true;
            this.lblFormName.Location = new System.Drawing.Point(12, 24);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(67, 13);
            this.lblFormName.TabIndex = 0;
            this.lblFormName.Text = "Form Name: ";
            // 
            // comboBoxFormNames
            // 
            this.comboBoxFormNames.FormattingEnabled = true;
            this.comboBoxFormNames.Location = new System.Drawing.Point(113, 21);
            this.comboBoxFormNames.Name = "comboBoxFormNames";
            this.comboBoxFormNames.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFormNames.TabIndex = 1;
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(12, 69);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(66, 13);
            this.lblFieldName.TabIndex = 2;
            this.lblFieldName.Text = "Field Name: ";
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(113, 66);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(152, 20);
            this.txtFieldName.TabIndex = 2;
            // 
            // lblInputType
            // 
            this.lblInputType.AutoSize = true;
            this.lblInputType.Location = new System.Drawing.Point(12, 115);
            this.lblInputType.Name = "lblInputType";
            this.lblInputType.Size = new System.Drawing.Size(64, 13);
            this.lblInputType.TabIndex = 5;
            this.lblInputType.Text = "Input Type: ";
            // 
            // comboBoxInputType
            // 
            this.comboBoxInputType.FormattingEnabled = true;
            this.comboBoxInputType.Items.AddRange(new object[] {
            "Text",
            "Password",
            "Button",
            "Submit"});
            this.comboBoxInputType.Location = new System.Drawing.Point(113, 112);
            this.comboBoxInputType.Name = "comboBoxInputType";
            this.comboBoxInputType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInputType.TabIndex = 3;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(12, 162);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 7;
            this.lblValue.Text = "Value";
            // 
            // txtFieldValue
            // 
            this.txtFieldValue.Location = new System.Drawing.Point(113, 159);
            this.txtFieldValue.Name = "txtFieldValue";
            this.txtFieldValue.Size = new System.Drawing.Size(152, 20);
            this.txtFieldValue.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(165, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(56, 208);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 25);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // InsertInputFieldDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 258);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtFieldValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.comboBoxInputType);
            this.Controls.Add(this.lblInputType);
            this.Controls.Add(this.txtFieldName);
            this.Controls.Add(this.lblFieldName);
            this.Controls.Add(this.comboBoxFormNames);
            this.Controls.Add(this.lblFormName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertInputFieldDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Input Field";
            this.Load += new System.EventHandler(this.InsertInputFieldDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.ComboBox comboBoxFormNames;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.Label lblInputType;
        private System.Windows.Forms.ComboBox comboBoxInputType;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtFieldValue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}