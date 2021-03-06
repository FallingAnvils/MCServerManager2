﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Renci.SshNet;

namespace MCServerManager2
{
    public partial class MainForm : Form
    {
        public static string ModpackDownloaderExeName = "mcmpgen.exe";
        public static string BungeeCordHandlerExeName = "bungeecordhandler.exe";

        ServerManagerHandler handler;
        public MainForm()
        {
            InitializeComponent();
        }

        public void Pause()
        {
            this.UseWaitCursor = true;
            this.Enabled = false;
            //MessageBox.Show("Pausing");
        }

        public void Resume()
        {
            this.Enabled = true;
            this.UseWaitCursor = false;
            //MessageBox.Show("Resuming");
        }

        string Editor;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => new AboutBox().ShowDialog();

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("Not yet, sorry.");

        private void MainForm_Load(object sender, EventArgs e)
        {
            var cfg = Config.ReadConfigFile("config.json");
            cfg = cfg == null ? new ConfigObject() : cfg;
            if(cfg.Hostname.IsNullOrWhiteSpace())
            {
                var result = TextPrompt.Prompt("Enter the hostname (IP Address)", "Hostname", false, false);
                if (result == null) Environment.Exit(1);
                cfg.Hostname = result;
            }
            if (cfg.Username.IsNullOrWhiteSpace())
            {
                var result = TextPrompt.Prompt("Enter the username", "Username", false, false);
                if (result == null) Environment.Exit(1);
                cfg.Username = result;
            }
            if (cfg.Port == 0)
            {
                var result = TextPrompt.Prompt("Enter the port (default 22)", "Port", false, false);
                if (result == null) Environment.Exit(1);
                int resultInt;
                if (!int.TryParse(result, out resultInt)) Environment.Exit(1);
                cfg.Port = resultInt;
            }
            if (cfg.Password.IsNullOrWhiteSpace())
            {
                cfg.Password = TextPrompt.Prompt("Enter the password", "Password", true, true);
            }

            if (!cfg.ModpackDownloaderExeName.IsNullOrWhiteSpace())
                ModpackDownloaderExeName = cfg.ModpackDownloaderExeName;

            if (!cfg.BungeeCordHandlerExeName.IsNullOrWhiteSpace())
                BungeeCordHandlerExeName = cfg.BungeeCordHandlerExeName;


            mountPoint_TextBox.Text = cfg.MountPoint;
            remoteLocation_TextBox.Text = cfg.RemoteLocation;

            Editor = cfg.Editor;

            if (!cfg.ServerPath.IsNullOrWhiteSpace()) mcServerPath_TextBox.Text = cfg.ServerPath;

            handler = new ServerManagerHandler(cfg);

            EventHandler<Renci.SshNet.Common.ExceptionEventArgs> sshError = (s, e2) =>
            {
                MessageBox.Show("An error has occurred: " + e2.Exception.Message);
                Console.Error.WriteLine(e2.Exception.ToString());
                connected_ToolStripLabel.Text = ((BaseClient)s).IsConnected ? "Connected" : "Failed to connect";
            };

            handler.SshHandler._Client.ErrorOccurred += sshError;
            handler.SftpHandler._Client.ErrorOccurred += sshError;

                                                  // so now visual studio wants to complain about you... but you work fine... and what about the stuff after it?
            MiscTools.SpawnBackgroundWorker(() => this.Invoke((MethodInvoker)(() => connected_ToolStripLabel.Text = handler.Connect() ? "Connected" : "Failed to connect")), () => {
                if(handler.IsConnected) // things to run as soon as connected
                {
                    mcServerPath_TextBox.Text = handler.SshHandler.RealPath(mcServerPath_TextBox.Text);
                    RefreshViews();
                    if (cfg.ExpandAllOnStart)
                    {
                        idleInstances_TreeView.ExpandAllExcept(x => x.EndsWith("launch.sh"));
                        runningInstances_TreeView.ExpandAllExcept(x => x.EndsWith("launch.sh"));
                    }
                }
            });           
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (handler != null && handler.IsConnected) handler.Cleanup();
        }


