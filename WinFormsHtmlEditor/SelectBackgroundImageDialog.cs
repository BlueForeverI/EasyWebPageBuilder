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
    public partial class SelectBackgroundImageDialog : Form
    {
        public SelectBackgroundImageDialog()
        {
            InitializeComponent();
        }

        public string ImageLocation
        {
            get
            {
                if (string.IsNullOrEmpty(txtLocation.Text))
                {
                    throw new Exception("You should specify the image location");
                }

                return txtLocation.Text;
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
                string location = this.ImageLocation;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg, *.bmp, *.png, *.gif)|*.jpg;*.bmp;*.png;*.gif";
            dlg.Multiselect = false;
            dlg.ShowDialog();
            if (dlg.FileName != null)
            {
                txtLocation.Text = dlg.FileName;
            }
        }
    }
}
