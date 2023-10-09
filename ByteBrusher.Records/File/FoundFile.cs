using ByteBrusher.Core.File.FileTypes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBrusher.Core.File
{
    public class FoundFile : IDisposable
    {
        public IFileType fileType { get; set; } = null;
        public FileInfo fileInfo { get; set; } = null;
        public bool gotDeleted { get; set; } = false;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
