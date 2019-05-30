using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCServerManager2
{
    public partial class ServerMonitorer : Form
    {
        public ServerMonitorer()
        {
            InitializeComponent();
        }

        public ServerManagerHandler ManagerHandler;

        private void PopulateCpuUsageTable()
        {
            CommandResultTuple cmdresult = null;
            MiscTools.SpawnBackgroundWorker(() => cmdresult = ManagerHandler.SshHandler.RunCommand("mpstat -o JSON"), () =>
            {
                if (cmdresult.ExitCode == 0)
                {
                    var result = JsonConvert.DeserializeObject<MPStatResult>(cmdresult.StdOut);
                    var numthreads = result.SysStat.Hosts[0].NumberOfCpus;
                    for (int i = 0; i < numthreads; i++)
                    {                  
                        var rowstyle = new RowStyle(SizeType.Absolute, 20);
                        this.Invoke((MethodInvoker)(() =>
                        {
                            cpuLoad_TableLayoutPanel.RowCount += 1;
                            cpuLoad_TableLayoutPanel.RowStyles.Add(rowstyle);
                            cpuLoad_TableLayoutPanel.Controls.Add(new Label() { Text = "" + i, AutoSize = true });
                            cpuLoad_TableLayoutPanel.Controls.Add(new ProgressBar() { Dock = DockStyle.Fill });
                            cpuLoad_TableLayoutPanel.Controls.Add(new Label() { Text = "? MHz", AutoSize = true });
                        }));
                    }
                    this.Invoke((MethodInvoker)(() =>
                    {
                        cpuLoad_TableLayoutPanel.RowCount += 1;
                        cpuLoad_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent));
                    }));
                }
            });
        }

        private void PopulateStaticStatTable()
        {
            CommandResultTuple usageCmdResult = null;

            MiscTools.SpawnBackgroundWorker(() => usageCmdResult = ManagerHandler.SshHandler.RunCommand("mpstat -o JSON"), () =>
            {
                if (usageCmdResult.ExitCode == 0)
                {
                    var result = JsonConvert.DeserializeObject<MPStatResult>(usageCmdResult.StdOut);
                    var localip = ManagerHandler.SshHandler.RunCommandSafe("hostname -I | sed 's/ /\\n/' | head -n 1").StdOut;
                    var extip = ManagerHandler.SshHandler.RunCommandSafe("curl ipinfo.io/ip").StdOut;

                    var host = result.SysStat.Hosts[0];

                    this.Invoke((MethodInvoker)(() =>
                    {
                        hostName_Label.Text = host.NodeName;
                        os_Label.Text = host.SysName;
                        osVersion_Label.Text = host.Release;
                        architecture_Label.Text = host.Machine;
                        localIP_Label.Text = localip;
                        externalIP_Label.Text = extip;
                    }));
                }
            });
        }

        private void CpuLoadUpdateLoop()
        {
            while(Visible)
            {
                var cmdresult_load = ManagerHandler.SshHandler.RunCommandSafe("mpstat -P ALL 1 1 -o JSON");
                var result = JsonConvert.DeserializeObject<MPStatResult>(cmdresult_load.StdOut);
                var a = result.SysStat.Hosts[0];
                for (int i = 0; i < a.Statistics[0].CpuLoad.Length; i++)
                {
                    var b = a.Statistics[0].CpuLoad[i];
                    var usedPercent = (b.Usr + b.Nice + b.Sys + b.IOWait + b.IRQ + b.Soft + b.Steal + b.Guest + b.GNice);
                    this.Invoke((MethodInvoker)(() => ((ProgressBar)cpuLoad_TableLayoutPanel.GetControlFromPosition(1, i + 1)).Value = (int)usedPercent));
                }

                var cmdresult_freq = ManagerHandler.SshHandler.GetCpuFrequencies().ToArray();
                var avg = cmdresult_freq.Average();
                this.Invoke((MethodInvoker)(() => ((Label)cpuLoad_TableLayoutPanel.GetControlFromPosition(2, 1)).Text = (int)avg + " MHz"));
                for (int i = 0; i < cmdresult_freq.Length; i++)
                {
                    var num = cmdresult_freq[i];
                    this.Invoke((MethodInvoker)(() => ((Label)cpuLoad_TableLayoutPanel.GetControlFromPosition(2, i + 2)).Text = (int)num + " MHz"));
                }

            }
        }

        private void SensorsUpdateLoop()
        {
            while(Visible)
            {
                var result = ManagerHandler.SshHandler.RunCommandSafe("sensors").StdOut.Replace("\n", "\r\n");
                this.Invoke((MethodInvoker)(() => sensors_TextBox.Text = result));
                Thread.Sleep(1000);
            }
        }

        private void TopUpdateLoop()
        {
            while(Visible)
            {
                int val = 0;
                string sort = string.Empty;
                this.Invoke((MethodInvoker)(() => { sort = (string)topSortBy_ComboBox.SelectedItem; val = (int)topLines_NumericUpDown.Value; }));

                var result = ManagerHandler.SshHandler.RunCommandSafe($"top -b -n 1 -o {(sort.IsNullOrWhiteSpace() ? "+%CPU" : sort)} | head -n {val}")
                    .StdOut
                    .Replace("\n", "\r\n");
                this.Invoke((MethodInvoker)(() => {
                    int scrollpos = top_TextBox.SelectionStart;
                    top_TextBox.Text = result;
                    top_TextBox.SelectionStart = scrollpos;
                    top_TextBox.ScrollToCaret();
                }));
                Thread.Sleep(1000);
            }
        }

        private void ServerMonitorInit()
        {
            PopulateCpuUsageTable();
            PopulateStaticStatTable();
        }

        private void ServerMonitorLoop()
        {
            MiscTools.SpawnBackgroundWorker(() => CpuLoadUpdateLoop());
            MiscTools.SpawnBackgroundWorker(() => SensorsUpdateLoop());
            MiscTools.SpawnBackgroundWorker(() => TopUpdateLoop());
        }

        private void ServerMonitorer_Load(object sender, EventArgs e)
        {
            MiscTools.SpawnBackgroundWorker(() =>
            {
                ServerMonitorInit();
                ServerMonitorLoop();
            });
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
