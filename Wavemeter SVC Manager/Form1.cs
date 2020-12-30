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

        public Boolean runt = true;
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

        }
        private void UpdateStatusLoop()
        {
            while (true)
            {
                if (runt == false)
                    { break; }
                SVC.LoadServiceInfo();
                if (SVC.SVCStatus() == ServiceControllerStatus.Running)
                {
                    checkBox1.Checked = true;
                    checkBox1.Text = Convert.ToString("Service is running");
                }
                else
                {
                    checkBox1.Checked = false;
                    checkBox1.Text = Convert.ToString("Stopped/Not Running");
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
            SVC.LoadServiceInfo();
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
            SVC.LoadServiceInfo();
            LogBox.AppendText(DateTime.Now.ToString() + " Service status : " + SVC.SVCStatus() + "\r\n");

        }
        private void RestartSVC_Click(object sender, EventArgs e)
        { 
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SVC.LoadServiceInfo();
            LogBox.AppendText(DateTime.Now.ToString() + " Service status : " + SVC.SVCStatus() + "\r\n");
            //LogBox.Text = LogBox.Text + SVC.SVCStatus() + "\r\n";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
