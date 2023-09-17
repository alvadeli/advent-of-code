using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
 

    public class Matrix<T> 
    {
        private readonly T[,] _data;

        public Matrix(int rows, int columns)
        {
            _data = new T[rows, columns];
        }

        public int RowCount => _data.GetLength(0);

        public int ColumnCount => _data.GetLength(1);

        // Indexer to access elements in the matrix
        public T this[int row, int col]
        {
            get { return _data[row, col]; }
            set { _data[row, col] = value; }
        }

        // Get a specific row as an array
        public T[] GetRow(int rowIndex)
        {
            var row = new T[ColumnCount];
            for (int col = 0; col < ColumnCount; col++)
            {
                row[col] = _data[rowIndex, col];
            }
            return row;
        }

        // Get a specific column as an array
        public T[] GetColumn(int columnIndex)
        {
            var column = new T[RowCount];
            for (int row = 0; row < RowCount; row++)
            {
                column[row] = _data[row, columnIndex];
            }
            return column;
        }
    }



}
