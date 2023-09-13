namespace day07
{
    public class Directory : IComparable<Directory>
    {
        private HashSet<Directory> _subDirectories = new HashSet<Directory>();
        private HashSet<File> _files = new HashSet<File>();

        public string Name { get; set; } = "";
        public Directory? Parent { get; set; } = null;

        public int Size { get; private set; }

        public int CompareTo(Directory? other)
        {
            return Name.CompareTo(other?.Name);
        }

        public override bool Equals(object? obj)
        {
            return obj is Directory directory &&
                   Name == directory.Name &&
                   Parent?.Name == directory.Parent?.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Parent);
        }

        public Directory GetSubDirectory(string name)
        {
            return _subDirectories.First(x => x.Name == name);
        }

        public void AddSubDirectory(Directory subDir)
        {
            _subDirectories.Add(subDir);
            Size = GetSize();
            if (Parent is not null) Parent.Size = Parent.GetSize();
        }

        public void AddFile(File file)
        {
            _files.Add(file);
            Size = GetSize();
            if (Parent is not null) Parent.Size = Parent.GetSize();
        }

        public List<Directory> GetSubDirectoriesRecursive()
        {
            var subDirectories = new List<Directory>();

            foreach (var subDir in _subDirectories)
            {
                subDirectories.Add(subDir);
                subDirectories.AddRange(subDir.GetSubDirectoriesRecursive());
            }

            return subDirectories;
        }

        private int GetSize()
        {
            int size = 0;
            foreach (var file in _files)
            {
                size += file.Size;
            }

            foreach (var subDir in _subDirectories)
            {
                size += subDir.GetSize();
            }

            return size;
        }
    }


}


