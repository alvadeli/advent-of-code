namespace Utils
{
    public static class Input
    {
        public static string GetInputFile()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filename = "input.txt";
            return Path.Combine(appDirectory,filename);
        }
    }
}