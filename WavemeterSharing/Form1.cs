using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WavemeterSharingApp
{
    public partial class Form1 : Form
    {
        private System.Threading.Thread t;
        private Boolean first_close = true;
        private Boolean runt = true;
        int PORT = 9898;
        private Boolean[] ChToshare;

        UdpClient udpClient = new UdpClient();

        delegate void SetTextCallback(Boolean STS);
        delegate void InitInfoCallback();
        [DllImport("wlmData.dll")]
        public static extern long Instantiate(long RFC, long Mode, long P1, long P2);
        [DllImport("wlmData.dll")]
        public static extern double GetFrequencyNum(long channel, int res = 0);
        [DllImport("wlmData.dll")]
        public static extern long GetAnalysisItemSize(long index);
        [DllImport("wlmData.dll")]
        public static extern long GetAnalysisItemCount(long index);
        [DllImport("wlmData.dll")]
        public static extern long GetPatternItemSize(long index);
        [DllImport("wlmData.dll")]
        public static extern long GetPatternItemCount(long index);
        [DllImport("wlmData.dll")]
        public static extern long GetPatternDataNum(long Chn, long Index, IntPtr PArray);
        [DllImport("wlmData.dll")]
        public static extern long SetPattern(long Index, long iEnable);

        private static List<IPAddress> BroadcastAddresses = new List<IPAddress>();


        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control) 
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                //notifyIcon1.Visible = true;
                if (first_close == true)
                {
                    notifyIcon1.ShowBalloonTip(1000);
                    first_close = false;
                }
            }
        }
        private static void GetIPBroadcast()
        { 
            foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.Supports(NetworkInterfaceComponent.IPv4) && netInterface.Name == Settings1.Default.Connection)
                {
                    foreach (var unicast in netInterface.GetIPProperties().UnicastAddresses)
                    {
                        if ((unicast.Address.AddressFamily != AddressFamily.InterNetwork) || (IPAddress.IsLoopback(unicast.Address) == true)) { continue; }
                        var address = unicast.Address;
                        var mask = unicast.IPv4Mask;
                        var addressInt = BitConverter.ToInt32(address.GetAddressBytes(), 0);
                        var maskInt = BitConverter.ToInt32(mask.GetAddressBytes(), 0);
                        var broadcastInt = addressInt | ~maskInt;
                        var broadcastAddress = new IPAddress(BitConverter.GetBytes(broadcastInt));
                        //Console.WriteLine(string.Format("{0,16} {1,16} {2,20}", address, mask, broadcastAddress));
                        BroadcastAddresses.Add(broadcastAddress);
                    }
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

        private void MenuExit_Click(object sender, EventArgs e)
        {
            SaveChannelsShare();
            Settings1.Default.Save();
            System.Environment.Exit(1);
        }
        private void MenuStart_Click(object sender, EventArgs e)
        {
            if(runt == false) {
                button1_Click(sender, e);
            }

            //System.Environment.Exit(1);
        }
        private void MenuStop_Click(object sender, EventArgs e)
        {
            if (runt == true)
            {
                runt = false;
                richTextBox1.AppendText(DateTime.Now.ToString() + " Process stopped" + "\r\n");
                richTextBox1.ScrollToCaret();
            }
            //System.Environment.Exit(1);
        }


        public Form1()
        {
            InitializeComponent();
            ChToshare = new Boolean[8];
            LoadChannelsShare();
            t = new System.Threading.Thread(UpdateStatusLoop);
            t.Start();
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.Closing += Form1_FormClosing;
            //richTextBox1.AppendText(DateTime.Now.ToString() + " Loaded Network interface from settings : " + Settings1.Default.Connection + "\r\n");
        }
        private void LoadChannelsShare()
        {
            ChToshare[0] = Settings1.Default.Channel1;
            Ch1CheckBox.Checked = ChToshare[0];
            ChToshare[1] = Settings1.Default.Channel2;
            Ch2CheckBox.Checked = ChToshare[1];
            ChToshare[2] = Settings1.Default.Channel3;
            Ch3CheckBox.Checked = ChToshare[2];
            ChToshare[3] = Settings1.Default.Channel4;
            Ch4CheckBox.Checked = ChToshare[3];
            ChToshare[4] = Settings1.Default.Channel5;
            Ch5CheckBox.Checked = ChToshare[4];
            ChToshare[5] = Settings1.Default.Channel6;
            Ch6CheckBox.Checked = ChToshare[5];
            ChToshare[6] = Settings1.Default.Channel7;
            Ch7CheckBox.Checked = ChToshare[6];
            ChToshare[7] = Settings1.Default.Channel8;
            Ch8CheckBox.Checked = ChToshare[7];
        }
        private void SaveChannelsShare()
        {
            Settings1.Default.Channel1 = ChToshare[0];
            Settings1.Default.Channel2 = ChToshare[1];
            Settings1.Default.Channel3 = ChToshare[2];
            Settings1.Default.Channel4 = ChToshare[3];
            Settings1.Default.Channel5 = ChToshare[4];
            Settings1.Default.Channel6 = ChToshare[5];
            Settings1.Default.Channel7 = ChToshare[6];
            Settings1.Default.Channel8 = ChToshare[7];
        }
        private void UpdateStatusLoop()
        {
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));
            SetStatus(true); //process is running
            WMChannel[] WMDATA = new WMChannel[8];
            for (int i = 0; i < 8; i++)
            {
                WMDATA[i] = new WMChannel();
                WMDATA[i].Channel = i + 1;
            }
            InitSettingsNotification();
            SetPattern(Globals.cSignal1Grating, Globals.cPatternEnable); //Enable the loading of the pattern array in memory
            GetIPBroadcast();

            while (true)
            {
                if (runt == false)
                {
                    SetStatus(false);
                    break; 
                }
                //SVC.LoadServiceInfo();
                if (runt == true)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (ChToshare[i]==false)
                        {
                            WMDATA[i].SetPatternSize(0, 0); //Don't share that channel (remove old memory)
                            continue;
                        }
                        double Freq = GetFrequencyNum(i + 1, 0);
                        WMDATA[i].Frequency = Freq;
                        WMDATA[i].SetPatternSize(GetPatternItemCount(Globals.cSignal1Grating), GetPatternItemSize(Globals.cSignal1Grating));
                        //WMDATA.SetWL(i,WL);

                        if (WMDATA[i].GetPatternSize() > 0)
                        {
                            GetPatternDataNum(i + 1, Globals.cSignal1Grating, WMDATA[i].GetPatternPtr());
                            WMDATA[i].SetPatternDataFromPtr();

                            /*for (int el = 0; el < WMDATA[i].GetPatternItemCnt(); el++)
                            {
                               Console.WriteLine(Marshal.ReadIntPtr(WMDATA[i].Patternhglobal, el * (int)WMDATA[i].GetPatternItemSize()));
                            }*/
                        }
                    }
                    var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(WMDATA));
                    foreach (IPAddress IPaddr in BroadcastAddresses)
                    {
                        udpClient.Send(data, data.Length, IPaddr.ToString(), PORT); //IMPORTANT!! CHANGE THIS TO THE SUBNET BROADCAST ADDRESS (10.10.12.255) THE ROUTERS DON'T FORWARD 255.255.255.255
                    }
                    }
                    Thread.Sleep((int)numericUpDown1.Value);
            }
            udpClient.Client.Close();
        }
        private void InitSettingsNotification()
        {
            if (this.StatusBox.InvokeRequired)
            {
                InitInfoCallback d = new InitInfoCallback(InitSettingsNotification);
                this.Invoke(d, new object[] { });
            }
            else
            {
                richTextBox1.AppendText(DateTime.Now.ToString() + " Loaded Network interface from settings : " + Settings1.Default.Connection + "\r\n");
                richTextBox1.ScrollToCaret();
            }
        }
            private void SetStatus(Boolean STS)
        {
            if (this.StatusBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatus);
                this.Invoke(d, new object[] { STS });
            }
            else
            {
                if (STS == true)
                {
                    StopProcessButton.Enabled = true;
                    StartProcessButton.Enabled = false;
                    StatusBox.Checked = true;
                    StatusBox.BackColor= Color.GreenYellow;
                    StatusBox.Text = Convert.ToString("Running");
                }
                else
                {
                    StopProcessButton.Enabled = false;
                    StartProcessButton.Enabled = true;
                    StatusBox.Checked = false;
                    StatusBox.BackColor = Color.LightCoral;
                    StatusBox.Text = Convert.ToString("Stopped");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            udpClient = new UdpClient();
            runt = true;
            t = new System.Threading.Thread(UpdateStatusLoop);
            t.Start();
            richTextBox1.AppendText(DateTime.Now.ToString() + " Process started" + "\r\n");
            richTextBox1.ScrollToCaret();
        }
        private void notifyIcon_MouseClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            //notifyIcon1.Visible = false;
        }
        private void Ch4CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChToshare[3] = Ch4CheckBox.Checked;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Ch7CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChToshare[6] = Ch7CheckBox.Checked;
        }

        private void Ch3CheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Ch1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChToshare[0] = Ch1CheckBox.Checked;
        }

        private void Ch2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChToshare[1] = Ch2CheckBox.Checked;
        }

        private void Ch5CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChToshare[4] = Ch5CheckBox.Checked;
        }

        private void Ch6CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChToshare[5] = Ch6CheckBox.Checked;
        }

        private void Ch8CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChToshare[7] = Ch8CheckBox.Checked;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void StopProcessButton_Click(object sender, EventArgs e)
        {
            runt = false;
            richTextBox1.AppendText(DateTime.Now.ToString() + " Process stopped" + "\r\n");
            richTextBox1.ScrollToCaret();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Settings1.Default.Connection = textBox1.Text;
            Settings1.Default.RefreshRate = (int)numericUpDown1.Value;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string targetURL = @"https://github.com/mmazzanti/WavemeterService/tree/master";
            System.Diagnostics.Process.Start("explorer.exe", targetURL);
            //System.Diagnostics.Process.Start(targetURL);
        }
    }
}
