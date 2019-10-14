using System;
using System.Collections.Generic;
using System.IO;

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

        // Contains raw decrypted file data (index + files)
        readonly byte[] data;

        public Archive(string filepath)
        {
            // Whether or not the archive need to be decrypted
            bool decrypt = true;

            // Load archive file
            data = File.ReadAllBytes(filepath);

            // Go through the data
            for (int i = 0; i < data.Length; i++)
            {
                // Check whether the current byte is part of the header
                if (i < HEADER.Length)
                {
                    // Check whether the current header byte is valid
                    if (data[i] != HEADER[i])
                    {
                        // If the header is not valid check if the file is decrypted
                        if (data[i] != (byte)(HEADER[i] ^ XOR))
                        {
                            // If the file is neither a valid decrypted nor an encrypted archive throw a FileFormatException
                            throw new FileFormatException("Invalid file header");
                        }
                        else
                        {
                            // If the file has a valid decrypted file header make sure that the decrypted file will not be encrypted again
                            decrypt = false;
                        }
                    }
                }

                // Decrypt the current byte of the file if neccessary
                if (decrypt) data[i] = (byte)(data[i] ^ XOR);
            }

            // Index
            Dictionary<string, long> index = new Dictionary<string, long>();

            // Offset at which file content starts
            int contentOffset = 0;

            // Populate the index
            for (int i = HEADER.Length; i < data.Length;)
            {
                // First byte is the length of the path
                int pathLength = data[i]; i++;

                // path's length also used as the index terminator if zero
                if (pathLength == 0)
                {
                    contentOffset = i;
                    break;
                }

                // Read the path
                string path = "";
                for (int j = 0; j < pathLength; j++, i++)
                {
                    path += (char)data[i];
                }

                // Read 8 bytes and convert them to a 64 bit integer to get the file's size
                byte[] sizeBytes = new byte[8];
                for (int j = 0; j < 8; j++, i++)
                {
                    sizeBytes[j] = data[i];
                }
                long size = BitConverter.ToInt64(sizeBytes, 0);

                // Add the current file to the index
                index.Add(path, size);
            }


            // Use the index to load all files
            foreach (string file in index.Keys)
            {
                byte[] fileData = new byte[index[file]];

                for (int i = 0; i < fileData.Length; i++, contentOffset++)
                {
                    fileData[i] = data[contentOffset];
                }

                Files.Add(file, fileData);
            }
        }
    }
}
