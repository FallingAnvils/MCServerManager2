namespace MCServerManager2
{
    public class ArgsObject
    {
        public string InstancesPath;
        public string InstanceName;
        public int RamMB;
        public string JavaArgs;
        public ServerType ServerType;
        public InstallType InstallType;
        public string Url;
        public string[] Ops;
        public string[] Whitelisted;
        public int Port = 25565;
        public string LevelName = "world";
        public bool OnlineMode = true;
        public bool CommandBlocksEnabled = true;
        public int Difficulty = 1;
        public bool WhiteList = true;
        public string[] ExcludedFiles;
        public string LevelType = "default";
        public SpigotType SpigotType;
        public string Version;
    }

    public class BCArgsObject
    {
        public string InstancePath;
        public string BungeePath;
        public BungeeType BungeeType;
        public string BungeeName;
        public int Port;
        public string Version;
    }

    public enum BungeeType
    {
        SpongeForge,
        SpongeVanilla,
        VanillaCord,
        Spigot
    }

    public enum InstallType
    {
        Install,
        Update
    }

    public enum ServerType
    {
        Modded,
        Bukkit,
        Bedrock
    }

    public enum SpigotType
    {
        BuildTools,
        DirectDownload
    }
}
