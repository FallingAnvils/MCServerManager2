using System;
using System.Linq;
using System.Windows.Forms;

namespace MCServerManager2
{
    public partial class InstanceCreationWizard : Form
    {
        public InstanceCreationWizard()
        {
            InitializeComponent();
        }

        public CreatorTab[] Order;
        public int OrderIndex;
        public ServerType ServerType;
        public string BasePath;

        public Tuple<ArgsObject, BCArgsObject> ResultValues;

        public void Next()
        {
            if(OrderIndex == Order.Length - 1) // we're done here
            {
                var argsobj = new ArgsObject();
                argsobj.ServerType = ServerType;
                argsobj.InstallType = InstallType.Install;
                argsobj.Version = mcVersion_TextBox.Text;
                argsobj.SpigotType = SpigotType.DirectDownload;
                if (ServerType == ServerType.Bukkit && useBuildTools_CheckBox.Checked) argsobj.SpigotType = SpigotType.BuildTools;
                argsobj.Url = downloadLink_TextBox.Text;
                argsobj.InstanceName = instanceName_TextBox.Text;
                argsobj.RamMB = (int)ram_NumericUpDown.Value;
                argsobj.Port = (int)port_NumericUpDown.Value;
                argsobj.Difficulty = (int)difficulty_NumericUpDown.Value;
                argsobj.LevelName = levelName_TextBox.Text;
                argsobj.LevelType = levelType_TextBox.Text;
                argsobj.WhiteList = whiteList_CheckBox.Checked;
                argsobj.Whitelisted = whiteList_ModifiableListBox.Values;
                argsobj.Ops = ops_ModifiableListBox.Values;
                argsobj.OnlineMode = bungeeCord_CheckBox.Checked ? false : onlineMode_CheckBox.Checked; // disable online mode if bungee is enabled
                argsobj.CommandBlocksEnabled = commandBlocks_CheckBox.Checked;
                argsobj.InstancesPath = BasePath;
                BCArgsObject bungeeargsobj = null;
                if (bungeeCord_CheckBox.Checked)
                {
                    bungeeargsobj = new BCArgsObject();
                    bungeeargsobj.Version = mcVersion_TextBox.Text;
                    bungeeargsobj.BungeeName = instanceName_TextBox.Text.Split('/').Last().Replace(' ', '_');
                    bungeeargsobj.BungeePath = BasePath.BetterPathJoinSlash(bungeeCordPath_TextBox.Text);
                    switch(ServerType) {
                        case ServerType.Bukkit:
                            bungeeargsobj.BungeeType = BungeeType.Spigot;
                            break;
                        case ServerType.Modded:
                            bungeeargsobj.BungeeType = BungeeType.SpongeForge;
                            break;
                    }
                    bungeeargsobj.InstancePath = BasePath.BetterPathJoinSlash(instanceName_TextBox.Text);
                    bungeeargsobj.Port = (int)port_NumericUpDown.Value;
                }
                ResultValues = Tuple.Create(argsobj, bungeeargsobj);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            if(OrderIndex <= Order.Length-2) this.tabControl1.SelectedIndex = (int)Order[++OrderIndex];
        }

        public void Previous()
        {
            if(OrderIndex-1 >= 0) this.tabControl1.SelectedIndex = (int)Order[--OrderIndex];
        }

        private void button1_Click(object sender, System.EventArgs e) => Next();

        private void button2_Click(object sender, System.EventArgs e) => Previous();

        private void InstanceCreationWizard_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = (int)Order[0];
        }
    }

    public enum CreatorTab
    {
        Start = 0,
        DownloadLink = 1,
        InstanceName = 2,
        RAM = 3,
        Port = 4,
        Difficulty = 5,
        LevelName = 6,
        LevelType = 7,
        Whitelisted = 8,
        Whitelist = 9,
        Ops = 10,
        OnlineMode = 11,
        CommandBlocks = 12,
        BungeeCord = 13
    }

    public static class CreatorTabOrder
    {
        public static CreatorTab[] Modded = new[] {
                            CreatorTab.Start,
                            CreatorTab.DownloadLink,
                            CreatorTab.InstanceName,
                            CreatorTab.RAM,
                            CreatorTab.Port,
                            CreatorTab.Difficulty,
                            CreatorTab.LevelName,
                            CreatorTab.LevelType,
                            CreatorTab.Whitelisted,
                            CreatorTab.Whitelist,
                            CreatorTab.Ops,
                            CreatorTab.OnlineMode,
                            CreatorTab.CommandBlocks,
                            CreatorTab.BungeeCord
        };

        public static CreatorTab[] Spigot = new[] {
                            CreatorTab.Start,
                            CreatorTab.DownloadLink,
                            CreatorTab.InstanceName,
                            CreatorTab.RAM,
                            CreatorTab.Port,
                            CreatorTab.Difficulty,
                            CreatorTab.LevelName,
                            CreatorTab.LevelType,
                            CreatorTab.Whitelisted,
                            CreatorTab.Whitelist,
                            CreatorTab.Ops,
                            CreatorTab.OnlineMode,
                            CreatorTab.CommandBlocks,
                            CreatorTab.BungeeCord
        };

        public static CreatorTab[] Bedrock = new[] {
                            CreatorTab.DownloadLink,
                            CreatorTab.InstanceName,
                            CreatorTab.Port,
                            CreatorTab.Difficulty,
                            CreatorTab.LevelName,
                            CreatorTab.Whitelisted,
                            CreatorTab.Whitelist,
                            CreatorTab.OnlineMode,
                            CreatorTab.CommandBlocks
        };

    }
}
