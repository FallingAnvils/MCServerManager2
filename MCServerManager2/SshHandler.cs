using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MCServerManager2
{
    public class SftpHandler
    {
        public SftpClient _Client;
        public bool IsConnected { get { return _Client.IsConnected; } }

        public SftpHandler(string username, string hostname, int port, string password)
        {
            _Client = new SftpClient(hostname, port, username, password);
        }

        public SftpHandler(string username, string hostname, string password)
        {
            _Client = new SftpClient(hostname, username, password);
        }

        public SftpHandler(ConnectionInfo info)
        {
            _Client = new SftpClient(info);
        }

        public void Cleanup()
        {
            _Client.Disconnect();
            _Client.Dispose();
        }

        public bool Connect()
        {
            try { _Client.Connect(); } catch { return false; }
            return _Client.IsConnected;
        }

        public void Download(string remoteFile, FileInfo localFile)
        {
            var fs = localFile.Create();
            _Client.DownloadFile(remoteFile, fs);
            fs.Close();
        }

        public void Upload(FileInfo localFile, string remoteFile)
        {
            var fs = localFile.OpenRead();
            _Client.UploadFile(fs, remoteFile, true);
            fs.Close();
        }

        public void UploadAndDelete(FileInfo localFile, string remoteFile)
        {
            Upload(localFile, remoteFile);
            localFile.Delete();
        }

    }

    public class SshHandler
    {
        public SshClient _Client;

        public bool IsConnected { get { return _Client.IsConnected; } }

        public SshHandler(string username, string hostname, int port, string password)
        {
            _Client = new SshClient(hostname, port, username, password);
        }
        public SshHandler(string username, string hostname, string password)
        {
            _Client = new SshClient(hostname, username, password);
        }
        public SshHandler(ConnectionInfo info)
        {
            _Client = new SshClient(info);
        }
        public void Cleanup()
        {
            _Client.Disconnect();
            _Client.Dispose();
        }
        public bool Connect()
        {
            try { _Client.Connect(); } catch { return false; }
            return _Client.IsConnected;
        }
        public CommandResultTuple RunCommand(string cmd)
        {
            var cmdres = _Client.RunCommand(cmd);
            return new CommandResultTuple(cmdres.Result, cmdres.Error, cmdres.ExitStatus);
        }
        public CommandResultTuple RunCommandSafe(string cmd)
        {
            var result = RunCommand(cmd);
            if (result.ExitCode != 0) throw new SshCommandFailedException("Command exited with code " + result.ExitCode);
            return result;
        }
        public List<string> FindWithName(string dir, string name)
        {
            if (dir.Contains("~")) dir = RealPath(dir).Quotate();
            var result = RunCommand("find " + dir + " -type f -name " + name.Quotate());
            if (result.ExitCode != 0) throw new SshCommandFailedException("Command exitied with code " + result.ExitCode);
            return result.StdOut.Split('\n').RemoveLastElement().ToList(); // remove trailing newline
        }
        public IEnumerable<string> GetRunningScreens()
        {           
            return
                GetRunningScreensRaw()
                .Select(x => x.Substring(x.IndexOf(".") + 1))
                .Select(x => x.Replace(':', '/'))
                .Select(x => x + "launch.sh");
        } 
        public IEnumerable<string> GetRunningScreensRaw()
        {
            var result = RunCommand("screen -ls | grep tached");
            if (result.ExitCode != 0) return new List<string>();
            return
                result.StdOut
                .Split('\n')
                .Select(str => str.Trim(new[] { ' ', '\t' }))
                .Where(x => !x.IsNullOrWhiteSpace())
                .Select(x => x.Substring(0, x.IndexOf('(')).Trim());
        }
        public string RealPath(string path)
        {
            return RunCommandSafe("realpath " + path).StdOut.Split('\n').First();
        }
        public IEnumerable<string> FilesInDirectory(string dir)
        {
            var result = RunCommandSafe("tree -fi " + dir.Quotate());
            if (result.ExitCode != 0) return new List<string>();
            return result.StdOut
                .Split('\n')
                .RemoveLastElement()
                .RemoveLastElement();   
        }

        public IEnumerable<float> GetCpuFrequencies()
        {
            var result = RunCommand("cat /proc/cpuinfo | grep MHz");
            return Regex.Replace(string.Join("\n", result.StdOut.Split('\n').RemoveLastElement()), @"[^0-9\.\n]+", "")
                .Split('\n')
                .Select(x => float.Parse(x));
        }
    }

    public class CommandResultTuple
    {
        public string StdOut;
        public string StdErr;
        public int ExitCode;
        public CommandResultTuple(string @out, string err, int exitcode)
        {
            StdOut = @out;
            StdErr = err;
            ExitCode = exitcode;
        }
    }

    public class SshCommandFailedException : Exception
    {
        public SshCommandFailedException() { }
        public SshCommandFailedException(string message) : base(message) { }
        public SshCommandFailedException(string message, Exception inner) : base(message, inner) { }
    }

}
