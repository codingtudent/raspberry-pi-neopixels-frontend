using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Renci.SshNet;

namespace raspberry_pi_neopixels_frontend
{
    public partial class Form1 : Form
    {
        //private delegate void SafeCallDelegate(string text);
        public Form1()
    {
        InitializeComponent();
        Control_page.Visible = false;
    }

    private void MenuStrip1_Click(object sender, EventArgs e)
    {

    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        if (e.ClickedItem.Text == "Login")
        {
            this.groupBox2.Visible = false;
            this.groupBox1.Visible = true;
        }
        if (e.ClickedItem.Text == "Control")
        {
            this.groupBox2.Visible = true;
            this.groupBox1.Visible = false;
        }
    }
        string host;
        string username;
        string password;
    private void button1_Click(object sender, EventArgs e)
    {
        richTextBox1.Clear();
            //thread2 = new Thread(new ThreadStart(SetText));
            //thread2.Start();
            //Thread.Sleep(1000);

            username = textBox2.Text;
            password = textBox1.Text;
            host = textBox3.Text;
            richTextBox1.Text += string.Format("\n" + username);
            richTextBox1.Text += string.Format("\n"+password);
            richTextBox1.Text += string.Format("\n" + host);


            //string remoteDirectory = "/home/pi";


            using (SshClient sshclient = new SshClient(host, username, password))
        {
            try
            {
                sshclient.Connect();
                Control_page.Visible = true;
                /*
                var files = sftp.ListDirectory(remoteDirectory);
                Control_page.Visible = true;
                foreach (var file in files)
                {
                    richTextBox1.Text += string.Format(file.Name);
                }
                sc.Execute();
                sftp.Disconnect();
                */

                //SshCommand sc = sshclient.CreateCommand("sudo python3 rainbow.py");
                //sc.Execute();
                //richTextBox1.Text += string.Format(sc.Result);

                //sc = sshclient.CreateCommand("1");
                //sc.Execute();
                sshclient.Disconnect();

            }
            catch (Exception er)
            {
                richTextBox1.Text += string.Format("An exception has been caught " + er.ToString());
            }
                
        }
    }


    private void Red_Click(object sender, EventArgs e)
    {
        using (SshClient sshclient = new SshClient(host, username, password))
        {
            try
            {
                sshclient.Connect();
                SshCommand sc = sshclient.CreateCommand("sudo python3 red.py");
                sc.Execute();
                richTextBox1.Text += string.Format(sc.Result);
                //sshclient.Disconnect();
            }
            catch (Exception er)
            {
                richTextBox1.Text += string.Format("An exception has been caught " + er.ToString());
            }
        }
    }

        private void green_Click(object sender, EventArgs e)
        {
            using (SshClient sshclient = new SshClient(host, username, password))
            {
                try
                {
                    sshclient.Connect();
                    SshCommand sc = sshclient.CreateCommand("sudo python3 green.py");
                    sc.Execute();
                    richTextBox1.Text += string.Format(sc.Result);
                    sshclient.Disconnect();
                }
                catch (Exception er)
                {
                    richTextBox1.Text += string.Format("An exception has been caught " + er.ToString());
                }
            }
        }

        private void blue_Click(object sender, EventArgs e)
        {
            using (SshClient sshclient = new SshClient(host, username, password))
            {
                try
                {
                    sshclient.Connect();
                    SshCommand sc = sshclient.CreateCommand("sudo python3 blue.py");
                    sc.Execute();
                    richTextBox1.Text += string.Format(sc.Result);
                    sshclient.Disconnect();
                }
                catch (Exception er)
                {
                    richTextBox1.Text += string.Format("An exception has been caught " + er.ToString());
                }
            }
        }

        private void rainbow_Click(object sender, EventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)
        {
            using (SshClient sshclient = new SshClient(host, username, password))
            {
                try
                {
                    sshclient.Connect();
                    SshCommand sc = sshclient.CreateCommand("sudo python3 blank.py");
                    sc.Execute();
                    richTextBox1.Text += string.Format(sc.Result);
                    sshclient.Disconnect();
                }
                catch (Exception er)
                {
                    richTextBox1.Text += string.Format("An exception has been caught " + er.ToString());
                }
            }
        }
        /*
private void WriteTextSafe(string text)
{
if (textBox1.InvokeRequired)
{
var d = new SafeCallDelegate(WriteTextSafe);
textBox1.Invoke(d, new object[] { text });
}
else
{
textBox1.Text = text;
}
}
*/
        /*
        private void SetText(string text)
        {
            Thread myThread = new System.Threading.Thread(delegate () {
                string remoteDirectory = "/home/pi";

                string host = @"192.168.1.24";
                string username = "pi";
                string password = @"raspbian";

                using (SftpClient sftp = new SftpClient(host, username, password))
                {
                    try
                    {
                        sftp.Connect();

                        var files = sftp.ListDirectory(remoteDirectory);

                        foreach (var file in files)
                        {
                            richTextBox1.Text += string.Format(file.Name);
                        }

                        sftp.Disconnect();
                    }
                    catch (Exception er)
                    {
                        richTextBox1.Text += string.Format("An exception has been caught " + er.ToString());
                    }
                }
            });

            myThread.Start();
            WriteTextSafe(text);
        }
        */
    }

}
