namespace Client
{
    partial class ClientMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存日志到ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.网络NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手动更改连接设定MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动测试默认配置文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rbNetworkController = new System.Windows.Forms.RadioButton();
            this.lvDetails = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rbOS = new System.Windows.Forms.RadioButton();
            this.rbDriver = new System.Windows.Forms.RadioButton();
            this.rbGPU = new System.Windows.Forms.RadioButton();
            this.rbMem = new System.Windows.Forms.RadioButton();
            this.rbCPU = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvConfigsDetails = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label21 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lvLog = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.lvTesting = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.serverIP = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.serverUUID = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制项目和值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.网络NToolStripMenuItem,
            this.测试TToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(811, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.另存日志到ToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 另存日志到ToolStripMenuItem
            // 
            this.另存日志到ToolStripMenuItem.Name = "另存日志到ToolStripMenuItem";
            this.另存日志到ToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.另存日志到ToolStripMenuItem.Text = "保存日志到...(&S)";
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // 网络NToolStripMenuItem
            // 
            this.网络NToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.手动更改连接设定MToolStripMenuItem});
            this.网络NToolStripMenuItem.Name = "网络NToolStripMenuItem";
            this.网络NToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.网络NToolStripMenuItem.Text = "网络(&N)";
            // 
            // 手动更改连接设定MToolStripMenuItem
            // 
            this.手动更改连接设定MToolStripMenuItem.Name = "手动更改连接设定MToolStripMenuItem";
            this.手动更改连接设定MToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.手动更改连接设定MToolStripMenuItem.Text = "手动更改连接设定(&M)";
            // 
            // 测试TToolStripMenuItem
            // 
            this.测试TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启动测试默认配置文件ToolStripMenuItem});
            this.测试TToolStripMenuItem.Name = "测试TToolStripMenuItem";
            this.测试TToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.测试TToolStripMenuItem.Text = "测试(&T)";
            // 
            // 启动测试默认配置文件ToolStripMenuItem
            // 
            this.启动测试默认配置文件ToolStripMenuItem.Name = "启动测试默认配置文件ToolStripMenuItem";
            this.启动测试默认配置文件ToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.启动测试默认配置文件ToolStripMenuItem.Text = "启动测试(默认配置文件)";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(15, 30);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 395);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rbNetworkController);
            this.tabPage1.Controls.Add(this.lvDetails);
            this.tabPage1.Controls.Add(this.rbOS);
            this.tabPage1.Controls.Add(this.rbDriver);
            this.tabPage1.Controls.Add(this.rbGPU);
            this.tabPage1.Controls.Add(this.rbMem);
            this.tabPage1.Controls.Add(this.rbCPU);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(776, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "系统";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rbNetworkController
            // 
            this.rbNetworkController.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbNetworkController.AutoSize = true;
            this.rbNetworkController.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbNetworkController.Location = new System.Drawing.Point(421, 55);
            this.rbNetworkController.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbNetworkController.Name = "rbNetworkController";
            this.rbNetworkController.Size = new System.Drawing.Size(92, 25);
            this.rbNetworkController.TabIndex = 7;
            this.rbNetworkController.Text = "网络适配器";
            this.rbNetworkController.UseVisualStyleBackColor = true;
            this.rbNetworkController.CheckedChanged += new System.EventHandler(this.rbNetworkController_CheckedChanged);
            // 
            // lvDetails
            // 
            this.lvDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11});
            this.lvDetails.ContextMenuStrip = this.contextMenuStrip1;
            this.lvDetails.FullRowSelect = true;
            this.lvDetails.GridLines = true;
            this.lvDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDetails.HideSelection = false;
            this.lvDetails.Location = new System.Drawing.Point(11, 89);
            this.lvDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvDetails.MultiSelect = false;
            this.lvDetails.Name = "lvDetails";
            this.lvDetails.ShowItemToolTips = true;
            this.lvDetails.Size = new System.Drawing.Size(755, 269);
            this.lvDetails.TabIndex = 6;
            this.lvDetails.UseCompatibleStateImageBehavior = false;
            this.lvDetails.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "项目";
            this.columnHeader10.Width = 160;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "值";
            this.columnHeader11.Width = 390;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制值ToolStripMenuItem,
            this.复制项目和值ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 52);
            // 
            // 复制值ToolStripMenuItem
            // 
            this.复制值ToolStripMenuItem.Name = "复制值ToolStripMenuItem";
            this.复制值ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.复制值ToolStripMenuItem.Text = "复制值";
            this.复制值ToolStripMenuItem.Click += new System.EventHandler(this.复制值ToolStripMenuItem_Click);
            // 
            // 复制项目和值ToolStripMenuItem
            // 
            this.复制项目和值ToolStripMenuItem.Name = "复制项目和值ToolStripMenuItem";
            this.复制项目和值ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.复制项目和值ToolStripMenuItem.Text = "复制项目和值";
            this.复制项目和值ToolStripMenuItem.Click += new System.EventHandler(this.复制项目和值ToolStripMenuItem_Click);
            // 
            // rbOS
            // 
            this.rbOS.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOS.AutoSize = true;
            this.rbOS.Checked = true;
            this.rbOS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbOS.Location = new System.Drawing.Point(11, 55);
            this.rbOS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbOS.Name = "rbOS";
            this.rbOS.Size = new System.Drawing.Size(77, 25);
            this.rbOS.TabIndex = 5;
            this.rbOS.TabStop = true;
            this.rbOS.Text = "操作系统";
            this.rbOS.UseVisualStyleBackColor = true;
            this.rbOS.CheckedChanged += new System.EventHandler(this.rbOS_CheckedChanged);
            // 
            // rbDriver
            // 
            this.rbDriver.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDriver.AutoSize = true;
            this.rbDriver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbDriver.Location = new System.Drawing.Point(537, 55);
            this.rbDriver.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbDriver.Name = "rbDriver";
            this.rbDriver.Size = new System.Drawing.Size(62, 25);
            this.rbDriver.TabIndex = 4;
            this.rbDriver.Text = "驱动器";
            this.rbDriver.UseVisualStyleBackColor = true;
            this.rbDriver.CheckedChanged += new System.EventHandler(this.rbDriver_CheckedChanged);
            // 
            // rbGPU
            // 
            this.rbGPU.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbGPU.AutoSize = true;
            this.rbGPU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbGPU.Location = new System.Drawing.Point(311, 55);
            this.rbGPU.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbGPU.Name = "rbGPU";
            this.rbGPU.Size = new System.Drawing.Size(92, 25);
            this.rbGPU.TabIndex = 3;
            this.rbGPU.Text = "显示适配器";
            this.rbGPU.UseVisualStyleBackColor = true;
            this.rbGPU.CheckedChanged += new System.EventHandler(this.rbGPU_CheckedChanged);
            // 
            // rbMem
            // 
            this.rbMem.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbMem.AutoSize = true;
            this.rbMem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbMem.Location = new System.Drawing.Point(216, 55);
            this.rbMem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbMem.Name = "rbMem";
            this.rbMem.Size = new System.Drawing.Size(77, 25);
            this.rbMem.TabIndex = 2;
            this.rbMem.Text = "内存设备";
            this.rbMem.UseVisualStyleBackColor = true;
            this.rbMem.CheckedChanged += new System.EventHandler(this.rbMem_CheckedChanged);
            // 
            // rbCPU
            // 
            this.rbCPU.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCPU.AutoSize = true;
            this.rbCPU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbCPU.Location = new System.Drawing.Point(105, 55);
            this.rbCPU.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbCPU.Name = "rbCPU";
            this.rbCPU.Size = new System.Drawing.Size(92, 25);
            this.rbCPU.TabIndex = 1;
            this.rbCPU.Text = "中央处理器";
            this.rbCPU.UseVisualStyleBackColor = true;
            this.rbCPU.CheckedChanged += new System.EventHandler(this.rbCPU_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "该工具报告计算机的配置详情并进行相关测试\r\n系统信息详情";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(776, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "配置文件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 16);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(150, 15);
            this.label22.TabIndex = 5;
            this.label22.Text = "回传的配置文件时间:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvConfigsDetails);
            this.groupBox2.Location = new System.Drawing.Point(11, 82);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(756, 277);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配置文件详情";
            // 
            // lvConfigsDetails
            // 
            this.lvConfigsDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvConfigsDetails.GridLines = true;
            this.lvConfigsDetails.HideSelection = false;
            this.lvConfigsDetails.Location = new System.Drawing.Point(8, 22);
            this.lvConfigsDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvConfigsDetails.Name = "lvConfigsDetails";
            this.lvConfigsDetails.Size = new System.Drawing.Size(739, 247);
            this.lvConfigsDetails.TabIndex = 0;
            this.lvConfigsDetails.UseCompatibleStateImageBehavior = false;
            this.lvConfigsDetails.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "值";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(124, 35);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(643, 30);
            this.progressBar1.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 44);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(105, 15);
            this.label21.TabIndex = 2;
            this.label21.Text = "接收配置文件:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.lvLog);
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Controls.Add(this.label25);
            this.tabPage3.Controls.Add(this.progressBar2);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.lvTesting);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(776, 366);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "测试";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(653, 317);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 44);
            this.button3.TabIndex = 7;
            this.button3.Text = "手动上载数据";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(653, 267);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 44);
            this.button2.TabIndex = 6;
            this.button2.Text = "保存日志";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9});
            this.lvLog.GridLines = true;
            this.lvLog.HideSelection = false;
            this.lvLog.Location = new System.Drawing.Point(4, 225);
            this.lvLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(640, 136);
            this.lvLog.TabIndex = 5;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "时间";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "描述";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(4, 198);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(255, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "每隔15分钟自动上传结果到服务器";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(653, 164);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(111, 15);
            this.label25.TabIndex = 3;
            this.label25.Text = "00:12:24  16%";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(128, 151);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(517, 40);
            this.progressBar2.TabIndex = 2;
            this.progressBar2.Value = 16;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.Location = new System.Drawing.Point(4, 151);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "启动测试";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lvTesting
            // 
            this.lvTesting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvTesting.GridLines = true;
            this.lvTesting.HideSelection = false;
            this.lvTesting.Location = new System.Drawing.Point(4, 3);
            this.lvTesting.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvTesting.Name = "lvTesting";
            this.lvTesting.Size = new System.Drawing.Size(764, 140);
            this.lvTesting.TabIndex = 0;
            this.lvTesting.UseCompatibleStateImageBehavior = false;
            this.lvTesting.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "测试项目";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "启动时间";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "详情";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "测试完成比例";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "预计需时";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(575, 474);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(271, 15);
            this.label18.TabIndex = 2;
            this.label18.Text = "x86Tester Client Copyright(C) ???";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 441);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 15);
            this.label19.TabIndex = 0;
            this.label19.Text = "服务器地址:";
            // 
            // serverIP
            // 
            this.serverIP.AutoSize = true;
            this.serverIP.Location = new System.Drawing.Point(121, 441);
            this.serverIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(68, 15);
            this.serverIP.TabIndex = 1;
            this.serverIP.Text = "(未连接)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 474);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(135, 15);
            this.label23.TabIndex = 3;
            this.label23.Text = "服务器唯一标识符:";
            // 
            // serverUUID
            // 
            this.serverUUID.AutoSize = true;
            this.serverUUID.Location = new System.Drawing.Point(169, 474);
            this.serverUUID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serverUUID.Name = "serverUUID";
            this.serverUUID.Size = new System.Drawing.Size(68, 15);
            this.serverUUID.TabIndex = 4;
            this.serverUUID.Text = "(未连接)";
            // 
            // ClientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 498);
            this.Controls.Add(this.serverUUID);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.serverIP);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(829, 545);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(829, 545);
            this.Name = "ClientMain";
            this.Text = "x86自动测试系统 -测试器端";
            this.Load += new System.EventHandler(this.ClientMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem 另存日志到ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 网络NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试TToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvConfigsDetails;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvTesting;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label serverIP;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label serverUUID;
        private System.Windows.Forms.ToolStripMenuItem 手动更改连接设定MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动测试默认配置文件ToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbOS;
        private System.Windows.Forms.RadioButton rbDriver;
        private System.Windows.Forms.RadioButton rbGPU;
        private System.Windows.Forms.RadioButton rbMem;
        private System.Windows.Forms.RadioButton rbCPU;
        private System.Windows.Forms.ListView lvDetails;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.RadioButton rbNetworkController;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制项目和值ToolStripMenuItem;
    }
}

