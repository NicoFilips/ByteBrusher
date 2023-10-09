using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBrusher.Core.File.FileTypes.Interface;

namespace ByteBrusher.Core.File.FileTypes
{
    public record Document : IFileType
    {
        public string Name => "Document";
        private static readonly string[] suffix = { ".doc", ".docx", ".pdf", ".txt", ".xlsx", ".xls" };
    }
}
