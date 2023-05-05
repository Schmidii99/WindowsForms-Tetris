using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Position
    {
        public int Row;
        public int Column;

        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
