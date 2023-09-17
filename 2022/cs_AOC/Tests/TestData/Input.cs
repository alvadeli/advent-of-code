using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestData
{
    internal class Input
    {
        public static string GetFile(string filename)
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(appDirectory, "TestData", filename);
        }
    }
}
