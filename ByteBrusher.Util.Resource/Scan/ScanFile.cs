using ByteBrusher.Util.Interface.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ByteBrusher.Util.Resource.Scan
{
    public class ScanUtil : IScanUtil
    {

        public bool isDuplicate(string directoryPath)
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

        public string ComputeSha256Hash(string filename)
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

        public List<string> GetFiles(string path) 
        {
            return Directory.GetFiles($"{path}", path).ToList<string>();
        }

        /// </inheritdoc>
        public List<FileInfo> fileInfos(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            return info.GetFiles("*", SearchOption.AllDirectories).ToList();
        }
    }
}