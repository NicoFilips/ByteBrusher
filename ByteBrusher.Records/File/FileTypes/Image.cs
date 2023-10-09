using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBrusher.Core.File.FileTypes.Interface;

namespace ByteBrusher.Core.File.FileTypes
{
    public record Image : IFileType
    {
        public string Name => "Image";

        private static readonly string[] suffix = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };

    }
}