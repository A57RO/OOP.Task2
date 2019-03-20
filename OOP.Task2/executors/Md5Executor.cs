using System;
using System.IO;
using System.Security.Cryptography;

namespace OOP.Task2
{
    public class Md5Executor : IExecutable
    {
        public string Process(FileInfo f)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = f.Open(FileMode.Open, FileAccess.Read))
                {
                    var binaryHash = md5.ComputeHash(stream);
                    var hash = BitConverter.ToString(binaryHash).Replace("-", string.Empty).ToLowerInvariant();   
                    return hash;
                }
            }
        }
    }
}