using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Code
{
    public class Day07
    {
        public int Solve(List<string> input)
        {
            var top = Parse(input);
            top.CalculateSize();

            var sizes = new Dictionary<string, int>();
            GetAllSizes(top, sizes);

            return sizes.Where(s => s.Value <= 100000).Select(m => m.Value).Sum();
        }

        public int Solve2(List<string> input)
        {
            var top = Parse(input);
            top.CalculateSize();

            var sizes = new Dictionary<string, int>();
            GetAllSizes(top, sizes);

            var maxSize = 40000000;
            var toDelete = top.Size - maxSize;
            return sizes.Values.Where(s => s >= toDelete).Min();
        }

        private static void GetAllSizes(Directory d,  Dictionary<string, int> sizes)
        {
            sizes[d.Path] = d.Size;
            foreach (var dir in d.Directories.Values)
            {
                GetAllSizes(dir, sizes);
            }
        }

        public static Directory Parse(List<string> input)
        {
            var top = new Directory("/", null);

            var current = top;
            foreach (var line in input.Skip(1))
            {
                if (line == "$ ls")
                {
                }
                else if (line == "$ cd ..")
                {
                    current = current.Parent;
                }
                else if (line.StartsWith("$ cd"))
                {
                    var dirName = line.Substring(5);
                    current = current.Directories[dirName];
                }
                else if (line.StartsWith("dir"))
                {
                    var parts = line.Split(" ");
                    var name = parts[1];
                    current.Directories.Add(name, new Directory(name, current));
                }
                else
                {
                    var parts = line.Split(" ");
                    var size = int.Parse(parts[0]);
                    var name = parts[1];
                    var file = new File(name, size);
                    current.Files.Add(file);
                }
            }

            return top;
        }

        public class Directory
        {
            public string Name { get; }
            public string Path { get; }
            public Directory Parent { get; }
            public int Size { get; set; } 
            public readonly Dictionary<string, Directory> Directories = new();
            public readonly List<File> Files = new();

            public Directory(string name, Directory parent)
            {
                Name = name;
                Path = parent?.Path + "/" + name;
                Parent = parent;
            }

            public int CalculateSize()
            {
                var total = 0;
                foreach (var directory in Directories.Values)
                {
                    directory.CalculateSize();
                    total += directory.Size;
                }

                foreach (var file in Files)
                {
                    total += file.Size;
                }

                Size = total;
                return Size;
            }
        }

        public class File
        {
            public string Name { get; }
            public int Size { get; }

            public File(string name, int size)
            {
                Name = name;
                Size = size;
            }
        }
    }
}