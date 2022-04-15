using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
        {
          // System.Windows.Forms.MessageBox.Show("cmd" + "/c (cd " + System.IO.Path.GetDirectoryName(this.Context.Parameters["AssemblyPath"]) + ")&" + " (choice /t 1 /d y /n >nul) & (\"" +
                //System.IO.Path.GetDirectoryName(this.Context.Parameters["AssemblyPath"]) + "\\Client.exe\") & exit");
            System.Diagnostics.Process.Start("cmd","/c (cd " + System.IO.Path.GetDirectoryName(this.Context.Parameters["AssemblyPath"]) + ") & (choice /t 1 /d y /n >nul) & (start Client.exe) & exit");
            base.OnAfterInstall(savedState);
        }
        
    }
}
