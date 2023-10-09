using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes.Interface;
using ByteBrusher.Core.FileTypes;
using ByteBrusher.Core.IOptions;
using ByteBrusher.Util.Interface.Scan;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace ByteBrusher.Util.Resource.Scan
{
    public class ScanUtil : IScanUtil
    {
        private readonly ILogger<ScanUtil> _logger;
        private readonly IOptions<FileExtensions> _options;

        public ScanUtil(ILogger<ScanUtil> logger, IOptions<FileExtensions> options)
        {
            _logger = logger;
            _options = options;
        }

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
            return Directory.GetFiles($"{path}", path).ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<FoundFile> GetFileInfos(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            foreach (var file in info.GetFiles("*", SearchOption.AllDirectories).ToList())
            {
                yield return new FoundFile
                   {
                    fileInfo = file,
                    fileType = ClassifyFile(file.Name),
                   };
            } 
        }

        /// <inheritdoc/>
        public IFileType ClassifyFile(string filename)
        {
            try
            {
                string suffix = filename.Substring(filename.LastIndexOf('.'));
                var FileDictionary = new Dictionary<IFileType, string[]>
            {
                { new Document(), _options.Value.DocumentSuffix },
                { new Image(), _options.Value.ImageSuffix },
                { new Video(), _options.Value.VideoSuffix },
            };
                return FileDictionary.FirstOrDefault(entry => entry.Value.Contains(suffix)).Key;
            }
            catch (Exception ex)
            {
                return new Unspecified();
            }
        }
    }
}