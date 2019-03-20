using System;
using System.IO;
using System.Security.Cryptography;


namespace OOP.Task2
{
    public class SHA256Executor : IExecutable
    {
        public string Process(FileInfo f)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = f.Open(FileMode.Open, FileAccess.Read))
                {
                    var binaryHash = sha256.ComputeHash(stream);
                    var hash = BitConverter.ToString(binaryHash).Replace("-", string.Empty).ToLowerInvariant();
                    return hash;
                }
            }
        }
    }
}