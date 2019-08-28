namespace MCServerManager2
{
    partial class ServerMonitorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cpuLoad_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.averageCpuUsage_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label100 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.averageCpuUsage_Label = new System.Windows.Forms.Label();
            this.averageCpuFreq_Label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.externalIP_Label = new System.Windows.Forms.Label();
            this.localIP_Label = new System.Windows.Forms.Label();
            this.architecture_Label = new System.Windows.Forms.Label();
            this.osVersion_Label = new System.Windows.Forms.Label();
            this.os_Label = new System.Windows.Forms.Label();
            this.txthostName_Label = new System.Windows.Forms.Label();
            this.txtos_Label = new System.Windows.Forms.Label();
            this.txtosVersion_Label = new System.Windows.Forms.Label();
            this.txtarchitecture_Label = new System.Windows.Forms.Label();
            this.txtlocalIP_Label = new System.Windows.Forms.Label();
            this.txtexternalIP_Label = new System.Windows.Forms.Label();
            this.hostName_Label = new System.Windows.Forms.Label();
            this.sensors_TextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.top_TextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.topSortBy_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.topLines_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cpuLoad_TableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topLines_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cpuLoad_TableLayoutPanel
            // 
            this.cpuLoad_TableLayoutPanel.AutoScroll = true;
            this.cpuLoad_TableLayoutPanel.ColumnCount = 3;
            this.cpuLoad_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.cpuLoad_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cpuLoad_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.cpuLoad_TableLayoutPanel.Controls.Add(this.averageCpuUsage_ProgressBar, 1, 1);
            this.cpuLoad_TableLayoutPanel.Controls.Add(this.label100, 1, 0);
            this.cpuLoad_TableLayoutPanel.Controls.Add(this.label98, 0, 0);
            this.cpuLoad_TableLayoutPanel.Controls.Add(this.averageCpuUsage_Label, 0, 1);
            this.cpuLoad_TableLayoutPanel.Controls.Add(this.averageCpuFreq_Label, 2, 1);
            this.cpuLoad_TableLayoutPanel.Controls.Add(this.label4, 2, 0);
            this.cpuLoad_TableLayoutPanel.Location = new System.Drawing.Point(246, 3);
            this.cpuLoad_TableLayoutPanel.Name = "cpuLoad_TableLayoutPanel";
            this.cpuLoad_TableLayoutPanel.RowCount = 2;
            this.cpuLoad_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.cpuLoad_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.cpuLoad_TableLayoutPanel.Size = new System.Drawing.Size(272, 449);
            this.cpuLoad_TableLayoutPanel.TabIndex = 7;
            // 
            // averageCpuUsage_ProgressBar
            // 
            this.averageCpuUsage_ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.averageCpuUsage_ProgressBar.Location = new System.Drawing.Point(38, 23);
            this.averageCpuUsage_ProgressBar.Name = "averageCpuUsage_ProgressBar";
            this.averageCpuUsage_ProgressBar.Size = new System.Drawing.Size(168, 423);
            this.averageCpuUsage_ProgressBar.TabIndex = 36;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(38, 0);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(26, 13);
            this.label100.TabIndex = 19;
            this.label100.Text = "Use";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(3, 0);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(29, 13);
            this.label98.TabIndex = 17;
            this.label98.Text = "CPU";
            // 
            // averageCpuUsage_Label
            // 
            this.averageCpuUsage_Label.AutoSize = true;
            this.averageCpuUsage_Label.Location = new System.Drawing.Point(3, 20);
            this.averageCpuUsage_Label.Name = "averageCpuUsage_Label";
            this.averageCpuUsage_Label.Size = new System.Drawing.Size(18, 13);
            this.averageCpuUsage_Label.TabIndex = 35;
            this.averageCpuUsage_Label.Text = "All";
            // 
            // averageCpuFreq_Label
            // 
            this.averageCpuFreq_Label.AutoSize = true;
            this.averageCpuFreq_Label.Location = new System.Drawing.Point(212, 20);
            this.averageCpuFreq_Label.Name = "averageCpuFreq_Label";
            this.averageCpuFreq_Label.Size = new System.Drawing.Size(38, 13);
            this.averageCpuFreq_Label.TabIndex = 37;
            this.averageCpuFreq_Label.Text = "? MHz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Frequency";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.externalIP_Label, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.localIP_Label, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.architecture_Label, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.osVersion_Label, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.os_Label, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txthostName_Label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtos_Label, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtosVersion_Label, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtarchitecture_Label, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtlocalIP_Label, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtexternalIP_Label, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.hostName_Label, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1185, 43);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // externalIP_Label
            // 
            this.externalIP_Label.AutoSize = true;
            this.externalIP_Label.Location = new System.Drawing.Point(988, 21);
            this.externalIP_Label.Name = "externalIP_Label";
            this.externalIP_Label.Size = new System.Drawing.Size(35, 13);
            this.externalIP_Label.TabIndex = 11;
            this.externalIP_Label.Text = "label3";
            // 
            // localIP_Label
            // 
            this.localIP_Label.AutoSize = true;
            this.localIP_Label.Location = new System.Drawing.Point(791, 21);
            this.localIP_Label.Name = "localIP_Label";
            this.localIP_Label.Size = new System.Drawing.Size(35, 13);
            this.localIP_Label.TabIndex = 10;
            this.localIP_Label.Text = "label3";
            // 
            // architecture_Label
            // 
            this.architecture_Label.AutoSize = true;
            this.architecture_Label.Location = new System.Drawing.Point(594, 21);
            this.architecture_Label.Name = "architecture_Label";
            this.architecture_Label.Size = new System.Drawing.Size(35, 13);
            this.architecture_Label.TabIndex = 9;
            this.architecture_Label.Text = "label3";
            // 
            // osVersion_Label
            // 
            this.osVersion_Label.AutoSize = true;
            this.osVersion_Label.Location = new System.Drawing.Point(397, 21);
            this.osVersion_Label.Name = "osVersion_Label";
            this.osVersion_Label.Size = new System.Drawing.Size(35, 13);
            this.osVersion_Label.TabIndex = 8;
            this.osVersion_Label.Text = "label3";
            // 
            // os_Label
            // 
            this.os_Label.AutoSize = true;
            this.os_Label.Location = new System.Drawing.Point(200, 21);
            this.os_Label.Name = "os_Label";
            this.os_Label.Size = new System.Drawing.Size(35, 13);
            this.os_Label.TabIndex = 7;
            this.os_Label.Text = "label3";
            // 
            // txthostName_Label
            // 
            this.txthostName_Label.AutoSize = true;
            this.txthostName_Label.Location = new System.Drawing.Point(3, 0);
            this.txthostName_Label.Name = "txthostName_Label";
            this.txthostName_Label.Size = new System.Drawing.Size(55, 13);
            this.txthostName_Label.TabIndex = 0;
            this.txthostName_Label.Text = "Hostname";
            // 
            // txtos_Label
            // 
            this.txtos_Label.AutoSize = true;
            this.txtos_Label.Location = new System.Drawing.Point(200, 0);
            this.txtos_Label.Name = "txtos_Label";
            this.txtos_Label.Size = new System.Drawing.Size(22, 13);
            this.txtos_Label.TabIndex = 1;
            this.txtos_Label.Text = "OS";
            // 
            // txtosVersion_Label
            // 
            this.txtosVersion_Label.AutoSize = true;
            this.txtosVersion_Label.Location = new System.Drawing.Point(397, 0);
            this.txtosVersion_Label.Name = "txtosVersion_Label";
            this.txtosVersion_Label.Size = new System.Drawing.Size(42, 13);
            this.txtosVersion_Label.TabIndex = 2;
            this.txtosVersion_Label.Text = "Version";
            // 
            // txtarchitecture_Label
            // 
            this.txtarchitecture_Label.AutoSize = true;
            this.txtarchitecture_Label.Location = new System.Drawing.Point(594, 0);
            this.txtarchitecture_Label.Name = "txtarchitecture_Label";
            this.txtarchitecture_Label.Size = new System.Drawing.Size(64, 13);
            this.txtarchitecture_Label.TabIndex = 3;
            this.txtarchitecture_Label.Text = "Architecture";
            // 
            // txtlocalIP_Label
            // 
            this.txtlocalIP_Label.AutoSize = true;
            this.txtlocalIP_Label.Location = new System.Drawing.Point(791, 0);
            this.txtlocalIP_Label.Name = "txtlocalIP_Label";
            this.txtlocalIP_Label.Size = new System.Drawing.Size(46, 13);
            this.txtlocalIP_Label.TabIndex = 4;
            this.txtlocalIP_Label.Text = "Local IP";
            // 
            // txtexternalIP_Label
            // 
            this.txtexternalIP_Label.AutoSize = true;
            this.txtexternalIP_Label.Location = new System.Drawing.Point(988, 0);
            this.txtexternalIP_Label.Name = "txtexternalIP_Label";
            this.txtexternalIP_Label.Size = new System.Drawing.Size(58, 13);
            this.txtexternalIP_Label.TabIndex = 5;
            this.txtexternalIP_Label.Text = "External IP";
            // 
            // hostName_Label
            // 
            this.hostName_Label.AutoSize = true;
            this.hostName_Label.Location = new System.Drawing.Point(3, 21);
            this.hostName_Label.Name = "hostName_Label";
            this.hostName_Label.Size = new System.Drawing.Size(35, 13);
            this.hostName_Label.TabIndex = 6;
            this.hostName_Label.Text = "label3";
            // 
            // sensors_TextBox
            // 
            this.sensors_TextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sensors_TextBox.Location = new System.Drawing.Point(3, 3);
            this.sensors_TextBox.Multiline = true;
            this.sensors_TextBox.Name = "sensors_TextBox";
            this.sensors_TextBox.ReadOnly = true;
            this.sensors_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.sensors_TextBox.Size = new System.Drawing.Size(237, 446);
            this.sensors_TextBox.TabIndex = 9;
            this.sensors_TextBox.WordWrap = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.sensors_TextBox);
            this.flowLayoutPanel1.Controls.Add(this.cpuLoad_TableLayoutPanel);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1185, 585);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.top_TextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(524, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(499, 446);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // top_TextBox
            // 
            this.top_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.top_TextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top_TextBox.Location = new System.Drawing.Point(3, 68);
            this.top_TextBox.Multiline = true;
            this.top_TextBox.Name = "top_TextBox";
            this.top_TextBox.ReadOnly = true;
            this.top_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.top_TextBox.Size = new System.Drawing.Size(493, 375);
            this.top_TextBox.TabIndex = 0;
            this.top_TextBox.WordWrap = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.topSortBy_ComboBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.topLines_NumericUpDown, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(493, 59);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // topSortBy_ComboBox
            // 
            this.topSortBy_ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topSortBy_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.topSortBy_ComboBox.FormattingEnabled = true;
            this.topSortBy_ComboBox.Items.AddRange(new object[] {
            "+%CPU",
            "-%CPU",
            "+%MEM",
            "-%MEM",
            "+VIRT",
            "-VIRT",
            "+RES",
            "-RES",
            "+COMMAND",
            "-COMMAND",
            "+PID",
            "-PID",
            "+NI",
            "-NI",
            "+TIME",
            "-TIME"});
            this.topSortBy_ComboBox.Location = new System.Drawing.Point(49, 3);
            this.topSortBy_ComboBox.Name = "topSortBy_ComboBox";
            this.topSortBy_ComboBox.Size = new System.Drawing.Size(441, 21);
            this.topSortBy_ComboBox.TabIndex = 1;
            this.topSortBy_ComboBox.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sort by";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lines";
            // 
            // topLines_NumericUpDown
            // 
            this.topLines_NumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topLines_NumericUpDown.Location = new System.Drawing.Point(49, 30);
            this.topLines_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.topLines_NumericUpDown.Name = "topLines_NumericUpDown";
            this.topLines_NumericUpDown.Size = new System.Drawing.Size(441, 20);
            this.topLines_NumericUpDown.TabIndex = 3;
            this.topLines_NumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // ServerMonitorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 628);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "ServerMonitorer";
            this.Text = "ServerMonitorer";
            this.Load += new System.EventHandler(this.ServerMonitorer_Load);
            this.ResizeBegin += new System.EventHandler(this.ServerMonitorer_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.ServerMonitorer_ResizeEnd);
            this.cpuLoad_TableLayoutPanel.ResumeLayout(false);
            this.cpuLoad_TableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topLines_NumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel cpuLoad_TableLayoutPanel;
        private System.Windows.Forms.ProgressBar averageCpuUsage_ProgressBar;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label averageCpuUsage_Label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label txthostName_Label;
        private System.Windows.Forms.Label txtos_Label;
        private System.Windows.Forms.Label txtosVersion_Label;
        private System.Windows.Forms.Label txtarchitecture_Label;
        private System.Windows.Forms.Label txtlocalIP_Label;
        private System.Windows.Forms.Label txtexternalIP_Label;
        private System.Windows.Forms.Label hostName_Label;
        private System.Windows.Forms.Label externalIP_Label;
        private System.Windows.Forms.Label localIP_Label;
        private System.Windows.Forms.Label architecture_Label;
        private System.Windows.Forms.Label osVersion_Label;
        private System.Windows.Forms.Label os_Label;
        private System.Windows.Forms.TextBox sensors_TextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox top_TextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox topSortBy_ComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown topLines_NumericUpDown;
        private System.Windows.Forms.Label averageCpuFreq_Label;
        private System.Windows.Forms.Label label4;
    }
}