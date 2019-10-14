using System;
using System.Collections.Generic;

namespace Atlacomm.ArchiveFormat
{
    public class ArchiveFile
    {
        public string Name;
        public long Size;

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

    public class ArchiveFolder
    {
        public string Name;
        public List<ArchiveFile> Files;
        public List<ArchiveFolder> Folders;

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

        public ArchiveFolder(string name, IList<ArchiveFile> files = null, IList<ArchiveFolder> folders = null)
        {
            Name = name;
            Files = new List<ArchiveFile>(files ?? Array.Empty<ArchiveFile>());
            Folders = new List<ArchiveFolder>(folders ?? Array.Empty<ArchiveFolder>());
        }

        public long Size
        {
            get
            {
                long ret = 0;

                foreach (ArchiveFile file in Files)
                {
                    ret += file.Size;
                }

                foreach (ArchiveFolder folder in Folders)
                {
                    ret += folder.Size;
                }

                return ret;
            }
        }

        public override string ToString()
        {
            return ToString(0);
        }

        public string ToString(int level = 0)
        {
            string ret = "";

            for (int i = 0; i < level; i++)
            {
                ret += "  ";
            }

            ret += Name;

            foreach (ArchiveFolder folder in Folders)
            {
                ret += "\n";

                ret += folder.ToString(level + 1);
            }

            foreach (ArchiveFile file in Files)
            {
                ret += "\n";

                for (int i = 0; i < level + 1; i++)
                {
                    ret += "  ";
                }

                ret += file.ToString();
            }

            return ret;
        }
    }

    public partial class Archive
    {
        public ArchiveFolder GetAsStruct()
        {
            ArchiveFolder rootFolder = new ArchiveFolder("ROOT");

            foreach (string file in Files.Keys)
            {
                int folderCount = file.Length - file.Replace("/", "").Length;
                string[] split = file.Split('/');

                ArchiveFolder currentFolder = rootFolder;

                for (int i = 0; i < folderCount; i++)
                {
                    string folder = split[i];

                    bool folderExists = false;
                    foreach (ArchiveFolder archiveFolder in currentFolder.Folders)
                    {
                        if (archiveFolder.Name == folder)
                        {
                            folderExists = true;
                            currentFolder = archiveFolder;
                            break;
                        }
                    }

                    if (!folderExists)
                    {
                        ArchiveFolder newFolder = new ArchiveFolder(folder);
                        currentFolder.Folders.Add(newFolder);
                        currentFolder = newFolder;
                    }
                }

                currentFolder.Files.Add(new ArchiveFile(split[folderCount], Files[file].Length));
            }

            return rootFolder;
        }
    }
}
