using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;
using ScintillaNet;
using HTMLBuilderLibrary;
using System.IO;
using System.Threading;

namespace WinFormsHtmlEditor
{
    public partial class MainWindow : Form
    {
        private Scintilla editor = new Scintilla();
        private HTMLBuilder builder;
        private string filePath = string.Empty;
        private bool newFile = false;
        private bool modifiedDocument = false;
        private bool openedDocument = false;

        public MainWindow()
        {
            InitializeComponent();

            editor.ConfigurationManager.Language = "html";
            editor.Margins[0].Width = 20;
            editor.Height = tabEditor.Height;
            editor.Width = tabEditor.Width;
            editor.LineWrap.Mode = WrapMode.Word;
            editor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            editor.DocumentChange += new EventHandler<NativeScintillaEventArgs>(editor_DocumentChange);
            tabEditor.Controls.Add(editor);

            browserDesign.DocumentText = "<html><body></body></html>";
            builder = new HTMLBuilder(browserDesign.Document.DomDocument as IHTMLDocument2);
            builder.EnterDesignMode();
            browserDesign.Focus();
        }

        private void editor_DocumentChange(object sender, NativeScintillaEventArgs e)
        {
            modifiedDocument = true;
        }

        private void browserDesign_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            modifiedDocument = true;

            if (e.KeyData == (Keys.Control | Keys.F))
            {
                modeTabs.SelectedTab = tabEditor;
                FindReplaceDialog dlgFind = new FindReplaceDialog();
                dlgFind.Scintilla = editor;
                dlgFind.ShowDialog();
                dlgFind.Activate();
                dlgFind.Focus();
                return;
            }
        }

        /// <summary>
        /// Converts a Color object to a RGB color
        /// </summary>
        /// <param name="selectedColor">The Color object to convert</param>
        /// <returns>The string representation of the RGB color</returns>
        internal static string ConvertColorToRgb(Color selectedColor)
        {
            StringBuilder rgbColor = new StringBuilder();
            rgbColor.Append("#");

            if (selectedColor.R == 0)
            {
                rgbColor.Append("00");
            }
            else
            {
                rgbColor.Append(selectedColor.R.ToString("X"));
            }

            if (selectedColor.G == 0)
            {
                rgbColor.Append("00");
            }
            else
            {
                rgbColor.Append(selectedColor.G.ToString("X"));
            }

            if (selectedColor.B == 0)
            {
                rgbColor.Append("00");
            }
            else
            {
                rgbColor.Append(selectedColor.B.ToString("X"));
            }

            return rgbColor.ToString();
        }

        /// <summary>
        /// Converts a RGB color to a Color object
        /// </summary>
        /// <param name="rgbColor">The RGB value of the color</param>
        /// <returns>The Color object</returns>
        internal static Color ConvertRgbToColor(string rgbColor)
        {
            string rgbValue = rgbColor.Remove(0, 1);
            
            int redValue = Convert.ToInt32(rgbValue.Substring(0, 2), 16);
            int greenValue = Convert.ToInt32(rgbValue.Substring(2, 2), 16);
            int blueValue = Convert.ToInt32(rgbValue.Substring(4, 2), 16);

            return Color.FromArgb(redValue, greenValue, blueValue);
        }

        /// <summary>
        /// Updates the editor when the Editor tab is selected
        /// </summary>
        private void UpdateEditor()
        {
            if (!string.IsNullOrEmpty(builder.HTMLContent))
            {
                editor.Text = builder.HTMLContent;
            }
            else
            {
                editor.Text = HTMLBuilder.FormatHtml(browserDesign.DocumentText);
            }

            editMenuItem.Enabled = false;
            insertMenuItem.Enabled = false;
            formatMenuItem.Enabled = false;
            tableMenuItem.Enabled = false;
            formMenuItem.Enabled = false;

            undoToolbarButton.Enabled = false;
            redoToolbarButton.Enabled = false;
            cutToolbarButton.Enabled = false;
            copyToolbarButton.Enabled = false;
            pasteToolbarButton.Enabled = false;
            fontToolbarButton.Enabled = false;
            fontColorToolbarButton.Enabled = false;
            hyperlinkToolbarButton.Enabled = false;
            imageToolbarButton.Enabled = false;
            tableToolbarButton.Enabled = false;
            listToolbarButton.Enabled = false;
            formToolbarButton.Enabled = false;
        }

