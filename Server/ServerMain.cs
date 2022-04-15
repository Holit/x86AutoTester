using System;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using static Server.WebSocket;
using static System.Windows.Forms.ListViewItem;

namespace Server
{
    public partial class ServerMain : Form
    {
        public ServerMain()
        {
            InitializeComponent();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //在此处添加退出之前的保存、上传操作。
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_uuid.Text = Program.Uuid;
            tbServerInfo.Text += "\r\n[" + DateTime.Now.ToString("HH:mm:ss.ffff") + "] 服务器端启动...";
            tbServerInfo.Text += "\r\n[" + DateTime.Now.ToString("HH:mm:ss.ffff") + "] 执行自动检查....";
            tbServerInfo.Text += "\r\n[" + DateTime.Now.ToString("HH:mm:ss.ffff") + "] 无插件...";
            //获取本机即插即用设备的数量
            nudPnPCount.Value = 0;
            try
            {
                ManagementClass managementClass = new ManagementClass("Win32_PnPEntity");
                ManagementObjectCollection moCollection = managementClass.GetInstances();
                Program.configFile.outlet_pnp_count = moCollection.Count;
                nudPnPCount.Value = moCollection.Count;
                managementClass.Dispose();
            }
            catch (Exception ex)
            {
                Program.ReportError(ex, false, 0x8001EF01);
            }
        }

        private void cbCPU_CheckedChanged(object sender, EventArgs e)
        {
            gbCPU.Enabled = cbCPU.Checked;
        }

        private void cbMem_CheckedChanged(object sender, EventArgs e)
        {
            gbMem.Enabled = cbMem.Checked;
        }

        private void cbDisk_CheckedChanged(object sender, EventArgs e)
        {
            gbChkdsk.Enabled = cbDisk.Checked;
            gbDiskIO.Enabled = cbDisk.Checked;

        }

        private void cbOutlet_CheckedChanged(object sender, EventArgs e)
        {
            cbOutlet_audioPlay.Enabled = cbOutlet.Checked;
            cbOutlet_COM.Enabled = cbOutlet.Checked;
            cbOutlet_USB.Enabled = cbOutlet.Checked;
            gbOutlet_Audio.Enabled = cbOutlet.Checked;
        }
        #region 设置描述文本
        private void setDefaultDescription()
        {
            tbDescription.Text = Properties.Resources.default_Description;
        }
        private void cbOther_Preset_CheckedChanged(object sender, EventArgs e)
        {
            gbPreset.Enabled = cbOther_Preset.Checked;
        }

        private void cbOutlet_VolMax_CheckedChanged(object sender, EventArgs e)
        {
            cbOutlet_VolAuto.Enabled = !cbOutlet_VolMax.Checked;
        }
        private void cbCPU_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.CPU_Enable_Description;
        }

