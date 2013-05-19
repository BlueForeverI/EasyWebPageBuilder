using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLBuilderLibrary
{
    /// <summary>
    /// List of all table cell properties
    /// </summary>
    public enum CellProperties
    {
        BackgroundColor,
        BorderColor,
        BorderSize, 
        Height,
        Width,
        Rowspan,
        Colspan
    }

    /// <summary>
    /// A class that contains the properties of a table cell
    /// </summary>
    public class TableCell
    {
        private string backgroundColor;
        private string borderColor;
        private int? borderSize;
        private int? width;
        private int? height;
        private int? rowspan;
        private int? colspan;

        public TableCell() { }

        public TableCell(string backgroundColor, string borderColor, int borderSize, int width, int height,
            int rowspan, int colspan)
        {
            this.BackgroundColor = backgroundColor;
            this.BorderColor = borderColor;
            this.BorderSize = borderSize;
            this.Width = width;
            this.Height = height;
            this.Rowspan = rowspan;
            this.Colspan = colspan;
        }

        public string BackgroundColor
        {
            get
            {
                return this.backgroundColor;
            }
            set
            {
                this.backgroundColor = value;
            }
        }

        public string BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                this.borderColor = value;
            }
        }

        public int? BorderSize
        {
            get
            {
                return this.borderSize;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The cell border size should be a positive number");
                }

                this.borderSize = value;
            }
        }

        public int? Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The cell width should be a positive number");
                }

                this.width = value;
            }
        }

        public int? Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The cell height should be a positive number");
                }

                this.height = value;
            }
        }

        public int? Rowspan
        {
            get
            {
                return this.rowspan;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The rowspan should be a positive number");
                }

                this.rowspan = value;
            }
        }

        public int? Colspan
        {
            get
            {
                return this.colspan;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The colspan should be a positive number");
                }

                this.colspan = value;
            }
        }
    }
}
