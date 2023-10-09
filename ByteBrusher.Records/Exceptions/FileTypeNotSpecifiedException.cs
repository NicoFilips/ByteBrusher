using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBrusher.Core.Exceptions
{
    public class FileTypeNotSpecifiedException : Exception
    {
        public FileTypeNotSpecifiedException(string message) : base(message) { }
    }
}
