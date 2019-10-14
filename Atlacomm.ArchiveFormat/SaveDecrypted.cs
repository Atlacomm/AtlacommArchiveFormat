using System.IO;
namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        public void SaveDecrypted(string path)
        {
            File.WriteAllBytes(path, data);
        }
    }
}
