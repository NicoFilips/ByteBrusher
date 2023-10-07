using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBrusher.Records.FileTypes
{
    public record Video
    {
        private static readonly string[] suffix = { ".mp4", ".avi", ".mkv", ".mov", ".flv" }; 
    }
}