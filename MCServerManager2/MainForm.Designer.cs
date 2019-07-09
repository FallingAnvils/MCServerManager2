namespace MCServerManager2
{
    partial class MainForm
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
            this.runningInstances_TreeView = new System.Windows.Forms.TreeView();
            this.idleInstances_TreeView = new System.Windows.Forms.TreeView();
            this.open_Button = new System.Windows.Forms.Button();
            this.kill_Button = new System.Windows.Forms.Button();
            this.restart_Button = new System.Windows.Forms.Button();
            this.refreshLists_Button = new System.Windows.Forms.Button();
            this.createInstance_Button = new System.Windows.Forms.Button();
            this.modifyInstance_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.remoteLocation_TextBox = new System.Windows.Forms.TextBox();
            this.mountPoint_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mcServerPath_TextBox = new System.Windows.Forms.TextBox();
            this.start_Button = new System.Windows.Forms.Button();
            this.stop_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.expandLists_Button = new System.Windows.Forms.Button();
            this.deleteInstances_Button = new System.Windows.Forms.Button();
            this.openMonitor_Button = new System.Windows.Forms.Button();
            this.openFolder_Button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.connected_ToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // runningInstances_TreeView
            // 
            this.runningInstances_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runningInstances_TreeView.HideSelection = false;
            this.runningInstances_TreeView.Location = new System.Drawing.Point(3, 3);
            this.runningInstances_TreeView.Name = "runningInstances_TreeView";
            this.runningInstances_TreeView.PathSeparator = "/";
            this.runningInstances_TreeView.Size = new System.Drawing.Size(359, 420);
            this.runningInstances_TreeView.TabIndex = 0;
            this.runningInstances_TreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.runningInstances_TreeView_BeforeSelect);
            // 
            // idleInstances_TreeView
            // 
            this.idleInstances_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idleInstances_TreeView.HideSelection = false;
            this.idleInstances_TreeView.Location = new System.Drawing.Point(404, 3);
            this.idleInstances_TreeView.Name = "idleInstances_TreeView";
            this.idleInstances_TreeView.PathSeparator = "/";
            this.idleInstances_TreeView.Size = new System.Drawing.Size(359, 420);
            this.idleInstances_TreeView.TabIndex = 1;
            this.idleInstances_TreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.idleInstances_TreeView_BeforeSelect);
            // 
            // open_Button
            // 
            this.open_Button.Location = new System.Drawing.Point(3, 138);
            this.open_Button.Name = "open_Button";
            this.open_Button.Size = new System.Drawing.Size(23, 23);
            this.open_Button.TabIndex = 8;
            this.open_Button.Text = "Open";
            this.open_Button.UseVisualStyleBackColor = true;
            this.open_Button.Click += new System.EventHandler(this.open_Button_Click);
            // 
            // kill_Button
            // 
            this.kill_Button.Location = new System.Drawing.Point(3, 198);
            this.kill_Button.Name = "kill_Button";
            this.kill_Button.Size = new System.Drawing.Size(24, 23);
            this.kill_Button.TabIndex = 10;
            this.kill_Button.Text = ">! Kill";
            this.kill_Button.UseVisualStyleBackColor = true;
            this.kill_Button.Click += new System.EventHandler(this.kill_Button_Click);
            // 
            // restart_Button
            // 
            this.restart_Button.Location = new System.Drawing.Point(3, 168);
            this.restart_Button.Name = "restart_Button";
            this.restart_Button.Size = new System.Drawing.Size(23, 23);
            this.restart_Button.TabIndex = 9;
            this.restart_Button.Text = "Restart";
            this.restart_Button.UseVisualStyleBackColor = true;
            this.restart_Button.Click += new System.EventHandler(this.restart_Button_Click);
            // 
            // refreshLists_Button
            // 
            this.refreshLists_Button.Location = new System.Drawing.Point(215, 3);
            this.refreshLists_Button.Name = "refreshLists_Button";
            this.refreshLists_Button.Size = new System.Drawing.Size(103, 23);
            this.refreshLists_Button.TabIndex = 6;
            this.refreshLists_Button.Text = "Refresh Lists";
            this.refreshLists_Button.UseVisualStyleBackColor = true;
            this.refreshLists_Button.Click += new System.EventHandler(this.refreshLists_Button_Click);
            // 
            // createInstance_Button
            // 
            this.createInstance_Button.Location = new System.Drawing.Point(3, 3);
            this.createInstance_Button.Name = "createInstance_Button";
            this.createInstance_Button.Size = new System.Drawing.Size(95, 23);
            this.createInstance_Button.TabIndex = 4;
            this.createInstance_Button.Text = "Create Instance";
            this.createInstance_Button.UseVisualStyleBackColor = true;
            this.createInstance_Button.Click += new System.EventHandler(this.createInstance_Button_Click);
            // 
            // modifyInstance_Button
            // 
            this.modifyInstance_Button.Location = new System.Drawing.Point(104, 3);
            this.modifyInstance_Button.Name = "modifyInstance_Button";
            this.modifyInstance_Button.Size = new System.Drawing.Size(105, 23);
            this.modifyInstance_Button.TabIndex = 5;
            this.modifyInstance_Button.Text = "Modify Instance";
            this.modifyInstance_Button.UseVisualStyleBackColor = true;
            this.modifyInstance_Button.Click += new System.EventHandler(this.modifyInstance_Button_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.remoteLocation_TextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mountPoint_TextBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.mcServerPath_TextBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(766, 55);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // remoteLocation_TextBox
            // 
            this.remoteLocation_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteLocation_TextBox.Location = new System.Drawing.Point(97, 30);
            this.remoteLocation_TextBox.Name = "remoteLocation_TextBox";
            this.remoteLocation_TextBox.Size = new System.Drawing.Size(295, 20);
            this.remoteLocation_TextBox.TabIndex = 3;
            // 
            // mountPoint_TextBox
            // 
            this.mountPoint_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mountPoint_TextBox.Location = new System.Drawing.Point(468, 3);
            this.mountPoint_TextBox.Name = "mountPoint_TextBox";
            this.mountPoint_TextBox.Size = new System.Drawing.Size(295, 20);
            this.mountPoint_TextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MC Server Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mount Point";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Remote Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // mcServerPath_TextBox
            // 
            this.mcServerPath_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mcServerPath_TextBox.Location = new System.Drawing.Point(97, 3);
            this.mcServerPath_TextBox.Name = "mcServerPath_TextBox";
            this.mcServerPath_TextBox.Size = new System.Drawing.Size(295, 20);
            this.mcServerPath_TextBox.TabIndex = 1;
            this.mcServerPath_TextBox.Text = "~";
            // 
            // start_Button
            // 
            this.start_Button.Location = new System.Drawing.Point(3, 258);
            this.start_Button.Name = "start_Button";
            this.start_Button.Size = new System.Drawing.Size(23, 23);
            this.start_Button.TabIndex = 12;
            this.start_Button.Text = "< Start";
            this.start_Button.UseVisualStyleBackColor = true;
            this.start_Button.Click += new System.EventHandler(this.start_Button_Click);
            // 
            // stop_Button
            // 
            this.stop_Button.Location = new System.Drawing.Point(3, 228);
            this.stop_Button.Name = "stop_Button";
            this.stop_Button.Size = new System.Drawing.Size(23, 23);
            this.stop_Button.TabIndex = 11;
            this.stop_Button.Text = "> Stop";
            this.stop_Button.UseVisualStyleBackColor = true;
            this.stop_Button.Click += new System.EventHandler(this.stop_Button_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.start_Button, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.stop_Button, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.kill_Button, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.restart_Button, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.open_Button, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(368, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(30, 420);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.runningInstances_TreeView, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.idleInstances_TreeView, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(766, 426);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.createInstance_Button);
            this.flowLayoutPanel1.Controls.Add(this.modifyInstance_Button);
            this.flowLayoutPanel1.Controls.Add(this.refreshLists_Button);
            this.flowLayoutPanel1.Controls.Add(this.expandLists_Button);
            this.flowLayoutPanel1.Controls.Add(this.deleteInstances_Button);
            this.flowLayoutPanel1.Controls.Add(this.openMonitor_Button);
            this.flowLayoutPanel1.Controls.Add(this.openFolder_Button);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(766, 29);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // expandLists_Button
            // 
            this.expandLists_Button.Location = new System.Drawing.Point(324, 3);
            this.expandLists_Button.Name = "expandLists_Button";
            this.expandLists_Button.Size = new System.Drawing.Size(88, 23);
            this.expandLists_Button.TabIndex = 7;
            this.expandLists_Button.Text = "Expand All";
            this.expandLists_Button.UseVisualStyleBackColor = true;
            this.expandLists_Button.Click += new System.EventHandler(this.expandLists_Button_Click);
            // 
            // deleteInstances_Button
            // 
            this.deleteInstances_Button.Location = new System.Drawing.Point(418, 3);
            this.deleteInstances_Button.Name = "deleteInstances_Button";
            this.deleteInstances_Button.Size = new System.Drawing.Size(75, 23);
            this.deleteInstances_Button.TabIndex = 8;
            this.deleteInstances_Button.Text = "Delete";
            this.deleteInstances_Button.UseVisualStyleBackColor = true;
            this.deleteInstances_Button.Click += new System.EventHandler(this.deleteInstances_Button_Click);
            // 
            // openMonitor_Button
            // 
            this.openMonitor_Button.Location = new System.Drawing.Point(499, 3);
            this.openMonitor_Button.Name = "openMonitor_Button";
            this.openMonitor_Button.Size = new System.Drawing.Size(80, 23);
            this.openMonitor_Button.TabIndex = 9;
            this.openMonitor_Button.Text = "Open Monitor";
            this.openMonitor_Button.UseVisualStyleBackColor = true;
            this.openMonitor_Button.Click += new System.EventHandler(this.openMonitor_Button_Click);
            // 
            // openFolder_Button
            // 
            this.openFolder_Button.Location = new System.Drawing.Point(585, 3);
            this.openFolder_Button.Name = "openFolder_Button";
            this.openFolder_Button.Size = new System.Drawing.Size(75, 23);
            this.openFolder_Button.TabIndex = 10;
            this.openFolder_Button.Text = "Open Folder";
            this.openFolder_Button.UseVisualStyleBackColor = true;
            this.openFolder_Button.Click += new System.EventHandler(this.openFolder_Button_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 477);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 426);
            this.panel2.TabIndex = 15;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connected_ToolStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(766, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // connected_ToolStripLabel
            // 
            this.connected_ToolStripLabel.Name = "connected_ToolStripLabel";
            this.connected_ToolStripLabel.Size = new System.Drawing.Size(79, 17);
            this.connected_ToolStripLabel.Text = "Disconnected";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(766, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 556);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(300, 340);
            this.Name = "MainForm";
            this.Text = "MCServerManager2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView runningInstances_TreeView;
        private System.Windows.Forms.TreeView idleInstances_TreeView;
        private System.Windows.Forms.Button open_Button;
        private System.Windows.Forms.Button kill_Button;
        private System.Windows.Forms.Button restart_Button;
        private System.Windows.Forms.Button refreshLists_Button;
        private System.Windows.Forms.Button createInstance_Button;
        private System.Windows.Forms.Button modifyInstance_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mcServerPath_TextBox;
        private System.Windows.Forms.TextBox remoteLocation_TextBox;
        private System.Windows.Forms.TextBox mountPoint_TextBox;
        private System.Windows.Forms.Button start_Button;
        private System.Windows.Forms.Button stop_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel connected_ToolStripLabel;
        private System.Windows.Forms.Button expandLists_Button;
        private System.Windows.Forms.Button deleteInstances_Button;
        private System.Windows.Forms.Button openMonitor_Button;
        private System.Windows.Forms.Button openFolder_Button;
    }
}

