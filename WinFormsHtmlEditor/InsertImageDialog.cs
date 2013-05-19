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
    public partial class InsertImageDialog : Form
    {
        public InsertImageDialog()
        {
            InitializeComponent();
        }

        public String ImageLocation
        {
            get
            {
                if (string.IsNullOrEmpty(txtLocation.Text))
                {
                    throw new Exception("You must specify the image location");
                }

                if (!txtLocation.Text.Contains(":\\") && !txtLocation.Text.Contains("http://"))
                {
                    throw new Exception("The specified image location is not valid");
                }

                return txtLocation.Text;
            }
        }

        public String ImageID
        {
            get
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    throw new Exception("You must specify the image ID");
                }

                return txtId.Text;
            }
        }

        public string AlternativeText
        {
            get
            {
                if (string.IsNullOrEmpty(txtAlt.Text))
                {
                    throw new Exception("You must specify the alternative text fot the image");
                }

                return txtAlt.Text;
            }
        }

        public int BorderSize
        {
            get
            {
                if (string.IsNullOrEmpty(txtBorder.Text))
                {
                    throw new Exception("You must specify the image border size");
                }

                int borderSize;
                if (!int.TryParse(txtBorder.Text, out borderSize))
                {
                    throw new Exception("Incorrect image border size");
                }

                if (borderSize < 0)
                {
                    throw new Exception("The image border should be a positive number");
                }

                return borderSize;
            }
        }

        public int ImageWidth
        {
            get
            {
                if (string.IsNullOrEmpty(txtWidth.Text))
                {
                    throw new Exception("You must specify the image width");
                }

                int imageWidth;
                if (!int.TryParse(txtWidth.Text, out imageWidth))
                {
                    throw new Exception("Incorrect image width");
                }
                if (imageWidth <= 0)
                {
                    throw new Exception("The image width should be a positive number");
                }

                return imageWidth;
            }
        }

        public int ImageHeight
        {
            get
            {
                if (string.IsNullOrEmpty(txtHeight.Text))
                {
                    throw new Exception("You must specify the image height");
                }

                int imageHeight;
                if (!int.TryParse(txtHeight.Text, out imageHeight))
                {
                    throw new Exception("Incorrect image height");
                }
                if (imageHeight <= 0)
                {
                    throw new Exception("The image height should be a positive number");
                }

                return imageHeight;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg, *.bmp, *.png, *.gif)|*.jpg;*.bmp;*.png;*.gif";
            dlg.Multiselect = false;
            
            if (dlg.ShowDialog() == DialogResult.OK && dlg.FileName != null)
            {
                txtLocation.Text = dlg.FileName;
                Bitmap selectedImage = new Bitmap(dlg.FileName);
                txtHeight.Text = selectedImage.Height.ToString();
                txtWidth.Text = selectedImage.Width.ToString();
                txtBorder.Text = "0";
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
                string imageId = this.ImageID;
                string altText = this.AlternativeText;
                int border = this.BorderSize;
                int width = this.ImageWidth;
                int height = this.ImageHeight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
