using System.IO;
namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        public void Decrypt(string path)
        {
            File.WriteAllBytes(path, data);
        }
    }
}
