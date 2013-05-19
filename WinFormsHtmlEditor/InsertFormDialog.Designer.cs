namespace WinFormsHtmlEditor
{
    partial class InsertFormDialog
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
            this.txtFormName = new System.Windows.Forms.TextBox();
            this.lblFormAction = new System.Windows.Forms.Label();
            this.txtFormAction = new System.Windows.Forms.TextBox();
            this.lblFormMethod = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.comboBoxFormMethod = new System.Windows.Forms.ComboBox();
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
            // txtFormName
            // 
            this.txtFormName.Location = new System.Drawing.Point(85, 21);
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.Size = new System.Drawing.Size(152, 20);
            this.txtFormName.TabIndex = 1;
            // 
            // lblFormAction
            // 
            this.lblFormAction.AutoSize = true;
            this.lblFormAction.Location = new System.Drawing.Point(12, 64);
            this.lblFormAction.Name = "lblFormAction";
            this.lblFormAction.Size = new System.Drawing.Size(43, 13);
            this.lblFormAction.TabIndex = 2;
            this.lblFormAction.Text = "Action: ";
            // 
            // txtFormAction
            // 
            this.txtFormAction.Location = new System.Drawing.Point(85, 61);
            this.txtFormAction.Name = "txtFormAction";
            this.txtFormAction.Size = new System.Drawing.Size(152, 20);
            this.txtFormAction.TabIndex = 2;
            // 
            // lblFormMethod
            // 
            this.lblFormMethod.AutoSize = true;
            this.lblFormMethod.Location = new System.Drawing.Point(12, 102);
            this.lblFormMethod.Name = "lblFormMethod";
            this.lblFormMethod.Size = new System.Drawing.Size(49, 13);
            this.lblFormMethod.TabIndex = 4;
            this.lblFormMethod.Text = "Method: ";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(137, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(28, 154);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 25);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // comboBoxFormMethod
            // 
            this.comboBoxFormMethod.FormattingEnabled = true;
            this.comboBoxFormMethod.Items.AddRange(new object[] {
            "Get",
            "Post"});
            this.comboBoxFormMethod.Location = new System.Drawing.Point(85, 99);
            this.comboBoxFormMethod.Name = "comboBoxFormMethod";
            this.comboBoxFormMethod.Size = new System.Drawing.Size(75, 21);
            this.comboBoxFormMethod.TabIndex = 3;
            // 
            // InsertFormDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(261, 200);
            this.Controls.Add(this.comboBoxFormMethod);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblFormMethod);
            this.Controls.Add(this.txtFormAction);
            this.Controls.Add(this.lblFormAction);
            this.Controls.Add(this.txtFormName);
            this.Controls.Add(this.lblFormName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertFormDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.TextBox txtFormName;
        private System.Windows.Forms.Label lblFormAction;
        private System.Windows.Forms.TextBox txtFormAction;
        private System.Windows.Forms.Label lblFormMethod;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox comboBoxFormMethod;
    }
}