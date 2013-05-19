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
    public partial class CellPropertiesDialog : Form
    {
        public CellPropertiesDialog()
        {
            InitializeComponent();
        }

        public Color CellBackgroundColor
        {
            get
            {
                return this.btnBackgroundColor.BackColor;
            }
            set
            {
                this.btnBackgroundColor.BackColor = value;
            }
        }

        public Color CellBorderColor
        {
            get
            {
                return this.btnBorderColor.BackColor;
            }
            set
            {
                this.btnBorderColor.BackColor = value;
            }
        }

        public int? CellBorderSize
        {
            get
            {
                if (string.IsNullOrEmpty(this.txtBorderSize.Text))
                {
                    throw new Exception("You should specify the table border thickness");
                }

                if (txtBorderSize.Text == "Default")
                {
                    return null;
                }

                int borderSize;
                if (!Int32.TryParse(txtBorderSize.Text, out borderSize))
                {
                    throw new Exception("Incorrect cell border size");
                }

                if (borderSize <= 0)
                {
                    throw new Exception("The table border thickness should be a positive number");
                }

                return borderSize;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The table border thickness should be a positive number");
                }

                this.txtBorderSize.Text = value.ToString();
            }
        }

        public int? CellWidth
        {
            get
            {
                if (string.IsNullOrEmpty(this.txtWidth.Text))
                {
                    throw new Exception("You should specify the cell width");
                }

                else if (txtWidth.Text == "Default")
                {
                    return null;
                }

                int width;
                if (!Int32.TryParse(txtWidth.Text, out width))
                {
                    throw new Exception("Incorrect cell width");
                }

                if (width <= 0)
                {
                    throw new Exception("The cell width should be a positive number");
                }

                return width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The cell width should be a positive number");
                }

                this.txtWidth.Text = value.ToString();
            }
        }

        public int? CellHeight
        {
            get
            {
                if (string.IsNullOrEmpty(this.txtHeight.Text))
                {
                    throw new Exception("You should specify the cell height");
                }

                if (txtHeight.Text == "Default")
                {
                    return null;
                }

                int height;
                if (!Int32.TryParse(txtHeight.Text, out height))
                {
                    throw new Exception("Incorrect cell height");
                }

                if (height <= 0)
                {
                    throw new Exception("The cell height should be a positive number");
                }

                return height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The cell height should be a positive number");
                }

                this.txtHeight.Text = value.ToString();
            }
        }

        public int? Rowspan
        {
            get
            {
                if(string.IsNullOrEmpty(txtRowspan.Text))
                {
                    throw new Exception("You should specify the cell rowspan");
                }

                if (txtRowspan.Text == "Default")
                {
                    return null;
                }

                int rowspan;
                if(!int.TryParse(txtRowspan.Text, out rowspan))
                {
                    throw new Exception("Incorrect cell rowspan");
                }

                if(rowspan <= 0)
                {
                    throw new Exception("The cell rowspan should be a positive number");
                }

                return rowspan;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The cell rowspan should be a positive number");
                }

                this.txtRowspan.Text = value.ToString();
            }
        }

        public int? Colspan
        {
            get
            {
                if(string.IsNullOrEmpty(txtColspan.Text))
                {
                    throw new Exception("You should specify the cell colspan");
                }

                if (txtColspan.Text == "Default")
                {
                    return null;
                }

                int colspan;
                if(!int.TryParse(txtColspan.Text, out colspan))
                {
                    throw new Exception("Incorrect cell colspan");
                }

                if(colspan <= 0)
                {
                    throw new Exception("The cell colspan should be a positive number");
                }

                return colspan;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The cell colspan should be a positive number");
                }

                this.txtColspan.Text = value.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlgBackColor = new ColorDialog();
            dlgBackColor.AllowFullOpen = true;
            dlgBackColor.AnyColor = true;
            dlgBackColor.ShowDialog();

            if (dlgBackColor.Color != null)
            {
                this.btnBackgroundColor.BackColor = dlgBackColor.Color;
            }
        }

        private void btnBorderColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlgBorderColor = new ColorDialog();
            dlgBorderColor.AllowFullOpen = true;
            dlgBorderColor.AnyColor = true;
            dlgBorderColor.ShowDialog();

            if (dlgBorderColor.Color != null)
            {
                this.btnBorderColor.BackColor = dlgBorderColor.Color;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int? borderSize = this.CellBorderSize;
                int? width = this.CellWidth;
                int? height = this.CellHeight;
                int? rowspan = this.Rowspan;
                int? colspan = this.Colspan;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
