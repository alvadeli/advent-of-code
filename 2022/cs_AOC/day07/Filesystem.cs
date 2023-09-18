using System.Data;

namespace day07
{
    public static class FileSystem
    {
        private const int DiskSpace = 70000000;

        public static int GetDirSizeSum(Directory topLevel)
        {
            var directories = topLevel.GetSubDirectoriesRecursive();

            int sum = 0;
            foreach (var dir in directories)
            {
                int size = dir.Size;
                if (size <= 100000)
                {
                    sum += size;
                }
            }

            return sum;
        }

        public static int GetDirectorySizeToFreeDisk(Directory topLevel)
        {
            const int NeededSpace = 30000000;
            int allocated = topLevel.Size;

            var directories = new List<Directory>() { topLevel };

            directories.AddRange(topLevel.GetSubDirectoriesRecursive());
            directories = directories.OrderBy(x => x.Size).ToList();
            
            foreach (var dir in directories) 
            {
                if (DiskSpace - allocated + dir.Size >= NeededSpace)
                {
                    return dir.Size;
                }
            }
            return allocated;

        }


        public static Directory ReconstructDirectory(string[] terminalOutput)
        {
            var topDirectory = new Directory() { Name = terminalOutput[0].Split(" ")[2] };
            var currenDirectory = topDirectory;

            for (int i = 1; i < terminalOutput.Length; i++)
            {
                string[] lineContent = terminalOutput[i].Split(" ");
                if (lineContent[1] == "ls")
                {
                    int j = i + 1;
                    bool isDirContent = true;
                    while (isDirContent && j < terminalOutput.Length)
                    {
                        string[] dirContent = terminalOutput[j].Split(" ");
                        switch (dirContent[0])
                        {
                            case "$":
                                j--;
                                isDirContent = false;
                                continue;
                            case "dir":
                                currenDirectory.AddSubDirectory(new Directory() { Name = dirContent[1], Parent = currenDirectory });
                                break;
                            default:
                                currenDirectory.AddFile(new File() { Name = dirContent[1], Size = int.Parse(dirContent[0]) });
                                break;
                        }
                        j++;
                    }
                    i = j;

                }
                else if (lineContent[1] == "cd")
                {
                    if (lineContent[2] == "..")
                    {
                        if (currenDirectory.Parent is not null)
                        {
                            currenDirectory = currenDirectory.Parent;
                        }
                        continue;
                    }

                    currenDirectory.AddSubDirectory(new Directory() { Name = lineContent[2], Parent = currenDirectory });
                    currenDirectory = currenDirectory.GetSubDirectory(lineContent[2]);

                }
            }

            return topDirectory;
        }



    }





}


