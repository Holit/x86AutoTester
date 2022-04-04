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
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace Client
{
    public partial class ClientMain : Form
    {
        ConfigFile configFile;
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

        private async Task ShowDeatils(string path, string groupPropetry = "Name")
        {
            ManagementObjectCollection managementBaseObjects = await WMITest.GetDeatils(path);
            lvDetails.UseWaitCursor = true;
            lvDetails.BeginUpdate();
            lvDetails.Groups.Clear();
            lvDetails.Items.Clear();
            lvDetails.ShowGroups = true;
            foreach (ManagementObject mo in managementBaseObjects)
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

        }
        private void ClientMain_Load(object sender, EventArgs e)
        {
            _ = ShowDeatils("Win32_OperatingSystem", "Caption");
        }

        private void rbCPU_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCPU.Checked)
            {
                _ = ShowDeatils("Win32_Processor");
            }
        }

        private void rbMem_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMem.Checked)
            {
                _ = ShowDeatils("Win32_PhysicalMemory", "Tag");
            }
        }

        private void rbGPU_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGPU.Checked)
            {
                _ = ShowDeatils("Win32_VideoController");

            }
        }

        private void rbDriver_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDriver.Checked)
            {
                _ = ShowDeatils("Win32_DiskDrive", "Caption");
            }
        }

        private void rbOS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOS.Checked)
            {
                _ = ShowDeatils("Win32_OperatingSystem");
            }
        }

        private void rbNetworkController_CheckedChanged(object sender, EventArgs e)
        {

            if (rbNetworkController.Checked)
            {
                _ = ShowDeatils("Win32_NetworkAdapter");
            }
        }

        private void 复制值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDetails.SelectedItems.Count == 1)
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

        private void 读入配置文件CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "x86自动测试软件配置文件|*.jht|任意文件|*.*";
            openFileDialog1.Title = "手动读入配置文件";
            
            openFileDialog1.FileName = Environment.CurrentDirectory;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                MessageBox.Show("尝试解释文件" + path);
                if (System.IO.File.Exists(path))
                {
                    try
                    {
                        configFile = Newtonsoft.Json.JsonConvert.DeserializeObject(
                            Encoding.UTF8.GetString(
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
            //格式化JSON
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(Newtonsoft.Json.JsonConvert.SerializeObject(configFile));
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                tbConfigFileDetail.Text = textWriter.ToString();
            }
            else
            {
                tbConfigFileDetail.Text = Newtonsoft.Json.JsonConvert.SerializeObject(configFile);
            }

            //MessageBox.Show(Newtonsoft.Json.JsonConvert.SerializeObject(configFile));
        }

    }
}
