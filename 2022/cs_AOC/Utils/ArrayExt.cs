using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class ArrayExt
    {
        public static void InitializeAll<T>(this T[,] array, T value) 
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = value;
                }
            }
        }

        public static bool IsEqualTo<T>(this T[,] array1, T[,] array2)
        {
            if (array1.GetLength(0) != array2.GetLength(0) || array1.GetLength(1) != array2.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    if (!EqualityComparer<T>.Default.Equals(array1[i, j], array2[i, j]))
                    {
                        return false; 
                    }
                }
            }

            return true;
        }
    }
}