        private void cbCPU_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbCPU_ErrorStop_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Error_Stop_Description;
        }

        private void cbCPU_ErrorStop_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbCPU_AllTemp_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.CPU_AllTemp_Description;
        }

        private void cbCPU_AllTemp_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbCPU_details_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.CPU_details_Description;
        }

        private void cbCPU_details_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbCPU_allFanSpeed_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.CPU_allFanSpeed_Description;
        }

        private void cbCPU_allFanSpeed_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbMem_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Mem_Enable_Description;
        }

        private void cbMem_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbMem_ErrorStop_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Error_Stop_Description;
        }

        private void cbMem_ErrorStop_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbMem_ErrorLocation_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Mem_ErrorLocation_Description;
        }

        private void cbMem_ErrorLocation_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbDisk_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Disk_chkdsk_Description;
        }

        private void cbDisk_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbNet_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Net_Enable_Description;
        }

        private void cbNet_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cnNet_CommCheck_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Net_CommCheck_Description;
        }

        private void cnNet_CommCheck_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbNet_web_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Net_web_Description;
        }

        private void cbNet_web_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbNet_MAC_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Net_MAC_Description;
        }

        private void cbNet_MAC_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbOutlet_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Outlet_Description;
        }

        private void cbOutlet_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbOutlet_COM_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Outlet_COM_Description;
        }

        private void cbOutlet_COM_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbOutlet_USB_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Outlet_USB_Description;
        }

        private void cbOutlet_USB_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbOutlet_audioPlay_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Outlet_audioPlay_Description;
        }

        private void cbOutlet_audioPlay_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbOutlet_VolAuto_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Outlet_VolAuto_Description;
        }

        private void cbOutlet_VolAuto_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbOutlet_VolMax_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Outlet_VolMax_Description;
        }

        private void cbOutlet_VolMax_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbOther_RTCLocal_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Other_RTCLocal_Description;
        }

        private void cbOther_RTCLocal_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbOther_Preset_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Other_Preset_Description;
        }

        private void cbOther_Preset_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbOther_AllInfo_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Other_AllInfo_Description;
        }

        private void cbOther_AllInfo_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbOther_RTCLocal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbOther_Preset_MouseEnter_1(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Other_Preset_Description;
        }

        private void cbOther_Preset_MouseLeave_1(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void cbOther_AllInfo_MouseEnter_1(object sender, EventArgs e)
        {

            tbDescription.Text = Properties.Resources.Other_AllInfo_Description;
        }

        private void cbOther_AllInfo_MouseLeave_1(object sender, EventArgs e)
        {
            setDefaultDescription();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            tbDescription.Text = Properties.Resources.Outlet_PnPDevices_Count;

        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            setDefaultDescription();
        }
        #endregion
        public void setClientCount(int count)
        {
            lCurrentConnection.Invoke((MethodInvoker)delegate
            {
                lCurrentConnection.Text = count.ToString();
            });
        }

        private void ConcludeConfig()
        {
            try
            {

                Program.configFile.senderUUID = label_uuid.Text;
                Program.configFile.CreationTime = DateTime.Now;
                Program.configFile.global_cpu = cbCPU.Checked;
                Program.configFile.global_mem = cbMem.Checked;
                Program.configFile.global_disk = cbDisk.Checked;
                Program.configFile.global_net = cbNet.Checked;

                Program.configFile.cpu_error_stop = cbCPU_ErrorStop.Checked;
                Program.configFile.cpu_all_temp = cbCPU_AllTemp.Checked;
                Program.configFile.cpu_all_fan_speed = cbCPU_allFanSpeed.Checked;
                Program.configFile.cpu_detailed_info = cbCPU_details.Checked;

                Program.configFile.mem_error_stop = cbMem_ErrorStop.Checked;
                Program.configFile.mem_error_address = cbMem_ErrorLocation.Checked;

                Program.configFile.net_test = cbNet_CommCheck.Checked;
                Program.configFile.net_mac = cbNet_MAC.Checked;
                Program.configFile.net_web_test = cbNet_web.Checked;

                Program.configFile.outlet_com = cbOutlet_COM.Checked;
                Program.configFile.outlet_usb = cbOutlet_USB.Checked;
                Program.configFile.outlet_pnp_count = Convert.ToInt32(nudPnPCount.Value);
                Program.configFile.audio_playback = cbOutlet_audioPlay.Checked;
                Program.configFile.audio_adjust_vol = cbOutlet_VolAuto.Checked;
                Program.configFile.audio_max_vol = cbOutlet_VolMax.Checked;
                //add default device.
                //请将此部分写为异步操作
                //阻塞执行可能需要1~3s的卡顿。

                if ((Program.configFile.override_flag & ConfigFile.OVERRIDE_FLAG.Processor) == ConfigFile.OVERRIDE_FLAG.None)
                {
                    ManagementClass managementClass = new ManagementClass("Win32_Processor");
                    ManagementObjectCollection moCollection = managementClass.GetInstances();
                    foreach (ManagementObject mo in moCollection)
                    {
                        ConfigFile.Processor dev = new ConfigFile.Processor();
                        dev.Family = mo["Family"].ToString();
                        dev.Name = mo["Name"].ToString();
                        dev.Manufacturer = mo["Manufacturer"].ToString();
                        dev.id = Program.configFile.Processors.Count + 1;
                        dev.MaxClockSpeed = mo["MaxClockSpeed"].ToString();
                        dev.ProcessorId = mo["ProcessorId"].ToString();
                        Program.configFile.Processors.Add(dev);
                    }
                    managementClass.Dispose();
                }
                if ((Program.configFile.override_flag & ConfigFile.OVERRIDE_FLAG.PhysicalMemory) == ConfigFile.OVERRIDE_FLAG.None)
                {
                    ManagementClass managementClass = new ManagementClass("Win32_PhysicalMemory");
                    ManagementObjectCollection moCollection = managementClass.GetInstances();
                    foreach (ManagementObject mo in moCollection)
                    {
                        ConfigFile.PhysicalMemory dev = new ConfigFile.PhysicalMemory();
                        dev.PartNumber = mo["PartNumber"].ToString();
                        dev.SerialNumber = mo["SerialNumber"].ToString();
                        dev.Manufacturer = mo["Manufacturer"].ToString();
                        dev.Capacity = mo["Capacity"].ToString();
                        dev.Speed = mo["Speed"].ToString();
                        dev.id = Program.configFile.PhysicalMemorys.Count + 1;
                        Program.configFile.PhysicalMemorys.Add(dev);
                    }
                    managementClass.Dispose();
                }
                if ((Program.configFile.override_flag & ConfigFile.OVERRIDE_FLAG.Disk) == ConfigFile.OVERRIDE_FLAG.None)
                {
                    ManagementClass managementClass = new ManagementClass("Win32_DiskDrive");
                    ManagementObjectCollection moCollection = managementClass.GetInstances();
                    foreach (ManagementObject mo in moCollection)
                    {
                        ConfigFile.Disk dev = new ConfigFile.Disk();
                        dev.id = Program.configFile.Disks.Count + 1;
                        dev.Manufacturer = mo["Manufacturer"].ToString();
                        dev.MediaType = mo["MediaType"].ToString();
                        dev.Model = mo["Model"].ToString();
                        dev.SerialNumber = mo["SerialNumber"] == null ? "null" : mo["SerialNumber"].ToString();
                        dev.Size = mo["Size"].ToString();
                        Program.configFile.Disks.Add(dev);
                    }
                    managementClass.Dispose();
                }
                if ((Program.configFile.override_flag & ConfigFile.OVERRIDE_FLAG.NetworkAdapter) ==
                    ConfigFile.OVERRIDE_FLAG.None)
                {
                    ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapter");
                    ManagementObjectCollection moCollection = managementClass.GetInstances();
                    foreach (ManagementObject mo in moCollection)
                    {
                        ConfigFile.NetworkAdapter dev = new ConfigFile.NetworkAdapter();
                        dev.id = Program.configFile.NetworkAdapters.Count + 1;
                        dev.Description = mo["Description"].ToString();
                        //GUID可能会变，因此按照测试结果更改
                        dev.GUID = mo["GUID"] == null ? "null" : mo["GUID"].ToString();
                        dev.Speed = mo["Speed"] == null ? "null" : mo["Speed"].ToString();
                        Program.configFile.NetworkAdapters.Add(dev);
                    }
                    managementClass.Dispose();
                }
                if ((Program.configFile.override_flag & ConfigFile.OVERRIDE_FLAG.VideoController) == ConfigFile.OVERRIDE_FLAG.None)
                {
                    ManagementClass managementClass = new ManagementClass("Win32_VideoController");
                    ManagementObjectCollection moCollection = managementClass.GetInstances();
                    foreach (ManagementObject mo in moCollection)
                    {
                        ConfigFile.VideoController dev = new ConfigFile.VideoController();
                        dev.id = Program.configFile.VideoControllers.Count + 1;
                        dev.AdapterCompatibility = mo["AdapterCompatibility"].ToString();
                        dev.AdapterRAM = mo["AdapterRAM"].ToString();
                        dev.Name = mo["Name"].ToString();
                        dev.VideoProcessor = mo["VideoProcessor"].ToString();
                        Program.configFile.VideoControllers.Add(dev);
                    }
                    managementClass.Dispose();
                }

                //////////////////////////////////////////////////////////////////////////
                ///保存到配置文件（jht文件）
                ///这里做了base64编码，为了防止一些文字在传递过程中出现编码错误
                string jsonres = Newtonsoft.Json.JsonConvert.SerializeObject(Program.configFile);
                jsonres = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonres));
                System.IO.File.WriteAllText("configfile.jht", jsonres);
            }
            catch (Exception ex)
            {
                Program.ReportError(ex, false,0x8002AE00);
            }
        }
        public void setClientState(string client, string current, int finishedCount)
        {
            lvClients.Invoke((MethodInvoker)delegate
            {
                lvClients.BeginUpdate();
                ListViewItem item = lvClients.Items[client];
                if (item == null)
                {
                    lvClients.Items.Add(item = new ListViewItem(client));
                    item.Name = client;
                }
                if (item.SubItems.Count < 1) item.SubItems.Add(new ListViewItem.ListViewSubItem());
                item.SubItems[0].Text = client;
                if (item.SubItems.Count < 2) item.SubItems.Add(new ListViewItem.ListViewSubItem());
                item.SubItems[1].Text = current;
                if (item.SubItems.Count < 3) item.SubItems.Add(new ListViewItem.ListViewSubItem());
                item.SubItems[2].Text = finishedCount + "/" + ClientTask.Tasks.Count();
                lvClients.EndUpdate();
            });
        }
        public void setClientState(Client client)
        {
            setClientState(client.ClientUrl, client.currentTask.Describe, ClientTask.Tasks.Count - client.GetRemainTaskCount() - 1);
        }
        public void setClientLog(string client, string log)
        {
            clientLog.Invoke((MethodInvoker)delegate
            {
                ListViewItem item = new ListViewItem();
                item.Text = DateTime.Now.ToString("HH:mm:ss");
                item.SubItems.Add(new ListViewSubItem(item, client));
                item.SubItems.Add(new ListViewSubItem(item, log));
                clientLog.Items.Add(item);
            });
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + client + " " + log);
        }
        private void btnAddDev_Click(object sender, EventArgs e)
        {
            if (combPreset_SelDev.SelectedIndex != -1)
            {
                if (combPreset_SelDev.SelectedItem.ToString() == "中央处理器设备")
                {
                    Program.configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.Processor;
                    ((ConfigFile.Processor)pgPreset.SelectedObject).id = Program.configFile.Processors.Count + 1;
                    Program.configFile.Processors.Add((ConfigFile.Processor)pgPreset.SelectedObject);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = Program.configFile.Processors.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.Processor).Name);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "内存设备")
                {
                    Program.configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.PhysicalMemory;
                    ((ConfigFile.PhysicalMemory)pgPreset.SelectedObject).id = Program.configFile.PhysicalMemorys.Count + 1;
                    Program.configFile.PhysicalMemorys.Add(pgPreset.SelectedObject as ConfigFile.PhysicalMemory);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = Program.configFile.PhysicalMemorys.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.PhysicalMemory).SerialNumber);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "驱动器设备")
                {
                    Program.configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.Disk;
                    ((ConfigFile.Disk)pgPreset.SelectedObject).id = Program.configFile.Disks.Count + 1;
                    Program.configFile.Disks.Add(pgPreset.SelectedObject as ConfigFile.Disk);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = Program.configFile.Disks.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.Disk).Manufacturer);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "网络适配器设备")
                {
                    Program.configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.NetworkAdapter;
                    ((ConfigFile.NetworkAdapter)pgPreset.SelectedObject).id = Program.configFile.NetworkAdapters.Count + 1;
                    Program.configFile.NetworkAdapters.Add(pgPreset.SelectedObject as ConfigFile.NetworkAdapter);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = Program.configFile.NetworkAdapters.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.NetworkAdapter).Description);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "显示适配器设备")
                {
                    Program.configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.VideoController;
                    ((ConfigFile.VideoController)pgPreset.SelectedObject).id = Program.configFile.VideoControllers.Count + 1;
                    Program.configFile.VideoControllers.Add(pgPreset.SelectedObject as ConfigFile.VideoController);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = Program.configFile.VideoControllers.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.VideoController).Name);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
            }

        }

        private void lvPreset_Dev_SelectedIndexChanged(object sender, EventArgs e)
        {
            combPreset_SelDev.SelectedItem = null;
            if (lvPreset_Dev.SelectedItems.Count == 1)
            {
                btnDelDev.Enabled = true;
                if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "中央处理器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = Program.configFile.Processors[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                    lvPreset_Dev.SelectedItems[0].SubItems[2].Text = Program.configFile.Processors[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1].Name;
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "内存设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = Program.configFile.PhysicalMemorys[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                    lvPreset_Dev.SelectedItems[0].SubItems[2].Text = Program.configFile.PhysicalMemorys[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1].Manufacturer;
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "驱动器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = Program.configFile.Disks[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                    lvPreset_Dev.SelectedItems[0].SubItems[2].Text = Program.configFile.Disks[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1].Manufacturer;
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "网络适配器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = Program.configFile.NetworkAdapters[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                    lvPreset_Dev.SelectedItems[0].SubItems[2].Text = Program.configFile.NetworkAdapters[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1].Description;
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "显示适配器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = Program.configFile.VideoControllers[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                    lvPreset_Dev.SelectedItems[0].SubItems[2].Text = Program.configFile.VideoControllers[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1].Name;
                }
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            ConcludeConfig();
            btnSend.Enabled = true;
        }

        private void cbOther_Preset_CheckedChanged_1(object sender, EventArgs e)
        {

            if (cbOther_Preset.Checked)
            {
                gbPreset.Enabled = true;
                gbPreset.Visible = true;
                cbOther_AllInfo.Location = new System.Drawing.Point(10, 248);
                tbDescription.Location = new System.Drawing.Point(318, 310);
                pgPreset.Visible = true;
            }
            else
            {
                gbPreset.Enabled = false;
                gbPreset.Visible = false;
                cbOther_AllInfo.Location = new System.Drawing.Point(10, 56);
                tbDescription.Location = new System.Drawing.Point(318, 48);
                pgPreset.Visible = false;
            }
        }

        private void combPreset_SelDev_SelectedValueChanged(object sender, EventArgs e)
        {
            if (combPreset_SelDev.SelectedItem != null)
            {
                if (combPreset_SelDev.SelectedItem.ToString() == "中央处理器设备")
                {
                    ConfigFile.Processor cpu = new ConfigFile.Processor();
                    pgPreset.SelectedObject = cpu;
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "内存设备")
                {
                    ConfigFile.PhysicalMemory memory = new ConfigFile.PhysicalMemory();
                    pgPreset.SelectedObject = memory;
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "驱动器设备")
                {
                    ConfigFile.Disk disk = new ConfigFile.Disk();
                    pgPreset.SelectedObject = disk;
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "网络适配器设备")
                {
                    ConfigFile.NetworkAdapter network = new ConfigFile.NetworkAdapter();
                    pgPreset.SelectedObject = network;
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "显示适配器设备")
                {
                    ConfigFile.VideoController gpu = new ConfigFile.VideoController();
                    pgPreset.SelectedObject = gpu;
                }
            }
        }

        private void btnDelDev_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(this, "删除设备\n" + lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() + "\n描述："
                + lvPreset_Dev.SelectedItems[0].SubItems[2].ToString() + " ?", "删除指定设备"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                if (lvPreset_Dev.SelectedItems.Count == 1)
                {
                    if (lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() == "中央处理器设备")
                    {
                        foreach (ConfigFile.Processor dev in Program.configFile.Processors)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                Program.configFile.Processors.Remove(dev);
                            }
                        }
                    }
                    else if (lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() == "内存设备")
                    {
                        foreach (ConfigFile.PhysicalMemory dev in Program.configFile.PhysicalMemorys)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                Program.configFile.PhysicalMemorys.Remove(dev);
                            }
                        }
                    }
                    else if (lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() == "驱动器设备")
                    {
                        foreach (ConfigFile.Disk dev in Program.configFile.Disks)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                Program.configFile.Disks.Remove(dev);
                            }
                        }
                    }
                    else if (lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() == "网络适配器设备")
                    {
                        foreach (ConfigFile.NetworkAdapter dev in Program.configFile.NetworkAdapters)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                Program.configFile.NetworkAdapters.Remove(dev);
                            }
                        }
                    }
                    else if (lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() == "显示适配器设备")
                    {
                        foreach (ConfigFile.VideoController dev in Program.configFile.VideoControllers)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                Program.configFile.VideoControllers.Remove(dev);
                            }
                        }
                    }
                }
            }
        }

        private void 载入已有的配置文件LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JSON配置文件|*.jht|所有文件|*.*";
            openFileDialog1.Title = "选择配置文件";
            openFileDialog1.FileName = Environment.CurrentDirectory;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                //MessageBox.Show("尝试解释文件" + path);
                if (System.IO.File.Exists(path))
                {
                    try
                    {
                        Program.configFile = Newtonsoft.Json.JsonConvert.DeserializeObject(
                            Encoding.UTF8.GetString(
                                Convert.FromBase64String(
                                    System.IO.File.ReadAllText(path)
                                    ))
                            , typeof(ConfigFile)) as ConfigFile;
                    }
                    catch (Exception ex)
                    {
                        Program.ReportError(ex, false, 0x8003001E, Title: "解释文件失败");
                        path = null;
                    }
                }
            }
        }

        private void 保存当前配置文件为服务器配置SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JSON配置文件|*.jht|任意文件|*.*";
            saveFileDialog1.Title = "保存配置文件";
            saveFileDialog1.FileName = Environment.CurrentDirectory;
            saveFileDialog1.ShowDialog(this);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string jsonres = Newtonsoft.Json.JsonConvert.SerializeObject(Program.configFile);
                    jsonres = Convert.ToBase64String(Encoding.Default.GetBytes(jsonres));
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, jsonres);
                }
                catch(Exception ex)
                {
                    Program.ReportError(ex, false, 0x8003001F, Title: "存取配置文件时失败");
                }
            }

        }

        private void label_backdoor_Click(object sender, EventArgs e)
        {
            if(false)
            {
                //此处由后门测试代码段自定义
                try
                {
                    throw new System.NotSupportedException("此代码不应该被执行");
                }
                catch(Exception ex)
                {
                    Program.ReportError(ex, true, 0xFFFFFFFF, Title: "检测到执行错误");
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            if (Program.CurrentState == Program.TestingStates.Stopped || Program.CurrentState == Program.TestingStates.Paused)
            {
                Program.CurrentState = Program.TestingStates.Running;
                btnChangeState.Text = "⏸";
                WebSocket.Client.GlobalStartTask();
            }
            else if (Program.CurrentState == Program.TestingStates.Running)
            {
                Program.CurrentState = Program.TestingStates.Paused;
                btnChangeState.Text = "▶";
                WebSocket.Client.GlobalPauseTask();
            }
        }
        public void UpdateGlobalProgress()
        {
            pbGlobalProgress.Invoke((MethodInvoker)delegate {
                if (dic_Sockets.Count() == 0)
                {
                    pbGlobalProgress.Value = 0;
                }
                else
                {
                    int remainTask = dic_Sockets.Sum((kv) => {
                        int count = ClientTask.Tasks.Count - kv.Value.GetRemainTaskCount() - 1;
                        if (count < 0) count = 0;
                        return count;
                        });
                    int taskTotal = dic_Sockets.Count() * ClientTask.Tasks.Count;
                    pbGlobalProgress.Value = remainTask *100 / taskTotal;
                }
            });
        }
    }
}
