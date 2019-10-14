using System.IO;

namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        public void Extract(string folderpath)
        {
            // Go through all files in the archive
            foreach (string file in Files.Keys)
            {
                // Create destination file path
                string filepath = Path.Combine(folderpath, file);

                // Get directory from destination file path
                string dir = Path.GetDirectoryName(filepath);

                // Create directory if it doesn't exist
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                // Write file to destination file path
                File.WriteAllBytes(filepath, GetFile(file));
            }
        }
    }
}
