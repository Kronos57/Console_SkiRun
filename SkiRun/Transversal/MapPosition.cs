using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRun.Transversal
{
    public class MapPosition
    {
        public int Value { get; set; }

        public int RowPosition { get; set; }

        public int ColumnPosition { get; set; }

        public MapPosition()
        {

        }

        public MapPosition(int value, int rowPosition, int columnPosition)
        {
            this.Value = value;
            this.RowPosition = rowPosition;
            this.ColumnPosition = columnPosition;
        }
    }
}