        private void RefreshViews(List<string> addToRunning = null, List<string> addToIdle = null)
        {
            Pause();
            var runexp = runningInstances_TreeView.Nodes.GetExpansionState();
            var runidl = idleInstances_TreeView.Nodes.GetExpansionState();

            if (addToRunning != null) runexp.AddRange(addToRunning);
            if (addToIdle != null) runidl.AddRange(addToIdle);

            handler.PopulateViews(runningInstances_TreeView, idleInstances_TreeView, mcServerPath_TextBox.Text);
            //runningInstances_TreeView.ExpandAll(); // these
            //idleInstances_TreeView.ExpandAll();    // are temporary

            runningInstances_TreeView.Nodes.SetExpansionState(runexp);
            idleInstances_TreeView.Nodes.SetExpansionState(runidl);
            Resume();
        }

        private void refreshLists_Button_Click(object sender, EventArgs e) => RefreshViews();

        private void start_Button_Click(object sender, EventArgs e)
        {
            TreeNode node;
            if ((node = idleInstances_TreeView.SelectedNode) != null)
            {
                var nodes = TreeViewHandler.GetAllChildren(node);
                //var serverpathreal = handler.SshHandler.RealPath(mcServerPath_TextBox.Text);
                var scriptPaths = nodes.Where(x => x.FullPath.EndsWith("launch.sh")).Select(x => x.FullPath);
                handler.StartInstances(scriptPaths);
                var addToRunning = node.Nodes.GetExpansionState();
                addToRunning.AddRange(node.AllParents());
                addToRunning.Add(node.FullPath);
                RefreshViews(addToRunning);
            }
            else
            {
                MessageBox.Show("No instance or instance group selected");
            }
        }

        private void stop_Button_Click(object sender, EventArgs e)
        {
            TreeNode node;
            if((node = runningInstances_TreeView.SelectedNode) != null)
            {
                var nodes = TreeViewHandler.GetAllChildren(node);
                var scriptpaths = nodes.Where(x => x.FullPath.EndsWith("launch.sh")).Select(x => x.FullPath);
                ((Button)sender).Enabled = false;
                handler.StopInstances(scriptpaths).ContinueWith(x => this.Invoke((MethodInvoker)(() => 
                {
                    var expanded = node.Nodes.GetExpansionState();
                    if (node.Parent.IsExpanded) expanded.Add(node.Parent.FullPath);
                    if (node.IsExpanded) expanded.Add(node.FullPath);
                    RefreshViews(null, expanded);
                    ((Button)sender).Enabled = true;
                })));
            }
            else
            {
                MessageBox.Show("No running instance or instance group selected");
            }
        }

        private void kill_Button_Click(object sender, EventArgs e)
        {
            TreeNode node;
            if((node = runningInstances_TreeView.SelectedNode) != null)
            {
                var nodes = TreeViewHandler.GetAllChildren(node);
                var scriptpaths = nodes.Where(x => x.FullPath.EndsWith("launch.sh")).Select(x => x.FullPath);
                Pause();
                handler.KillInstances(scriptpaths);
                RefreshViews();
            }
            else
            {
                MessageBox.Show("No running instance or instance group selected");
            }
        }

        private void restart_Button_Click(object sender, EventArgs e)
        {
            TreeNode node;
            if ((node = runningInstances_TreeView.SelectedNode) != null)
            {
                var nodes = TreeViewHandler.GetAllChildren(node);
                var scriptpaths = nodes.Where(x => x.FullPath.EndsWith("launch.sh")).Select(x => x.FullPath);
                Pause();
                handler.StopInstances(scriptpaths).ContinueWith(x => { handler.StartInstances(scriptpaths); this.Invoke((MethodInvoker)(() => RefreshViews())); });
            }
            else
            {
                MessageBox.Show("No running instance or instance group selected");
            }
        }

        private void expandLists_Button_Click(object sender, EventArgs e)
        {
            //idleInstances_TreeView.ExpandAll();
            idleInstances_TreeView.ExpandAllExcept(x => x.EndsWith("launch.sh"));
            //runningInstances_TreeView.ExpandAll();
            runningInstances_TreeView.ExpandAllExcept(x => x.EndsWith("launch.sh"));
        }

        private void open_Button_Click(object sender, EventArgs e)
        {
            TreeNode node;
            if ((node = runningInstances_TreeView.SelectedNode) != null)
            {
                var nodes = TreeViewHandler.GetAllChildren(node);
                var scriptpaths = nodes.Where(x => x.FullPath.EndsWith("launch.sh")).Select(x => x.FullPath);
                handler.OpenPutties(scriptpaths);
            }
            else
            {
                MessageBox.Show("No running instance or instance group selected");
            }
        }

