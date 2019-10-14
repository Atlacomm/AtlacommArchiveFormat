namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        public byte[] BuildArchiveEnrypted()
        {
            byte[] data = BuildArchive();

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ XOR);
            }

            return data;
        }
    }
}
