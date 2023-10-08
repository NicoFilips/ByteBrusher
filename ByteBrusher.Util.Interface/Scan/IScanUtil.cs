using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBrusher.Util.Interface.Scan
{
    public interface IScanUtil
    {
        /// <summary>
        /// Grabs every file with a lot of information and stores it in a List
        /// --> Tested with 100k Images and videos, RAM usage is within a few Megabytes
        /// </summary>
        public List<FileInfo> GetFileInfos(string path);
    }
}
