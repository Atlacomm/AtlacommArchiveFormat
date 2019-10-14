using System.IO;

namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        public void Extract(string folderpath)
        {
            foreach (string file in index.Keys)
            {
                string filepath = Path.Combine(folderpath, file);
                string dir = Path.GetDirectoryName(filepath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                File.WriteAllBytes(filepath, GetFile(file));
            }
        }
    }
}
