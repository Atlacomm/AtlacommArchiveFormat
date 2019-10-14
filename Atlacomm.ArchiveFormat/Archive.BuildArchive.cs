using System;
using System.Collections.Generic;

namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        public byte[] BuildArchive()
        {
            List<byte> data = new List<byte>();

            // Write header
            foreach (byte b in HEADER)
            {
                data.Add((byte)(b ^ XOR));
            }

            // Write index
            foreach (string file in Files.Keys)
            {
                data.Add((byte)file.Length);

                foreach (char c in file)
                {
                    data.Add((byte)c);
                }

                byte[] sizeBytes = BitConverter.GetBytes((long)Files[file].Length);
                foreach (byte b in sizeBytes)
                {
                    data.Add(b);
                }
            }

            // Write index terminator
            data.Add(0);

            foreach (string file in Files.Keys)
            {
                foreach (byte b in Files[file])
                {
                    data.Add(b);
                }
            }

            return data.ToArray();
        }
    }
}
