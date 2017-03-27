using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZabbixAgentInstaller.Common;
using ZabbixAgentInstaller.Model;

namespace ZabbixAgentInstaller
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }


        public static readonly String[] OsTypes = new String[2] { "64", "32" };
        public static readonly String ZabbixFolder = "Zabbix";
        public static readonly List<PCConfig> configs = SerializeHelper.DeserializeJsonFromFile<List<PCConfig>>("PCConfig.Json");

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cbDrives.Items.AddRange(DiskHelper.GetAllDiskName());
            cbOstype.Items.AddRange(OsTypes);
            tbIP.Text = IPHelper.GetAddressIPFromKeys(configs.Select(c => c.ip).ToList());
            InitDefault();

        }
        private void InitDefault()
        {
            if (cbDrives.Items.Contains("D:\\"))
            {
                cbDrives.SelectedItem = "D:\\";
            }
            else cbDrives.SelectedItem = cbDrives.Items[0];

            bool type = Environment.Is64BitOperatingSystem;

            if (type)
            {
                cbOstype.SelectedItem = "64";
            }
            else cbOstype.SelectedItem = cbOstype.Items[0];


            //检查是否存在于config中
            var PC = configs.Find(c => c.ip == tbIP.Text);
            if (PC != null)
            {
                tbHostname.Text = PC.name;
            }
            else MessageBox.Show("Cannot find matched pc in config file,please type in hostname by yourself.");

            InitZabbixParams();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            InstallZabbix();

        }

        String zabbix_InstallExe;
        String zabbix_ConfigFileName;
        String zabbixfolder;
      
        private void InstallZabbix()
        {
            InitZabbixParams();
            CopyZabbixToDes();
            OperateService(ServiceOperation.Install);
            EditConfig();
            FireWallHelper.NetFwAddPorts(ZabbixFolder, 10050, "TCP");
            OperateService(ServiceOperation.Start);
        }
        private void InitZabbixParams()
        {
            zabbixfolder = cbDrives.Text + "zabbix\\";
            zabbix_InstallExe = zabbixfolder + cbOstype.Text + "\\zabbix_agentd.exe";
            zabbix_ConfigFileName = zabbixfolder + "zabbix_agentd.conf";
        }

        private void CopyZabbixToDes()
        {

            String destiFolder = zabbixfolder;
            FileHelper.CopyDir(ZabbixFolder, destiFolder);
        }


        private void OperateService(ServiceOperation op)
        {
            String param = String.Empty;
            switch (op)
            {
                case ServiceOperation.Install:
                    param = " -i ";
                    break;
                case ServiceOperation.Start:
                    param = " -s ";
                    break;
                case ServiceOperation.Uninstall:
                    param = " -d ";
                    break;
                case ServiceOperation.Stop:
                    param = " -x ";
                    break;
                default:
                    MessageBox.Show("Error operation for zabbix service!"); break;
            }
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.Arguments = " -c " + zabbix_ConfigFileName + param;
                info.FileName = zabbix_InstallExe;
                Process.Start(info);
            }
            catch (Exception)
            {
                MessageBox.Show("Process start error with" + zabbix_InstallExe + " -c " + zabbix_ConfigFileName + param);
            }
        }

        private void EditConfig()
        {
            String zabbix_hostOrginalContent = "Hostname=XXX";
            String zabbix_hostReplaceContent = "Hostname=" + tbHostname.Text;


            String zabbix_logOrginalContent = @"d:\zabbix\zabbix_agentd.log";
            String zabbix_logReplaceContent = zabbixfolder + "zabbix_agentd.log";

            FileHelper.ReplaceFileMuti(zabbix_ConfigFileName, new string[2] { zabbix_hostOrginalContent, zabbix_logOrginalContent }, new string[2] { zabbix_hostReplaceContent, zabbix_logReplaceContent });
        }
        enum ServiceOperation
        {
            Start,
            Install,
            Uninstall,
            Stop,
        }

        private void btnUni_Click(object sender, EventArgs e)
        {
            InitZabbixParams();
            OperateService(ServiceOperation.Stop);
            OperateService(ServiceOperation.Uninstall);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            InitZabbixParams();
            OperateService(ServiceOperation.Stop);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            InitZabbixParams();
            OperateService(ServiceOperation.Stop);
            OperateService(ServiceOperation.Start);

        }
    }
}
