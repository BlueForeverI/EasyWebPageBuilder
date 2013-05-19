using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using mshtml;
using System.Drawing;
using System.IO;

namespace HTMLBuilderLibrary
{
    public enum InputFieldType
    {
        Text,
        Password,
        Button,
        Submit
    }

    public enum SubmitMethod
    {
        Get,
        Post
    }

    public enum ListType
    {
        CapitalLetters,
        LowerLetters,
        CapitalRoman,
        LowerRoman,
        Decimal,
        Disc,
        Circle,
        Square
    }

    /// <summary>
    /// The class that provides HTML editing functionality
    /// </summary>
    public class HTMLBuilder
    {
        private IHTMLDocument2 document;        
        private List<string> imagePaths = new List<string>();           //list that contains the 'src' attributes of all 
                                                                        //images in the document

        public HTMLBuilder(IHTMLDocument2 doc)
        {
            this.document = doc;
        }

        /// <summary>
        /// The HTML representation of the document
        /// </summary>
        public string HTMLContent
        {
            get
            {
                IHTMLElementCollection htmlElements = this.document.all;
                
                if (htmlElements.item(0).outerHtml != null)
                {
                    return FormatHtml(htmlElements.item(0).outerHtml);
                }
                else
                {
                    return string.Empty;
                }
            }
            private set
            {
                this.LoadHtmlContent(value);
            }
        }


