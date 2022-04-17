using System.Collections;
using System.ComponentModel;

namespace Client
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            InitializeComponent();
        }

        protected override void OnAfterInstall(IDictionary savedState)
        {   ///此代码已经被禁用，尝试重新启用可能造成安全隐患
            ///具体而言，安装程序(msi)将运行在UAC控制允许的最高权限下，这将绕过UAC控制启动子进程
            ///在任何情况下，这都是不允许的
            ///另外，这将绕过Windows防火墙初始配置。
            //System.Diagnostics.Process.Start("cmd","/c (cd " + System.IO.Path.GetDirectoryName(this.Context.Parameters["AssemblyPath"]) + ") & (choice /t 1 /d y /n >nul) & (start Client.exe) & exit");

            base.OnAfterInstall(savedState);
        }

    }
}
