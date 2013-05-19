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
    public partial class TablePropertiesDialog : Form
    {
        public TablePropertiesDialog()
        {
            InitializeComponent();
        }

        public Color TableBackgroundColor
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

        public Color TableBorderColor
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

        public int? TableBorderSize
        {
            get
            {
                if(string.IsNullOrEmpty(this.txtBorderSize.Text))
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
                    throw new Exception("Incorrect table border size");
                }
                if(borderSize <= 0)
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

        public int? TableWidth
        {
            get
            {
                if (string.IsNullOrEmpty(this.txtWidth.Text))
                {
                    throw new Exception("You should specify the table width");
                }

                if (txtWidth.Text == "Default")
                {
                    return null;
                }

                int width;
                if (!Int32.TryParse(txtWidth.Text, out width))
                {
                    throw new Exception("Incorrect table width");
                }

                if (width <= 0)
                {
                    throw new Exception("The table width should be a positive number");
                }

                return width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The table width should be a positive number");
                }

                this.txtWidth.Text = value.ToString();
            }
        }

        public int? TableHeight
        {
            get
            {
                if (string.IsNullOrEmpty(this.txtHeight.Text))
                {
                    throw new Exception("You should specify the table height");
                }

                if (txtHeight.Text == "Default")
                {
                    return null;
                }

                int height;
                if (!Int32.TryParse(txtHeight.Text, out height))
                {
                    throw new Exception("Incorrect table height");
                }

                if (height <= 0)
                {
                    throw new Exception("The table height should be a positive number");
                }

                return height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The table height should be a positive number");
                }

                this.txtHeight.Text = value.ToString();
            }
        }

        public int? TableCellSpacing
        {
            get
            {
                if (string.IsNullOrEmpty(this.txtCellSpacing.Text))
                {
                    throw new Exception("You should specify the table cell spacing");
                }

                if (txtCellSpacing.Text == "Default")
                {
                    return null;
                }

                int cellSpacing;
                if (!Int32.TryParse(txtCellSpacing.Text, out cellSpacing))
                {
                    throw new Exception("Incorrect table cell spacing");
                }

                if (cellSpacing < 0)
                {
                    throw new Exception("The table cell spacing should be a positive number or 0");
                }

                return cellSpacing;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("The table cell spacing should be a positive number or 0");
                }

                this.txtCellSpacing.Text = value.ToString();
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
                int? borderSize = this.TableBorderSize;
                int? width = this.TableWidth;
                int? height = this.TableHeight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
