using System;
using System.IO;

namespace Atlacomm.Archive
{
    public partial class Archive
    {
        public static void Create(string source, string destination)
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
                    using (FileStream fsR = File.OpenRead(path))
                    {
                        byte[] buffer = new byte[fsR.Length];
                        for (int i = 0; i < fsR.Length; i++)
                        {
                            buffer[i] = (byte)(fsR.ReadByte() ^ XOR);
                        }

                        fs.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
