using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Atlacomm.ArchiveFormat;

namespace Atlacomm.Archiver
{
    public partial class MainWindow : Form
    {
        Archive archive = null;
        ArchiveFolder rootFolder = null;
        ArchiveFolder currentFolder = null;

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
            if (archive == null) return;
            if (rootFolder == null) return;
            if (currentFolder == null) return;

            fileView.Items.Clear();

            foreach (ArchiveFolder folder in currentFolder.Folders)
            {
                ListViewItem item = new ListViewItem(folder.Name); // Name
                item.SubItems.Add("File folder"); // Type
                item.SubItems.Add(folder.SizeFormatted); // Size

                fileView.Items.Add(item);
            }

            foreach (ArchiveFile file in currentFolder.Files)
            {
                ListViewItem item = new ListViewItem(file.Name); // Name

                string[] extension = file.Name.Split('.');
                if (extension.Length == 1) item.SubItems.Add("File"); // Type
                else item.SubItems.Add(extension[extension.Length - 1].ToUpper() + " file");

                item.SubItems.Add(file.SizeFormatted); // Size

                fileView.Items.Add(item);
            }

            string path = "/";

            for (int i = 1; i < parentFolders.Count; i++)
            {
                path += parentFolders[i].Name;
                path += "/";
            }

            if (currentFolder.Name != rootFolder.Name) path += currentFolder.Name;

            pathTextBox.Text = path;
        }

        private void fileView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                string path = "";

                for (int i = 1; i < parentFolders.Count; i++)
                {
                    path += parentFolders[i].Name;
                    path += "/";
                }

                if (currentFolder.Name != rootFolder.Name) path += currentFolder.Name + "/";
                path += fileView.SelectedItems[0].Text;

                if (archive.Contains(path)) fileContextMenu.Show(fileView, e.Location);
            }
        }

        private void fileView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string selectedItem = fileView.SelectedItems[0].Text;

                foreach (ArchiveFolder folder in currentFolder.Folders)
                {
                    if (folder.Name == selectedItem)
                    {
                        parentFolders.Add(currentFolder);
                        currentFolder = folder;
                        UpdateFileView();
                        break;
                    }
                }
            }
        }

        private void buttonPrevFolder_Click(object sender, EventArgs e)
        {
            if (parentFolders.Count == 0) return;

            currentFolder = parentFolders[parentFolders.Count - 1];
            parentFolders.RemoveAt(parentFolders.Count - 1);

            UpdateFileView();
        }

        private void mainMenu_File_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainMenu_File_Open_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadArchive(openFileDialog.FileName);

                UpdateFileView();
            }
        }

        private void mainMenu_Help_About_Click(object sender, EventArgs e)
        {
            new AboutWindow().ShowDialog();
        }

        private void fileContextMenu_Extract_Click(object sender, EventArgs e)
        {
            string selectedItem = fileView.SelectedItems[0].Text;

            string path = "";

            for (int i = 1; i < parentFolders.Count; i++)
            {
                path += parentFolders[i].Name;
                path += "/";
            }

            if (currentFolder.Name != rootFolder.Name) path += currentFolder.Name + "/";
            path += selectedItem;

            byte[] file = archive.GetFile(path);

            string cleanFilter = openFileDialog.Filter;

            saveFileDialog.Filter = selectedItem + "|" + selectedItem + "|" + openFileDialog.Filter;
            saveFileDialog.FileName = selectedItem;

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, file);
            }

            saveFileDialog.Filter = cleanFilter;
        }
    }
}
