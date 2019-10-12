using System;
using System.Collections.Generic;
using System.IO;

namespace Atlacomm.Archive
{
    public partial class Archive
    {
        const byte XOR = 0x89;
        static readonly byte[] HEADER = { (byte)'A', (byte)'M', (byte)'M' };
        
        readonly Dictionary<string, long> index = new Dictionary<string, long>();
        readonly byte[] data;
        readonly int contentOffset = 0;

        public Archive(string filepath)
        {
            int lastFinishedPercent = -1;

            data = File.ReadAllBytes(filepath);
            for (int i = 0; i < data.Length; i++)
            {
                if (i < HEADER.Length && data[i] != HEADER[i]) throw new FileFormatException("Invalid file header");

                data[i] = (byte)(data[i] ^ XOR);

                int finishedPercent = (int)(i / (float)data.Length * 100);
                if (finishedPercent != lastFinishedPercent) Console.WriteLine(finishedPercent);
                lastFinishedPercent = finishedPercent;
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

                Console.WriteLine(path);

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
