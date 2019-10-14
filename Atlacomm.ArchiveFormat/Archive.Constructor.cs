using System;
using System.Collections.Generic;
using System.IO;

namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        const byte XOR = 0x89;
        static readonly byte[] HEADER = { (byte)'A', (byte)'M', (byte)'M' };
        static readonly byte[] DECRYPTED_HEADER = { (byte)(HEADER[0] ^ XOR), (byte)(HEADER[1] ^ XOR), (byte)(HEADER[2] ^ XOR) };

        readonly Dictionary<string, long> index = new Dictionary<string, long>();
        readonly byte[] data;
        readonly int contentOffset = 0;

        public Archive(string filepath)
        {
            bool decrypt = true;

            data = File.ReadAllBytes(filepath);
            for (int i = 0; i < data.Length; i++)
            {
                if (i < HEADER.Length && data[i] != HEADER[i])
                {
                    if (i < DECRYPTED_HEADER.Length && data[i] != DECRYPTED_HEADER[i])
                    {
                        throw new FileFormatException("Invalid file header");
                    }
                    else
                    {
                        decrypt = false;
                    }
                }

                data[i] = (byte)(data[i] ^ (decrypt ? XOR : 0));
            }

            for (int i = HEADER.Length; i < data.Length;)
            {
                int pathLength = data[i]; i++;

                if (pathLength == 0)
                {
                    contentOffset = i;
                    break;
                }

                string path = "";
                for (int j = 0; j < pathLength; j++, i++)
                {
                    path += (char)data[i];
                }

                byte[] sizeBytes = new byte[8];
                for (int j = 0; j < 8; j++, i++)
                {
                    sizeBytes[j] = data[i];
                }

                long size = BitConverter.ToInt64(sizeBytes, 0);

                index.Add(path, size);
            }
        }
    }
}
