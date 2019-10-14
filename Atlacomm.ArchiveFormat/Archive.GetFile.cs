namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        public byte[] GetFile(string filepath)
        {
            if (!Contains(filepath)) return null;

            return Files[filepath];
        }
    }
}
