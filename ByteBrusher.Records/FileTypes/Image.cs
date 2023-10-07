using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBrusher.Records.FileTypes
{
        public record Image
        {
            private static readonly string[] suffix = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
        }
    }