using System.Collections.Generic;

namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        // byte used XOR encryption
        const byte XOR = 0x89;

        // Headers for file validation and detection (is the file encrypted, decrypted or invalid)
        static readonly byte[] HEADER = { (byte)'A', (byte)'M', (byte)'M' };

        // Contains all files and their paths
        readonly Dictionary<string, byte[]> Files = new Dictionary<string, byte[]>();
    }
}
