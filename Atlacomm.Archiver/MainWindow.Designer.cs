namespace Atlacomm.Archiver
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.fileView = new System.Windows.Forms.ListView();
            this.fileView_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileView_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileView_Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.mainMenu_File = new System.Windows.Forms.MenuItem();
            this.mainMenu_File_Open = new System.Windows.Forms.MenuItem();
            this.mainMenu_File_Exit = new System.Windows.Forms.MenuItem();
            this.mainMenu_Help = new System.Windows.Forms.MenuItem();
            this.mainMenu_Help_About = new System.Windows.Forms.MenuItem();
            this.buttonPrevFolder = new System.Windows.Forms.Button();
            this.fileContextMenu = new System.Windows.Forms.ContextMenu();
            this.fileContextMenu_Extract = new System.Windows.Forms.MenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainMenu_File_Save = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mainMenu_File_SaveDecrypted = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.Enabled = false;
            this.pathTextBox.Location = new System.Drawing.Point(36, 3);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(720, 20);
            this.pathTextBox.TabIndex = 3;
            // 
            // fileView
            // 
            this.fileView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileView_Name,
            this.fileView_Type,
            this.fileView_Size});
            this.fileView.FullRowSelect = true;
            this.fileView.HideSelection = false;
            this.fileView.Location = new System.Drawing.Point(5, 28);
            this.fileView.Name = "fileView";
            this.fileView.Size = new System.Drawing.Size(751, 429);
            this.fileView.TabIndex = 4;
            this.fileView.UseCompatibleStateImageBehavior = false;
            this.fileView.View = System.Windows.Forms.View.Details;
            this.fileView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fileView_MouseClick);
            this.fileView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileView_MouseDoubleClick);
            // 
            // fileView_Name
            // 
            this.fileView_Name.Text = "Name";
            this.fileView_Name.Width = 354;
            // 
            // fileView_Type
            // 
            this.fileView_Type.DisplayIndex = 2;
            this.fileView_Type.Text = "Type";
            this.fileView_Type.Width = 136;
            // 
            // fileView_Size
            // 
            this.fileView_Size.DisplayIndex = 1;
            this.fileView_Size.Text = "Size";
            this.fileView_Size.Width = 135;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Atlacomm Archive Files|*.aaf|All files|*.*";
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mainMenu_File,
            this.mainMenu_Help});
            // 
            // mainMenu_File
            // 
            this.mainMenu_File.Index = 0;
            this.mainMenu_File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mainMenu_File_Open,
            this.mainMenu_File_Save,
            this.mainMenu_File_SaveDecrypted,
            this.menuItem1,
            this.mainMenu_File_Exit});
            this.mainMenu_File.Text = "File";
            // 
            // mainMenu_File_Open
            // 
            this.mainMenu_File_Open.Index = 0;
            this.mainMenu_File_Open.Text = "Open";
            this.mainMenu_File_Open.Click += new System.EventHandler(this.mainMenu_File_Open_Click);
            // 
            // mainMenu_File_Exit
            // 
            this.mainMenu_File_Exit.Index = 4;
            this.mainMenu_File_Exit.Text = "Exit";
            this.mainMenu_File_Exit.Click += new System.EventHandler(this.mainMenu_File_Exit_Click);
            // 
            // mainMenu_Help
            // 
            this.mainMenu_Help.Index = 1;
            this.mainMenu_Help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mainMenu_Help_About});
            this.mainMenu_Help.Text = "Help";
            // 
            // mainMenu_Help_About
            // 
            this.mainMenu_Help_About.Index = 0;
            this.mainMenu_Help_About.Text = "About";
            this.mainMenu_Help_About.Click += new System.EventHandler(this.mainMenu_Help_About_Click);
            // 
            // buttonPrevFolder
            // 
            this.buttonPrevFolder.BackgroundImage = global::Atlacomm.Archiver.Properties.Resources.arrowUp;
            this.buttonPrevFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPrevFolder.Location = new System.Drawing.Point(5, 0);
            this.buttonPrevFolder.Name = "buttonPrevFolder";
            this.buttonPrevFolder.Size = new System.Drawing.Size(25, 25);
            this.buttonPrevFolder.TabIndex = 2;
            this.buttonPrevFolder.UseVisualStyleBackColor = true;
            this.buttonPrevFolder.Click += new System.EventHandler(this.buttonPrevFolder_Click);
            // 
            // fileContextMenu
            // 
            this.fileContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileContextMenu_Extract});
            // 
            // fileContextMenu_Extract
            // 
            this.fileContextMenu_Extract.Index = 0;
            this.fileContextMenu_Extract.Text = "Extract";
            this.fileContextMenu_Extract.Click += new System.EventHandler(this.fileContextMenu_Extract_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "All files|*.*";
            // 
            // mainMenu_File_Save
            // 
            this.mainMenu_File_Save.Index = 1;
            this.mainMenu_File_Save.Text = "Save";
            this.mainMenu_File_Save.Click += new System.EventHandler(this.mainMenu_File_Save_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // mainMenu_File_SaveDecrypted
            // 
            this.mainMenu_File_SaveDecrypted.Index = 2;
            this.mainMenu_File_SaveDecrypted.Text = "Save (decrypted)";
            this.mainMenu_File_SaveDecrypted.Click += new System.EventHandler(this.mainMenu_File_SaveDecrypted_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 461);
            this.Controls.Add(this.fileView);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.buttonPrevFolder);
            this.Menu = this.mainMenu;
            this.Name = "MainWindow";
            this.Text = "Atlacomm Archiver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPrevFolder;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.ListView fileView;
        private System.Windows.Forms.ColumnHeader fileView_Name;
        private System.Windows.Forms.ColumnHeader fileView_Size;
        private System.Windows.Forms.ColumnHeader fileView_Type;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem mainMenu_File;
        private System.Windows.Forms.MenuItem mainMenu_File_Open;
        private System.Windows.Forms.MenuItem mainMenu_File_Exit;
        private System.Windows.Forms.MenuItem mainMenu_Help;
        private System.Windows.Forms.MenuItem mainMenu_Help_About;
        private System.Windows.Forms.ContextMenu fileContextMenu;
        private System.Windows.Forms.MenuItem fileContextMenu_Extract;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuItem mainMenu_File_Save;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mainMenu_File_SaveDecrypted;
    }
}