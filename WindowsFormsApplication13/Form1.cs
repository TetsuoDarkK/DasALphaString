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

namespace WindowsFormsApplication13
{
    public partial class Form1 : Form
    {
        private string dicompath;
        private string finalpath;
        private string port;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter writetext = new StreamWriter(@"C:\dcmtk\bin\write.bat"))
            {
                writetext.WriteLine(@"C:\dcmtk\bin\Storescu-tls +r " +textBox1.Text+" "+textBox2.Text+ " +sd " + textBox3.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            port = "555";
            dicompath = textBox3.Text;
            //storescp 555 -pm -sp -od C:\MyDir -xcs "C:\dcmtk\bin\storescu-tls +r 192.168.99.13 106 +sd #p" -tos 5 -d
            finalpath = port + " -pm -sp -od" + ((char)34) + dicompath + ((char)34) + " -xcs" + "C:\\dcmtk\\bin\\storescu-tls +r 192.168.99.13 106 +sd #p" +" -tos 5 -d";
            finalpath = port + " -pm -sp -xcs C:\\dcmtk\\bin\\write.bat -ll debug -tos 5'" + " -od " + ((char)34) + dicompath + ((char)34);


            ////
            Process startInfo2 = new Process();
            startInfo2.StartInfo.CreateNoWindow = true;
            startInfo2.StartInfo.UseShellExecute = false;
            startInfo2.StartInfo.RedirectStandardOutput = true;
            startInfo2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo2.StartInfo.FileName = @"C:\dcmtk\bin\storescp-tls.exe";
            startInfo2.StartInfo.Arguments = finalpath;
            startInfo2.StartInfo.RedirectStandardOutput = true;
            //int seconds = await SleepAsync(2000);
            startInfo2.Start();
            textBox6.Text = finalpath;




           // System.Diagnostics.Process.Start(@"C:\Batchfiles\write.bat");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Enter Path for images...";
            if (fbd.ShowDialog() == DialogResult.OK)
                MessageBox.Show(fbd.SelectedPath);
            textBox3.Text = fbd.SelectedPath;
        }
    }
}
