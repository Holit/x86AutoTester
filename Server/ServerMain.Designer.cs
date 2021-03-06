namespace Server
{
    partial class ServerMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbServerInfo = new System.Windows.Forms.TextBox();
            this.lCurrentConnection = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_uuid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCurrentConnCount = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pgPreset = new System.Windows.Forms.PropertyGrid();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.gbCPU = new System.Windows.Forms.GroupBox();
            this.cbCPU_details = new System.Windows.Forms.CheckBox();
            this.cbCPU_allFanSpeed = new System.Windows.Forms.CheckBox();
            this.cbCPU_AllTemp = new System.Windows.Forms.CheckBox();
            this.cbCPU_ErrorStop = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCPU = new System.Windows.Forms.CheckBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.gbMem = new System.Windows.Forms.GroupBox();
            this.cbMem_ErrorLocation = new System.Windows.Forms.CheckBox();
            this.cbMem_ErrorStop = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbMem = new System.Windows.Forms.CheckBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.gbDiskIO = new System.Windows.Forms.GroupBox();
            this.rbDisk_max4GBBlock = new System.Windows.Forms.RadioButton();
            this.rbDisk_min4GBBlock = new System.Windows.Forms.RadioButton();
            this.ebDisk_fragFile = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.gbChkdsk = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbDisk = new System.Windows.Forms.CheckBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.cbNet_web = new System.Windows.Forms.CheckBox();
            this.cbNet_MAC = new System.Windows.Forms.CheckBox();
            this.cbNet_CommCheck = new System.Windows.Forms.CheckBox();
            this.cbNet = new System.Windows.Forms.CheckBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.nudPnPCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.gbOutlet_Audio = new System.Windows.Forms.GroupBox();
            this.cbOutlet_VolMax = new System.Windows.Forms.CheckBox();
            this.cbOutlet_VolAuto = new System.Windows.Forms.CheckBox();
            this.cbOutlet_audioPlay = new System.Windows.Forms.CheckBox();
            this.cbOutlet_USB = new System.Windows.Forms.CheckBox();
            this.cbOutlet_COM = new System.Windows.Forms.CheckBox();
            this.cbOutlet = new System.Windows.Forms.CheckBox();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.cbOther_AllInfo = new System.Windows.Forms.CheckBox();
            this.gbPreset = new System.Windows.Forms.GroupBox();
            this.btnDelDev = new System.Windows.Forms.Button();
            this.lvPreset_Dev = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddDev = new System.Windows.Forms.Button();
            this.combPreset_SelDev = new System.Windows.Forms.ComboBox();
            this.cbOther_Preset = new System.Windows.Forms.CheckBox();
            this.cbOther_RTCLocal = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label24 = new System.Windows.Forms.Label();
            this.clientLog = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvClients = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnChangeState = new System.Windows.Forms.Button();
            this.label_backdoor = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.载入已有的配置文件LToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存当前配置文件为服务器配置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.服务器SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动测试BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停所有测试PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新UUIDUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label26 = new System.Windows.Forms.Label();
            this.pbGlobalProgress = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.serverMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.gbCPU.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.gbMem.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.gbDiskIO.SuspendLayout();
            this.gbChkdsk.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPnPCount)).BeginInit();
            this.gbOutlet_Audio.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.gbPreset.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverMainBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(24, 53);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1266, 853);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.tbServerInfo);
            this.tabPage1.Controls.Add(this.lCurrentConnection);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label_uuid);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.labelCurrentConnCount);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage1.Size = new System.Drawing.Size(1250, 806);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "服务器配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(14, 178);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(916, 5);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // tbServerInfo
            // 
            this.tbServerInfo.BackColor = System.Drawing.Color.White;
            this.tbServerInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbServerInfo.Location = new System.Drawing.Point(14, 178);
            this.tbServerInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbServerInfo.Multiline = true;
            this.tbServerInfo.Name = "tbServerInfo";
            this.tbServerInfo.ReadOnly = true;
            this.tbServerInfo.Size = new System.Drawing.Size(916, 508);
            this.tbServerInfo.TabIndex = 6;
            // 
            // lCurrentConnection
            // 
            this.lCurrentConnection.AutoSize = true;
            this.lCurrentConnection.Location = new System.Drawing.Point(170, 138);
            this.lCurrentConnection.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lCurrentConnection.Name = "lCurrentConnection";
            this.lCurrentConnection.Size = new System.Drawing.Size(24, 25);
            this.lCurrentConnection.TabIndex = 5;
            this.lCurrentConnection.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(285, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "本页允许您配置服务器的属性";
            // 
            // label_uuid
            // 
            this.label_uuid.AutoSize = true;
            this.label_uuid.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_uuid.Location = new System.Drawing.Point(242, 102);
            this.label_uuid.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_uuid.Name = "label_uuid";
            this.label_uuid.Size = new System.Drawing.Size(84, 26);
            this.label_uuid.TabIndex = 3;
            this.label_uuid.Text = "{uuid}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(621, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "此客户端启动后即侦听私有协议端口，您无需进行连接相关的操作";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "服务器唯一标识符: ";
            // 
            // labelCurrentConnCount
            // 
            this.labelCurrentConnCount.AutoSize = true;
            this.labelCurrentConnCount.Location = new System.Drawing.Point(12, 138);
            this.labelCurrentConnCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelCurrentConnCount.Name = "labelCurrentConnCount";
            this.labelCurrentConnCount.Size = new System.Drawing.Size(129, 25);
            this.labelCurrentConnCount.TabIndex = 0;
            this.labelCurrentConnCount.Text = "当前连接数: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pgPreset);
            this.tabPage2.Controls.Add(this.tbDescription);
            this.tabPage2.Controls.Add(this.btnSend);
            this.tabPage2.Controls.Add(this.btnSaveConfig);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage2.Size = new System.Drawing.Size(1250, 806);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "配置文件详情";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pgPreset
            // 
            this.pgPreset.Location = new System.Drawing.Point(636, 92);
            this.pgPreset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pgPreset.Name = "pgPreset";
            this.pgPreset.Size = new System.Drawing.Size(596, 492);
            this.pgPreset.TabIndex = 12;
            this.pgPreset.Visible = false;
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.White;
            this.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescription.Location = new System.Drawing.Point(636, 92);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.Size = new System.Drawing.Size(596, 192);
            this.tbDescription.TabIndex = 11;
            this.tbDescription.Text = "将在此处显示具体项目的描述，将鼠标悬停在任意控件上查看详情...";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(434, 710);
            this.btnSend.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(192, 62);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "下发到客户端";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(230, 710);
            this.btnSaveConfig.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(192, 62);
            this.btnSaveConfig.TabIndex = 7;
            this.btnSaveConfig.Text = "保存配置文件";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Controls.Add(this.tabPage11);
            this.tabControl2.Location = new System.Drawing.Point(18, 92);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(616, 605);
            this.tabControl2.TabIndex = 6;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.gbCPU);
            this.tabPage5.Controls.Add(this.cbCPU);
            this.tabPage5.Location = new System.Drawing.Point(8, 39);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage5.Size = new System.Drawing.Size(600, 558);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "处理器";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // gbCPU
            // 
            this.gbCPU.Controls.Add(this.cbCPU_details);
            this.gbCPU.Controls.Add(this.cbCPU_allFanSpeed);
            this.gbCPU.Controls.Add(this.cbCPU_AllTemp);
            this.gbCPU.Controls.Add(this.cbCPU_ErrorStop);
            this.gbCPU.Controls.Add(this.label9);
            this.gbCPU.Location = new System.Drawing.Point(20, 63);
            this.gbCPU.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbCPU.Name = "gbCPU";
            this.gbCPU.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbCPU.Size = new System.Drawing.Size(568, 297);
            this.gbCPU.TabIndex = 1;
            this.gbCPU.TabStop = false;
            this.gbCPU.Text = "压力测试";
            // 
            // cbCPU_details
            // 
            this.cbCPU_details.AutoSize = true;
            this.cbCPU_details.Enabled = false;
            this.cbCPU_details.Location = new System.Drawing.Point(10, 250);
            this.cbCPU_details.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbCPU_details.Name = "cbCPU_details";
            this.cbCPU_details.Size = new System.Drawing.Size(394, 29);
            this.cbCPU_details.TabIndex = 11;
            this.cbCPU_details.Text = "详细记录利用率(增大测试回传包体积)";
            this.cbCPU_details.UseVisualStyleBackColor = true;
            this.cbCPU_details.MouseEnter += new System.EventHandler(this.cbCPU_details_MouseEnter);
            this.cbCPU_details.MouseLeave += new System.EventHandler(this.cbCPU_details_MouseLeave);
            // 
            // cbCPU_allFanSpeed
            // 
            this.cbCPU_allFanSpeed.AutoSize = true;
            this.cbCPU_allFanSpeed.Enabled = false;
            this.cbCPU_allFanSpeed.Location = new System.Drawing.Point(10, 205);
            this.cbCPU_allFanSpeed.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbCPU_allFanSpeed.Name = "cbCPU_allFanSpeed";
            this.cbCPU_allFanSpeed.Size = new System.Drawing.Size(275, 29);
            this.cbCPU_allFanSpeed.TabIndex = 10;
            this.cbCPU_allFanSpeed.Text = "记录所有时刻的风扇转速";
            this.cbCPU_allFanSpeed.UseVisualStyleBackColor = true;
            this.cbCPU_allFanSpeed.MouseEnter += new System.EventHandler(this.cbCPU_allFanSpeed_MouseEnter);
            this.cbCPU_allFanSpeed.MouseLeave += new System.EventHandler(this.cbCPU_allFanSpeed_MouseLeave);
            // 
            // cbCPU_AllTemp
            // 
            this.cbCPU_AllTemp.AutoSize = true;
            this.cbCPU_AllTemp.Enabled = false;
            this.cbCPU_AllTemp.Location = new System.Drawing.Point(12, 162);
            this.cbCPU_AllTemp.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbCPU_AllTemp.Name = "cbCPU_AllTemp";
            this.cbCPU_AllTemp.Size = new System.Drawing.Size(233, 29);
            this.cbCPU_AllTemp.TabIndex = 9;
            this.cbCPU_AllTemp.Text = "记录所有时刻的温度";
            this.cbCPU_AllTemp.UseVisualStyleBackColor = true;
            this.cbCPU_AllTemp.MouseEnter += new System.EventHandler(this.cbCPU_AllTemp_MouseEnter);
            this.cbCPU_AllTemp.MouseLeave += new System.EventHandler(this.cbCPU_AllTemp_MouseLeave);
            // 
            // cbCPU_ErrorStop
            // 
            this.cbCPU_ErrorStop.AutoSize = true;
            this.cbCPU_ErrorStop.Enabled = false;
            this.cbCPU_ErrorStop.Location = new System.Drawing.Point(12, 117);
            this.cbCPU_ErrorStop.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbCPU_ErrorStop.Name = "cbCPU_ErrorStop";
            this.cbCPU_ErrorStop.Size = new System.Drawing.Size(191, 29);
            this.cbCPU_ErrorStop.TabIndex = 8;
            this.cbCPU_ErrorStop.Text = "出现错误即停止";
            this.cbCPU_ErrorStop.UseVisualStyleBackColor = true;
            this.cbCPU_ErrorStop.MouseEnter += new System.EventHandler(this.cbCPU_ErrorStop_MouseEnter);
            this.cbCPU_ErrorStop.MouseLeave += new System.EventHandler(this.cbCPU_ErrorStop_MouseLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(390, 50);
            this.label9.TabIndex = 7;
            this.label9.Text = "压力测试将利用中央处理器对大规模问题\r\n进行运算，并监测其温度";
            // 
            // cbCPU
            // 
            this.cbCPU.AutoSize = true;
            this.cbCPU.Checked = true;
            this.cbCPU.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCPU.Enabled = false;
            this.cbCPU.Location = new System.Drawing.Point(20, 20);
            this.cbCPU.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbCPU.Name = "cbCPU";
            this.cbCPU.Size = new System.Drawing.Size(149, 29);
            this.cbCPU.TabIndex = 0;
            this.cbCPU.Text = "启用此测试";
            this.cbCPU.UseVisualStyleBackColor = true;
            this.cbCPU.CheckedChanged += new System.EventHandler(this.cbCPU_CheckedChanged);
            this.cbCPU.MouseEnter += new System.EventHandler(this.cbCPU_MouseEnter);
            this.cbCPU.MouseLeave += new System.EventHandler(this.cbCPU_MouseLeave);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.gbMem);
            this.tabPage6.Controls.Add(this.cbMem);
            this.tabPage6.Location = new System.Drawing.Point(8, 39);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage6.Size = new System.Drawing.Size(600, 558);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "内存";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // gbMem
            // 
            this.gbMem.Controls.Add(this.cbMem_ErrorLocation);
            this.gbMem.Controls.Add(this.cbMem_ErrorStop);
            this.gbMem.Controls.Add(this.label16);
            this.gbMem.Location = new System.Drawing.Point(20, 63);
            this.gbMem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbMem.Name = "gbMem";
            this.gbMem.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbMem.Size = new System.Drawing.Size(568, 223);
            this.gbMem.TabIndex = 7;
            this.gbMem.TabStop = false;
            this.gbMem.Text = "压力测试";
            // 
            // cbMem_ErrorLocation
            // 
            this.cbMem_ErrorLocation.AutoSize = true;
            this.cbMem_ErrorLocation.Enabled = false;
            this.cbMem_ErrorLocation.Location = new System.Drawing.Point(12, 162);
            this.cbMem_ErrorLocation.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbMem_ErrorLocation.Name = "cbMem_ErrorLocation";
            this.cbMem_ErrorLocation.Size = new System.Drawing.Size(352, 29);
            this.cbMem_ErrorLocation.TabIndex = 9;
            this.cbMem_ErrorLocation.Text = "试图获取错误区域内存地址(高级)";
            this.cbMem_ErrorLocation.UseVisualStyleBackColor = true;
            this.cbMem_ErrorLocation.MouseEnter += new System.EventHandler(this.cbMem_ErrorLocation_MouseEnter);
            this.cbMem_ErrorLocation.MouseLeave += new System.EventHandler(this.cbMem_ErrorLocation_MouseLeave);
            // 
            // cbMem_ErrorStop
            // 
            this.cbMem_ErrorStop.AutoSize = true;
            this.cbMem_ErrorStop.Enabled = false;
            this.cbMem_ErrorStop.Location = new System.Drawing.Point(12, 117);
            this.cbMem_ErrorStop.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbMem_ErrorStop.Name = "cbMem_ErrorStop";
            this.cbMem_ErrorStop.Size = new System.Drawing.Size(191, 29);
            this.cbMem_ErrorStop.TabIndex = 8;
            this.cbMem_ErrorStop.Text = "出现错误即停止";
            this.cbMem_ErrorStop.UseVisualStyleBackColor = true;
            this.cbMem_ErrorStop.MouseEnter += new System.EventHandler(this.cbMem_ErrorStop_MouseEnter);
            this.cbMem_ErrorStop.MouseLeave += new System.EventHandler(this.cbMem_ErrorStop_MouseLeave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 30);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(432, 50);
            this.label16.TabIndex = 7;
            this.label16.Text = "压力测试将对内存设备进行大规模读取和占用\r\n请提前保存重要数据";
            // 
            // cbMem
            // 
            this.cbMem.AutoSize = true;
            this.cbMem.Checked = true;
            this.cbMem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMem.Enabled = false;
            this.cbMem.Location = new System.Drawing.Point(20, 20);
            this.cbMem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbMem.Name = "cbMem";
            this.cbMem.Size = new System.Drawing.Size(149, 29);
            this.cbMem.TabIndex = 6;
            this.cbMem.Text = "启用此测试";
            this.cbMem.UseVisualStyleBackColor = true;
            this.cbMem.CheckedChanged += new System.EventHandler(this.cbMem_CheckedChanged);
            this.cbMem.MouseEnter += new System.EventHandler(this.cbMem_MouseEnter);
            this.cbMem.MouseLeave += new System.EventHandler(this.cbMem_MouseLeave);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.gbDiskIO);
            this.tabPage7.Controls.Add(this.gbChkdsk);
            this.tabPage7.Controls.Add(this.cbDisk);
            this.tabPage7.Location = new System.Drawing.Point(8, 39);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(600, 558);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "驱动器";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // gbDiskIO
            // 
            this.gbDiskIO.Controls.Add(this.rbDisk_max4GBBlock);
            this.gbDiskIO.Controls.Add(this.rbDisk_min4GBBlock);
            this.gbDiskIO.Controls.Add(this.ebDisk_fragFile);
            this.gbDiskIO.Controls.Add(this.label19);
            this.gbDiskIO.Enabled = false;
            this.gbDiskIO.Location = new System.Drawing.Point(20, 153);
            this.gbDiskIO.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbDiskIO.Name = "gbDiskIO";
            this.gbDiskIO.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbDiskIO.Size = new System.Drawing.Size(568, 253);
            this.gbDiskIO.TabIndex = 9;
            this.gbDiskIO.TabStop = false;
            this.gbDiskIO.Text = "高压读写监测";
            // 
            // rbDisk_max4GBBlock
            // 
            this.rbDisk_max4GBBlock.AutoSize = true;
            this.rbDisk_max4GBBlock.Location = new System.Drawing.Point(18, 198);
            this.rbDisk_max4GBBlock.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.rbDisk_max4GBBlock.Name = "rbDisk_max4GBBlock";
            this.rbDisk_max4GBBlock.Size = new System.Drawing.Size(256, 29);
            this.rbDisk_max4GBBlock.TabIndex = 10;
            this.rbDisk_max4GBBlock.TabStop = true;
            this.rbDisk_max4GBBlock.Text = "整块文件(>4GB,NTFS)";
            this.rbDisk_max4GBBlock.UseVisualStyleBackColor = true;
            // 
            // rbDisk_min4GBBlock
            // 
            this.rbDisk_min4GBBlock.AutoSize = true;
            this.rbDisk_min4GBBlock.Location = new System.Drawing.Point(18, 148);
            this.rbDisk_min4GBBlock.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.rbDisk_min4GBBlock.Name = "rbDisk_min4GBBlock";
            this.rbDisk_min4GBBlock.Size = new System.Drawing.Size(241, 29);
            this.rbDisk_min4GBBlock.TabIndex = 9;
            this.rbDisk_min4GBBlock.TabStop = true;
            this.rbDisk_min4GBBlock.Text = "整块文件(<4GB,FAT)";
            this.rbDisk_min4GBBlock.UseVisualStyleBackColor = true;
            // 
            // ebDisk_fragFile
            // 
            this.ebDisk_fragFile.AutoSize = true;
            this.ebDisk_fragFile.Location = new System.Drawing.Point(18, 98);
            this.ebDisk_fragFile.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ebDisk_fragFile.Name = "ebDisk_fragFile";
            this.ebDisk_fragFile.Size = new System.Drawing.Size(241, 29);
            this.ebDisk_fragFile.TabIndex = 8;
            this.ebDisk_fragFile.TabStop = true;
            this.ebDisk_fragFile.Text = "碎片文件(4KB,8线程)";
            this.ebDisk_fragFile.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 30);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(432, 50);
            this.label19.TabIndex = 7;
            this.label19.Text = "生成数据写入磁盘\r\n请注意：此操作可能会导致完好磁盘寿命衰减";
            // 
            // gbChkdsk
            // 
            this.gbChkdsk.Controls.Add(this.label17);
            this.gbChkdsk.Location = new System.Drawing.Point(20, 63);
            this.gbChkdsk.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbChkdsk.Name = "gbChkdsk";
            this.gbChkdsk.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbChkdsk.Size = new System.Drawing.Size(568, 78);
            this.gbChkdsk.TabIndex = 8;
            this.gbChkdsk.TabStop = false;
            this.gbChkdsk.Text = "坏道检查";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 30);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(332, 25);
            this.label17.TabIndex = 7;
            this.label17.Text = "将调用chkdsk进行坏道检查与修复";
            // 
            // cbDisk
            // 
            this.cbDisk.AutoSize = true;
            this.cbDisk.Checked = true;
            this.cbDisk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisk.Enabled = false;
            this.cbDisk.Location = new System.Drawing.Point(20, 20);
            this.cbDisk.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbDisk.Name = "cbDisk";
            this.cbDisk.Size = new System.Drawing.Size(149, 29);
            this.cbDisk.TabIndex = 6;
            this.cbDisk.Text = "启用此测试";
            this.cbDisk.UseVisualStyleBackColor = true;
            this.cbDisk.CheckedChanged += new System.EventHandler(this.cbDisk_CheckedChanged);
            this.cbDisk.MouseEnter += new System.EventHandler(this.cbDisk_MouseEnter);
            this.cbDisk.MouseLeave += new System.EventHandler(this.cbDisk_MouseLeave);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.cbNet_web);
            this.tabPage8.Controls.Add(this.cbNet_MAC);
            this.tabPage8.Controls.Add(this.cbNet_CommCheck);
            this.tabPage8.Controls.Add(this.cbNet);
            this.tabPage8.Location = new System.Drawing.Point(8, 39);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(600, 558);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "网络组件";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // cbNet_web
            // 
            this.cbNet_web.AutoSize = true;
            this.cbNet_web.Enabled = false;
            this.cbNet_web.Location = new System.Drawing.Point(20, 108);
            this.cbNet_web.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbNet_web.Name = "cbNet_web";
            this.cbNet_web.Size = new System.Drawing.Size(170, 29);
            this.cbNet_web.TabIndex = 9;
            this.cbNet_web.Text = "外网访问测试";
            this.cbNet_web.UseVisualStyleBackColor = true;
            this.cbNet_web.MouseEnter += new System.EventHandler(this.cbNet_web_MouseEnter);
            this.cbNet_web.MouseLeave += new System.EventHandler(this.cbNet_web_MouseLeave);
            // 
            // cbNet_MAC
            // 
            this.cbNet_MAC.AutoSize = true;
            this.cbNet_MAC.Checked = true;
            this.cbNet_MAC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNet_MAC.Location = new System.Drawing.Point(20, 152);
            this.cbNet_MAC.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbNet_MAC.Name = "cbNet_MAC";
            this.cbNet_MAC.Size = new System.Drawing.Size(344, 29);
            this.cbNet_MAC.TabIndex = 8;
            this.cbNet_MAC.Text = "检查MAC地址规范( IEEE802.1 )";
            this.cbNet_MAC.UseVisualStyleBackColor = true;
            this.cbNet_MAC.MouseEnter += new System.EventHandler(this.cbNet_MAC_MouseEnter);
            this.cbNet_MAC.MouseLeave += new System.EventHandler(this.cbNet_MAC_MouseLeave);
            // 
            // cbNet_CommCheck
            // 
            this.cbNet_CommCheck.AutoSize = true;
            this.cbNet_CommCheck.Checked = true;
            this.cbNet_CommCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNet_CommCheck.Enabled = false;
            this.cbNet_CommCheck.Location = new System.Drawing.Point(20, 63);
            this.cbNet_CommCheck.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbNet_CommCheck.Name = "cbNet_CommCheck";
            this.cbNet_CommCheck.Size = new System.Drawing.Size(170, 29);
            this.cbNet_CommCheck.TabIndex = 7;
            this.cbNet_CommCheck.Text = "进行通信测试";
            this.cbNet_CommCheck.UseVisualStyleBackColor = true;
            this.cbNet_CommCheck.MouseEnter += new System.EventHandler(this.cnNet_CommCheck_MouseEnter);
            this.cbNet_CommCheck.MouseLeave += new System.EventHandler(this.cnNet_CommCheck_MouseLeave);
            // 
            // cbNet
            // 
            this.cbNet.AutoSize = true;
            this.cbNet.Checked = true;
            this.cbNet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNet.Enabled = false;
            this.cbNet.Location = new System.Drawing.Point(20, 20);
            this.cbNet.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbNet.Name = "cbNet";
            this.cbNet.Size = new System.Drawing.Size(149, 29);
            this.cbNet.TabIndex = 6;
            this.cbNet.Text = "启用此测试";
            this.cbNet.UseVisualStyleBackColor = true;
            this.cbNet.MouseEnter += new System.EventHandler(this.cbNet_MouseEnter);
            this.cbNet.MouseLeave += new System.EventHandler(this.cbNet_MouseLeave);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.nudPnPCount);
            this.tabPage9.Controls.Add(this.label1);
            this.tabPage9.Controls.Add(this.gbOutlet_Audio);
            this.tabPage9.Controls.Add(this.cbOutlet_USB);
            this.tabPage9.Controls.Add(this.cbOutlet_COM);
            this.tabPage9.Controls.Add(this.cbOutlet);
            this.tabPage9.Location = new System.Drawing.Point(8, 39);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(600, 558);
            this.tabPage9.TabIndex = 4;
            this.tabPage9.Text = "外设组件";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // nudPnPCount
            // 
            this.nudPnPCount.Location = new System.Drawing.Point(490, 102);
            this.nudPnPCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPnPCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPnPCount.Name = "nudPnPCount";
            this.nudPnPCount.Size = new System.Drawing.Size(68, 31);
            this.nudPnPCount.TabIndex = 12;
            this.nudPnPCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPnPCount.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "即插即用设备校验数量:";
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // gbOutlet_Audio
            // 
            this.gbOutlet_Audio.Controls.Add(this.cbOutlet_VolMax);
            this.gbOutlet_Audio.Controls.Add(this.cbOutlet_VolAuto);
            this.gbOutlet_Audio.Controls.Add(this.cbOutlet_audioPlay);
            this.gbOutlet_Audio.Location = new System.Drawing.Point(20, 152);
            this.gbOutlet_Audio.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbOutlet_Audio.Name = "gbOutlet_Audio";
            this.gbOutlet_Audio.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbOutlet_Audio.Size = new System.Drawing.Size(568, 128);
            this.gbOutlet_Audio.TabIndex = 9;
            this.gbOutlet_Audio.TabStop = false;
            this.gbOutlet_Audio.Text = "音频组件";
            // 
            // cbOutlet_VolMax
            // 
            this.cbOutlet_VolMax.AutoSize = true;
            this.cbOutlet_VolMax.Enabled = false;
            this.cbOutlet_VolMax.Location = new System.Drawing.Point(216, 80);
            this.cbOutlet_VolMax.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbOutlet_VolMax.Name = "cbOutlet_VolMax";
            this.cbOutlet_VolMax.Size = new System.Drawing.Size(170, 29);
            this.cbOutlet_VolMax.TabIndex = 2;
            this.cbOutlet_VolMax.Text = "保持最大音量";
            this.cbOutlet_VolMax.UseVisualStyleBackColor = true;
            this.cbOutlet_VolMax.CheckedChanged += new System.EventHandler(this.cbOutlet_VolMax_CheckedChanged);
            this.cbOutlet_VolMax.MouseEnter += new System.EventHandler(this.cbOutlet_VolMax_MouseEnter);
            this.cbOutlet_VolMax.MouseLeave += new System.EventHandler(this.cbOutlet_VolMax_MouseLeave);
            // 
            // cbOutlet_VolAuto
            // 
            this.cbOutlet_VolAuto.AutoSize = true;
            this.cbOutlet_VolAuto.Enabled = false;
            this.cbOutlet_VolAuto.Location = new System.Drawing.Point(12, 80);
            this.cbOutlet_VolAuto.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbOutlet_VolAuto.Name = "cbOutlet_VolAuto";
            this.cbOutlet_VolAuto.Size = new System.Drawing.Size(170, 29);
            this.cbOutlet_VolAuto.TabIndex = 1;
            this.cbOutlet_VolAuto.Text = "自动调节音量";
            this.cbOutlet_VolAuto.UseVisualStyleBackColor = true;
            this.cbOutlet_VolAuto.MouseEnter += new System.EventHandler(this.cbOutlet_VolAuto_MouseEnter);
            this.cbOutlet_VolAuto.MouseLeave += new System.EventHandler(this.cbOutlet_VolAuto_MouseLeave);
            // 
            // cbOutlet_audioPlay
            // 
            this.cbOutlet_audioPlay.AutoSize = true;
            this.cbOutlet_audioPlay.Checked = true;
            this.cbOutlet_audioPlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOutlet_audioPlay.Location = new System.Drawing.Point(12, 37);
            this.cbOutlet_audioPlay.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbOutlet_audioPlay.Name = "cbOutlet_audioPlay";
            this.cbOutlet_audioPlay.Size = new System.Drawing.Size(233, 29);
            this.cbOutlet_audioPlay.TabIndex = 0;
            this.cbOutlet_audioPlay.Text = "尝试访问硬件并发声";
            this.cbOutlet_audioPlay.UseVisualStyleBackColor = true;
            this.cbOutlet_audioPlay.MouseEnter += new System.EventHandler(this.cbOutlet_audioPlay_MouseEnter);
            this.cbOutlet_audioPlay.MouseLeave += new System.EventHandler(this.cbOutlet_audioPlay_MouseLeave);
            // 
            // cbOutlet_USB
            // 
            this.cbOutlet_USB.AutoSize = true;
            this.cbOutlet_USB.Checked = true;
            this.cbOutlet_USB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOutlet_USB.Location = new System.Drawing.Point(20, 108);
            this.cbOutlet_USB.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbOutlet_USB.Name = "cbOutlet_USB";
            this.cbOutlet_USB.Size = new System.Drawing.Size(171, 29);
            this.cbOutlet_USB.TabIndex = 8;
            this.cbOutlet_USB.Text = "访问外设USB";
            this.cbOutlet_USB.UseVisualStyleBackColor = true;
            this.cbOutlet_USB.MouseEnter += new System.EventHandler(this.cbOutlet_USB_MouseEnter);
            this.cbOutlet_USB.MouseLeave += new System.EventHandler(this.cbOutlet_USB_MouseLeave);
            // 
            // cbOutlet_COM
            // 
            this.cbOutlet_COM.AutoSize = true;
            this.cbOutlet_COM.Checked = true;
            this.cbOutlet_COM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOutlet_COM.Location = new System.Drawing.Point(20, 63);
            this.cbOutlet_COM.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbOutlet_COM.Name = "cbOutlet_COM";
            this.cbOutlet_COM.Size = new System.Drawing.Size(387, 29);
            this.cbOutlet_COM.TabIndex = 7;
            this.cbOutlet_COM.Text = "试图向已知的所有COM端口发送数据";
            this.cbOutlet_COM.UseVisualStyleBackColor = true;
            this.cbOutlet_COM.MouseEnter += new System.EventHandler(this.cbOutlet_COM_MouseEnter);
            this.cbOutlet_COM.MouseLeave += new System.EventHandler(this.cbOutlet_COM_MouseLeave);
            // 
            // cbOutlet
            // 
            this.cbOutlet.AutoSize = true;
            this.cbOutlet.Checked = true;
            this.cbOutlet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOutlet.Enabled = false;
            this.cbOutlet.Location = new System.Drawing.Point(20, 20);
            this.cbOutlet.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbOutlet.Name = "cbOutlet";
            this.cbOutlet.Size = new System.Drawing.Size(149, 29);
            this.cbOutlet.TabIndex = 6;
            this.cbOutlet.Text = "启用此测试";
            this.cbOutlet.UseVisualStyleBackColor = true;
            this.cbOutlet.CheckedChanged += new System.EventHandler(this.cbOutlet_CheckedChanged);
            this.cbOutlet.MouseEnter += new System.EventHandler(this.cbOutlet_MouseEnter);
            this.cbOutlet.MouseLeave += new System.EventHandler(this.cbOutlet_MouseLeave);
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.cbOther_AllInfo);
            this.tabPage11.Controls.Add(this.gbPreset);
            this.tabPage11.Controls.Add(this.cbOther_Preset);
            this.tabPage11.Controls.Add(this.cbOther_RTCLocal);
            this.tabPage11.Location = new System.Drawing.Point(8, 39);
            this.tabPage11.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(600, 558);
            this.tabPage11.TabIndex = 6;
            this.tabPage11.Text = "校验";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // cbOther_AllInfo
            // 
            this.cbOther_AllInfo.AutoSize = true;
            this.cbOther_AllInfo.Enabled = false;
            this.cbOther_AllInfo.Location = new System.Drawing.Point(20, 108);
            this.cbOther_AllInfo.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.cbOther_AllInfo.Name = "cbOther_AllInfo";
            this.cbOther_AllInfo.Size = new System.Drawing.Size(170, 29);
            this.cbOther_AllInfo.TabIndex = 9;
            this.cbOther_AllInfo.Text = "传递所有信息";
            this.cbOther_AllInfo.UseVisualStyleBackColor = true;
            this.cbOther_AllInfo.MouseEnter += new System.EventHandler(this.cbOther_AllInfo_MouseEnter_1);
            this.cbOther_AllInfo.MouseLeave += new System.EventHandler(this.cbOther_AllInfo_MouseLeave_1);
            // 
            // gbPreset
            // 
            this.gbPreset.Controls.Add(this.btnDelDev);
            this.gbPreset.Controls.Add(this.lvPreset_Dev);
            this.gbPreset.Controls.Add(this.btnAddDev);
            this.gbPreset.Controls.Add(this.combPreset_SelDev);
            this.gbPreset.Enabled = false;
            this.gbPreset.Location = new System.Drawing.Point(20, 108);
            this.gbPreset.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.gbPreset.Name = "gbPreset";
            this.gbPreset.Padding = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.gbPreset.Size = new System.Drawing.Size(528, 287);
            this.gbPreset.TabIndex = 8;
            this.gbPreset.TabStop = false;
            this.gbPreset.Text = "自定义配置校验";
            this.gbPreset.Visible = false;
            // 
            // btnDelDev
            // 
            this.btnDelDev.Enabled = false;
            this.btnDelDev.Location = new System.Drawing.Point(456, 227);
            this.btnDelDev.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDelDev.Name = "btnDelDev";
            this.btnDelDev.Size = new System.Drawing.Size(56, 40);
            this.btnDelDev.TabIndex = 17;
            this.btnDelDev.Text = "-";
            this.btnDelDev.UseVisualStyleBackColor = true;
            this.btnDelDev.Click += new System.EventHandler(this.btnDelDev_Click);
            // 
            // lvPreset_Dev
            // 
            this.lvPreset_Dev.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader6});
            this.lvPreset_Dev.FullRowSelect = true;
            this.lvPreset_Dev.GridLines = true;
            this.lvPreset_Dev.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPreset_Dev.HideSelection = false;
            this.lvPreset_Dev.Location = new System.Drawing.Point(12, 47);
            this.lvPreset_Dev.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lvPreset_Dev.MultiSelect = false;
            this.lvPreset_Dev.Name = "lvPreset_Dev";
            this.lvPreset_Dev.Size = new System.Drawing.Size(500, 166);
            this.lvPreset_Dev.TabIndex = 16;
            this.lvPreset_Dev.UseCompatibleStateImageBehavior = false;
            this.lvPreset_Dev.View = System.Windows.Forms.View.Details;
            this.lvPreset_Dev.SelectedIndexChanged += new System.EventHandler(this.lvPreset_Dev_SelectedIndexChanged);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "#";
            this.columnHeader8.Width = 22;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "设备类型";
            this.columnHeader9.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "说明";
            this.columnHeader6.Width = 150;
            // 
            // btnAddDev
            // 
            this.btnAddDev.Location = new System.Drawing.Point(388, 227);
            this.btnAddDev.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAddDev.Name = "btnAddDev";
            this.btnAddDev.Size = new System.Drawing.Size(56, 40);
            this.btnAddDev.TabIndex = 15;
            this.btnAddDev.Text = "+";
            this.btnAddDev.UseVisualStyleBackColor = true;
            this.btnAddDev.Click += new System.EventHandler(this.btnAddDev_Click);
            // 
            // combPreset_SelDev
            // 
            this.combPreset_SelDev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combPreset_SelDev.FormattingEnabled = true;
            this.combPreset_SelDev.Items.AddRange(new object[] {
            "中央处理器设备",
            "内存设备",
            "驱动器设备",
            "网络适配器设备",
            "显示适配器设备"});
            this.combPreset_SelDev.Location = new System.Drawing.Point(12, 227);
            this.combPreset_SelDev.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.combPreset_SelDev.MaxDropDownItems = 5;
            this.combPreset_SelDev.Name = "combPreset_SelDev";
            this.combPreset_SelDev.Size = new System.Drawing.Size(360, 33);
            this.combPreset_SelDev.TabIndex = 14;
            this.combPreset_SelDev.SelectedValueChanged += new System.EventHandler(this.combPreset_SelDev_SelectedValueChanged);
            // 
            // cbOther_Preset
            // 
            this.cbOther_Preset.AutoSize = true;
            this.cbOther_Preset.Location = new System.Drawing.Point(20, 63);
            this.cbOther_Preset.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.cbOther_Preset.Name = "cbOther_Preset";
            this.cbOther_Preset.Size = new System.Drawing.Size(191, 29);
            this.cbOther_Preset.TabIndex = 7;
            this.cbOther_Preset.Text = "校验自定义配置\r\n";
            this.cbOther_Preset.UseVisualStyleBackColor = true;
            this.cbOther_Preset.CheckedChanged += new System.EventHandler(this.cbOther_Preset_CheckedChanged_1);
            this.cbOther_Preset.MouseEnter += new System.EventHandler(this.cbOther_Preset_MouseEnter_1);
            this.cbOther_Preset.MouseLeave += new System.EventHandler(this.cbOther_Preset_MouseLeave_1);
            // 
            // cbOther_RTCLocal
            // 
            this.cbOther_RTCLocal.AutoSize = true;
            this.cbOther_RTCLocal.Checked = true;
            this.cbOther_RTCLocal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOther_RTCLocal.Enabled = false;
            this.cbOther_RTCLocal.Location = new System.Drawing.Point(20, 17);
            this.cbOther_RTCLocal.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.cbOther_RTCLocal.Name = "cbOther_RTCLocal";
            this.cbOther_RTCLocal.Size = new System.Drawing.Size(170, 29);
            this.cbOther_RTCLocal.TabIndex = 6;
            this.cbOther_RTCLocal.Text = "执行时间校验";
            this.cbOther_RTCLocal.UseVisualStyleBackColor = true;
            this.cbOther_RTCLocal.CheckedChanged += new System.EventHandler(this.cbOther_RTCLocal_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(390, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "您可以在下方的选项卡组中勾选测试项目";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.clientLog);
            this.tabPage3.Controls.Add(this.lvClients);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1250, 806);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "各终端测试情况";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 375);
            this.label24.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(96, 25);
            this.label24.TabIndex = 13;
            this.label24.Text = "终端日志";
            // 
            // clientLog
            // 
            this.clientLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader5});
            this.clientLog.HideSelection = false;
            this.clientLog.Location = new System.Drawing.Point(12, 405);
            this.clientLog.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.clientLog.Name = "clientLog";
            this.clientLog.Size = new System.Drawing.Size(1226, 389);
            this.clientLog.TabIndex = 7;
            this.clientLog.UseCompatibleStateImageBehavior = false;
            this.clientLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "时间";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "地址";
            this.columnHeader7.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "描述";
            this.columnHeader5.Width = 350;
            // 
            // lvClients
            // 
            this.lvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvClients.GridLines = true;
            this.lvClients.HideSelection = false;
            this.lvClients.Location = new System.Drawing.Point(12, 108);
            this.lvClients.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lvClients.Name = "lvClients";
            this.lvClients.Size = new System.Drawing.Size(1226, 257);
            this.lvClients.TabIndex = 6;
            this.lvClients.UseCompatibleStateImageBehavior = false;
            this.lvClients.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "地址";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "当前项目";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "总体完成进度";
            this.columnHeader3.Width = 150;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 28);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(432, 50);
            this.label8.TabIndex = 5;
            this.label8.Text = "本页允许您查看正在进行测试的各终端的状况\r\n在下方选择一个终端进行操作";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label28);
            this.tabPage4.Controls.Add(this.label27);
            this.tabPage4.Location = new System.Drawing.Point(8, 39);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1250, 806);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "关于";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(30, 88);
            this.label28.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(249, 50);
            this.label28.TabIndex = 1;
            this.label28.Text = "2022年服务外包大赛作品\r\n哈尔滨工程大学";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(30, 37);
            this.label27.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(215, 25);
            this.label27.TabIndex = 0;
            this.label27.Text = "x86测试软件服务器端";
            // 
            // btnChangeState
            // 
            this.btnChangeState.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangeState.Location = new System.Drawing.Point(878, 920);
            this.btnChangeState.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnChangeState.Name = "btnChangeState";
            this.btnChangeState.Size = new System.Drawing.Size(54, 52);
            this.btnChangeState.TabIndex = 11;
            this.btnChangeState.Text = "▶";
            this.btnChangeState.UseVisualStyleBackColor = true;
            this.btnChangeState.Click += new System.EventHandler(this.btnChangeState_Click);
            // 
            // label_backdoor
            // 
            this.label_backdoor.AutoSize = true;
            this.label_backdoor.Location = new System.Drawing.Point(954, 935);
            this.label_backdoor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_backdoor.Name = "label_backdoor";
            this.label_backdoor.Size = new System.Drawing.Size(346, 25);
            this.label_backdoor.TabIndex = 3;
            this.label_backdoor.Text = "x86Tester Client Copyright(C) HEU\r\n";
            this.label_backdoor.Click += new System.EventHandler(this.label_backdoor_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 984);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1298, 41);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(62, 31);
            this.toolStripStatusLabel1.Text = "就绪";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.服务器SToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1298, 42);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.载入已有的配置文件LToolStripMenuItem,
            this.保存当前配置文件为服务器配置SToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(111, 38);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 载入已有的配置文件LToolStripMenuItem
            // 
            this.载入已有的配置文件LToolStripMenuItem.Name = "载入已有的配置文件LToolStripMenuItem";
            this.载入已有的配置文件LToolStripMenuItem.Size = new System.Drawing.Size(513, 44);
            this.载入已有的配置文件LToolStripMenuItem.Text = "载入已有的配置文件(&L)";
            this.载入已有的配置文件LToolStripMenuItem.Click += new System.EventHandler(this.载入已有的配置文件LToolStripMenuItem_Click);
            // 
            // 保存当前配置文件为服务器配置SToolStripMenuItem
            // 
            this.保存当前配置文件为服务器配置SToolStripMenuItem.Name = "保存当前配置文件为服务器配置SToolStripMenuItem";
            this.保存当前配置文件为服务器配置SToolStripMenuItem.Size = new System.Drawing.Size(513, 44);
            this.保存当前配置文件为服务器配置SToolStripMenuItem.Text = "保存当前配置文件为服务器配置(S)";
            this.保存当前配置文件为服务器配置SToolStripMenuItem.Click += new System.EventHandler(this.保存当前配置文件为服务器配置SToolStripMenuItem_Click);
            // 
            // 服务器SToolStripMenuItem
            // 
            this.服务器SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启动测试BToolStripMenuItem,
            this.暂停所有测试PToolStripMenuItem,
            this.toolStripSeparator1,
            this.刷新UUIDUToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.服务器SToolStripMenuItem.Name = "服务器SToolStripMenuItem";
            this.服务器SToolStripMenuItem.Size = new System.Drawing.Size(138, 38);
            this.服务器SToolStripMenuItem.Text = "服务器(&V)";
            // 
            // 启动测试BToolStripMenuItem
            // 
            this.启动测试BToolStripMenuItem.Name = "启动测试BToolStripMenuItem";
            this.启动测试BToolStripMenuItem.Size = new System.Drawing.Size(365, 44);
            this.启动测试BToolStripMenuItem.Text = "启动测试(B)";
            this.启动测试BToolStripMenuItem.Click += new System.EventHandler(this.启动测试BToolStripMenuItem_Click);
            // 
            // 暂停所有测试PToolStripMenuItem
            // 
            this.暂停所有测试PToolStripMenuItem.Enabled = false;
            this.暂停所有测试PToolStripMenuItem.Name = "暂停所有测试PToolStripMenuItem";
            this.暂停所有测试PToolStripMenuItem.Size = new System.Drawing.Size(365, 44);
            this.暂停所有测试PToolStripMenuItem.Text = "暂停所有测试(&P)";
            this.暂停所有测试PToolStripMenuItem.Click += new System.EventHandler(this.暂停所有测试PToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(362, 6);
            // 
            // 刷新UUIDUToolStripMenuItem
            // 
            this.刷新UUIDUToolStripMenuItem.Enabled = false;
            this.刷新UUIDUToolStripMenuItem.Name = "刷新UUIDUToolStripMenuItem";
            this.刷新UUIDUToolStripMenuItem.Size = new System.Drawing.Size(365, 44);
            this.刷新UUIDUToolStripMenuItem.Text = "刷新UUID(&U)";
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(365, 44);
            this.退出EToolStripMenuItem.Text = "存储所有报告为...(&R)";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(26, 935);
            this.label26.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(96, 25);
            this.label26.TabIndex = 6;
            this.label26.Text = "总体进度";
            // 
            // pbGlobalProgress
            // 
            this.pbGlobalProgress.Location = new System.Drawing.Point(146, 920);
            this.pbGlobalProgress.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pbGlobalProgress.Name = "pbGlobalProgress";
            this.pbGlobalProgress.Size = new System.Drawing.Size(720, 52);
            this.pbGlobalProgress.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // serverMainBindingSource
            // 
            this.serverMainBindingSource.DataSource = typeof(Server.ServerMain);
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 1025);
            this.Controls.Add(this.pbGlobalProgress);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnChangeState);
            this.Controls.Add(this.label_backdoor);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1324, 1096);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1324, 1096);
            this.Name = "ServerMain";
            this.Text = "x86自动测试系统 - 服务器端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.gbCPU.ResumeLayout(false);
            this.gbCPU.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.gbMem.ResumeLayout(false);
            this.gbMem.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.gbDiskIO.ResumeLayout(false);
            this.gbDiskIO.PerformLayout();
            this.gbChkdsk.ResumeLayout(false);
            this.gbChkdsk.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPnPCount)).EndInit();
            this.gbOutlet_Audio.ResumeLayout(false);
            this.gbOutlet_Audio.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            this.gbPreset.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverMainBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelCurrentConnCount;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_uuid;
        private System.Windows.Forms.Label label_backdoor;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox gbCPU;
        private System.Windows.Forms.CheckBox cbCPU_details;
        private System.Windows.Forms.CheckBox cbCPU_allFanSpeed;
        private System.Windows.Forms.CheckBox cbCPU_AllTemp;
        private System.Windows.Forms.CheckBox cbCPU_ErrorStop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbCPU;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.GroupBox gbMem;
        private System.Windows.Forms.CheckBox cbMem_ErrorLocation;
        private System.Windows.Forms.CheckBox cbMem_ErrorStop;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cbMem;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.GroupBox gbDiskIO;
        private System.Windows.Forms.RadioButton rbDisk_max4GBBlock;
        private System.Windows.Forms.RadioButton rbDisk_min4GBBlock;
        private System.Windows.Forms.RadioButton ebDisk_fragFile;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox gbChkdsk;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox cbDisk;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.CheckBox cbNet_MAC;
        private System.Windows.Forms.CheckBox cbNet_CommCheck;
        private System.Windows.Forms.CheckBox cbNet;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.GroupBox gbOutlet_Audio;
        private System.Windows.Forms.CheckBox cbOutlet_VolMax;
        private System.Windows.Forms.CheckBox cbOutlet_VolAuto;
        private System.Windows.Forms.CheckBox cbOutlet_audioPlay;
        private System.Windows.Forms.CheckBox cbOutlet_USB;
        private System.Windows.Forms.CheckBox cbOutlet_COM;
        private System.Windows.Forms.CheckBox cbOutlet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 服务器SToolStripMenuItem;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnChangeState;
        private System.Windows.Forms.ListView clientLog;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lvClients;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ProgressBar pbGlobalProgress;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox cbNet_web;
        private System.Windows.Forms.ToolStripMenuItem 载入已有的配置文件LToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存当前配置文件为服务器配置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动测试BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂停所有测试PToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 刷新UUIDUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.Label lCurrentConnection;
        private System.Windows.Forms.BindingSource serverMainBindingSource;
        private System.Windows.Forms.PropertyGrid pgPreset;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.CheckBox cbOther_AllInfo;
        private System.Windows.Forms.GroupBox gbPreset;
        private System.Windows.Forms.ListView lvPreset_Dev;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnAddDev;
        private System.Windows.Forms.ComboBox combPreset_SelDev;
        private System.Windows.Forms.CheckBox cbOther_Preset;
        private System.Windows.Forms.CheckBox cbOther_RTCLocal;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnDelDev;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbServerInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPnPCount;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}

