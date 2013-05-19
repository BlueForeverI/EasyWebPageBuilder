using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HTMLBuilderLibrary;

namespace WinFormsHtmlEditor
{
    public partial class InsertFormDialog : Form
    {
        public InsertFormDialog()
        {
            InitializeComponent();
        }

        public List<string> ExistingFormNames
        {
            get;
            set;
        }

        public string FormName
        {
            get
            {
                if (string.IsNullOrEmpty(txtFormName.Text))
                {
                    throw new Exception("You should specify the form name");
                }

                if (txtFormName.Text.Contains(' '))
                {
                    throw new Exception("Invalid form name");
                }

                if (this.ExistingFormNames.Contains(txtFormName.Text))
                {
                    throw new Exception("The form already exists");
                }

                return txtFormName.Text;
            }
        }

        public string FormAction
        {
            get
            {
                if (string.IsNullOrEmpty(txtFormAction.Text))
                {
                    throw new Exception("You should specify the form action");
                }

                return txtFormAction.Text;
            }
        }

        public SubmitMethod FormMethod
        {
            get
            {
                string selectedItem = comboBoxFormMethod.SelectedItem.ToString();

                if (string.IsNullOrEmpty(selectedItem))
                {
                    throw new Exception("You should specify the form submit method");
                }

                if(selectedItem != "Get" && selectedItem != "Post")
                {
                    throw new Exception("Invalid form submit method");
                }

                SubmitMethod method = new SubmitMethod();
                switch (selectedItem)
                {
                    case "Get":
                        method = SubmitMethod.Get;
                        break;

                    case "Post":
                        method = SubmitMethod.Post;
                        break;
                }

                return method;
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
                string name = this.FormName;
                string action = this.FormAction;
                SubmitMethod method = this.FormMethod;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
