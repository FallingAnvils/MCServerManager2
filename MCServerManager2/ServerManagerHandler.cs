using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCServerManager2
{
    public class ServerManagerHandler
    {
        public const string ServerScreenPrefix = "MSM.";

        public PuttyOpener PuttyOpener;
        public SshHandler SshHandler;
        public SftpHandler SftpHandler;

        public bool IsConnected { get { return SshHandler.IsConnected && SftpHandler.IsConnected; } }

        public ServerManagerHandler(ConfigObject cfg)
        {
            PuttyOpener = new PuttyOpener(cfg.Username, cfg.Hostname, cfg.Password, cfg.Port);
            SshHandler = new SshHandler(cfg.Username, cfg.Hostname, cfg.Port, cfg.Password);
            SftpHandler = new SftpHandler(cfg.Username, cfg.Hostname, cfg.Port, cfg.Password);
        }
    
        public bool Connect()
        {
            return SshHandler.Connect() && SftpHandler.Connect();
        }

        public void Cleanup()
        {
            SshHandler.Cleanup();
            SftpHandler.Cleanup();
        }

        public void PopulateViews(TreeView running, TreeView idle, string serversPath)
        {
            running.Nodes.Clear();
            idle.Nodes.Clear();
            var screens = SshHandler.GetRunningScreens();
            TreeViewHandler.Add(running, screens);
            var strs = SshHandler.FindWithName(serversPath, "launch.sh");
            strs.RemoveAll(x => screens.Contains(x));
            TreeViewHandler.Add(idle, strs);
        }

        //public void PopulateRunningView(TreeView running)
        //{
        //    TreeViewHandler.Add(running, SshHandler.GetRunningScreens());
        //}

        //public void PopulateIdleView(TreeView idle, string serversPath)
        //{
        //    var strs = SshHandler.FindWithName(serversPath, "launch.sh");
        //    //var startswith = MiscTools.CommonStartsWith(strs);
        //    TreeViewHandler.Add(idle, strs/*strs.Select(x => x.Substring(startswith.Length))*/);
        //}

        public void StartInstances(IEnumerable<string> launchScriptPaths)
        {
            foreach (string path in launchScriptPaths) StartInstance(path);
        }

        public void StartInstance(string launchScriptPath)
        {
            var dir = MiscTools.DirWithoutFile(launchScriptPath);
            var cd = "cd " + dir.Quotate();
            var sessionName = ServerScreenPrefix + dir.Replace('/', ':');
            var fullCmd = cd.CombineCommand("screen -dmS " + sessionName.Quotate() + " ./launch.sh");
            SshHandler.RunCommand(fullCmd);
        }

        public Task StopInstances(IEnumerable<string> paths)
        {
            var tasks = new List<Task>();
            foreach (string path in paths)
            {
                tasks.Add(StopInstance(path));
            }
            var waitTask = new Task(() =>
            {
                Task.WaitAll(tasks.ToArray());
            });
            waitTask.Start();
            return waitTask;
        }

        public Task StopInstance(string path)
        {
            var runningScreens = SshHandler.GetRunningScreensRaw();
            var screenid = runningScreens.Where(x => x.Replace(':', '/').EndsWith(MiscTools.DirWithoutFile(path))).FirstOrDefault();
            var task = new Task(() => {
                SshHandler.RunCommand(("while screen -S " + screenid.Quotate() + " -X stuff \"stop\nend\n\"").CombineCommand("do sleep 0.5; done"));
            });
            task.Start();
            return task;
        }

        public void KillInstances(IEnumerable<string> paths)
        {
            foreach (string path in paths) KillInstance(path);
        }

        public void KillInstance(string path)
        {
            var runningScreens = SshHandler.GetRunningScreensRaw();
            var screenid = runningScreens.Where(x => x.Replace(':', '/').EndsWith(MiscTools.DirWithoutFile(path))).FirstOrDefault();
            SshHandler.RunCommand("screen -S " + screenid.Quotate() + " -X quit");
        }

        public void OpenPutties(IEnumerable<string> paths)
        {
            foreach (string path in paths) OpenPutty(path);
        }

        public void OpenPutty(string path)
        {
            var runningScreens = SshHandler.GetRunningScreensRaw();
            var screenid = runningScreens.Where(x => x.Replace(':', '/').EndsWith(MiscTools.DirWithoutFile(path))).FirstOrDefault();
            var proc = PuttyOpener.OpenPutty("screen -x " + screenid.Quotate());
            proc.WaitForInputIdle();
        }

        /// <summary>
        /// Takes an ArgsObject and starts PuTTY with mcmpgen.exe to do things
        /// </summary>
        /// <param name="aobj"></param>
        /// <returns>PuTTY process</returns>
        public Process CreateInstance(ArgsObject aobj)
        {
            var json = JsonConvert.SerializeObject(aobj).Replace("\"", "\\\"");
            var cmd = ("cd " + aobj.InstancesPath).CombineCommand($"mono {MainForm.ModpackDownloaderExeName} " + json.Quotate());
            Console.WriteLine(cmd);
            return PuttyOpener.OpenPutty(cmd);
        }

        public Process BungeeifyInstance(BCArgsObject baobj, string basePath)
        {
            var json = JsonConvert.SerializeObject(baobj).Replace("\"", "\\\"");
            var cmd = ("cd " + basePath).CombineCommand($"mono {MainForm.BungeeCordHandlerExeName} " + json.Quotate());
            Console.WriteLine(cmd);
            return PuttyOpener.OpenPutty(cmd);
        }

        public Process UpdateInstance(ArgsObject aobj)
        {
            aobj.InstallType = InstallType.Update;
            return CreateInstance(aobj);
        }
    }
}
