using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace OOP.Task2
{
    public class FileWorker
    {
        private readonly string path;
        public bool isRecursive { get; set; } = false;
        
        public FileWorker(string path)
        {
            this.path = path.Replace(@"\", @"\\");
        }

        public void Execute(IExecutable command)
        {
            var result = new List<string>();
            var currentDirectory = new DirectoryInfo(path);
            if (currentDirectory.Exists)
            {
                var availableFiles = new List<FileInfo>(currentDirectory.GetFiles());
                if (isRecursive)
                {
                    GetAllFiles(currentDirectory, availableFiles);
                }

                foreach (var file in availableFiles)
                {
                    result.Add(ConvertPath(file) + " : " + command.Process(file));
                }
                
                SaveResult(result);
            }
        }

        private void GetAllFiles(DirectoryInfo currentDirectory, List<FileInfo> files)
        {
            if (currentDirectory.Exists)
            {
                files.AddRange(currentDirectory.GetFiles());
                var availableDirectories = currentDirectory.GetDirectories();
                foreach (var directory in availableDirectories)
                {
                    GetAllFiles(directory, files);
                }
            }
        }

        private void SaveResult(List<string> results)
        {
            File.WriteAllLines("result.txt", results);
        }
        
        private string ConvertPath(FileInfo f)
        {
            Regex rx = new Regex(@""+path+"(.*)");
            var match = rx.Match(f.FullName);
            return match.Groups[1].Value;
        }
    }
}