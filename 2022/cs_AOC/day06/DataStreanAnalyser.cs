using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day06
{
    public static class DataStreamAnalyser
    {
        public enum Type
        {
            Marker = 4,
            Message = 14
        }

        public static int GetEndPostionOfType(string datastream, Type type)
        {
            int length = (int)type;
            return GetEndPositionOfDistinctCharSequence(datastream, length);
        }

        public static int GetEndPositionOfDistinctCharSequence(string text, int length)
        {
            int endPostion = 0;
            char[] markerCandidate = new char[length];

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    markerCandidate[j] = text[i + j];
                }

                if (markerCandidate.Distinct().Count() == markerCandidate.Length)
                {
                    endPostion = i + length;
                    break;
                }

            }

            return endPostion;
        }
    }
}
