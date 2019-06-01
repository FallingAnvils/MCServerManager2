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


        /// <summary>
        /// Controls in the CPU Usage/Frequency table, with (0,0) at the All label, and positive Y going down
        /// Don't use GetControlFromPosition, Mono likes to return null
        /// </summary>
        private Control[,] _CpuUsageTableControls;

        private void PopulateCpuUsageTable()
        {
            CommandResultTuple cmdresult = null;
            MiscTools.SpawnBackgroundWorker(() => cmdresult = ManagerHandler.SshHandler.RunCommand("mpstat -o JSON"), () =>
            {
                if (cmdresult.ExitCode == 0)
                {
                    var result = JsonConvert.DeserializeObject<MPStatResult>(cmdresult.StdOut);
                    var numthreads = result.SysStat.Hosts[0].NumberOfCpus;

                    _CpuUsageTableControls = new Control[3, numthreads];

                    _CpuUsageTableControls = new Control[3, numthreads + 1];
                    _CpuUsageTableControls[0, 0] = averageCpuUsage_Label;
                    _CpuUsageTableControls[1, 0] = averageCpuUsage_ProgressBar;
                    _CpuUsageTableControls[2, 0] = averageCpuFreq_Label;


                    for (int i = 0; i < numthreads; i++)
                    {                  
                        var rowstyle = new RowStyle(SizeType.Absolute, 20);
                        this.Invoke((MethodInvoker)(() =>
                        {
                            cpuLoad_TableLayoutPanel.RowCount += 1;
                            cpuLoad_TableLayoutPanel.RowStyles.Add(rowstyle);

                            var threadNumLbl = new Label { Text = "" + i, AutoSize = true };
                            var usageProgBar = new ProgressBar { Dock = DockStyle.Fill };
                            var freqLbl = new Label { Text = "? MHz", AutoSize = true };

                            _CpuUsageTableControls[0, i+1] = threadNumLbl;
                            _CpuUsageTableControls[1, i+1] = usageProgBar;
                            _CpuUsageTableControls[2, i+1] = freqLbl;

                            cpuLoad_TableLayoutPanel.Controls.Add(threadNumLbl);
                            cpuLoad_TableLayoutPanel.Controls.Add(usageProgBar);
                            cpuLoad_TableLayoutPanel.Controls.Add(freqLbl);
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
                var host = result.SysStat.Hosts[0];
                for (int i = 0; i < host.Statistics[0].CpuLoad.Length; i++)
                {
                    var b = host.Statistics[0].CpuLoad[i];
                    var usedPercent = (int)(b.Usr + b.Nice + b.Sys + b.IOWait + b.IRQ + b.Soft + b.Steal + b.Guest + b.GNice);
                    this.Invoke((MethodInvoker)(() => ((ProgressBar)_CpuUsageTableControls[1, i]).Value = usedPercent));
                }

                var cmdresult_freq = ManagerHandler.SshHandler.GetCpuFrequencies().ToArray();
                var avg = (int)cmdresult_freq.Average();
                var max = (int)cmdresult_freq.Max();
                var min = (int)cmdresult_freq.Min();
                this.Invoke((MethodInvoker)(() => ((Label)_CpuUsageTableControls[2, 0]).Text = avg + " MHz"));
                for (int i = 0; i < cmdresult_freq.Length; i++)
                {
                    var num = (int)cmdresult_freq[i];

                    this.Invoke((MethodInvoker)(() =>
                    {
                        var lbl = (Label)_CpuUsageTableControls[2, i + 1];
                        lbl.Text = num + " MHz";
                        if (num == max) lbl.ForeColor = Color.Red;
                        else if (num == min) lbl.ForeColor = Color.Blue;
                        else if (lbl.ForeColor != Color.Black) lbl.ForeColor = SystemColors.ControlText;
                    }));
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
                int headAmnt = 0;
                string sort = string.Empty;
                this.Invoke((MethodInvoker)(() => { sort = (string)topSortBy_ComboBox.SelectedItem; headAmnt = (int)topLines_NumericUpDown.Value; }));

                var result = ManagerHandler.SshHandler.RunCommandSafe($"top -b -n 1 -o {(sort.IsNullOrWhiteSpace() ? "+%CPU" : sort)} | head -n {headAmnt}")
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

        private void ServerMonitorer_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }

        private void ServerMonitorer_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout();
        }
    }
}
