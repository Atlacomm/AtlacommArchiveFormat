using System;
using System.Collections.Generic;

namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        public ArchiveFolder GetFileHierarchy()
        {
            // Root Folder
            ArchiveFolder rootFolder = new ArchiveFolder("ROOT");

            // Go through all files in archive
            foreach (string file in Files.Keys)
            {
                // Count the subdirectories the file is in
                int folderCount = file.Length - file.Replace("/", "").Length;

                // Split file path on slash
                string[] split = file.Split('/');

                // Keep track of the current folder
                ArchiveFolder currentFolder = rootFolder;

                // Go through all subdirectories
                for (int i = 0; i < folderCount; i++)
                {
                    // Get current directory
                    string folder = split[i];

                    // Check if the folder already exists in the file structure
                    bool folderExists = false;
                    foreach (ArchiveFolder archiveFolder in currentFolder.Folders)
                    {
                        if (archiveFolder.Name == folder)
                        {
                            // If the folder exists set it as the current folder
                            folderExists = true;
                            currentFolder = archiveFolder;
                            break;
                        }
                    }

                    // If the folder doesn't exist create it and set it as the current folder
                    if (!folderExists)
                    {
                        ArchiveFolder newFolder = new ArchiveFolder(folder);
                        currentFolder.Folders.Add(newFolder);
                        currentFolder = newFolder;
                    }
                }

                // Add the file to the folder
                currentFolder.Files.Add(new ArchiveFile(split[folderCount], Files[file].Length));
            }

            // Return the root folder
            return rootFolder;
        }
    }
}
