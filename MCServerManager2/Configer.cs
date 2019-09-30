using Newtonsoft.Json;
using System.IO;

namespace MCServerManager2
{
    public class Config
    {
        public static ConfigObject ReadConfigFile(string file)
        {
            if (File.Exists(file)) return ReadConfig(File.ReadAllText(file));
            else return null;
        }
        
        public static ConfigObject ReadConfig(string text)
        {
            return JsonConvert.DeserializeObject<ConfigObject>(text);
        }
    }

    public class ConfigObject
    {
        public string Username;
        public string Hostname;
        public int Port;
        public string Password;
        public string ServerPath;
        public string Editor;
        public bool ExpandAllOnStart;
        public string MountPoint;
        public string RemoteLocation;
        public string ModpackDownloaderExeName;
        public string BungeeCordHandlerExeName;
    }
}