        /// <summary>
        /// Updates the designer when the Designer tab is selected
        /// </summary>
        private void UpdateDesigner()
        {
            if (!string.IsNullOrEmpty(editor.Text))
            {
                builder.LoadHtmlContent(editor.Text);
            }

            EnableMenuItems();
        }

        private void EnableMenuItems()
        {
            editMenuItem.Enabled = true;
            insertMenuItem.Enabled = true;
            formatMenuItem.Enabled = true;
            tableMenuItem.Enabled = true;
            formMenuItem.Enabled = true;

            saveFileToolbarButton.Enabled = true;
            undoToolbarButton.Enabled = true;
            redoToolbarButton.Enabled = true;
            cutToolbarButton.Enabled = true;
            copyToolbarButton.Enabled = true;
            pasteToolbarButton.Enabled = true;
            fontToolbarButton.Enabled = true;
            fontColorToolbarButton.Enabled = true;
            hyperlinkToolbarButton.Enabled = true;
            imageToolbarButton.Enabled = true;
            tableToolbarButton.Enabled = true;
            listToolbarButton.Enabled = true;
            formToolbarButton.Enabled = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modifiedDocument)
            {
                DialogResult saveDocumentMsgBox = ShowSaveDocumentPrompt();
                switch (saveDocumentMsgBox)
                {
                    case DialogResult.Yes:
                        if (newFile)
                        {
                            saveToolStripMenuItem_Click(sender, e);
                        }
                        else
                        {
                            builder.SaveHtmlFile(filePath);
                        }
                        break;

                    case DialogResult.No:
                    case DialogResult.Cancel:
                        break;
                }
            }

            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "HTML Files (*.html, *.htm)|*.html;*.htm";
            dlgOpenFile.Multiselect = false;
            dlgOpenFile.Title = "Open HTML File";
            dlgOpenFile.ShowDialog();

