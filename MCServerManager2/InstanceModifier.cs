using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Renci.SshNet.Sftp;

namespace MCServerManager2
{
    public partial class InstanceModifier : Form
    {
        public string FullDirPath;
        public ServerManagerHandler ManagerHandler;
        public string Editor;

        public void Pause()
        {
            this.UseWaitCursor = true;
            this.Enabled = false;
        }

        public void Resume()
        {
            this.Enabled = true;
            this.UseWaitCursor = false;
        }

        public InstanceModifier()
        {
            InitializeComponent();
        }

        private void InstanceModifier_Load(object sender, EventArgs e)
        {
            RefreshFileList();
            ExpandToInstance();
        }

        public void RefreshFileList()
        {
            Pause();
            var expanded = fileList_TreeView.Nodes.GetExpansionState();

            fileList_TreeView.Nodes.Clear();
            TreeViewHandler.Add(fileList_TreeView, ManagerHandler.SshHandler.FilesInDirectory(FullDirPath));

            fileList_TreeView.Nodes.SetExpansionState(expanded);
            Resume();
        }

        private void editFile_Button_Click(object sender, EventArgs e)
        {
            // is the selected node a file?
            if(ManagerHandler.SshHandler.RunCommand("test -f " + fileList_TreeView.SelectedNode.FullPath.Quotate()).ExitCode == 0)
            {
                var file = fileList_TreeView.SelectedNode.FullPath;
                var localfile = new FileInfo(file.Split('/').Last());
                ManagerHandler.SftpHandler.Download(file, localfile);
                Process proc;
                if (Editor == null)
                    proc = Process.Start(localfile.FullName.Quotate());
                else
                    proc = Process.Start(Editor, localfile.FullName.Quotate());

                MiscTools.SpawnBackgroundWorker(() => proc.WaitForExit(), () => {
                    ManagerHandler.SftpHandler.UploadAndDelete(localfile, file);
                });
            }
            else
            {
                MessageBox.Show("Selected node is not a file");
            }
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            if(fileList_TreeView.SelectedNode != null)
            {
                if(MessageBox.Show("Are you sure you want to delete this file/directory tree? THIS CANNOT BE UNDONE", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var path = fileList_TreeView.SelectedNode.FullPath;
                    ManagerHandler.SshHandler.RunCommand("rm -rf " + path.Quotate());
                    RefreshFileList();
                }
            }
        }

        private void refreshFileList_Button_Click(object sender, EventArgs e)
        {
            RefreshFileList();
        }

        private void expandAll_Button_Click(object sender, EventArgs e)
        {
            fileList_TreeView.ExpandAll();
        }

        private void uploadFiles_Button_Click(object sender, EventArgs e)
        {
            if(fileList_TreeView.SelectedNode != null)
            {
                var dialog = new OpenFileDialog();
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.Multiselect = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Pause();
                    foreach (var fullpath in dialog.FileNames)
                    {
                        var name = new FileInfo(fullpath).Name;
                        ManagerHandler.SftpHandler.Upload(new FileInfo(fullpath), fileList_TreeView.SelectedNode.FullPath.BetterPathJoinSlash(name));
                    }
                    RefreshFileList();
                    Resume();
                }
            }
            else
            {
                MessageBox.Show("Select a directory to upload to");
            }

        }

        public void ExpandToInstance()
        {
            var node = fileList_TreeView.Nodes.FindTreeNodeByFullPath(FullDirPath);
            node.ExpandParents();
            node.Expand();
        }

        private void expandToInstance_Button_Click(object sender, EventArgs e) => ExpandToInstance();

        private void download_Button_Click(object sender, EventArgs e)
        {
            var node = fileList_TreeView.SelectedNode;
            if (ManagerHandler.SshHandler.RunCommand("test -f " + node.FullPath.Quotate()).ExitCode == 0)
            {
                var dialog = new SaveFileDialog();
                var ext = node.Text.Split('.').Last();
                dialog.Filter = $"File of type (*.{ext})|*.{ext}";
                dialog.DefaultExt = ext;
                dialog.AddExtension = true;
                dialog.FileName = node.Text;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MiscTools.SpawnBackgroundWorker(() => ManagerHandler.SftpHandler.Download(node.FullPath, new FileInfo(dialog.FileName)));
                }
            }
            else
            {
                MessageBox.Show("Selected node is not a file");
            }
        }

        private void installJar_Button_Click(object sender, EventArgs e)
        {
            if(fileList_TreeView.SelectedNode != null)
            {
                var dir = fileList_TreeView.SelectedNode.FullPath;
                var result = TextPrompt.Prompt("Enter the URL to download", "Install JAR", false, false);
                if (result != null)
                {
                    Pause();
                    var realurl = ManagerHandler.SshHandler.RunCommand("curl -Ls -w %{url_effective} -o /dev/null " + result).StdOut;
                    var newname = realurl.Split('/').Last();  // not the full path
                    var modname = newname.Split('-').First(); // the name of the mod, e.g. "worldedit" in "worldedit-5.2.5.jar"

                    bool isOldVersionInstalled = false;
                    var oldVersion = string.Empty; // full path
                    foreach (var item in ManagerHandler.SftpHandler._Client.ListDirectory(dir))
                    {
                        if (item.IsRegularFile && item.Name.Contains(modname))
                        {
                            isOldVersionInstalled = true;
                            oldVersion = item.FullName;
                        }
                    }

                    if (isOldVersionInstalled)
                    {
                        if (MessageBox.Show("Mod " + modname.Quotate() + " is already installed. You are replacing version " + oldVersion.Split('/').Last().Quotate() + " with version " + newname.Quotate() + ". Yes (replace) or No (don't replace)?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ManagerHandler.SftpHandler._Client.DeleteFile(oldVersion);

                            ManagerHandler.SshHandler.RunCommand(("cd " + dir).CombineCommand("wget --content-disposition " + realurl));
                        }
                    }
                    else
                    {
                        ManagerHandler.SshHandler.RunCommand(("cd " + dir).CombineCommand("wget --content-disposition " + realurl));
                    }
                    Resume();
                    RefreshFileList();
                }
            }
            else
            {
                MessageBox.Show("Select a directory to install to (the mods or plugins folder)");
            }
        }
    }
}
