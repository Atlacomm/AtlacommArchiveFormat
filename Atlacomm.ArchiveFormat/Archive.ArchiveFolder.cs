using System;
using System.Collections.Generic;

namespace Atlacomm.ArchiveFormat
{
    public class ArchiveFolder
    {
        // Folder name
        public string Name;

        // Files
        public List<ArchiveFile> Files;

        // Subdirectories
        public List<ArchiveFolder> Folders;

        // Get size formatted
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

        // Calculate and return folder size
        public long Size
        {
            get
            {
                long ret = 0;
                foreach (ArchiveFile file in Files) ret += file.Size;
                foreach (ArchiveFolder folder in Folders) ret += folder.Size;
                return ret;
            }
        }

        public ArchiveFolder(string name, IList<ArchiveFile> files = null, IList<ArchiveFolder> folders = null)
        {
            Name = name;
            Files = new List<ArchiveFile>(files ?? Array.Empty<ArchiveFile>());
            Folders = new List<ArchiveFolder>(folders ?? Array.Empty<ArchiveFolder>());
        }

        // Return folder name
        public override string ToString()
        {
            return Name;
        }
    }
}