            try
            {
                if (File.Exists(dlgOpenFile.FileName))
                {
                    builder.LoadHtmlFile(dlgOpenFile.FileName);
                    modeTabs.Visible = true;

                    filePath = dlgOpenFile.FileName;
                    string fileName = filePath.Split('\\').Last();
                    this.Text = fileName + " - Easy Web Page Builder";
                    newFile = false;
                    modifiedDocument = false;
                    openedDocument = true;
                    EnableMenuItems();
                    browserDesign.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "HTML File (*.html, *.htm)|*.html, *.htm";
            dlgSaveFile.OverwritePrompt = true;
            dlgSaveFile.DefaultExt = "*.html";
            dlgSaveFile.CheckPathExists = true;
            dlgSaveFile.AddExtension = true;
            dlgSaveFile.ShowDialog();

            try
            {
                if (!string.IsNullOrEmpty(dlgSaveFile.FileName))
                {
                    builder.MakeImagePathsRelative();
                    if (!string.IsNullOrEmpty(builder.HTMLContent))
                    {
                        builder.SaveHtmlFile(dlgSaveFile.FileName);
                    }
                    else
                    {
                        File.WriteAllText(dlgSaveFile.FileName, HTMLBuilder.FormatHtml(browserDesign.DocumentText));
                    }

                    FileInfo savedFile = new FileInfo(dlgSaveFile.FileName);
                    builder.CopyImagesToFilePath(savedFile.DirectoryName);
                    builder.LoadHtmlFile(savedFile.FullName);
                    this.Text = savedFile.Name + " - Easy Web Page Builder";

                    modifiedDocument = false;
                    newFile = false;
                }
            }
            catch (Exception ex)
            {
                //this exception does not make any sense
                if(ex.Message.Contains("URI formats"))
                {
                    builder.LoadHtmlFile(dlgSaveFile.FileName);
                    this.Text = new FileInfo(dlgSaveFile.FileName).Name + " - Easy Web Page Builder";
                    modifiedDocument = false;
                    newFile = false;
                    return;
                }

                MessageBox.Show(ex.Message + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modifiedDocument)
            {
                DialogResult saveDocumentMsgBox = ShowSaveDocumentPrompt();
                switch (saveDocumentMsgBox)
                {
                    case DialogResult.Yes:
                        if (newFile)
                        {
                            saveToolStripMenuItem_Click(sender, e);
                        }
                        else
                        {
                            builder.SaveHtmlFile(filePath);
                        }
                        break;

                    case DialogResult.No:
                    case DialogResult.Cancel:
                        break;
                }
            }

            this.Text = "Untitled - Easy Web Page Builder";
            newFile = true;
            openedDocument = true;
            filePath = "Untitled";
            modeTabs.Visible = true;
            EnableMenuItems();
            builder.ClearHtmlContent();
            browserDesign.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void modeTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (modeTabs.SelectedIndex)
            {
                case 0:
                    UpdateDesigner();
                    browserDesign.Focus();
                    break;
                case 1:
                    UpdateEditor();
                    editor.Focus();
                    break;
            }
        }

        private void pictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertImageDialog dlgInsertImage = new InsertImageDialog();
            dlgInsertImage.ShowDialog();
            if (dlgInsertImage.DialogResult == DialogResult.OK)
            {
                string location = dlgInsertImage.ImageLocation;
                string id = dlgInsertImage.ImageID;
                string altText = dlgInsertImage.AlternativeText;
                int borderSize = dlgInsertImage.BorderSize;
                int width = dlgInsertImage.ImageWidth;
                int height = dlgInsertImage.ImageHeight;

                Thread insertImageThread = new Thread(new ThreadStart(() =>
                    {
                        builder.InsertImage(location, id, borderSize, altText, width, height);
                    }));

                insertImageThread.Start();
                modifiedDocument = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FontDialog dlgFontChooser = new FontDialog();
                Font textFont = builder.GetSelectedTextFont();
                if (textFont != null)
                {
                    dlgFontChooser.Font = textFont;
                }

                if (dlgFontChooser.ShowDialog() == DialogResult.OK)
                {
                    Font selectedFont = dlgFontChooser.Font;
                    string fontName = selectedFont.Name; ;
                    builder.ChangeFontFamily(fontName);

                    double fontSize = Math.Ceiling((double)selectedFont.Size);
                    builder.ChangeFontSize(fontSize.ToString());

                    builder.MakeSelectionBold(!selectedFont.Bold);
                    builder.MakeSelectionItalic(!selectedFont.Italic);
                    builder.MakeSelectionStrikeout(!selectedFont.Strikeout);
                    builder.MakeSelectionUnderlined(!selectedFont.Underline);

                    modifiedDocument = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog dlgColorChooser = new ColorDialog();
                dlgColorChooser.AllowFullOpen = true;
                dlgColorChooser.AnyColor = true;
                if (dlgColorChooser.ShowDialog() == DialogResult.OK)
                {
                    Color selectedColor = dlgColorChooser.Color;
                    string rgbColor = ConvertColorToRgb(selectedColor);

                    builder.ChangeFontColor(rgbColor);
                    modifiedDocument = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }       

        /// <summary>
        /// Asks the user for saving the modified document
        /// </summary>
        /// <returns>The user's choice</returns>
        private DialogResult ShowSaveDocumentPrompt()
        {
            DialogResult saveDocumentMsgBox = MessageBox.Show(string.Format("Save file \"{0}\" ?", filePath),
                "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            return saveDocumentMsgBox;
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertTableDialog dlgInsertTable = new InsertTableDialog();
            dlgInsertTable.ShowDialog();

            if (dlgInsertTable.DialogResult == DialogResult.OK)
            {
                string id = dlgInsertTable.TableID;
                int borderSize = dlgInsertTable.BorderSize;
                int rows = dlgInsertTable.Rows;
                int cols = dlgInsertTable.Columns;
                string borderColor = MainWindow.ConvertColorToRgb(dlgInsertTable.BorderColor);

                Thread insertTableThread = new Thread(new ThreadStart(() =>
                    {
                        builder.InsertTable(id, rows, cols, borderSize, borderColor);
                    }));

                insertTableThread.Start();
                modifiedDocument = true;
            }
        }

        private void leftAlignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            builder.AlignSelection("left");
            modifiedDocument = true;
        }

        private void rightAlignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            builder.AlignSelection("right");
            modifiedDocument = true;
        }

        private void centerAlignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            builder.AlignSelection("center");
            modifiedDocument = true;
        }

        private void headingStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertHeadingDialog dlgInsertHeading = new InsertHeadingDialog();
            dlgInsertHeading.ShowDialog();

            if (dlgInsertHeading.DialogResult == DialogResult.OK)
            {
                string headingText = dlgInsertHeading.HeadingText;
                int headingSize = dlgInsertHeading.HeadingSize;
                builder.InsertHeading(headingText, headingSize);
                modifiedDocument = true;
            }
        }

        private void hyperlinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertHyperlinkDialog dlgInsertHyperlink = new InsertHyperlinkDialog();
            dlgInsertHyperlink.ShowDialog();

            if (dlgInsertHyperlink.DialogResult == DialogResult.OK)
            {
                string hyperlinkText = dlgInsertHyperlink.HyperlinkText;
                string hyperlinkUrl = dlgInsertHyperlink.HyperlinkUrl;
                builder.InsertHyperlink(hyperlinkText, hyperlinkUrl);
                modifiedDocument = true;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            builder.Undo();
            modifiedDocument = true;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            builder.Redo();
            modifiedDocument = true;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            builder.Cut();
            modifiedDocument = true;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            builder.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            builder.Paste();
            modifiedDocument = true;
        }

        private void pageBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlgColorChooser = new ColorDialog();
            dlgColorChooser.AllowFullOpen = true;
            dlgColorChooser.AnyColor = true;

            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = dlgColorChooser.Color;
                string rgbColor = MainWindow.ConvertColorToRgb(selectedColor);
                builder.SetDocumentBackgroundColor(rgbColor);
                modifiedDocument = true;
            }
        }

        private void pageBackgroundImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectBackgroundImageDialog dlgSelectBackImage = new SelectBackgroundImageDialog();
            dlgSelectBackImage.ShowDialog();

            if (dlgSelectBackImage.DialogResult == DialogResult.OK)
            {
                string location = dlgSelectBackImage.ImageLocation;
                builder.SetDocumentBackgroundImage(location);
                modifiedDocument = true;
            }
        }

        private void pageTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectTitleDialog dlgSelectTitle = new SelectTitleDialog();
            dlgSelectTitle.ShowDialog();

            if (dlgSelectTitle.DialogResult == DialogResult.OK)
            {
                builder.SetTitle(dlgSelectTitle.PageTitle);
                modifiedDocument = true;
            }
        }

        private void horizontalLineStripMenuItem_Click(object sender, EventArgs e)
        {
            builder.InsertHorizontalLine();
            modifiedDocument = true;
        }

        private void cellPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IHTMLTableCell selectedElement = builder.GetSelectedTableCellElement();
            try
            {
                TableCell selectedCell = builder.GetSelectedTableCell();
                CellPropertiesDialog dlgCellProperties = new CellPropertiesDialog();

                if (selectedCell.BackgroundColor != null)
                {
                    dlgCellProperties.CellBackgroundColor = ConvertRgbToColor(selectedCell.BackgroundColor);
                }
                if (selectedCell.BorderColor != null)
                {
                    dlgCellProperties.CellBorderColor = ConvertRgbToColor(selectedCell.BorderColor);
                }
                if (selectedCell.BorderSize != null)
                {
                    dlgCellProperties.CellBorderSize = selectedCell.BorderSize;
                }
                if (selectedCell.Height != null)
                {
                    dlgCellProperties.CellHeight = selectedCell.Height;
                }
                if (selectedCell.Width != null)
                {
                    dlgCellProperties.CellWidth = selectedCell.Width;
                }
                if (selectedCell.Rowspan != null)
                {
                    dlgCellProperties.Rowspan = selectedCell.Rowspan;
                }
                if (selectedCell.Colspan != null)
                {
                    dlgCellProperties.Colspan = selectedCell.Colspan;
                }

                dlgCellProperties.ShowDialog();
                if (dlgCellProperties.DialogResult == DialogResult.OK)
                {
                    builder.ChangeCellProperty(selectedElement, CellProperties.BackgroundColor,
                        ConvertColorToRgb(dlgCellProperties.CellBackgroundColor));
                    builder.ChangeCellProperty(selectedElement, CellProperties.BorderColor,
                        ConvertColorToRgb(dlgCellProperties.CellBorderColor));
                    builder.ChangeCellProperty(selectedElement, CellProperties.BorderSize,
                        dlgCellProperties.CellBorderSize.ToString());
                    builder.ChangeCellProperty(selectedElement, CellProperties.Height,
                        dlgCellProperties.CellHeight.ToString());
                    builder.ChangeCellProperty(selectedElement, CellProperties.Width,
                        dlgCellProperties.CellWidth.ToString());
                    builder.ChangeCellProperty(selectedElement, CellProperties.Rowspan,
                        dlgCellProperties.Rowspan.ToString());
                    builder.ChangeCellProperty(selectedElement, CellProperties.Colspan,
                        dlgCellProperties.Colspan.ToString());

                    modifiedDocument = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tablePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IHTMLTable selectedElement = builder.GetSelectedTableElement();
                Table selectedTable = builder.GetSelectedTable();

                TablePropertiesDialog dlgTableProperties = new TablePropertiesDialog();
                if (selectedTable.BackgroundColor != null)
                {
                    dlgTableProperties.TableBackgroundColor = ConvertRgbToColor(selectedTable.BackgroundColor);
                }
                if (selectedTable.BorderColor != null)
                {
                    dlgTableProperties.TableBorderColor = ConvertRgbToColor(selectedTable.BorderColor);
                }
                if (selectedTable.BorderSize != null)
                {
                    dlgTableProperties.TableBorderSize = selectedTable.BorderSize;
                }
                if (selectedTable.Width != null)
                {
                    dlgTableProperties.TableWidth = selectedTable.Width;
                }
                if (selectedTable.Height != null)
                {
                    dlgTableProperties.TableHeight = selectedTable.Height;
                }
                if (selectedTable.CellSpacing != null)
                {
                    dlgTableProperties.TableCellSpacing = selectedTable.CellSpacing;
                }

                dlgTableProperties.ShowDialog();
                if (dlgTableProperties.DialogResult == DialogResult.OK)
                {
                    builder.ChangeTableProperty(selectedElement, TableProperties.BackgroundColor,
                        ConvertColorToRgb(dlgTableProperties.TableBackgroundColor));
                    builder.ChangeTableProperty(selectedElement, TableProperties.BorderColor,
                        ConvertColorToRgb(dlgTableProperties.TableBorderColor));
                    builder.ChangeTableProperty(selectedElement, TableProperties.BorderSize,
                        dlgTableProperties.TableBorderSize.ToString());
                    builder.ChangeTableProperty(selectedElement, TableProperties.Height,
                        dlgTableProperties.TableHeight.ToString());
                    builder.ChangeTableProperty(selectedElement, TableProperties.Width,
                        dlgTableProperties.TableWidth.ToString());
                    builder.ChangeTableProperty(selectedElement, TableProperties.CellSpacing,
                        dlgTableProperties.TableCellSpacing.ToString());

                    modifiedDocument = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            builder.DeleteSelectedCell();
            modifiedDocument = true;
            
        }

        private void toolStripMenuItemTableInsert_Click(object sender, EventArgs e)
        {
            tableToolStripMenuItem_Click(sender, e);
        }

        private void insertCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            builder.InsertCell();
            modifiedDocument = true;

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modifiedDocument == true && newFile == false)
            {
                if (!string.IsNullOrEmpty(builder.HTMLContent))
                {
                    builder.SaveHtmlFile(filePath);
                }
                else
                {
                    File.WriteAllText(filePath, HTMLBuilder.FormatHtml(browserDesign.DocumentText));
                }

                modifiedDocument = false;
            }
            else if (modifiedDocument == true && newFile == true)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void fileMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = modifiedDocument;
            saveAsToolStripMenuItem.Enabled = openedDocument;
        }

        private void tableMenuItem_Click(object sender, EventArgs e)
        {
            cellPropertiesToolStripMenuItem.Enabled = (builder.GetSelectedTableCell() != null);
            insertCellToolStripMenuItem.Enabled = (builder.GetSelectedTableCell() != null);
            deleteCellToolStripMenuItem.Enabled = (builder.GetSelectedTableCell() != null);
            tablePropertiesToolStripMenuItem.Enabled = (builder.GetSelectedTableCell() != null);
        }

        private void ApplicationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modifiedDocument)
            {
                DialogResult saveDocumentMsgBox = ShowSaveDocumentPrompt();
                switch (saveDocumentMsgBox)
                {
                    case DialogResult.Yes:
                        if (newFile)
                        {
                            saveToolStripMenuItem_Click(sender, e);
                        }
                        else
                        {
                            builder.SaveHtmlFile(filePath);
                        }
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                }
            }
        }

        private void undoContextMenuItem_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem_Click(sender, e);
        }

        private void redoContextMenuItem_Click(object sender, EventArgs e)
        {
            redoToolStripMenuItem_Click(sender, e);
        }

        private void cutContextMenuItem_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void copyContextMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void pasteContextMenuItem_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }

        private void backgroundColorContextMenuItem_Click(object sender, EventArgs e)
        {
            pageBackgroundColorToolStripMenuItem_Click(sender, e);
        }

        private void cellPropertiesContextMenuItem_Click(object sender, EventArgs e)
        {
            cellPropertiesToolStripMenuItem_Click(sender, e);
        }

        private void insertCellContextMenuItem_Click(object sender, EventArgs e)
        {
            insertCellToolStripMenuItem_Click(sender, e);
        }

        private void deleteCellContextMenuItem_Click(object sender, EventArgs e)
        {
            deleteCellToolStripMenuItem_Click(sender, e);
        }

        private void tablePropertiesContextMenuItem_Click(object sender, EventArgs e)
        {
            tablePropertiesToolStripMenuItem_Click(sender, e);
        }

        private void contextMenu_Opened(object sender, EventArgs e)
        {
            cellContextMenuItem.Enabled = (builder.GetSelectedTableCell() != null);
            tablePropertiesContextMenuItem.Enabled = (builder.GetSelectedTableCell() != null);
        }

        private void newFileToolbarButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void openFileToolbarButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void saveFileToolbarButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void undoToolbarButton_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem_Click(sender, e);
        }

        private void redoToolbarButton_Click(object sender, EventArgs e)
        {
            redoToolStripMenuItem_Click(sender, e);
        }

        private void cutToolbarButton_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void copyToolbarButton_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void pasteToolbarButton_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }

        private void hyperlinkToolbarButton_Click(object sender, EventArgs e)
        {
            hyperlinkToolStripMenuItem_Click(sender, e);
        }

        private void imageToolbarButton_Click(object sender, EventArgs e)
        {
            pictureToolStripMenuItem_Click(sender, e);
        }

        private void tableToolbarButton_Click(object sender, EventArgs e)
        {
            tableToolStripMenuItem_Click(sender, e);
        }

        private void fontToolbarButton_Click(object sender, EventArgs e)
        {
            fontToolStripMenuItem_Click(sender, e);
        }

        private void fontColorToolbarButton_Click(object sender, EventArgs e)
        {
            fontColorToolStripMenuItem_Click(sender, e);
        }

        private void formToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertFormDialog dlgInsertForm = new InsertFormDialog();
            dlgInsertForm.ExistingFormNames = builder.GetFormNames();
            if (dlgInsertForm.ShowDialog() == DialogResult.OK)
            {
                builder.InsertForm(dlgInsertForm.FormName, dlgInsertForm.FormAction,
                    dlgInsertForm.FormMethod);
            }
        }

        private void insertFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formToolStripMenuItem_Click(sender, e);
        }

        private void insertInputFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (builder.GetFormNames().Count != 0)
            {
                InsertInputFieldDialog dlgInsertInput = new InsertInputFieldDialog();
                dlgInsertInput.ExistingFormNames = builder.GetFormNames();
                if (dlgInsertInput.ShowDialog() == DialogResult.OK)
                {
                    builder.InsertInputField(dlgInsertInput.FieldName, dlgInsertInput.FormName,
                        dlgInsertInput.FieldType, dlgInsertInput.FieldValue);
                }
            }
            else
            {
                MessageBox.Show("There are no forms inserted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertListDialog dlgInsertList = new InsertListDialog();
            if (dlgInsertList.ShowDialog() == DialogResult.OK)
            {
                builder.InsertList(dlgInsertList.Ordered, dlgInsertList.ListType,
                    dlgInsertList.ListItems);
            }
        }

        private void listToolbarButton_Click(object sender, EventArgs e)
        {
            listToolStripMenuItem_Click(sender, e);
        }

        private void formToolbarButton_Click(object sender, EventArgs e)
        {
            insertFormToolStripMenuItem_Click(sender, e);
        }
    }
}
