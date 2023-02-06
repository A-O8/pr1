using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prakteka1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         void GetInstalledApps()


        {List<string> items = new List<string>();
            string SoftwareKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                          
                            if (sk.GetValue("DisplayName") != null)
                            {
                                listBox1.Items.Add(sk.GetValue("DisplayName"));
                                
                            }
                            }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Exception",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    items.Clear();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetInstalledApps();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
  // GetAllProcess();
        }

      

        
    }
}




