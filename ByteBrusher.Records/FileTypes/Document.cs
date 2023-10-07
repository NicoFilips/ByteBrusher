using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBrusher.Records.FileTypes
{
    public record Document
    {
        private static readonly string[] suffix = { ".doc", ".docx", ".pdf", ".txt", ".xlsx", ".xls" }; 
    }
}
