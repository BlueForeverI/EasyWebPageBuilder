namespace WinFormsHtmlEditor
{
    partial class InsertTableDialog
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
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblBorderSize = new System.Windows.Forms.Label();
            this.txtBorderSize = new System.Windows.Forms.TextBox();
            this.lblRows = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.lblCols = new System.Windows.Forms.Label();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.lblBorderColor = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 33);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(54, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Table ID: ";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(119, 30);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(83, 20);
            this.txtId.TabIndex = 0;
            // 
            // lblBorderSize
            // 
            this.lblBorderSize.AutoSize = true;
            this.lblBorderSize.Location = new System.Drawing.Point(12, 95);
            this.lblBorderSize.Name = "lblBorderSize";
            this.lblBorderSize.Size = new System.Drawing.Size(96, 13);
            this.lblBorderSize.TabIndex = 2;
            this.lblBorderSize.Text = "Border Thickness: ";
            // 
            // txtBorderSize
            // 
            this.txtBorderSize.Location = new System.Drawing.Point(119, 92);
            this.txtBorderSize.Name = "txtBorderSize";
            this.txtBorderSize.Size = new System.Drawing.Size(83, 20);
            this.txtBorderSize.TabIndex = 1;
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(229, 33);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(40, 13);
            this.lblRows.TabIndex = 3;
            this.lblRows.Text = "Rows: ";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(289, 30);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(83, 20);
            this.txtRows.TabIndex = 2;
            // 
            // lblCols
            // 
            this.lblCols.AutoSize = true;
            this.lblCols.Location = new System.Drawing.Point(229, 95);
            this.lblCols.Name = "lblCols";
            this.lblCols.Size = new System.Drawing.Size(53, 13);
            this.lblCols.TabIndex = 5;
            this.lblCols.Text = "Columns: ";
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(289, 92);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(83, 20);
            this.txtColumns.TabIndex = 3;
            // 
            // lblBorderColor
            // 
            this.lblBorderColor.AutoSize = true;
            this.lblBorderColor.Location = new System.Drawing.Point(12, 160);
            this.lblBorderColor.Name = "lblBorderColor";
            this.lblBorderColor.Size = new System.Drawing.Size(71, 13);
            this.lblBorderColor.TabIndex = 4;
            this.lblBorderColor.Text = "Border Color: ";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.Location = new System.Drawing.Point(106, 154);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(22, 23);
            this.btnColor.TabIndex = 4;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(163, 154);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 25);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(272, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // InsertTableDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 201);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lblBorderColor);
            this.Controls.Add(this.lblCols);
            this.Controls.Add(this.txtColumns);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.lblBorderSize);
            this.Controls.Add(this.txtBorderSize);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertTableDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Table";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblBorderSize;
        private System.Windows.Forms.TextBox txtBorderSize;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label lblCols;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.Label lblBorderColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}