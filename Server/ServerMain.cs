using Server.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        //Description generate
        //此处需要重复下述代码
        //如果有其他好方法，比如eventhandler也可以
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

        public void setClientCount(int count)
        {
            当前连接数.Invoke((MethodInvoker)delegate
            {
                当前连接数.Text = count.ToString();
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
                    configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.CPU;
                    ((ConfigFile.CPU)pgPreset.SelectedObject).id = configFile.CPUs.Count + 1;
                    configFile.CPUs.Add((ConfigFile.CPU)pgPreset.SelectedObject);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = configFile.CPUs.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.CPU).Name);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "内存设备")
                {
                    configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.Memory;
                    ((ConfigFile.Memory)pgPreset.SelectedObject).id = configFile.Mems.Count + 1;
                    configFile.Mems.Add(pgPreset.SelectedObject as ConfigFile.Memory);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = configFile.Mems.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.Memory).SerialNumber);
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
                    configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.NetworkController;
                    ((ConfigFile.NetworkController)pgPreset.SelectedObject).id = configFile.NetworkControllers.Count + 1;
                    configFile.NetworkControllers.Add(pgPreset.SelectedObject as ConfigFile.NetworkController);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = configFile.NetworkControllers.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.NetworkController).Description);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "显示适配器设备")
                {
                    configFile.override_flag |= ConfigFile.OVERRIDE_FLAG.GPU;
                    ((ConfigFile.GPU)pgPreset.SelectedObject).id = configFile.GPUs.Count + 1;
                    configFile.GPUs.Add(pgPreset.SelectedObject as ConfigFile.GPU);
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = configFile.GPUs.Count.ToString();
                    listViewItem.SubItems.Add(combPreset_SelDev.SelectedItem.ToString());
                    listViewItem.SubItems.Add((pgPreset.SelectedObject as ConfigFile.GPU).Name);
                    lvPreset_Dev.Items.Add(listViewItem);
                }
            }
            
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

        private void lvPreset_Dev_SelectedIndexChanged(object sender, EventArgs e)
        {
            combPreset_SelDev.SelectedItem = null;
            if (lvPreset_Dev.SelectedItems.Count  == 1)
            {
                btnDelDev.Enabled = true;
                if(lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "中央处理器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = configFile.CPUs[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                    lvPreset_Dev.SelectedItems[0].SubItems[2].Text = configFile.CPUs[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1].Name;
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "内存设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = configFile.Mems[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "驱动器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = configFile.Disks[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "网络适配器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = configFile.NetworkControllers[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                }
                else if (lvPreset_Dev.SelectedItems[0].SubItems[1].Text == "显示适配器设备")
                {
                    pgPreset.SelectedObject = null;
                    pgPreset.SelectedObject = configFile.GPUs[int.Parse(lvPreset_Dev.SelectedItems[0].Text) - 1];
                }
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {

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
                    ConfigFile.CPU cpu = new ConfigFile.CPU();
                    pgPreset.SelectedObject = cpu;
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "内存设备")
                {
                    ConfigFile.Memory memory = new ConfigFile.Memory();
                    pgPreset.SelectedObject = memory;
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "驱动器设备")
                {
                    ConfigFile.Disk disk = new ConfigFile.Disk();
                    pgPreset.SelectedObject = disk;
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "网络适配器设备")
                {
                    ConfigFile.NetworkController network = new ConfigFile.NetworkController();
                    pgPreset.SelectedObject = network;
                }
                else if (combPreset_SelDev.SelectedItem.ToString() == "显示适配器设备")
                {
                    ConfigFile.GPU gpu = new ConfigFile.GPU();
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
                        foreach (ConfigFile.CPU dev in configFile.CPUs)
                        {
                            if(dev.id ==int.Parse( lvPreset_Dev.SelectedItems [0].SubItems[0].ToString()))
                            {
                                configFile.CPUs.Remove(dev);
                            }
                        }
                    }
                    else if (lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() == "内存设备")
                    {
                        foreach (ConfigFile.Memory dev in configFile.Mems)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                configFile.Mems.Remove(dev);
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
                        foreach (ConfigFile.NetworkController dev in configFile.NetworkControllers)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                configFile.NetworkControllers.Remove(dev);
                            }
                        }
                    }
                    else if (lvPreset_Dev.SelectedItems[0].SubItems[1].ToString() == "显示适配器设备")
                    {
                        foreach (ConfigFile.GPU dev in configFile.GPUs)
                        {
                            if (dev.id == int.Parse(lvPreset_Dev.SelectedItems[0].SubItems[0].ToString()))
                            {
                                configFile.GPUs.Remove(dev);
                            }
                        }
                    }
                }
            }
        }
    }
}
