namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        public byte[] GetFile(string filepath)
        {
            // If the archive does contain the specifed file return null
            if (!Contains(filepath)) return null;

            // Return the specified file
            return Files[filepath];
        }
    }
}
