using System;
using System.IO;

namespace Atlacomm.ArchiveFormat
{
    public delegate void ArchiveUpdateCallback(string file, int percent);

    public partial class Archive
    {
        public static void Create(string source, string destination, ArchiveUpdateCallback archiveUpdateCallback = null)
        {
            string[] paths = Directory.GetFiles(source, "*", SearchOption.AllDirectories);

            using (FileStream fs = File.Create(destination))
            {
                // Reset position in stream
                fs.Seek(0, SeekOrigin.Begin);

                // Write header
                foreach (byte b in HEADER)
                {
                    fs.WriteByte(b);
                }

                // Write index
                foreach (string path in paths)
                {
                    string internalPath = path.Replace('\\', '/');
                    internalPath = internalPath.Substring(internalPath.IndexOf('/') + 1);

                    fs.WriteByte((byte)(internalPath.Length ^ XOR));

                    foreach (char c in internalPath)
                    {
                        fs.WriteByte((byte)(c ^ XOR));
                    }

                    byte[] sizeArray = BitConverter.GetBytes(new FileInfo(path).Length);

                    foreach (byte b in sizeArray)
                    {
                        fs.WriteByte((byte)(b ^ XOR));
                    }
                }

                fs.WriteByte((byte)(0 ^ XOR));

                // Write content
                foreach (string path in paths)
                {
                    string internalPath = path.Replace('\\', '/');
                    internalPath = internalPath.Substring(internalPath.IndexOf('/') + 1);

                    using (FileStream fsR = File.OpenRead(path))
                    {
                        int lastPercent = -1;

                        byte[] buffer = new byte[fsR.Length];
                        for (int i = 0; i < fsR.Length; i++)
                        {
                            buffer[i] = (byte)(fsR.ReadByte() ^ XOR);

                            int percent = (int)(i / (float)fsR.Length * 100);

                            if (percent > lastPercent) archiveUpdateCallback?.Invoke(internalPath, percent);

                            lastPercent = percent;
                        }
                        fs.Write(buffer, 0, buffer.Length);
                    }
                    archiveUpdateCallback?.Invoke(internalPath, 100);
                }
            }
        }
    }
}
