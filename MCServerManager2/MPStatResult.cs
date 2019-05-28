using Newtonsoft.Json;

namespace MCServerManager2
{
    public class MPStatResult
    {
        public MPStatSysStat SysStat;
    }

    public class MPStatSysStat
    {
        public MPStatHost[] Hosts;
    }

    public class MPStatHost
    {
        public string NodeName;
        public string SysName;
        public string Release;
        public string Machine;
        [JsonProperty(PropertyName = "number-of-cpus")]
        public int NumberOfCpus;
        public string Date;
        public MPStatStatistic[] Statistics;
    }

    public class MPStatStatistic
    {
        public string Timestamp;
        [JsonProperty(PropertyName = "cpu-load")]
        public MPStatCpuLoad[] CpuLoad;
    }

    public class MPStatCpuLoad
    {
        public string Cpu;
        public double Usr;
        public double Nice;
        public double Sys;
        public double IOWait;
        public double IRQ;
        public double Soft;
        public double Steal;
        public double Guest;
        public double GNice;
        public double Idle;
    }
}
