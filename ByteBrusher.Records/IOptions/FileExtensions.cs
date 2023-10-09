using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBrusher.Core.IOptions
{
    public class FileExtensions
    {
        public string[] VideoSuffix { get; set; } = new string[0];
        public string[] ImageSuffix { get; set; } = new string[0];
        public string[] DocumentSuffix { get; set; } = new string[0];

    }
}
