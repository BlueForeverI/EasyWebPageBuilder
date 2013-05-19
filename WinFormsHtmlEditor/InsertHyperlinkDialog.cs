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
    public partial class InsertHyperlinkDialog : Form
    {
        public InsertHyperlinkDialog()
        {
            InitializeComponent();
        }

        public string HyperlinkText
        {
            get
            {
                if (string.IsNullOrEmpty(txtHyperlinkText.Text))
                {
                    throw new Exception("You should specify the hyperlink text");
                }

                return this.txtHyperlinkText.Text;
            }
        }

        public string HyperlinkUrl
        {
            get
            {
                if (string.IsNullOrEmpty(txtHyperlinkUrl.Text))
                {
                    throw new Exception("You should specify the hyperlink URL");
                }

                if (!txtHyperlinkUrl.Text.Contains('.') && !txtHyperlinkUrl.Text.Contains(@"http://"))
                {
                    throw new Exception("Incorrect URL");
                }

                return txtHyperlinkUrl.Text;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string text = this.HyperlinkText;
                string url = this.HyperlinkUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
