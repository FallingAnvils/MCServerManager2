using System;
using System.Diagnostics;
using System.IO;

namespace MCServerManager2
{
    public class PuttyOpener
    {
        public string Executable;
        public string Username;
        public string Hostname;
        public int Port;
        public string Password;
        public string TmpFileName;
        public PuttyOpener(string username, string hostname, string password, int port = 22, string tmpFileName = "putmp", string exe = "putty")
        {
            Username = username;
            Hostname = hostname;
            Password = password;
            Port = port;
            TmpFileName = tmpFileName;
            Executable = exe;
        }

        public Process OpenPutty(string cmd)
        {
            File.WriteAllText(TmpFileName, cmd);
            var process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                FileName = Executable,
                Arguments = $"-ssh {Username}@{Hostname} -P {Port} -pw {Password.Quotate()} -m {TmpFileName.Quotate()} -t",
                WorkingDirectory = Environment.CurrentDirectory
            };
            if (process.Start()) return process; else throw new Exception("Process failed to start"); // idk what exception type to use
        }
    }
}