        /// <summary>
        /// Formats the given string in a valid HTML code
        /// </summary>
        /// <param name="nativeTags">The native code to format</param>
        /// <returns></returns>
        public static string FormatHtml(string nativeTags)
        {
            string upperTags = nativeTags.Replace("<META content=\"MSHTML 6.00.2900.2180\" name=GENERATOR>",
                "");

            StringBuilder strBuilder = new StringBuilder(upperTags);

            strBuilder.Replace("<HTML", "<html");
            strBuilder.Replace("<html>", "<html>\n");
            strBuilder.Replace("</HTML>", "\n</html>");
            strBuilder.Replace("<BODY", "<body");
            strBuilder.Replace("</BODY>", "\n</body>");
            strBuilder.Replace("<HEAD", "<head");
            strBuilder.Replace("</HEAD>", "</head>");
            strBuilder.Replace("<TITLE", "<title");
            strBuilder.Replace("</TITLE>", "</title>");
            strBuilder.Replace("<TABLE", "<table");
            strBuilder.Replace("</TABLE>", "</table>");
            strBuilder.Replace("<TBODY", "<tbody");
            strBuilder.Replace("</TBODY>", "</tbody>");
            strBuilder.Replace("<DIV", "<div");
            strBuilder.Replace("</DIV>", "</div>");
            strBuilder.Replace("<P", "<p");
            strBuilder.Replace("</P>", "</p>");
            strBuilder.Replace("<A", "<a");
            strBuilder.Replace("</A>", "</a>");
            strBuilder.Replace("<UL", "<ul");
            strBuilder.Replace("</UL>", "</ul>");
            strBuilder.Replace("<OL", "<ol");
            strBuilder.Replace("</OL>", "</ol>");
            strBuilder.Replace("<LI", "<li");
            strBuilder.Replace("</LI>", "</li>");
            strBuilder.Replace("<TR", "<tr");
            strBuilder.Replace("</TR>", "</tr>");
            strBuilder.Replace("<TD", "<td");
            strBuilder.Replace("</TD>", "</td>");
            strBuilder.Replace("<HR", "<hr");
            strBuilder.Replace("</HR>", "</hr>");
            strBuilder.Replace("<IMG", "<img");
            strBuilder.Replace("</IMG>", "</img>");
            strBuilder.Replace("<H", "<h");
            strBuilder.Replace("<BR>", "<br />\n");
            strBuilder.Replace("</H1>", "</h1>");
            strBuilder.Replace("</H2>", "</h2>");
            strBuilder.Replace("</H3>", "</h3>");
            strBuilder.Replace("</H4>", "</h4>");
            strBuilder.Replace("</H5>", "</h5>");
            strBuilder.Replace("</H6>", "</h6>");
            strBuilder.Replace("<FORM", "<form");
            strBuilder.Replace("</FORM>", "\n</form>");
            strBuilder.Replace("<META", "<meta");
            strBuilder.Replace("<INPUT", "<input");
            strBuilder.Replace("</INPUT>", "</input>");
            strBuilder.Replace("<STYLE", "<style");
            strBuilder.Replace("</STYLE>", "</style>");
            strBuilder.Replace("FONT-WEIGHT:", "font-weight:");
            strBuilder.Replace("FONT-FAMILY:", "font-family:");
            strBuilder.Replace("FONT-STYLE:", "font-style:");
            strBuilder.Replace("FONT-WEIGHT:", "font-weight:");
            strBuilder.Replace("FONT-FAMILY:", "font-family:");
            strBuilder.Replace("FONT-SIZE:", "font-size:");
            strBuilder.Replace("TEXT-ALIGN:", "text-align:");
            strBuilder.Replace("BORDER-WIDTH:", "border-width:");
            strBuilder.Replace("POSITION:", "position:");
            strBuilder.Replace("TEXT-DECORATION:", "text-decoration:");
            strBuilder.Replace("BORDER-TOP-WIDTH:", "border-top-width:");
            strBuilder.Replace("BORDER-LEFT-WIDTH:", "border-left-width:");
            strBuilder.Replace("BORDER-BOTTOM-WIDTH:", "border-bottom-width:");
            strBuilder.Replace("BORDER-RIGHT-WIDTH:", "border-right-width:");
            strBuilder.Replace("BORDER-TOP-COLOR:", "border-top-color:");
            strBuilder.Replace("BORDER-LEFT-COLOR:", "border-left-color:");
            strBuilder.Replace("BORDER-BOTTOM-COLOR:", "border-bottom-color:");
            strBuilder.Replace("BORDER-RIGHT-COLOR:", "border-right-color:");
            strBuilder.Replace("BORDER-TOP:", "border-top:");
            strBuilder.Replace("BORDER-LEFT:", "border-left:");
            strBuilder.Replace("BORDER-BOTTOM:", "border-bottom:");
            strBuilder.Replace("BORDER-RIGHT:", "border-right:");
            strBuilder.Replace("BACKGROUND-COLOR:", "background-color:");
            strBuilder.Replace("COLOR:", "color:");
            strBuilder.Replace("LIST-STYLE-TYPE:", "list-style-type:");
            strBuilder.Replace("LEFT:", "left:");
            strBuilder.Replace("TOP:", "top:");
            strBuilder.Replace("WIDTH:", "width:");
            strBuilder.Replace("HEIGHT:", "height:");
            strBuilder.Replace("about:blank", "");
            strBuilder.Replace("<body>", "<body>\n");
            if (!strBuilder.ToString().Contains("<style"))
            {
                strBuilder.Replace("<head>", "<head>\n<style type=\"text/css\">\n\n</style>\n");
            }

            if (strBuilder.ToString().Contains("<li"))
            {
                strBuilder.Insert(strBuilder.ToString().IndexOf("<li>"), "</li>");
                strBuilder.Remove(strBuilder.ToString().IndexOf("</li>"), 5);
                strBuilder.Replace("</ol>", "\n</ol>");
                strBuilder.Replace("</ul>", "\n</ul>");
            }

            if (strBuilder.ToString().Contains("<table"))
            {
                strBuilder.Replace("</tr>", "\n</tr>");
                strBuilder.Replace("</tbody>", "\n</tbody>");
                strBuilder.Replace("</table>", "\n</table>");
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// Loads the document from a specified content
        /// </summary>
        /// <param name="content">The content string to load</param>
        public void LoadHtmlContent(string content)
        {
            this.ClearHtmlContent();
            this.document.open();
            this.document.write(content);
            this.document.close();
            this.MakeInsertedElementMovable();
        }

        /// <summary>
        /// Clears the current document
        /// </summary>
        public void ClearHtmlContent()
        {
            this.document.write("");
            this.document.close();
        }

        /// <summary>
        /// Loads the document from a given file
        /// </summary>
        /// <param name="fileName">The file to load</param>
        public void LoadHtmlFile(string fileName)
        {
            try
            {
                string htmlContent = File.ReadAllText(fileName);
                this.LoadHtmlContent(htmlContent);
                this.ConvertImagePathsToURI(new FileInfo(fileName).DirectoryName);
                this.MakeInsertedElementMovable();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid file name");
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException("The file path is too long");
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("The specified directory was not found");
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("You do not have the necessary permissions");
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The specified file was not found");
            }
        }

        /// <summary>
        /// Saves the document to a file
        /// </summary>
        /// <param name="fileName">The file name to save</param>
        public void SaveHtmlFile(string fileName)
        {
            try
            {
                StringBuilder strBuilder = new StringBuilder(this.HTMLContent);
                strBuilder.Insert(0, "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n");
                File.WriteAllText(fileName, strBuilder.ToString(), Encoding.Unicode);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid file name");
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException("The file path is too long");
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("The specified directory was not found");
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("You do not have the necessary permissions");
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The specified file was not found");
            }
        }

        /// <summary>
        /// Add an element style in the 'style' tag
        /// </summary>
        /// <param name="id">The ID of the element</param>
        /// <param name="style">The style of the element</param>
        public void AddStyle(string id, string style)
        {
            StringBuilder styleBuilder = new StringBuilder(this.HTMLContent);
            string styleToInsert = "#" + id + "\n{\n    " + style + ";\n}\n";
            styleBuilder.Insert(this.HTMLContent.IndexOf("</style>"), styleToInsert);
            this.HTMLContent = styleBuilder.ToString();
        }

        /// <summary>
        /// Gets the style of the selected text
        /// </summary>
        /// <returns>The text style as IHTMLStyle</returns>
        public IHTMLStyle GetSelectedTextStyle()
        {
            if (GetSelectedElement() != null)
            {
                return GetSelectedElement().style;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the font of the selected text: decoration, size, font family, etc.
        /// </summary>
        /// <returns>The font as Font object</returns>
        public Font GetSelectedTextFont()
        {
            IHTMLStyle selectedFont = this.GetSelectedTextStyle();
            if (selectedFont != null)
            {
                string family = selectedFont.fontFamily;
                string size = "12";
                if (selectedFont.fontSize != null)
                {
                    size = selectedFont.fontSize.Split('p')[0];
                }
                FontStyle style = 0;
                if (selectedFont.fontWeight == "bold")
                {
                    style = style | FontStyle.Bold;
                }
                if (selectedFont.fontStyle == "italic")
                {
                    style = style | FontStyle.Italic;
                }
                if (selectedFont.textDecorationLineThrough)
                {
                    style = style | FontStyle.Strikeout;
                }
                if (selectedFont.textDecorationUnderline)
                {
                    style = style | FontStyle.Underline;
                }

                return new Font(family, float.Parse(size), style, GraphicsUnit.Point);
            }

            return null;
        }

        /// <summary>
        /// Makes the document editable
        /// </summary>
        public void EnterDesignMode()
        {
            this.document.designMode = "on";
        }

        /// <summary>
        /// Enables moving the inserted element
        /// </summary>
        private void MakeInsertedElementMovable()
        {
            this.document.execCommand("AbsolutePosition", false, true);
            this.document.execCommand("2D-Position", false, true);
            this.document.execCommand("LiveResize", false, true);
        }

        public void Undo()
        {
            this.document.execCommand("Undo", false, null);
        }

        public void Redo()
        {
            this.document.execCommand("Redo", false, null);
        }

        public void Cut()
        {
            this.document.execCommand("Cut", false, null);
        }

        public void Copy()
        {
            this.document.execCommand("Copy", false, null);
        }

        public void Paste()
        {
            this.document.execCommand("Paste", false, null);
        }

        /// <summary>
        /// Inserts an image in the document
        /// </summary>
        /// <param name="src">The source of the image (file path or URL)</param>
        /// <param name="id">The ID of the image</param>
        /// <param name="border">The border size</param>
        /// <param name="altText">Alternative text</param>
        /// <param name="width">Width of the image</param>
        /// <param name="height">Height of the image</param>
        public void InsertImage(string src, string id, int border = 0, string altText = null,
            int width = 0, int height = 0)
        {
            if (src == null)
            {
                throw new ArgumentNullException("You must specify the image source!");
            }
            if (id == null)
            {
                throw new ArgumentNullException("You must specify the image ID!");
            }

            IHTMLTxtRange selection = this.document.selection.createRange() as IHTMLTxtRange;
            selection.pasteHTML("<img src=\"" + src + "\" id=\"" + id + "\" style=\"position:absolute\" />");

            IHTMLImgElement image = GetElementById(id) as IHTMLImgElement;
            if (border != 0)
            {
                (image as IHTMLElement).style.border = border.ToString() + "px solid #000000";
            }
            if (altText != null)
            {
                image.alt = altText;
            }
            if (width != 0)
            {
                (image as IHTMLElement).style.width = width.ToString();
            }
            if (height != 0)
            {
                (image as IHTMLElement).style.height = height.ToString();
            }

            imagePaths.Add(src);
            MakeInsertedElementMovable();
        }

        /// <summary>
        /// Gets a list of all form names in the document
        /// </summary>
        /// <returns>The form names as a list of strings</returns>
        public List<string> GetFormNames()
        {
            List<string> formNames = new List<string>();

            if (this.document.forms.length != 0)
            {
                foreach (IHTMLFormElement form in this.document.forms)
                {
                    formNames.Add(form.name);
                }
            }

            return formNames;
        }

        /// <summary>
        /// Inserts a new input form
        /// </summary>
        /// <param name="formName">The name of the form</param>
        /// <param name="action">The action attribute</param>
        /// <param name="method">The submitting method</param>
        public void InsertForm(string formName, string action, SubmitMethod method)
        {

            IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange;
            
            string submitMethod = string.Empty;
            switch (method)
            {
                case SubmitMethod.Get:
                    submitMethod = "get";
                    break;

                case SubmitMethod.Post:
                    submitMethod = "post";
                    break;
            }

            range.pasteHTML("<form name=\"" + formName + "\" action=\"" + action + 
                "\" method=\"" + submitMethod + "\"></form>");

        }

        /// <summary>
        /// Inserts a new input field
        /// </summary>
        /// <param name="fieldName">The name of the new field</param>
        /// <param name="formName">THe name of the form the field would be added</param>
        /// <param name="type">The type of the field</param>
        public void InsertInputField(string fieldName, string formName, InputFieldType type, string formValue)
        {
            string fieldType = string.Empty;
            switch (type)
            {
                case InputFieldType.Button:
                    fieldType = "button";
                    break;

                case InputFieldType.Password:
                    fieldType = "password";
                    break;

                case InputFieldType.Submit:
                    fieldType = "submit";
                    break;

                case InputFieldType.Text:
                    fieldType = "text";
                    break;
            }

            IHTMLFormElement form = this.GetElementByName(formName) as IHTMLFormElement;
            (form as IHTMLElement).innerHTML += "<input type=\"" + fieldType +
                                        "\" name=\"" + fieldName + "\" style=\"position: absolute\"" +
                                        "value=\"" + formValue + "\" />";
            MakeInsertedElementMovable();
        }

        /// <summary>
        /// Inserts a new table in the document
        /// </summary>
        /// <param name="id">The ID of the table</param>
        /// <param name="rows">The number of rows</param>
        /// <param name="cols">The number of columns</param>
        /// <param name="borderSize">The border size</param>
        /// <param name="borderColor">The border color</param>
        public void InsertTable(string id, int rows, int cols, int borderSize = 0, string borderColor = null)
        {
            IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange;
            range.pasteHTML("<table id=\"" + id + "\" style=\"position: absolute;\"></table>");

            IHTMLTable table = this.GetElementById(id) as IHTMLTable;
            if (table != null)
            {
                for (int i = 0; i < rows; i++)
                {
                    table.insertRow(i - 1);
                }

                table.cellPadding = "10";
                foreach (IHTMLTableRow row in table.rows)
                {
                    for (int i = 0; i < cols; i++)
                    {
                        IHTMLTableCell insertedCell = row.insertCell(i - 1);
                        (insertedCell as IHTMLElement).innerHTML = "&nbsp;";
                    }
                }

                if (borderSize >= 0)
                {
                    (table as IHTMLElement).style.border = borderSize + "px solid " + borderColor;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The border size should be a positive number");
                }

                this.AddStyle(id + " td", "border: " + borderSize + "px solid " + borderColor);
                this.AddStyle(id, (table as IHTMLElement).style.cssText);
                StringBuilder strBuilder = new StringBuilder(this.HTMLContent);
                int startIndexToDelete = this.HTMLContent.IndexOf("style=\"", HTMLContent.LastIndexOf("<table")) + 7;
                int endIndexToDelete = this.HTMLContent.IndexOf("position:", startIndexToDelete);
                strBuilder.Remove(startIndexToDelete, endIndexToDelete - startIndexToDelete);
                this.HTMLContent = strBuilder.ToString();

                this.MakeInsertedElementMovable();
            }
        }

        /// <summary>
        /// Inserts a new heading in the document
        /// </summary>
        /// <param name="text">The text of the heading</param>
        /// <param name="size">The heading size (1 - 7)</param>
        public void InsertHeading(string text, int size)
        {
            IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange;
            range.pasteHTML("<h" + size + ">" + text + "</h" + size + ">");
        }

        /// <summary>
        /// Inserts a new hyperlink in the document
        /// </summary>
        /// <param name="text">The title of the hyperlink</param>
        /// <param name="url">The URL of the hyperlink</param>
        public void InsertHyperlink(string text, string url)
        {
            IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange;
            range.pasteHTML("<a href=\"" + url + "\">" + text + "</a>");
        }

        /// <summary>
        /// Inserts a list
        /// </summary>
        /// <param name="ordered">Indicates whether the list should be ordered or not</param>
        /// <param name="type">The type of the list</param>
        /// <param name="items">The list items</param>
        public void InsertList(bool ordered, ListType type, List<string> items)
        {
            StringBuilder htmlText = new StringBuilder();
            string listType = string.Empty;
            switch (type)
            {
                case ListType.CapitalLetters:
                    listType = "upper-alpha";
                    break;

                case ListType.CapitalRoman:
                    listType = "upper-roman";
                    break;

                case ListType.Circle:
                    listType = "circle";
                    break;

                case ListType.Decimal:
                    listType = "decimal";
                    break;

                case ListType.Disc:
                    listType = "disc";
                    break;

                case ListType.LowerLetters:
                    listType = "lower-alpha";
                    break;

                case ListType.LowerRoman:
                    listType = "lower-roman";
                    break;

                case ListType.Square:
                    listType = "square";
                    break;
            }

            if (ordered)
            {
                htmlText.AppendLine("<ol>");
            }
            else
            {
                htmlText.AppendLine("<ul>");
            }

            foreach (string item in items)
            {
                htmlText.AppendLine("<li>" + item + "</li>");
            }

            if (ordered)
            {
                htmlText.AppendLine("</ol>");
            }
            else
            {
                htmlText.AppendLine("</ul");
            }

            IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange;
            range.pasteHTML(htmlText.ToString());
            range.select();

            if (this.GetSelectedElementType() != "BODY")
            {
                this.GetSelectedElement().parentElement.style.listStyleType = listType;
            }
            
        }

        /// <summary>
        /// Inserts a horizontal line (<hr/>) in the document
        /// </summary>
        public void InsertHorizontalLine()
        {
            IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange;
            range.pasteHTML("<hr/>");
            this.MakeInsertedElementMovable();
        }

        /// <summary>
        /// Sets the title of the current page
        /// </summary>
        /// <param name="title">The new title of the page</param>
        public void SetTitle(string title)
        {
            this.document.title = title;
        }

        public void SetDocumentBackgroundImage(string src)
        {
            (this.document.body as IHTMLBodyElement).background = src;
        }

        public void SetDocumentBackgroundColor(string color)
        {
            this.document.body.style.backgroundColor = color;
        }

        private void SetSelectedElementBackgroundColor(string color)
        {
            if (this.GetSelectedElement() != null)
            {
                this.GetSelectedElement().style.backgroundColor = color;
            }
        }

        public void MakeSelectionBold(bool undo)
        {
            if (this.GetSelectedTextStyle() != null)
            {
                if (undo)
                {
                    this.GetSelectedTextStyle().fontWeight = "normal";
                }
                else
                {
                    this.GetSelectedTextStyle().fontWeight = "bold";
                }
            }
            else
            {
                if (!undo)
                {
                    this.document.body.style.fontWeight = "bold";
                }
                else
                {
                    this.document.body.style.fontWeight = "normal";
                }
            }
        }

        public void MakeSelectionUnderlined(bool undo)
        {
            if (this.GetSelectedTextStyle() != null)
            {
                this.GetSelectedTextStyle().textDecorationUnderline = !undo;
            }
            else
            {
                this.document.body.style.textDecorationUnderline = !undo;
            }
        }

        public void MakeSelectionItalic(bool undo)
        {
            if (this.GetSelectedTextStyle() != null)
            {
                if (undo)
                {
                    this.GetSelectedTextStyle().fontStyle = "normal";
                }
                else
                {
                    this.GetSelectedTextStyle().fontStyle = "italic";
                }
            }
            else
            {
                if (!undo)
                {
                    this.document.body.style.fontStyle = "italic";
                }
                else
                {
                    this.document.body.style.fontStyle = "normal";
                }
            }
        }

        public void MakeSelectionStrikeout(bool undo)
        {
            if (this.GetSelectedTextStyle() != null)
            {
                this.GetSelectedTextStyle().textDecorationLineThrough = !undo;
            }
            else
            {
                this.document.body.style.textDecorationLineThrough = !undo;
            }
        }

        /// <summary>
        /// Aligns the selected text
        /// </summary>
        /// <param name="direction">The direction to align to</param>
        public void AlignSelection(string direction)
        {
            IHTMLElement selected = this.GetSelectedElement();
            if (selected != null)
            {
                string selectedType = this.GetSelectedElementType();
                if (selectedType == "BODY")
                {
                    IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange;
                    string selectedText = range.text;
                    range.execCommand("Delete", false, null);
                    range.pasteHTML("<p>" + selectedText + "</p>");
                    range.select();
                    this.AlignSelection(direction);
                }
                else if (selectedType == "A")
                {
                    IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange;
                    string selectedLink = this.GetSelectedElement().outerHTML;
                    range.execCommand("Delete", false, null);
                    range.pasteHTML("<div style=\"text-align: " + direction + ";\">" + selectedLink + "</div>");
                    range.select();
                }
                else
                {
                    selected.style.textAlign = direction;
                }
            }
        }

        public void ChangeFontFamily(string family)
        {
            if (this.GetSelectedElement() != null)
            {
                if (this.GetSelectedElementType() == "BODY")
                {
                    IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange;
                    string selectedText = range.text;
                    range.execCommand("Delete", false, null);
                    range.pasteHTML("<p>" + selectedText + "</p>");
                    range.select();
                    this.ChangeFontFamily(family);
                }
                else
                {
                    this.GetSelectedTextStyle().fontFamily = family;
                }
            }
            else
            {
                this.document.body.style.fontFamily = family;
            }
        }

        public void ChangeFontSize(string size)
        {
            if (this.GetSelectedElement() != null)
            {
                if (this.GetSelectedElementType() == "BODY")
                {
                    this.InsertParagraph(this.GetSelectedText()).select();
                    this.ChangeFontSize(size);
                }
                else
                {
                    this.GetSelectedTextStyle().fontSize = size;
                }
            }
            else
            {
                this.document.body.style.fontSize = size;
            }
        }

        public void ChangeFontColor(string color)
        {
            if (this.GetSelectedTextStyle() != null)
            {
                if (this.GetSelectedElementType() == "BODY")
                {
                    IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange;
                    string selectedText = range.text;
                    range.execCommand("Delete", false, null);
                    range.pasteHTML("<p>" + selectedText + "</p>");
                    range.select();
                    this.ChangeFontColor(color);
                }
                else
                {
                    this.GetSelectedTextStyle().color = color;
                }
            }
            else
            {
                this.document.body.style.color = color;
            }
        }

        private string GetSelectedText()
        {
            if (this.GetSelectedElement() != null)
            {
                IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange;
                return range.text;
            }
            else
            {
                return string.Empty;
            }
        }

        private IHTMLTxtRange InsertParagraph(string text)
        {
            IHTMLTxtRange range = this.document.selection.createRange() as IHTMLTxtRange; ;
            range.execCommand("Delete", false, null);
            range.pasteHTML("<p>" + text + "</p>");
            return range;
        }

        /// <summary>
        /// Gets an HTML element by specified ID
        /// </summary>
        /// <param name="id">The ID of the element</param>
        /// <returns>The element as with the specified ID if such found, null otherwise</returns>
        private IHTMLElement GetElementById(string id)
        {
            foreach (IHTMLElement element in this.document.all)
	        {
		        if(element.id == id)
                {
                    return element;
                }
	        }

            return null;
        }

        /// <summary>
        /// Gets and HTML element by specified name
        /// </summary>
        /// <param name="name">The name of the element</param>
        /// <returns>The element with the specified name</returns>
        private IHTMLElement GetElementByName(string name)
        {
            foreach (IHTMLFormElement element in this.document.forms)
            {
                if (element != null)
                {
                    if (element.name == name)
                    {
                        return element as IHTMLElement;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the selected in the designer element
        /// </summary>
        /// <returns>The selected element as IHTMLElement</returns>
        public IHTMLElement GetSelectedElement()
        {
            IHTMLTxtRange range = null;
            range = this.document.selection.createRange() as IHTMLTxtRange;
            if (range != null)
            {
                if (!string.IsNullOrEmpty(range.parentElement().innerHTML))
                {
                    return range.parentElement();
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Gets the element type of the specified element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The element type</returns>
        private string GetElementType(IHTMLElement element)
        {
            if (element != null)
            {
                string outerHtml = element.outerHTML;
                string[] elements = outerHtml.Split('<', ' ', '>');
                return elements[1];
            }
            else
            {
                throw new Exception("The specified element is null");
            }
        }

        /// <summary>
        /// Gets the element type of the selected element
        /// </summary>
        /// <returns>The element type</returns>
        private string GetSelectedElementType()
        {
            if (this.GetSelectedElement() != null)
            {
                return this.GetElementType(this.GetSelectedElement());
            }

            return null;
        }

        /// <summary>
        /// Gets the selected table cell
        /// </summary>
        /// <returns>The selected cell as TableCell object</returns>
        public TableCell GetSelectedTableCell()
        {
            if (this.GetSelectedElement() != null)
            {

                IHTMLTableCell selectedCell = GetSelectedTableCellElement();
                TableCell cell = new TableCell();

                if (selectedCell != null)
                {
                    cell.BackgroundColor = selectedCell.bgColor;
                    cell.BorderColor = selectedCell.borderColor;

                    if (string.IsNullOrEmpty((selectedCell as IHTMLElement).style.borderWidth))
                    {
                        cell.BorderSize = null;
                    }
                    else
                    {
                        string size = (selectedCell as IHTMLElement).style.borderWidth;
                        cell.BorderSize = Int32.Parse(size.Remove(size.Length - 2, 2));
                    }
                    if (string.IsNullOrEmpty(selectedCell.width))
                    {
                        cell.Width = null;
                    }
                    else
                    {
                        cell.Width = Int32.Parse(selectedCell.width);
                    }

                    if (string.IsNullOrEmpty(selectedCell.width))
                    {
                        cell.Width = null;
                    }
                    else
                    {
                        cell.Height = Int32.Parse(selectedCell.height);
                    }

                    if (string.IsNullOrEmpty(selectedCell.rowSpan.ToString()))
                    {
                        cell.Rowspan = null;
                    }
                    else
                    {
                        cell.Rowspan = selectedCell.rowSpan;
                    }

                    if (string.IsNullOrEmpty(selectedCell.colSpan.ToString()))
                    {
                        cell.Colspan = null;
                    }
                    else
                    {
                        cell.Colspan = selectedCell.colSpan;
                    }

                    return cell;
                }

                return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the IHTMLTableCell object of the selected cell
        /// </summary>
        /// <returns>The selected cell as IHTMLTableCell</returns>
        public IHTMLTableCell GetSelectedTableCellElement()
        {
            if (this.GetSelectedElement() != null)
            {
                if (this.GetSelectedElementType() == "TD")
                {
                    IHTMLTableCell selectedCell = this.GetSelectedElement() as IHTMLTableCell;
                    return selectedCell;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Changes a single property of a cell
        /// </summary>
        /// <param name="cell">The cell to modify</param>
        /// <param name="propertyName">The property to change</param>
        /// <param name="newValue">The new value of the property</param>
        public void ChangeCellProperty(IHTMLTableCell cell, CellProperties propertyName, string newValue)
        {
            IHTMLElement cellElement = cell as IHTMLElement; ;
            if (cellElement != null)
            {
                switch (propertyName)
                {
                    case CellProperties.BackgroundColor:
                        cellElement.style.backgroundColor = newValue;
                        break;

                    case CellProperties.BorderColor:
                        cellElement.style.borderColor = newValue;
                        break;

                    case CellProperties.BorderSize:
                        if (newValue != null)
                        {
                            cellElement.style.borderWidth = newValue;
                        }
                        break;

                    case CellProperties.Height:
                        if (newValue != null)
                        {
                            cellElement.style.height = newValue;
                        }
                        break;

                    case CellProperties.Width:
                        if (newValue != null)
                        {
                            cellElement.style.width = newValue;
                        }
                        break;

                    case CellProperties.Rowspan:
                        if(newValue != null)
                        {
                            cell.rowSpan = int.Parse(newValue);
                        }
                        break;

                    case CellProperties.Colspan:
                        if (newValue != null)
                        {
                            cell.colSpan = int.Parse(newValue);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Gets the selected table
        /// </summary>
        /// <returns>The selected table as Table object</returns>
        public Table GetSelectedTable()
        {
            if (this.GetSelectedElement() != null)
            {
                if(this.GetElementType(this.GetSelectedTableElement() as IHTMLElement) != "TABLE")
                {
                    return null;
                }

                IHTMLTable selectedTable = GetSelectedTableElement();
                Table table = new Table();

                if (selectedTable != null)
                {
                    table.BackgroundColor = selectedTable.bgColor;
                    table.BorderColor = selectedTable.borderColor;
                    table.BorderSize = Int32.Parse(selectedTable.border);

                    if (string.IsNullOrEmpty(selectedTable.width))
                    {
                        table.Width = null;
                    }
                    else
                    {
                        table.Width = Int32.Parse(selectedTable.width);
                    }

                    if(string.IsNullOrEmpty(selectedTable.height))
                    {
                        table.Height = null;
                    }
                    else
                    {
                        table.Height = Int32.Parse(selectedTable.height);
                    }

                    if (string.IsNullOrEmpty(selectedTable.cellSpacing))
                    {
                        table.CellSpacing = null;
                    }
                    else
                    {
                        table.CellSpacing = Int32.Parse(selectedTable.cellSpacing);
                    }
                }

                return table;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the IHTMLTable object of the selected table
        /// </summary>
        /// <returns>The selected table as IHTMLTable</returns>
        public IHTMLTable GetSelectedTableElement()
        {
            IHTMLTable selectedTable = this.GetSelectedElement().parentElement.parentElement.parentElement
                as IHTMLTable;
            return selectedTable;
        }

        /// <summary>
        /// Changes a single property of a table
        /// </summary>
        /// <param name="table">The table to modify</param>
        /// <param name="propertyName">The property to change</param>
        /// <param name="newValue">The new value of the property</param>
        public void ChangeTableProperty(IHTMLTable table, TableProperties propertyName, string newValue)
        {
            if (table != null)
            {
                IHTMLElement tableElement = table as IHTMLElement;
                switch (propertyName)
                {
                    case TableProperties.BackgroundColor:
                        tableElement.style.backgroundColor = newValue;
                        break;

                    case TableProperties.BorderColor:
                        tableElement.style.borderColor = newValue;
                        break;

                    case TableProperties.BorderSize:
                        if (newValue != null)
                        {
                            tableElement.style.borderWidth = newValue;
                        }
                        break;

                    case TableProperties.Height:
                        if (newValue != null)
                        {
                            tableElement.style.height = newValue;
                        }
                        break;

                    case TableProperties.Width:
                        if (newValue != null)
                        {
                            tableElement.style.width = newValue;
                        }
                        break;

                    case TableProperties.CellSpacing:
                        if (newValue != null)
                        {
                            table.cellSpacing = newValue;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Deletes the cell that the user has selected in the designer
        /// </summary>
        public void DeleteSelectedCell()
        {
            if (this.GetSelectedTableCell() != null)
            {
                IHTMLTableCell selectedCell = this.GetSelectedTableCellElement();
                IHTMLTableRow selectedRow = (selectedCell as IHTMLElement).parentElement as IHTMLTableRow;
                selectedRow.deleteCell(selectedCell.cellIndex);
            }
        }

        /// <summary>
        /// Inserts a new cell in the selected table
        /// </summary>
        public void InsertCell()
        {
            IHTMLTableCell selectedCell = this.GetSelectedTableCellElement();
            if (selectedCell != null)
            {
                IHTMLTableRow row = (selectedCell as IHTMLElement).parentElement as IHTMLTableRow;
                row.insertCell().innerHTML = "&nbsp;";
            }
        }

        /// <summary>
        /// Copies all images in the document to the path of the HTML file
        /// </summary>
        /// <param name="path">The path to copy the images</param>
        public void CopyImagesToFilePath(string path)
        {
            if (this.document.images.length != 0)
            {
                foreach (string imagePath in imagePaths)
                {
                    if (!imagePath.Contains("http"))
                    {
                        string imageName = imagePath.Split('\\').Last();
                        string destinationPath = path + "\\" + imageName;
                        if (!File.Exists(destinationPath))
                        {
                            File.Copy(imagePath, destinationPath, true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Makes all 'src' attributes of the images in the document relative to the HTML file
        /// </summary>
        public void MakeImagePathsRelative()
        {
            if (this.document.images.length != 0)
            {
                foreach (IHTMLImgElement image in this.document.images)
                {
                    imagePaths.Add(image.src);
                }

                foreach (IHTMLImgElement imagePath in this.document.images)
                {
                    if (!imagePath.src.Contains("http://"))
                    {
                        string newSrc = imagePath.src.Split(new string[]{"//", "/"}, StringSplitOptions.None).Last();
                        imagePath.src = newSrc;
                    }
                }
            }
        }

        /// <summary>
        /// Converts the relative paths of the images to absolute file locations 
        /// </summary>
        /// <param name="path"></param>
        public void ConvertImagePathsToURI(string path)
        {
            int length = this.document.images.length;
            if(this.document.images.length != 0)
            {
                foreach (IHTMLImgElement image in this.document.images)
                {
                    if (!image.src.Contains("http"))
                    {
                        string src = "file:///" + path + "\\" + image.src.Remove(0, 11);
                        image.src = src.Replace('\\', '/').Replace(" ", "%20");
                    }
                }
            }
        }
    }
}
