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
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //在此处添加退出之前的保存、上传操作。
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_uuid.Text = Guid.NewGuid().ToString();
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
    }
}
