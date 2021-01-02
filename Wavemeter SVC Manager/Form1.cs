using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;

namespace Wavemeter_SVC_Manager
{
    public partial class Form1 : Form
    {
        private Service SVC;
        private System.Threading.Thread t;
        private Boolean first_close = true;
        public Boolean runt = true;

        delegate void SetTextCallback(Boolean STS);
        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control) 
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                //notifyIcon1.Visible = true;
                if (first_close == true) { 
                    notifyIcon1.ShowBalloonTip(1000);
                    first_close = false;
                }
            }
        }
        private void Form1_FormClosing(object sender, CancelEventArgs e)
        {
                e.Cancel = true;
                Hide();
                //notifyIcon1.Visible = true;
                if (first_close == true)
                {
                    notifyIcon1.ShowBalloonTip(1000);
                first_close = false;
                }
        }
        private void notifyIcon_MouseClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            //notifyIcon1.Visible = false;
        }
        public Form1()
        {
            InitializeComponent();
            SVC = new Service();
            try
            {
                SVC.LoadServiceInfo(); //Better loading info at the startup of the program
            }
            catch (ServiceNotInstalled e)
            {
                string message = "Seems that the service is not installed. \n Please use the install it before using this program";
                MessageBox.Show(message,"Service not installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
                Application.Exit();
                Environment.Exit(0);
            }
            t = new System.Threading.Thread(UpdateStatusLoop);
            t.Start();
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.Closing += Form1_FormClosing;
        }
        private void SetStatus(Boolean STS)
        {
            if (this.checkBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatus);
                this.Invoke(d, new object[] { STS });
            }
            else { 
            if (STS == true)
            {
                checkBox1.Checked = true;
                checkBox1.Text = Convert.ToString("Service is running");
            }
            else
            {
                checkBox1.Checked = false;
                checkBox1.Text = Convert.ToString("Stopped/Not Running");
            }
            }
        }
        private void UpdateStatusLoop()
        {
            while (true)
            {
                if (runt == false)
                    { break; }
                //SVC.LoadServiceInfo();
                if (SVC.SVCStatus() == ServiceControllerStatus.Running)
                {
                    //checkBox1.Checked = true;
                    if (checkBox1.Checked == false) { 
                    SetStatus(true);
                    }
                    //checkBox1.Text = Convert.ToString("Service is running");
                }
                else
                {
                    //checkBox1.Checked = false;
                    if (checkBox1.Checked == true)
                    {
                        SetStatus(false);
                    }
                    //SetText("Stopped/Not Running");
                    //checkBox1.Text = Convert.ToString();
                }    
                Thread.Sleep(2000);
            }
        }

        private void StopSVC_Click(object sender, EventArgs e)
        {
            try { SVC.SVCStop(); }
            catch(Exception ex)
            {
                //The exception is raised by a service stop action, that can raise two possible events
                if (ex is System.ComponentModel.Win32Exception) 
                { 
                MessageBox.Show(ex.Message, "Error while stopping service!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex is InvalidOperationException) 
                { 
                MessageBox.Show(ex.Message, "Error while stopping service!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //SVC.LoadServiceInfo();
            LogBox.AppendText(DateTime.Now.ToString() + " Service status : " + SVC.SVCStatus() + "\r\n");

        }

        private void StartSVC_Click(object sender, EventArgs e)
        {
            try { SVC.SVCStart(); }
            catch (Exception ex)
            {
                //The exception is raised by a service stop action, that can raise two possible events
                if (ex is System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show(ex.Message, "Error while starting service!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex is InvalidOperationException)
                {
                    MessageBox.Show(ex.Message, "Error while starting service!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //SVC.LoadServiceInfo();
            LogBox.AppendText(DateTime.Now.ToString() + " Service status : " + SVC.SVCStatus() + "\r\n");

        }
        private void RestartSVC_Click(object sender, EventArgs e)
        {
            try { SVC.SVCRestart(); }
            catch (Exception ex)
            {
                //The exception is raised by a service stop action, that can raise two possible events
                if (ex is System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show(ex.Message, "Error while stopping service!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex is InvalidOperationException)
                {
                    MessageBox.Show(ex.Message, "Error while stopping service!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //SVC.LoadServiceInfo();
            LogBox.AppendText(DateTime.Now.ToString() + " Service status : " + SVC.SVCStatus() + "\r\n");

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SVC.LoadServiceInfo();
            LogBox.AppendText(DateTime.Now.ToString() + " Service status : " + SVC.SVCStatus() + "\r\n");
            //LogBox.Text = LogBox.Text + SVC.SVCStatus() + "\r\n";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void MenuRestore_Click(object sender, EventArgs e)
        {
            this.notifyIcon_MouseClick(sender, e);
        }

        private void MenuClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void MenuRestartSVC_Click(object sender, EventArgs e)
        {
            this.RestartSVC_Click(sender, e);
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            string targetURL = @"https://github.com/mmazzanti/WavemeterService/tree/master";
            System.Diagnostics.Process.Start(targetURL);
        }
    }
}
