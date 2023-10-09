using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBrusher.Core.File.FileTypes.Interface;

namespace ByteBrusher.Core.File.FileTypes
{
    public record Video : IFileType
    {
        public string Name => "Video";
        private static readonly string[] suffix = { ".mp4", ".avi", ".mkv", ".mov", ".flv" };
    }
}