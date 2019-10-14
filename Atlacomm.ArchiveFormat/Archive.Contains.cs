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
            // Return whether or not the Files Dictionary contaisn a file with the specified key
            return Files.Keys.Contains(filepath);
        }
    }
}
