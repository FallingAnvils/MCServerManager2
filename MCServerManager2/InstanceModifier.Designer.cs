namespace MCServerManager2
{
    partial class InstanceModifier
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
            this.fileList_TreeView = new System.Windows.Forms.TreeView();
            this.editFile_Button = new System.Windows.Forms.Button();
            this.delete_Button = new System.Windows.Forms.Button();
            this.refreshFileList_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.expandAll_Button = new System.Windows.Forms.Button();
            this.uploadFiles_Button = new System.Windows.Forms.Button();
            this.expandToInstance_Button = new System.Windows.Forms.Button();
            this.download_Button = new System.Windows.Forms.Button();
            this.installJar_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileList_TreeView
            // 
            this.fileList_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileList_TreeView.Location = new System.Drawing.Point(3, 3);
            this.fileList_TreeView.Name = "fileList_TreeView";
            this.fileList_TreeView.PathSeparator = "/";
            this.fileList_TreeView.Size = new System.Drawing.Size(669, 444);
            this.fileList_TreeView.TabIndex = 0;
            // 
            // editFile_Button
            // 
            this.editFile_Button.Location = new System.Drawing.Point(3, 3);
            this.editFile_Button.Name = "editFile_Button";
            this.editFile_Button.Size = new System.Drawing.Size(110, 23);
            this.editFile_Button.TabIndex = 1;
            this.editFile_Button.Text = "Edit File";
            this.editFile_Button.UseVisualStyleBackColor = true;
            this.editFile_Button.Click += new System.EventHandler(this.editFile_Button_Click);
            // 
            // delete_Button
            // 
            this.delete_Button.Location = new System.Drawing.Point(3, 61);
            this.delete_Button.Name = "delete_Button";
            this.delete_Button.Size = new System.Drawing.Size(110, 23);
            this.delete_Button.TabIndex = 2;
            this.delete_Button.Text = "Delete";
            this.delete_Button.UseVisualStyleBackColor = true;
            this.delete_Button.Click += new System.EventHandler(this.delete_Button_Click);
            // 
            // refreshFileList_Button
            // 
            this.refreshFileList_Button.Location = new System.Drawing.Point(3, 32);
            this.refreshFileList_Button.Name = "refreshFileList_Button";
            this.refreshFileList_Button.Size = new System.Drawing.Size(110, 23);
            this.refreshFileList_Button.TabIndex = 3;
            this.refreshFileList_Button.Text = "Refresh";
            this.refreshFileList_Button.UseVisualStyleBackColor = true;
            this.refreshFileList_Button.Click += new System.EventHandler(this.refreshFileList_Button_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.fileList_TreeView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.editFile_Button);
            this.flowLayoutPanel1.Controls.Add(this.refreshFileList_Button);
            this.flowLayoutPanel1.Controls.Add(this.delete_Button);
            this.flowLayoutPanel1.Controls.Add(this.expandAll_Button);
            this.flowLayoutPanel1.Controls.Add(this.uploadFiles_Button);
            this.flowLayoutPanel1.Controls.Add(this.expandToInstance_Button);
            this.flowLayoutPanel1.Controls.Add(this.download_Button);
            this.flowLayoutPanel1.Controls.Add(this.installJar_Button);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(678, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(119, 444);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // expandAll_Button
            // 
            this.expandAll_Button.Location = new System.Drawing.Point(3, 90);
            this.expandAll_Button.Name = "expandAll_Button";
            this.expandAll_Button.Size = new System.Drawing.Size(110, 23);
            this.expandAll_Button.TabIndex = 4;
            this.expandAll_Button.Text = "Expand All";
            this.expandAll_Button.UseVisualStyleBackColor = true;
            this.expandAll_Button.Click += new System.EventHandler(this.expandAll_Button_Click);
            // 
            // uploadFiles_Button
            // 
            this.uploadFiles_Button.Location = new System.Drawing.Point(3, 119);
            this.uploadFiles_Button.Name = "uploadFiles_Button";
            this.uploadFiles_Button.Size = new System.Drawing.Size(110, 23);
            this.uploadFiles_Button.TabIndex = 5;
            this.uploadFiles_Button.Text = "Upload File(s)";
            this.uploadFiles_Button.UseVisualStyleBackColor = true;
            this.uploadFiles_Button.Click += new System.EventHandler(this.uploadFiles_Button_Click);
            // 
            // expandToInstance_Button
            // 
            this.expandToInstance_Button.Location = new System.Drawing.Point(3, 148);
            this.expandToInstance_Button.Name = "expandToInstance_Button";
            this.expandToInstance_Button.Size = new System.Drawing.Size(110, 23);
            this.expandToInstance_Button.TabIndex = 6;
            this.expandToInstance_Button.Text = "Expand to Instance";
            this.expandToInstance_Button.UseVisualStyleBackColor = true;
            this.expandToInstance_Button.Click += new System.EventHandler(this.expandToInstance_Button_Click);
            // 
            // download_Button
            // 
            this.download_Button.Location = new System.Drawing.Point(3, 177);
            this.download_Button.Name = "download_Button";
            this.download_Button.Size = new System.Drawing.Size(110, 23);
            this.download_Button.TabIndex = 7;
            this.download_Button.Text = "Download";
            this.download_Button.UseVisualStyleBackColor = true;
            this.download_Button.Click += new System.EventHandler(this.download_Button_Click);
            // 
            // installJar_Button
            // 
            this.installJar_Button.Location = new System.Drawing.Point(3, 206);
            this.installJar_Button.Name = "installJar_Button";
            this.installJar_Button.Size = new System.Drawing.Size(110, 23);
            this.installJar_Button.TabIndex = 8;
            this.installJar_Button.Text = "Install Mod/Plugin";
            this.installJar_Button.UseVisualStyleBackColor = true;
            this.installJar_Button.Click += new System.EventHandler(this.installJar_Button_Click);
            // 
            // InstanceModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InstanceModifier";
            this.Text = "InstanceModifier";
            this.Load += new System.EventHandler(this.InstanceModifier_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView fileList_TreeView;
        private System.Windows.Forms.Button editFile_Button;
        private System.Windows.Forms.Button delete_Button;
        private System.Windows.Forms.Button refreshFileList_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button expandAll_Button;
        private System.Windows.Forms.Button uploadFiles_Button;
        private System.Windows.Forms.Button expandToInstance_Button;
        private System.Windows.Forms.Button download_Button;
        private System.Windows.Forms.Button installJar_Button;
    }
}