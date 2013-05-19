using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLBuilderLibrary
{
    /// <summary>
    /// List of all table properties
    /// </summary>
    public enum TableProperties
    {
        BackgroundColor,
        BorderColor, 
        BorderSize,
        Width,
        Height,
        CellSpacing
    }

    /// <summary>
    /// A class that contains the properties of a table
    /// </summary>
    public class Table
    {
        private string backgroundColor;
        private string borderColor;
        private int? borderSize;
        private int? width;
        private int? height;
        private int? cellSpacing;

        public Table() {}

        public Table(string backgroundColor, string borderColor, int borderSize, int width, int height, int cellSpacing)
        {
            this.BackgroundColor = backgroundColor;
            this.BorderColor = borderColor;
            this.BorderSize = borderSize;
            this.Width = width;
            this.Height = height;
            this.CellSpacing = cellSpacing;
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
                    throw new Exception("The table border size should be a positive number");
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
                    throw new Exception("The table width should be a positive number");
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
                    throw new Exception("The table height should be a positive number");
                }

                this.height = value;
            }
        }

        public int? CellSpacing
        {
            get
            {
                return this.cellSpacing;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("The table cell spacing should be a positive number or 0");
                }

                this.cellSpacing = value;
            }
        }
    }
}
