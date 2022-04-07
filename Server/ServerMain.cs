using Server.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Server.WebSocket;

namespace Server
{
    public partial class ServerMain : Form
    {
        public ConfigFile configFile = new ConfigFile();
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
            configFile.senderUUID = label_uuid.Text;
            configFile.CreationTime = DateTime.Now;
            configFile.global_cpu = cbCPU.Checked;
            configFile.global_mem = cbMem.Checked;
            configFile.global_disk = cbDisk.Checked;
            configFile.global_net = cbNet.Checked;

            configFile.cpu_error_stop = cbCPU_ErrorStop.Checked;
            configFile.cpu_all_temp = cbCPU_AllTemp.Checked;
            configFile.cpu_all_fan_speed = cbCPU_allFanSpeed.Checked;
            configFile.cpu_detailed_info = cbCPU_details.Checked;

            configFile.mem_error_stop = cbMem_ErrorStop.Checked;
            configFile.mem_error_address = cbMem_ErrorLocation.Checked;

            configFile.net_test = cbNet_CommCheck.Checked;
            configFile.net_mac = cbNet_MAC.Checked;
            configFile.net_web_test = cbNet_web.Checked;

            configFile.outlet_com = cbOutlet_COM.Checked;
            configFile.outlet_usb = cbOutlet_USB.Checked;
            configFile.audio_playback = cbOutlet_audioPlay.Checked;
            configFile.audio_adjust_vol = cbOutlet_VolAuto.Checked;
            configFile.audio_max_vol = cbOutlet_VolMax.Checked;
            //add default device.
            //请将此部分写为异步操作
            //阻塞执行可能需要1~3s的卡顿。

