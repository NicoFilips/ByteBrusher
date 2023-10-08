using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBrusher.Util.Interface.Scan
{
    public interface IScanUtil
    {
        public List<FileInfo> fileInfos(string path);
    }
}
