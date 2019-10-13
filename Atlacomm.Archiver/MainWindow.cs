using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Atlacomm.ArchiveFormat;

namespace Atlacomm.Archiver
{
    public partial class MainWindow : Form
    {
        Archive archive = null;
        ArchiveFolder rootFolder;
        ArchiveFolder currentFolder;

        List<ArchiveFolder> parentFolders = new List<ArchiveFolder>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void LoadArchive(string path)
        {
            archive = new Archive(path);
            rootFolder = archive.GetAsStruct();
            currentFolder = rootFolder;
        }

        public void UpdateFileView()
        {
            fileView.Items.Clear();

            foreach (ArchiveFolder folder in currentFolder.Folders)
            {
                ListViewItem item = new ListViewItem(folder.Name); // Name
                item.SubItems.Add("File folder"); // Type
                item.SubItems.Add(""); // Size

                fileView.Items.Add(item);
            }

            foreach (ArchiveFile file in currentFolder.Files)
            {
                ListViewItem item = new ListViewItem(file.Name); // Name

                string[] extension = file.Name.Split('.');
                if (extension.Length == 1) item.SubItems.Add("File"); // Type
                else item.SubItems.Add(extension[extension.Length - 1].ToUpper() + " File");
                item.SubItems.Add(file.Size + " KB"); // Size

                fileView.Items.Add(item);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadArchive("test.aaf");
            UpdateFileView();
        }

        private void fileView_DoubleClick(object sender, EventArgs e)
        {
            string selectedItem = fileView.SelectedItems[0].Text;

            foreach (ArchiveFolder folder in currentFolder.Folders)
            {
                if (folder.Name == selectedItem)
                {
                    parentFolders.Add(currentFolder);
                    currentFolder = folder;
                    break;
                }
            }

            UpdateFileView();
        }

        private void buttonPrevFolder_Click(object sender, EventArgs e)
        {
            if (parentFolders.Count == 0) return;

            currentFolder = parentFolders[parentFolders.Count - 1];
            parentFolders.RemoveAt(parentFolders.Count - 1);

            UpdateFileView();
        }
    }
}