            if((configFile.override_flag & ConfigFile.OVERRIDE_FLAG.Processor) == ConfigFile.OVERRIDE_FLAG.None)
            {
                ManagementClass managementClass = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moCollection = managementClass.GetInstances();
                foreach (ManagementObject mo in moCollection)
                {
                    ConfigFile.Processor dev = new ConfigFile.Processor();
                    dev.Family = mo["Family"].ToString();
                    dev.Name = mo["Name"].ToString();
                    dev.Manufacturer = mo["Manufacturer"].ToString();
                    dev.id = configFile.Processors.Count + 1;
                    dev.MaxClockSpeed = mo["MaxClockSpeed"].ToString();
                    dev.ProcessorId = mo["ProcessorId"].ToString();
                    configFile.Processors.Add(dev);
                }
                managementClass.Dispose();
            }            
            if((configFile.override_flag & ConfigFile.OVERRIDE_FLAG.PhysicalMemory) == ConfigFile.OVERRIDE_FLAG.None)
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
                    dev.id = configFile.PhysicalMemorys.Count + 1;
                    configFile.PhysicalMemorys.Add(dev);
                }
                managementClass.Dispose();
            }            
            if((configFile.override_flag & ConfigFile.OVERRIDE_FLAG.Disk) == ConfigFile.OVERRIDE_FLAG.None)
            {
                ManagementClass managementClass = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moCollection = managementClass.GetInstances();
                foreach (ManagementObject mo in moCollection)
                {
                    ConfigFile.Disk dev = new ConfigFile.Disk();
                    dev.id = configFile.Disks.Count + 1;
                    dev.Manufacturer = mo["Manufacturer"].ToString();
                    dev.MediaType = mo["MediaType"].ToString();
                    dev.Model = mo["Model"].ToString();
                    dev.SerialNumber = mo["SerialNumber"] == null ? "null"  : mo["SerialNumber"].ToString();
                    dev.Size = mo["Size"].ToString();
                    configFile.Disks.Add(dev);
                }
                managementClass.Dispose();
            }            
            if((configFile.override_flag & ConfigFile.OVERRIDE_FLAG.NetworkAdapter) == ConfigFile.OVERRIDE_FLAG.NetworkAdapter)
            {
                ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapter");
                ManagementObjectCollection moCollection = managementClass.GetInstances();
                foreach (ManagementObject mo in moCollection)
                {
                    ConfigFile.NetworkAdapter dev = new ConfigFile.NetworkAdapter();
                    dev.id = configFile.NetworkAdapters.Count + 1;
                    dev.Description = mo["Description"].ToString();
                    dev.GUID = mo["GUID"].ToString();
                    dev.Speed = mo["Speed"].ToString();
                    configFile.NetworkAdapters.Add(dev);
                }
                managementClass.Dispose();
            }            
            if((configFile.override_flag & ConfigFile.OVERRIDE_FLAG.VideoController) == ConfigFile.OVERRIDE_FLAG.None)
            {
                ManagementClass managementClass = new ManagementClass("Win32_VideoController");
                ManagementObjectCollection moCollection = managementClass.GetInstances();
                foreach (ManagementObject mo in moCollection)
                {
                    ConfigFile.VideoController dev = new ConfigFile.VideoController();
                    dev.id = configFile.VideoControllers.Count + 1;
                    dev.AdapterCompatibility = mo["AdapterCompatibility"].ToString();
                    dev.AdapterRAM = mo["AdapterRAM"].ToString();
                    dev.Name = mo["Name"].ToString();
                    dev.VideoProcessor = mo["VideoProcessor"].ToString();
                    configFile.VideoControllers.Add(dev);
                }
                managementClass.Dispose();
            }
            //////////////////////////////////////////////////////////////////////////
            ///保存到配置文件（jht文件）
            ///这里做了base64编码，为了防止一些文字在传递过程中出现编码错误
            string jsonres = Newtonsoft.Json.JsonConvert.SerializeObject(configFile);
            jsonres = Convert.ToBase64String(Encoding.Default.GetBytes(jsonres));
            System.IO.File.WriteAllText("configfile.jht", jsonres);
        }
        public void setClientState(string client,string current,int finishedCount)
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

        private void btnAddDev_Click(object sender, EventArgs e)
        {
            if(combPreset_SelDev.SelectedIndex != -1)
            {
                if(combPreset_SelDev.SelectedItem.ToString() == "中央处理器设备")
                {
                    configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.Processor;
                    ((ConfigFile.Processor)pgPreset.SelectedObject).id = configFile.Processors.Count + 1;
                    configFile.Processors.Add((ConfigFile.Processor)pgPreset.SelectedObject);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = configFile.Processors.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.Processor).Name);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "内存设备")
                {
                    configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.PhysicalMemory;
                    ((ConfigFile.PhysicalMemory)pgPreset.SelectedObject).id = configFile.PhysicalMemorys.Count + 1;
                    configFile.PhysicalMemorys.Add(pgPreset.SelectedObject as ConfigFile.PhysicalMemory);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = configFile.PhysicalMemorys.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.PhysicalMemory).SerialNumber);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "驱动器设备")
                {
                    configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.Disk;
                    ((ConfigFile.Disk)pgPreset.SelectedObject).id = configFile.Disks.Count + 1;
                    configFile.Disks.Add(pgPreset.SelectedObject as ConfigFile.Disk);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = configFile.Disks.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.Disk).Manufacturer);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "网络适配器设备")
                {
                    configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.NetworkAdapter;
                    ((ConfigFile.NetworkAdapter)pgPreset.SelectedObject).id = configFile.NetworkAdapters.Count + 1;
                    configFile.NetworkAdapters.Add(pgPreset.SelectedObject as ConfigFile.NetworkAdapter);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = configFile.NetworkAdapters.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.NetworkAdapter).Description);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "显示适配器设备")
                {
                    configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.VideoController;
                    ((ConfigFile.VideoController)pgPreset.SelectedObject).id = configFile.VideoControllers.Count + 1;
                    configFile.VideoControllers.Add(pgPreset.SelectedObject as ConfigFile.VideoController);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = configFile.VideoControllers.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.VideoController).Name);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
            }
            
        }

        private void lvPreset_Dev_SelectedIndexChanged(object sender, EventArgs e)
        {
            combPreset_SelDev.SelectedItem = null;
            if (lvPreset_Dev.SelectedItems.Count  == 1)
            {
                btnDelDev.Enabled = true;
                if(lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "中央处理器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = configFile.Processors[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                    lvPreset_Dev.SelectedItems[0].SubItems[2].Text = configFile.Processors[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1].Name;
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "内存设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = configFile.PhysicalMemorys[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                    lvPreset_Dev.SelectedItems[0].SubItems[2].Text = configFile.PhysicalMemorys[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1].Manufacturer;
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "驱动器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = configFile.Disks[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                    lvPreset_Dev.SelectedItems[0].SubItems[2].Text = configFile.Disks[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1].Manufacturer;
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "网络适配器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = configFile.NetworkAdapters[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                    lvPreset_Dev.SelectedItems[0].SubItems[2].Text = configFile.NetworkAdapters[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1].Description;
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "显示适配器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = configFile.VideoControllers[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                    lvPreset_Dev.SelectedItems[0].SubItems[2].Text = configFile.VideoControllers[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1].Name;
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
            if(combPreset_SelDev.SelectedItem != null)
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
            DialogResult res= MessageBox.Show(this,"删除设备\n" + lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() + "\n描述："
                + lvPreset_Dev.SelectedItems[0].SubItems[2].ToString() + " ?","删除指定设备"
                ,MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                if(lvPreset_Dev.SelectedItems.Count == 1)
                {
                    if (lvPreset_Dev.SelectedItems [0].SubItems[1].ToString() == "中央处理器设备")
                    {
                        foreach (ConfigFile.Processor dev in configFile.Processors)
                        {
                            if(dev.id ==int.Parse( lvPreset_Dev.SelectedItems [0].SubItems[0].ToString()))
                            {
                                configFile.Processors.Remove(dev);
                            }
                        }
                    }
                    else if (lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() == "内存设备")
                    {
                        foreach (ConfigFile.PhysicalMemory dev in configFile.PhysicalMemorys)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                configFile.PhysicalMemorys.Remove(dev);
                            }
                        }
                    }
                    else if (lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() == "驱动器设备")
                    {
                        foreach (ConfigFile.Disk dev in configFile.Disks)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                configFile.Disks.Remove(dev);
                            }
                        }
                    }
                    else if (lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() == "网络适配器设备")
                    {
                        foreach (ConfigFile.NetworkAdapter dev in configFile.NetworkAdapters)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                configFile.NetworkAdapters.Remove(dev);
                            }
                        }
                    }
                    else if (lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() == "显示适配器设备")
                    {
                        foreach (ConfigFile.VideoController dev in configFile.VideoControllers)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                configFile.VideoControllers.Remove(dev);
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
                        configFile = Newtonsoft.Json.JsonConvert.DeserializeObject(
                            Encoding.Default.GetString(
                                Convert.FromBase64String(
                                    System.IO.File.ReadAllText(path)
                                    ))
                            , typeof(ConfigFile)) as ConfigFile;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("解释文件时出现异常：" + ex.Message);
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
                string jsonres = Newtonsoft.Json.JsonConvert.SerializeObject(configFile);
                jsonres = Convert.ToBase64String(Encoding.Default.GetBytes(jsonres));
                System.IO.File.WriteAllText(saveFileDialog1.FileName, jsonres);
            }

        }

        private void label_backdoor_Click(object sender, EventArgs e)
        {
            if((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                MessageBox.Show("试图执行特殊代码");
                AutoTestMessage.Message wmiMessage = new AutoTestMessage.Message();
                ClientTask task = new ClientTask(wmiMessage, "null");
                task.HandleMessage(wmiMessage, null);
            }
        }
    }
}
