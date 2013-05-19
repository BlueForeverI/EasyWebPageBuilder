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
    public partial class InsertInputFieldDialog : Form
    {
        public InsertInputFieldDialog()
        {
            InitializeComponent();
        }

        private void InsertInputFieldDialog_Load(object sender, EventArgs e)
        {
            foreach (string formName in this.ExistingFormNames)
            {
                this.comboBoxFormNames.Items.Add(formName);
            }
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
                string selectedItem = this.comboBoxFormNames.SelectedItem.ToString();

                if (string.IsNullOrEmpty(selectedItem))
                {
                    throw new Exception("You should specify the form name");
                }

                if(!this.ExistingFormNames.Contains(selectedItem))
                {
                    throw new Exception("Invalid form name");
                }

                return selectedItem;
            }
        }

        public string FieldName
        {
            get
            {
                if (string.IsNullOrEmpty(txtFieldName.Text))
                {
                    throw new Exception("You should specify the field name");
                }

                if (txtFieldName.Text.Contains(' '))
                {
                    throw new Exception("Invalid field name");
                }

                return txtFieldName.Text;
            }
        }

        public InputFieldType FieldType
        {
            get
            {
                string selectedItem = this.comboBoxInputType.SelectedItem.ToString();

                if (string.IsNullOrEmpty(selectedItem))
                {
                    throw new Exception("You should specify the field type");
                }

                if (selectedItem != "Text" && selectedItem !=  "Button" 
                        && selectedItem != "Password" && selectedItem != "Submit")
                {
                    throw new Exception("Invalid field type");
                }

                InputFieldType fieldType = new InputFieldType();
                switch (selectedItem)
                {
                    case "Text":
                        fieldType = InputFieldType.Text;
                        break;

                    case "Button":
                        fieldType = InputFieldType.Button;
                        break;

                    case "Password":
                        fieldType = InputFieldType.Password;
                        break;

                    case "Submit":
                        fieldType = InputFieldType.Submit;
                        break;
                }

                return fieldType;
            }
        }

        public string FieldValue
        {
            get
            {
                return this.txtFieldValue.Text;
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
                string formName = this.FormName;
                string fieldName = this.FieldName;
                InputFieldType type = this.FieldType;
                string value = this.FieldValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
