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

namespace Server
{
    public partial class ServerMain : Form
    {
        public ServerMain()
        {
            InitializeComponent();
            setClientState("1", "2", 3);
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

        public void setClientState(string client,string current,int finishedCount)
        {
            lvClients.BeginUpdate();
            ListViewItem item=lvClients.Items[client];
            if (item == null) lvClients.Items.Add(item = new ListViewItem());
            if (item.SubItems.Count <1) item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = current;
            if (item.SubItems.Count <2) item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[1].Text = current;
            lvClients.EndUpdate();
        }
    }
}
