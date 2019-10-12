using System.IO;

namespace Atlacomm.Archive
{
    public partial class Archive
    {
        public void Save(string folderpath)
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
