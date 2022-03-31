﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Client
{
    public partial class ClientMain : Form
    {
        public ClientMain()
        {
            InitializeComponent();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //在此处添加退出之前的保存、上传操作。
            Close();
        }
        private object QueryWMIClass(string path, string propetyName, string connectionText = "")
        {
            object WMIClass = null;
            try
            {
                ManagementClass mProcessor = new ManagementClass(path);
                ManagementObjectCollection moCollectionProcessor = mProcessor.GetInstances();
                foreach (ManagementObject mo in moCollectionProcessor)
                {
                    WMIClass += mo[propetyName].ToString();
                }
                mProcessor.Dispose();
            }
            catch (Exception ex)
            {
                //Only for debugging.
                MessageBox.Show(ex.Message);
            }
            return WMIClass;
        }


        Dictionary<string, ManagementObjectCollection> ListViewMap = new Dictionary<string, ManagementObjectCollection>();
        /// <summary>
        /// 使用WMI穷举属性更新lvDeatil的内容
        /// </summary>
        /// <param name="path">WMI查询路径</param>
        /// <param name="groupPropetry">显示为Group的头部的标签的property</param>
        private async Task UpdatelvDeatilsAsync(string path, string groupPropetry = "Name")
        {
            if (!ListViewMap.ContainsKey(path))
            {
                ///应该改为异步操作
                await Task.Run(() =>
                {
                    ManagementClass mProcessor = new ManagementClass(path);
                    ManagementObjectCollection moCollectionProcessor = mProcessor.GetInstances();
                    mProcessor.Dispose();
                    ListViewMap[path] = moCollectionProcessor;
                }
                );
            }
            //await Task.Run(() =>
            //{
                lvDetails.UseWaitCursor = true;
                lvDetails.BeginUpdate();
                lvDetails.Groups.Clear();
                lvDetails.Items.Clear();
                lvDetails.ShowGroups = true;
                foreach (ManagementObject mo in ListViewMap[path])
                {
                    ListViewGroup listViewGroup = new ListViewGroup();
                    listViewGroup.Header = mo[groupPropetry].ToString();
                    //listViewGroup.HeaderAlignment = HorizontalAlignment.Center;
                    foreach (PropertyData pd in mo.Properties)
                    {
                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.Text = pd.Name;
                        listViewItem.SubItems.Add(pd.Value == null ? "null" : pd.Value.ToString());
                        listViewItem.ToolTipText = ("Type:" + pd.Type);
                        listViewGroup.Items.Add(listViewItem);
                        lvDetails.Items.Add(listViewItem);
                    }
                    lvDetails.Groups.Add(listViewGroup);
                }
                lvDetails.EndUpdate();
                lvDetails.UseWaitCursor = false;
            //});
        }
        private void ClientMain_Load(object sender, EventArgs e)
        {
            _ = UpdatelvDeatilsAsync("Win32_OperatingSystem", "Caption");
        }

        private void rbCPU_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCPU.Checked)
            {
                _ = UpdatelvDeatilsAsync("Win32_Processor");
            }
        }

        private void rbMem_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMem.Checked)
            {
                _ = UpdatelvDeatilsAsync("Win32_PhysicalMemory", "Tag");
            }
        }

        private void rbGPU_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGPU.Checked)
            {
                _ = UpdatelvDeatilsAsync("Win32_VideoController");

            }
        }

        private void rbDriver_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDriver.Checked)
            {
                _ = UpdatelvDeatilsAsync("Win32_DiskDrive", "Caption");
            }
        }

        private void rbOS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOS.Checked)
            {
                _ = UpdatelvDeatilsAsync("Win32_OperatingSystem");
            }
        }

        private void rbNetworkController_CheckedChanged(object sender, EventArgs e)
        {

            if (rbNetworkController.Checked)
            {
                _ = UpdatelvDeatilsAsync("Win32_NetworkAdapter");
            }
        }

        private void 复制值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lvDetails.SelectedItems.Count == 1)
            {
                Clipboard.SetText(lvDetails.SelectedItems[0].SubItems[1].Text);
            }
        }

        private void 复制项目和值ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (lvDetails.SelectedItems.Count == 1)
            {
                Clipboard.SetText(lvDetails.SelectedItems[0].SubItems[0].Text + " = " + lvDetails.SelectedItems[0].SubItems[1].Text);
            }
        }

        public void setServerIP(string s)
        {
            serverIP.Invoke((MethodInvoker)delegate
            {
                serverIP.Text = s;
            });
        }
        public void setServerUUID(string s)
        {
            serverUUID.Invoke((MethodInvoker)delegate
            {
                serverUUID.Text = s;
            });
        }
    }
}
