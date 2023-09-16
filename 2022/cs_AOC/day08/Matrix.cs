using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    using System;

    class Matrix
    {
        private readonly int[,] _data;

        public Matrix(int rows, int columns)
        {
            _data = new int[rows, columns];
        }

        public int RowCount => _data.GetLength(0);

        public int ColumnCount => _data.GetLength(1);

        // Indexer to access elements in the matrix
        public int this[int row, int col]
        {
            get { return _data[row, col]; }
            set { _data[row, col] = value; }
        }

        // Get a specific row as an array
        public int[] GetRow(int rowIndex)
        {
            int[] row = new int[ColumnCount];
            for (int col = 0; col < ColumnCount; col++)
            {
                row[col] = _data[rowIndex, col];
            }
            return row;
        }

        // Get a specific column as an array
        public int[] GetColumn(int columnIndex)
        {
            int[] column = new int[RowCount];
            for (int row = 0; row < RowCount; row++)
            {
                column[row] = _data[row, columnIndex];
            }
            return column;
        }
    }



}
