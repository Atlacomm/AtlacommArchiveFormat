using System;

namespace Atlacomm.ArchiveFormat
{
    public class ArchiveFile
    {
        // File name
        public string Name;

        // File size
        public long Size;

        // Get string formatted
        public string SizeFormatted
        {
            get
            {
                double size = Size;
                string unit = "bytes";
                if (size >= 1024)
                {
                    size /= 1024;
                    unit = "KB";
                }
                if (size >= 1024)
                {
                    size /= 1024;
                    unit = "MB";
                }
                if (size >= 1024)
                {
                    size /= 1024;
                    unit = "GB";
                }
                if (size >= 1024)
                {
                    size /= 1024;
                    unit = "TB";
                }

                return Math.Round(size, 1).ToString() + " " + unit;
            }
        }

        public ArchiveFile(string name, long size)
        {
            Name = name;
            Size = size;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