        private void createInstance_Button_Click(object sender, EventArgs e)
        {
            var installTypeChooser = new InstallTypeChooser();
            if(installTypeChooser.ShowDialog() == DialogResult.OK)
            {
                var creator = new InstanceCreationWizard();
                creator.BasePath = mcServerPath_TextBox.Text;
                switch (installTypeChooser.SelectionBox.SelectedItem)
                {
                    case "Modded":
                        creator.ServerType = ServerType.Modded;
                        creator.Order = CreatorTabOrder.Modded;
                        creator.ShowDialog();

                        var tupm = creator.ResultValues;
                        MiscTools.SpawnBackgroundWorker(() => handler.CreateInstance(tupm.Item1).WaitForExit(), () => {
                            if (tupm.Item2 != null) handler.BungeeifyInstance(tupm.Item2, tupm.Item1.InstancesPath);
                        });                        
                        break;
                    case "Spigot":
                        creator.ServerType = ServerType.Bukkit;
                        creator.Order = CreatorTabOrder.Spigot;
                        creator.ShowDialog();

                        var tups = creator.ResultValues;
                        MiscTools.SpawnBackgroundWorker(() => handler.CreateInstance(tups.Item1).WaitForExit(),
                        () => { if (tups.Item2 != null) handler.BungeeifyInstance(tups.Item2, tups.Item1.InstancesPath); });
                        break;
                    case "Bedrock":
                        creator.ServerType = ServerType.Bedrock;
                        creator.Order = CreatorTabOrder.Bedrock;
                        creator.ShowDialog();

                        var tupb = creator.ResultValues;
                        handler.CreateInstance(tupb.Item1);
                        break;
                }
            }

            //var creator = new InstanceCreationWizard();
           // creator.Order = new[] { 0, 4, 8, 1, 3 };
           // creator.ShowDialog();
        }

