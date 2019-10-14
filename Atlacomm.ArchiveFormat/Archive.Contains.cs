using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        public bool Contains(string filepath)
        {
            return Files.Keys.Contains(filepath);
        }
    }
}
