using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ByteBrusher.Util.Resource.Scan
{
    public static class ScanFile
    {
        static bool isDuplicate(string directoryPath)
        {
            var files = Directory.GetFiles(directoryPath);
            var fileHashes = new Dictionary<string, List<string>>();

            foreach (var file in files)
            {
                string fileHash = ComputeSha256Hash(file);
                if (fileHashes.ContainsKey(fileHash))
                {
                    fileHashes[fileHash].Add(file);
                }
                else
                {
                    fileHashes[fileHash] = new List<string> { file };
                }
            }
            return true;
        }

        static string ComputeSha256Hash(string filename)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    byte[] hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}