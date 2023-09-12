namespace Utils
{
    public static class Input
    {
        public static string GetInputFile(bool demo)
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filename = demo ? "demo-input.txt" : "input.txt";
            return appDirectory + filename;
        }
    }
}