﻿
namespace WavemeterSharingApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.StartProcessButton = new System.Windows.Forms.Button();
            this.StopProcessButton = new System.Windows.Forms.Button();
            this.Ch1CheckBox = new System.Windows.Forms.CheckBox();
            this.Ch6CheckBox = new System.Windows.Forms.CheckBox();
            this.Ch5CheckBox = new System.Windows.Forms.CheckBox();
            this.Ch3CheckBox = new System.Windows.Forms.CheckBox();
            this.Ch2CheckBox = new System.Windows.Forms.CheckBox();
            this.Ch7CheckBox = new System.Windows.Forms.CheckBox();
            this.Ch4CheckBox = new System.Windows.Forms.CheckBox();
            this.Ch8CheckBox = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StatusBox = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RefreshRate = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RefreshRatio = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshRate)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshRatio)).BeginInit();
            this.SuspendLayout();
            // 
            // StartProcessButton
            // 
            this.StartProcessButton.BackColor = System.Drawing.Color.YellowGreen;
            this.StartProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartProcessButton.Location = new System.Drawing.Point(4, 17);
            this.StartProcessButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartProcessButton.Name = "StartProcessButton";
            this.StartProcessButton.Size = new System.Drawing.Size(119, 30);
            this.StartProcessButton.TabIndex = 0;
            this.StartProcessButton.Text = "Start Process";
            this.StartProcessButton.UseVisualStyleBackColor = false;
            this.StartProcessButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // StopProcessButton
            // 
            this.StopProcessButton.BackColor = System.Drawing.Color.IndianRed;
            this.StopProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StopProcessButton.Location = new System.Drawing.Point(4, 56);
            this.StopProcessButton.Margin = new System.Windows.Forms.Padding(2);
            this.StopProcessButton.Name = "StopProcessButton";
            this.StopProcessButton.Size = new System.Drawing.Size(119, 30);
            this.StopProcessButton.TabIndex = 1;
            this.StopProcessButton.Text = "Stop Process";
            this.StopProcessButton.UseVisualStyleBackColor = false;
            this.StopProcessButton.Click += new System.EventHandler(this.StopProcessButton_Click);
            // 
            // Ch1CheckBox
            // 
            this.Ch1CheckBox.AutoSize = true;
            this.Ch1CheckBox.Location = new System.Drawing.Point(4, 18);
            this.Ch1CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Ch1CheckBox.Name = "Ch1CheckBox";
            this.Ch1CheckBox.Size = new System.Drawing.Size(82, 19);
            this.Ch1CheckBox.TabIndex = 2;
            this.Ch1CheckBox.Text = "Channel 1";
            this.Ch1CheckBox.UseVisualStyleBackColor = true;
            this.Ch1CheckBox.CheckedChanged += new System.EventHandler(this.Ch1CheckBox_CheckedChanged);
            // 
            // Ch6CheckBox
            // 
            this.Ch6CheckBox.AutoSize = true;
            this.Ch6CheckBox.Location = new System.Drawing.Point(104, 39);
            this.Ch6CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Ch6CheckBox.Name = "Ch6CheckBox";
            this.Ch6CheckBox.Size = new System.Drawing.Size(82, 19);
            this.Ch6CheckBox.TabIndex = 3;
            this.Ch6CheckBox.Text = "Channel 6";
            this.Ch6CheckBox.UseVisualStyleBackColor = true;
            this.Ch6CheckBox.CheckedChanged += new System.EventHandler(this.Ch6CheckBox_CheckedChanged);
            // 
            // Ch5CheckBox
            // 
            this.Ch5CheckBox.AutoSize = true;
            this.Ch5CheckBox.Location = new System.Drawing.Point(104, 17);
            this.Ch5CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Ch5CheckBox.Name = "Ch5CheckBox";
            this.Ch5CheckBox.Size = new System.Drawing.Size(82, 19);
            this.Ch5CheckBox.TabIndex = 4;
            this.Ch5CheckBox.Text = "Channel 5";
            this.Ch5CheckBox.UseVisualStyleBackColor = true;
            this.Ch5CheckBox.CheckedChanged += new System.EventHandler(this.Ch5CheckBox_CheckedChanged);
            // 
            // Ch3CheckBox
            // 
            this.Ch3CheckBox.AutoSize = true;
            this.Ch3CheckBox.Location = new System.Drawing.Point(4, 60);
            this.Ch3CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Ch3CheckBox.Name = "Ch3CheckBox";
            this.Ch3CheckBox.Size = new System.Drawing.Size(82, 19);
            this.Ch3CheckBox.TabIndex = 5;
            this.Ch3CheckBox.Text = "Channel 3";
            this.Ch3CheckBox.UseVisualStyleBackColor = true;
            this.Ch3CheckBox.CheckedChanged += new System.EventHandler(this.Ch3CheckBox_CheckedChanged);
            // 
            // Ch2CheckBox
            // 
            this.Ch2CheckBox.AutoSize = true;
            this.Ch2CheckBox.Location = new System.Drawing.Point(4, 39);
            this.Ch2CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Ch2CheckBox.Name = "Ch2CheckBox";
            this.Ch2CheckBox.Size = new System.Drawing.Size(82, 19);
            this.Ch2CheckBox.TabIndex = 6;
            this.Ch2CheckBox.Text = "Channel 2";
            this.Ch2CheckBox.UseVisualStyleBackColor = true;
            this.Ch2CheckBox.CheckedChanged += new System.EventHandler(this.Ch2CheckBox_CheckedChanged);
            // 
            // Ch7CheckBox
            // 
            this.Ch7CheckBox.AutoSize = true;
            this.Ch7CheckBox.Location = new System.Drawing.Point(104, 60);
            this.Ch7CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Ch7CheckBox.Name = "Ch7CheckBox";
            this.Ch7CheckBox.Size = new System.Drawing.Size(82, 19);
            this.Ch7CheckBox.TabIndex = 7;
            this.Ch7CheckBox.Text = "Channel 7";
            this.Ch7CheckBox.UseVisualStyleBackColor = true;
            this.Ch7CheckBox.CheckedChanged += new System.EventHandler(this.Ch7CheckBox_CheckedChanged);
            // 
            // Ch4CheckBox
            // 
            this.Ch4CheckBox.AutoSize = true;
            this.Ch4CheckBox.Location = new System.Drawing.Point(4, 81);
            this.Ch4CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Ch4CheckBox.Name = "Ch4CheckBox";
            this.Ch4CheckBox.Size = new System.Drawing.Size(82, 19);
            this.Ch4CheckBox.TabIndex = 8;
            this.Ch4CheckBox.Text = "Channel 4";
            this.Ch4CheckBox.UseVisualStyleBackColor = true;
            this.Ch4CheckBox.CheckedChanged += new System.EventHandler(this.Ch4CheckBox_CheckedChanged);
            // 
            // Ch8CheckBox
            // 
            this.Ch8CheckBox.AutoSize = true;
            this.Ch8CheckBox.Location = new System.Drawing.Point(104, 82);
            this.Ch8CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Ch8CheckBox.Name = "Ch8CheckBox";
            this.Ch8CheckBox.Size = new System.Drawing.Size(82, 19);
            this.Ch8CheckBox.TabIndex = 9;
            this.Ch8CheckBox.Text = "Channel 8";
            this.Ch8CheckBox.UseVisualStyleBackColor = true;
            this.Ch8CheckBox.CheckedChanged += new System.EventHandler(this.Ch8CheckBox_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(8, 133);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(549, 168);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Ch4CheckBox);
            this.groupBox1.Controls.Add(this.Ch1CheckBox);
            this.groupBox1.Controls.Add(this.Ch8CheckBox);
            this.groupBox1.Controls.Add(this.Ch2CheckBox);
            this.groupBox1.Controls.Add(this.Ch7CheckBox);
            this.groupBox1.Controls.Add(this.Ch3CheckBox);
            this.groupBox1.Controls.Add(this.Ch6CheckBox);
            this.groupBox1.Controls.Add(this.Ch5CheckBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(344, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(213, 107);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channels to share";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, -4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Wavemeter Sharing App";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 40);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StatusBox);
            this.groupBox2.Controls.Add(this.StartProcessButton);
            this.groupBox2.Controls.Add(this.StopProcessButton);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(130, 40);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(210, 90);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Process Controls";
            // 
            // StatusBox
            // 
            this.StatusBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.StatusBox.AutoSize = true;
            this.StatusBox.BackColor = System.Drawing.Color.Coral;
            this.StatusBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.YellowGreen;
            this.StatusBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusBox.Location = new System.Drawing.Point(130, 40);
            this.StatusBox.Margin = new System.Windows.Forms.Padding(2);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(51, 25);
            this.StatusBox.TabIndex = 2;
            this.StatusBox.Text = "Status";
            this.StatusBox.UseVisualStyleBackColor = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Wavemeter service manager is still running...";
            this.notifyIcon1.BalloonTipTitle = "Wavemeter service manager";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "WavemeterService";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStop,
            this.MenuStart,
            this.MenuExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // MenuStop
            // 
            this.MenuStop.Name = "MenuStop";
            this.MenuStop.Size = new System.Drawing.Size(98, 22);
            this.MenuStop.Text = "Stop";
            this.MenuStop.Click += new System.EventHandler(this.MenuStop_Click);
            // 
            // MenuStart
            // 
            this.MenuStart.Name = "MenuStart";
            this.MenuStart.Size = new System.Drawing.Size(98, 22);
            this.MenuStart.Text = "Start";
            this.MenuStart.Click += new System.EventHandler(this.MenuStart_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(98, 22);
            this.MenuExit.Text = "Exit";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(356, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 23);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "Local Area Connection";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // RefreshRate
            // 
            this.RefreshRate.Location = new System.Drawing.Point(81, 18);
            this.RefreshRate.Margin = new System.Windows.Forms.Padding(2);
            this.RefreshRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RefreshRate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RefreshRate.Name = "RefreshRate";
            this.RefreshRate.Size = new System.Drawing.Size(71, 23);
            this.RefreshRate.TabIndex = 17;
            this.RefreshRate.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.RefreshRate.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 28);
            this.button1.TabIndex = 18;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Refresh [ms]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Network Interface: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.RefreshRatio);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.RefreshRate);
            this.groupBox3.Location = new System.Drawing.Point(8, 303);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(548, 44);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Network settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Ratio";
            // 
            // RefreshRatio
            // 
            this.RefreshRatio.Location = new System.Drawing.Point(196, 17);
            this.RefreshRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RefreshRatio.Name = "RefreshRatio";
            this.RefreshRatio.Size = new System.Drawing.Size(44, 23);
            this.RefreshRatio.TabIndex = 22;
            this.RefreshRatio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RefreshRatio.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 355);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Wavemeter sharing App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RefreshRate)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshRatio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartProcessButton;
        private System.Windows.Forms.Button StopProcessButton;
        private System.Windows.Forms.CheckBox Ch1CheckBox;
        private System.Windows.Forms.CheckBox Ch6CheckBox;
        private System.Windows.Forms.CheckBox Ch5CheckBox;
        private System.Windows.Forms.CheckBox Ch3CheckBox;
        private System.Windows.Forms.CheckBox Ch2CheckBox;
        private System.Windows.Forms.CheckBox Ch7CheckBox;
        private System.Windows.Forms.CheckBox Ch4CheckBox;
        private System.Windows.Forms.CheckBox Ch8CheckBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox StatusBox;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem MenuStart;
        private System.Windows.Forms.ToolStripMenuItem MenuStop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown RefreshRate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RefreshRatio;
    }
}

