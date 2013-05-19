using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsHtmlEditor
{
    public partial class InsertHeadingDialog : Form
    {
        public InsertHeadingDialog()
        {
            InitializeComponent();
        }

        public string HeadingText
        {
            get
            {
                if (string.IsNullOrEmpty(txtHeadingText.Text))
                {
                    throw new Exception("You should enter the heading text");
                }

                return txtHeadingText.Text;
            }
        }

        public int HeadingSize
        {
            get
            {
                if (string.IsNullOrEmpty(txtHeadingSize.Text))
                {
                    throw new Exception("You should specify the heading size");
                }

                int size;
                if (!int.TryParse(txtHeadingSize.Text, out size))
                {
                    throw new Exception("Incorrect heading size");
                }
                else
                {
                    if (size < 1 || size > 6)
                    {
                        throw new Exception("The heading size should be between 1 and 6");
                    }
                }

                return size;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string text = this.HeadingText;
                int size = this.HeadingSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
