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
    public partial class SelectTitleDialog : Form
    {
        public SelectTitleDialog()
        {
            InitializeComponent();
        }

        public string PageTitle
        {
            get
            {
                if (string.IsNullOrEmpty(txtPageTitle.Text))
                {
                    throw new Exception("You should specify the page title");
                }

                return txtPageTitle.Text;
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
                string title = this.PageTitle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