        private void modifyInstance_Button_Click(object sender, EventArgs e)
        {
            var modifyTypeChooser = new ModifyTypeChooser();
            if (modifyTypeChooser.ShowDialog() == DialogResult.OK)
            {
                switch(modifyTypeChooser.SelectionBox.SelectedItem)
                {
                    case "Modify":
                        /*if (GetAnySelectedNode() != null)
                        {
                            var modifier = new InstanceModifier();
                            modifier.Editor = Editor;
                            modifier.ManagerHandler = handler;
                            modifier.FullDirPath = GetAnySelectedNode().FullPath;
                            modifier.Show();
                        }
                        else
                        {
                            MessageBox.Show("Select a directory in the idle instances.");
                        }*/
                        MessageBox.Show("This is pretty broken and useless right now. You should probably just have the drive mounted and use your own text editor and other programs.");
                        break;
                    case "Update":
                        if (GetAnySelectedNode() != null)
                        {
                            var children = GetAnySelectedNode().Nodes;
                            bool isInstance = false;
                            foreach (TreeNode child in children)
                                if (child.Text.Equals("launch.sh")) isInstance = true;
                            if(isInstance)
                            {
                                var instpath = GetAnySelectedNode().FullPath;
                                var wizard = new InstanceCreationWizard();
                                wizard.Order = new[] { CreatorTab.Start, CreatorTab.DownloadLink };
                                wizard.instanceName_TextBox.Text = instpath.Substring(MiscTools.CommonStartsWith(instpath, mcServerPath_TextBox.Text).Length);
                                wizard.BasePath = mcServerPath_TextBox.Text;

                                var chooser = new InstallTypeChooser();
                                if (chooser.ShowDialog() == DialogResult.OK)
                                {
                                    switch (chooser.SelectionBox.SelectedItem)
                                    {
                                        case "Modded":
                                            wizard.ServerType = ServerType.Modded;
                                            break;
                                        case "Spigot":
                                            wizard.ServerType = ServerType.Bukkit;
                                            break;
                                        case "Bedrock":
                                            wizard.ServerType = ServerType.Bedrock;
                                            break;
                                    }
                                }
                                if (wizard.ShowDialog() == DialogResult.OK)
                                {
                                    if(wizard.ServerType == ServerType.Modded) wizard.ResultValues.Item1.ExcludedFiles = new[] { // TODO: don't hardcode this
                "backups",
                "journeymap",
                "logs",
                "schematics",
                "world",
                "banned-ips.json",
                "banned-players.json",
                "eula.txt",
                "ops.json",
                "server.properties",
                "usercache.json",
                "usernamecache.json",
                "whitelist.json",
                "mods/aaasponge.jar",
                "config/sponge"
            };
                                    handler.UpdateInstance(wizard.ResultValues.Item1);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Select an instance in the idle instances");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select an instance in the idle instances");
                        }
                        break;
                }
            }
        }

        private void deleteInstances_Button_Click(object sender, EventArgs e)
        {
            if(idleInstances_TreeView.SelectedNode != null)
            {
                var toRemove = idleInstances_TreeView.SelectedNode.FullPath;
                if (MessageBox.Show(this, "Are you using BungeeCord? If using it, you must select the INSTANCE, not a containing folder", "BungeeCord", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {

                    var bungeeLocation = mcServerPath_TextBox.Text.BetterPathJoinSlash(TextPrompt.Prompt("Type the BungeeCord instance location", "BungeeCord", false, false));

                    var configpath = bungeeLocation.BetterPathJoinSlash("config.yml");

                    if (handler.SftpHandler._Client.Exists(configpath))
                    {
                        List<string> file = new List<string>(handler.SftpHandler._Client.ReadAllLines(configpath));

                        var shortname = toRemove.Split('/').Last().Replace(' ', '_');
                        var instanceIndex = file.IndexOf("  " + shortname + ":");

                        if (instanceIndex < 0)
                        {
                            MessageBox.Show("Instance wasn't found in BungeeCord config!");
                        }
                        else
                        {
                            var instanceDefinitionLength = 4;
                            for (int i = 0; i < instanceDefinitionLength; i++)
                            {
                                file.RemoveAt(instanceIndex);
                            }

                            // because sftp writealllines doesn't overwrite the entire file
                            handler.SftpHandler._Client.DeleteFile(configpath);

                            handler.SftpHandler._Client.WriteAllLines(configpath, file);

                            handler.SshHandler.RunCommand("rm -rf " + toRemove);
                            RefreshViews();
                        }
                    }
                    else
                    {
                        MessageBox.Show("It's not a BungeeCord instance or there's no config.yml");
                    }
                }
                else
                {
                    if (MessageBox.Show("Do you REALLY want to delete this PERMANENTLY?", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (MessageBox.Show("Do you REALLY REALLY want to delete this PERMANENTLY?", "Are you REALLY sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (MessageBox.Show("It's PERMANENT. Do you REALLY want to do this?", "ARE YOU REALLY SURE?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                if (MessageBox.Show("By clicking OK, the instance tree will be PERMANENTLY DELETED. THIS IS YOUR LAST CHANCE TO CLICK CANCEL.", "THIS IS YOUR LAST CHANCE!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    handler.SshHandler.RunCommand("rm -rf " + toRemove);
                                    RefreshViews();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a directory in the idle instances.");
            }
        }

        private void openMonitor_Button_Click(object sender, EventArgs e)
        {
            var monitorer = new ServerMonitorer();
            monitorer.ManagerHandler = handler;
            monitorer.Show();
        }

        private void openFolder_Button_Click(object sender, EventArgs e)
        {
            TreeNode node;
            if((node = GetAnySelectedNode()) != null)
            {
                var selected = node.FullPath;
                var loc = mountPoint_TextBox.Text + selected.Substring(MiscTools.CommonStartsWith(selected, remoteLocation_TextBox.Text).Length).Replace('/', Path.DirectorySeparatorChar);
                Process.Start(loc);
            }
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout();
        }

        private TreeNode GetAnySelectedNode()
        {
            return idleInstances_TreeView.SelectedNode != null ? idleInstances_TreeView.SelectedNode : runningInstances_TreeView.SelectedNode != null ? runningInstances_TreeView.SelectedNode : null;
        }

        private void runningInstances_TreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if(idleInstances_TreeView.SelectedNode != null)
            {
                idleInstances_TreeView.SelectedNode = null;
            }
        }

        private void idleInstances_TreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (runningInstances_TreeView.SelectedNode != null)
            {
                runningInstances_TreeView.SelectedNode = null;
            }
        }
    }
}
