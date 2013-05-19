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
    public partial class InsertTableDialog : Form
    {
        public InsertTableDialog()
        {
            InitializeComponent();
        }

        public string TableID
        {
            get
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    throw new Exception("You must speficy the table ID");
                }

                return txtId.Text;
            }
        }

        public int BorderSize
        {
            get
            {
                if (string.IsNullOrEmpty(txtBorderSize.Text))
                {
                    throw new Exception("You should specify the table border thickness");
                }

                int borderSize;
                if (!int.TryParse(txtBorderSize.Text, out borderSize))
                {
                    throw new Exception("Incorrect border thickness");
                }

                if (borderSize <= 0)
                {
                    throw new Exception("The border thickness should be a positive number");
                }

                return borderSize;
            }
        }

        public int Rows
        {
            get
            {
                if (string.IsNullOrEmpty(txtRows.Text))
                {
                    throw new Exception("You should specify the table row count");
                }

                int rows;
                if (!int.TryParse(txtRows.Text, out rows))
                {
                    throw new Exception("Incorrect table row count");
                }

                if (rows <= 0)
                {
                    throw new Exception("The table row count should be a positive number");
                }

                return rows;
            }
        }

        public int Columns
        {
            get
            {
                if (string.IsNullOrEmpty(txtColumns.Text))
                {
                    throw new Exception("You should specify the table column count");
                }

                int columns;
                if (!int.TryParse(txtColumns.Text, out columns))
                {
                    throw new Exception("Incorrect table column count");
                }

                if (columns <= 0)
                {
                    throw new Exception("The column count should be a positive number");
                }

                return columns;
            }
        }
        
        public Color BorderColor
        {
            get
            {
                return btnColor.BackColor;
            }
        }
		
        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlgColorChooser = new ColorDialog();
            dlgColorChooser.AllowFullOpen = true;
            dlgColorChooser.AnyColor = true;
            dlgColorChooser.ShowDialog();

            if (dlgColorChooser.Color != null)
            {
                btnColor.BackColor = dlgColorChooser.Color;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.TableID; 
                int borderSize = this.BorderSize;
                int rows = this.Rows;
                int columns = this.Columns;
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
