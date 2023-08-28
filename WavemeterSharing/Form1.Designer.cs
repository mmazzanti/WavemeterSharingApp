
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            StartProcessButton = new System.Windows.Forms.Button();
            StopProcessButton = new System.Windows.Forms.Button();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            label1 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            StatusBox = new System.Windows.Forms.CheckBox();
            notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            MenuStop = new System.Windows.Forms.ToolStripMenuItem();
            MenuStart = new System.Windows.Forms.ToolStripMenuItem();
            MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            textBox1 = new System.Windows.Forms.TextBox();
            RefreshRate = new System.Windows.Forms.NumericUpDown();
            button1 = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            RefreshRatio = new System.Windows.Forms.NumericUpDown();
            ToShare = new System.Windows.Forms.TabControl();
            Wavelengths = new System.Windows.Forms.TabPage();
            Ch1CheckBox = new System.Windows.Forms.CheckBox();
            Ch8CheckBox = new System.Windows.Forms.CheckBox();
            Ch2CheckBox = new System.Windows.Forms.CheckBox();
            Ch7CheckBox = new System.Windows.Forms.CheckBox();
            Ch3CheckBox = new System.Windows.Forms.CheckBox();
            Ch4CheckBox = new System.Windows.Forms.CheckBox();
            Ch6CheckBox = new System.Windows.Forms.CheckBox();
            Ch5CheckBox = new System.Windows.Forms.CheckBox();
            Patterns = new System.Windows.Forms.TabPage();
            PattCh8Checkbox = new System.Windows.Forms.CheckBox();
            PattCh7Checkbox = new System.Windows.Forms.CheckBox();
            PattCh6Checkbox = new System.Windows.Forms.CheckBox();
            PattCh5Checkbox = new System.Windows.Forms.CheckBox();
            PattCh4Checkbox = new System.Windows.Forms.CheckBox();
            PattCh3Checkbox = new System.Windows.Forms.CheckBox();
            PattCh2Checkbox = new System.Windows.Forms.CheckBox();
            PattCh1Checkbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RefreshRate).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RefreshRatio).BeginInit();
            ToShare.SuspendLayout();
            Wavelengths.SuspendLayout();
            Patterns.SuspendLayout();
            SuspendLayout();
            // 
            // StartProcessButton
            // 
            StartProcessButton.BackColor = System.Drawing.Color.YellowGreen;
            StartProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            StartProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StartProcessButton.Location = new System.Drawing.Point(4, 17);
            StartProcessButton.Margin = new System.Windows.Forms.Padding(2);
            StartProcessButton.Name = "StartProcessButton";
            StartProcessButton.Size = new System.Drawing.Size(119, 30);
            StartProcessButton.TabIndex = 0;
            StartProcessButton.Text = "Start Process";
            StartProcessButton.UseVisualStyleBackColor = false;
            StartProcessButton.Click += button1_Click;
            // 
            // StopProcessButton
            // 
            StopProcessButton.BackColor = System.Drawing.Color.IndianRed;
            StopProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            StopProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StopProcessButton.Location = new System.Drawing.Point(4, 56);
            StopProcessButton.Margin = new System.Windows.Forms.Padding(2);
            StopProcessButton.Name = "StopProcessButton";
            StopProcessButton.Size = new System.Drawing.Size(119, 30);
            StopProcessButton.TabIndex = 1;
            StopProcessButton.Text = "Stop Process";
            StopProcessButton.UseVisualStyleBackColor = false;
            StopProcessButton.Click += StopProcessButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            richTextBox1.Location = new System.Drawing.Point(8, 148);
            richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(553, 153);
            richTextBox1.TabIndex = 10;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(8, -4);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(294, 29);
            label1.TabIndex = 12;
            label1.Text = "Wavemeter Sharing App";
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(9, 55);
            pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(117, 89);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(StatusBox);
            groupBox2.Controls.Add(StartProcessButton);
            groupBox2.Controls.Add(StopProcessButton);
            groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox2.Location = new System.Drawing.Point(130, 46);
            groupBox2.Margin = new System.Windows.Forms.Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(2);
            groupBox2.Size = new System.Drawing.Size(198, 98);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Process Controls";
            // 
            // StatusBox
            // 
            StatusBox.Appearance = System.Windows.Forms.Appearance.Button;
            StatusBox.AutoSize = true;
            StatusBox.BackColor = System.Drawing.Color.Coral;
            StatusBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.YellowGreen;
            StatusBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            StatusBox.Location = new System.Drawing.Point(130, 40);
            StatusBox.Margin = new System.Windows.Forms.Padding(2);
            StatusBox.Name = "StatusBox";
            StatusBox.Size = new System.Drawing.Size(51, 25);
            StatusBox.TabIndex = 2;
            StatusBox.Text = "Status";
            StatusBox.UseVisualStyleBackColor = false;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Wavemeter service manager is still running...";
            notifyIcon1.BalloonTipTitle = "Wavemeter service manager";
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "WavemeterService";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MenuStop, MenuStart, MenuExit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(99, 70);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // MenuStop
            // 
            MenuStop.Name = "MenuStop";
            MenuStop.Size = new System.Drawing.Size(98, 22);
            MenuStop.Text = "Stop";
            MenuStop.Click += MenuStop_Click;
            // 
            // MenuStart
            // 
            MenuStart.Name = "MenuStart";
            MenuStart.Size = new System.Drawing.Size(98, 22);
            MenuStart.Text = "Start";
            MenuStart.Click += MenuStart_Click;
            // 
            // MenuExit
            // 
            MenuExit.Name = "MenuExit";
            MenuExit.Size = new System.Drawing.Size(98, 22);
            MenuExit.Text = "Exit";
            MenuExit.Click += MenuExit_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(356, 17);
            textBox1.Margin = new System.Windows.Forms.Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(106, 23);
            textBox1.TabIndex = 16;
            textBox1.Text = "Local Area Connection";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // RefreshRate
            // 
            RefreshRate.Location = new System.Drawing.Point(81, 18);
            RefreshRate.Margin = new System.Windows.Forms.Padding(2);
            RefreshRate.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            RefreshRate.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            RefreshRate.Name = "RefreshRate";
            RefreshRate.Size = new System.Drawing.Size(71, 23);
            RefreshRate.TabIndex = 17;
            RefreshRate.Value = new decimal(new int[] { 100, 0, 0, 0 });
            RefreshRate.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(471, 13);
            button1.Margin = new System.Windows.Forms.Padding(2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(78, 28);
            button1.TabIndex = 18;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(4, 20);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(73, 15);
            label2.TabIndex = 19;
            label2.Text = "Refresh [ms]";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(245, 20);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(107, 15);
            label3.TabIndex = 20;
            label3.Text = "Network Interface: ";
            label3.Click += label3_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(RefreshRatio);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(RefreshRate);
            groupBox3.Location = new System.Drawing.Point(8, 303);
            groupBox3.Margin = new System.Windows.Forms.Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(2);
            groupBox3.Size = new System.Drawing.Size(553, 44);
            groupBox3.TabIndex = 21;
            groupBox3.TabStop = false;
            groupBox3.Text = "Network settings";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(157, 20);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(34, 15);
            label4.TabIndex = 23;
            label4.Text = "Ratio";
            // 
            // RefreshRatio
            // 
            RefreshRatio.Location = new System.Drawing.Point(196, 17);
            RefreshRatio.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RefreshRatio.Name = "RefreshRatio";
            RefreshRatio.Size = new System.Drawing.Size(44, 23);
            RefreshRatio.TabIndex = 22;
            RefreshRatio.Value = new decimal(new int[] { 1, 0, 0, 0 });
            RefreshRatio.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // ToShare
            // 
            ToShare.Controls.Add(Wavelengths);
            ToShare.Controls.Add(Patterns);
            ToShare.Location = new System.Drawing.Point(333, 17);
            ToShare.Name = "ToShare";
            ToShare.SelectedIndex = 0;
            ToShare.Size = new System.Drawing.Size(228, 127);
            ToShare.TabIndex = 0;
            // 
            // Wavelengths
            // 
            Wavelengths.Controls.Add(Ch1CheckBox);
            Wavelengths.Controls.Add(Ch8CheckBox);
            Wavelengths.Controls.Add(Ch2CheckBox);
            Wavelengths.Controls.Add(Ch7CheckBox);
            Wavelengths.Controls.Add(Ch3CheckBox);
            Wavelengths.Controls.Add(Ch4CheckBox);
            Wavelengths.Controls.Add(Ch6CheckBox);
            Wavelengths.Controls.Add(Ch5CheckBox);
            Wavelengths.Location = new System.Drawing.Point(4, 24);
            Wavelengths.Name = "Wavelengths";
            Wavelengths.Padding = new System.Windows.Forms.Padding(3);
            Wavelengths.Size = new System.Drawing.Size(220, 99);
            Wavelengths.TabIndex = 0;
            Wavelengths.Text = "Wavelengths";
            Wavelengths.UseVisualStyleBackColor = true;
            // 
            // Ch1CheckBox
            // 
            Ch1CheckBox.AutoSize = true;
            Ch1CheckBox.Location = new System.Drawing.Point(5, 5);
            Ch1CheckBox.Margin = new System.Windows.Forms.Padding(2);
            Ch1CheckBox.Name = "Ch1CheckBox";
            Ch1CheckBox.Size = new System.Drawing.Size(79, 19);
            Ch1CheckBox.TabIndex = 2;
            Ch1CheckBox.Text = "Channel 1";
            Ch1CheckBox.UseVisualStyleBackColor = true;
            Ch1CheckBox.CheckedChanged += Ch1CheckBox_CheckedChanged;
            // 
            // Ch8CheckBox
            // 
            Ch8CheckBox.AutoSize = true;
            Ch8CheckBox.Location = new System.Drawing.Point(111, 74);
            Ch8CheckBox.Margin = new System.Windows.Forms.Padding(2);
            Ch8CheckBox.Name = "Ch8CheckBox";
            Ch8CheckBox.Size = new System.Drawing.Size(79, 19);
            Ch8CheckBox.TabIndex = 9;
            Ch8CheckBox.Text = "Channel 8";
            Ch8CheckBox.UseVisualStyleBackColor = true;
            Ch8CheckBox.CheckedChanged += Ch8CheckBox_CheckedChanged;
            // 
            // Ch2CheckBox
            // 
            Ch2CheckBox.AutoSize = true;
            Ch2CheckBox.Location = new System.Drawing.Point(5, 28);
            Ch2CheckBox.Margin = new System.Windows.Forms.Padding(2);
            Ch2CheckBox.Name = "Ch2CheckBox";
            Ch2CheckBox.Size = new System.Drawing.Size(79, 19);
            Ch2CheckBox.TabIndex = 6;
            Ch2CheckBox.Text = "Channel 2";
            Ch2CheckBox.UseVisualStyleBackColor = true;
            Ch2CheckBox.CheckedChanged += Ch2CheckBox_CheckedChanged;
            // 
            // Ch7CheckBox
            // 
            Ch7CheckBox.AutoSize = true;
            Ch7CheckBox.Location = new System.Drawing.Point(111, 51);
            Ch7CheckBox.Margin = new System.Windows.Forms.Padding(2);
            Ch7CheckBox.Name = "Ch7CheckBox";
            Ch7CheckBox.Size = new System.Drawing.Size(79, 19);
            Ch7CheckBox.TabIndex = 7;
            Ch7CheckBox.Text = "Channel 7";
            Ch7CheckBox.UseVisualStyleBackColor = true;
            Ch7CheckBox.CheckedChanged += Ch7CheckBox_CheckedChanged;
            // 
            // Ch3CheckBox
            // 
            Ch3CheckBox.AutoSize = true;
            Ch3CheckBox.Location = new System.Drawing.Point(5, 51);
            Ch3CheckBox.Margin = new System.Windows.Forms.Padding(2);
            Ch3CheckBox.Name = "Ch3CheckBox";
            Ch3CheckBox.Size = new System.Drawing.Size(79, 19);
            Ch3CheckBox.TabIndex = 5;
            Ch3CheckBox.Text = "Channel 3";
            Ch3CheckBox.UseVisualStyleBackColor = true;
            Ch3CheckBox.CheckedChanged += Ch3CheckBox_CheckedChanged;
            // 
            // Ch4CheckBox
            // 
            Ch4CheckBox.AutoSize = true;
            Ch4CheckBox.Location = new System.Drawing.Point(5, 74);
            Ch4CheckBox.Margin = new System.Windows.Forms.Padding(2);
            Ch4CheckBox.Name = "Ch4CheckBox";
            Ch4CheckBox.Size = new System.Drawing.Size(79, 19);
            Ch4CheckBox.TabIndex = 8;
            Ch4CheckBox.Text = "Channel 4";
            Ch4CheckBox.UseVisualStyleBackColor = true;
            Ch4CheckBox.CheckedChanged += Ch4CheckBox_CheckedChanged;
            // 
            // Ch6CheckBox
            // 
            Ch6CheckBox.AutoSize = true;
            Ch6CheckBox.Location = new System.Drawing.Point(111, 28);
            Ch6CheckBox.Margin = new System.Windows.Forms.Padding(2);
            Ch6CheckBox.Name = "Ch6CheckBox";
            Ch6CheckBox.Size = new System.Drawing.Size(79, 19);
            Ch6CheckBox.TabIndex = 3;
            Ch6CheckBox.Text = "Channel 6";
            Ch6CheckBox.UseVisualStyleBackColor = true;
            Ch6CheckBox.CheckedChanged += Ch6CheckBox_CheckedChanged;
            // 
            // Ch5CheckBox
            // 
            Ch5CheckBox.AutoSize = true;
            Ch5CheckBox.Location = new System.Drawing.Point(111, 5);
            Ch5CheckBox.Margin = new System.Windows.Forms.Padding(2);
            Ch5CheckBox.Name = "Ch5CheckBox";
            Ch5CheckBox.Size = new System.Drawing.Size(79, 19);
            Ch5CheckBox.TabIndex = 4;
            Ch5CheckBox.Text = "Channel 5";
            Ch5CheckBox.UseVisualStyleBackColor = true;
            Ch5CheckBox.CheckedChanged += Ch5CheckBox_CheckedChanged;
            // 
            // Patterns
            // 
            Patterns.Controls.Add(PattCh8Checkbox);
            Patterns.Controls.Add(PattCh7Checkbox);
            Patterns.Controls.Add(PattCh6Checkbox);
            Patterns.Controls.Add(PattCh5Checkbox);
            Patterns.Controls.Add(PattCh4Checkbox);
            Patterns.Controls.Add(PattCh3Checkbox);
            Patterns.Controls.Add(PattCh2Checkbox);
            Patterns.Controls.Add(PattCh1Checkbox);
            Patterns.Location = new System.Drawing.Point(4, 24);
            Patterns.Name = "Patterns";
            Patterns.Padding = new System.Windows.Forms.Padding(3);
            Patterns.Size = new System.Drawing.Size(220, 99);
            Patterns.TabIndex = 1;
            Patterns.Text = "Patterns";
            Patterns.UseVisualStyleBackColor = true;
            // 
            // PattCh8Checkbox
            // 
            PattCh8Checkbox.AutoSize = true;
            PattCh8Checkbox.Location = new System.Drawing.Point(111, 74);
            PattCh8Checkbox.Margin = new System.Windows.Forms.Padding(2);
            PattCh8Checkbox.Name = "PattCh8Checkbox";
            PattCh8Checkbox.Size = new System.Drawing.Size(79, 19);
            PattCh8Checkbox.TabIndex = 22;
            PattCh8Checkbox.Text = "Channel 8";
            PattCh8Checkbox.UseVisualStyleBackColor = true;
            PattCh8Checkbox.CheckedChanged += PattCh8Checkbox_CheckedChanged;
            // 
            // PattCh7Checkbox
            // 
            PattCh7Checkbox.AutoSize = true;
            PattCh7Checkbox.Location = new System.Drawing.Point(111, 51);
            PattCh7Checkbox.Margin = new System.Windows.Forms.Padding(2);
            PattCh7Checkbox.Name = "PattCh7Checkbox";
            PattCh7Checkbox.Size = new System.Drawing.Size(79, 19);
            PattCh7Checkbox.TabIndex = 22;
            PattCh7Checkbox.Text = "Channel 7";
            PattCh7Checkbox.UseVisualStyleBackColor = true;
            PattCh7Checkbox.CheckedChanged += PattCh7Checkbox_CheckedChanged;
            // 
            // PattCh6Checkbox
            // 
            PattCh6Checkbox.AutoSize = true;
            PattCh6Checkbox.Location = new System.Drawing.Point(111, 28);
            PattCh6Checkbox.Margin = new System.Windows.Forms.Padding(2);
            PattCh6Checkbox.Name = "PattCh6Checkbox";
            PattCh6Checkbox.Size = new System.Drawing.Size(79, 19);
            PattCh6Checkbox.TabIndex = 22;
            PattCh6Checkbox.Text = "Channel 6";
            PattCh6Checkbox.UseVisualStyleBackColor = true;
            PattCh6Checkbox.CheckedChanged += PattCh6Checkbox_CheckedChanged;
            // 
            // PattCh5Checkbox
            // 
            PattCh5Checkbox.AutoSize = true;
            PattCh5Checkbox.Location = new System.Drawing.Point(111, 5);
            PattCh5Checkbox.Margin = new System.Windows.Forms.Padding(2);
            PattCh5Checkbox.Name = "PattCh5Checkbox";
            PattCh5Checkbox.Size = new System.Drawing.Size(79, 19);
            PattCh5Checkbox.TabIndex = 22;
            PattCh5Checkbox.Text = "Channel 5";
            PattCh5Checkbox.UseVisualStyleBackColor = true;
            PattCh5Checkbox.CheckedChanged += PattCh5Checkbox_CheckedChanged;
            // 
            // PattCh4Checkbox
            // 
            PattCh4Checkbox.AutoSize = true;
            PattCh4Checkbox.Location = new System.Drawing.Point(5, 74);
            PattCh4Checkbox.Margin = new System.Windows.Forms.Padding(2);
            PattCh4Checkbox.Name = "PattCh4Checkbox";
            PattCh4Checkbox.Size = new System.Drawing.Size(79, 19);
            PattCh4Checkbox.TabIndex = 22;
            PattCh4Checkbox.Text = "Channel 4";
            PattCh4Checkbox.UseVisualStyleBackColor = true;
            PattCh4Checkbox.CheckedChanged += PattCh4Checkbox_CheckedChanged;
            // 
            // PattCh3Checkbox
            // 
            PattCh3Checkbox.AutoSize = true;
            PattCh3Checkbox.Location = new System.Drawing.Point(5, 51);
            PattCh3Checkbox.Margin = new System.Windows.Forms.Padding(2);
            PattCh3Checkbox.Name = "PattCh3Checkbox";
            PattCh3Checkbox.Size = new System.Drawing.Size(79, 19);
            PattCh3Checkbox.TabIndex = 22;
            PattCh3Checkbox.Text = "Channel 3";
            PattCh3Checkbox.UseVisualStyleBackColor = true;
            PattCh3Checkbox.CheckedChanged += PattCh3Checkbox_CheckedChanged;
            // 
            // PattCh2Checkbox
            // 
            PattCh2Checkbox.AutoSize = true;
            PattCh2Checkbox.Location = new System.Drawing.Point(5, 28);
            PattCh2Checkbox.Margin = new System.Windows.Forms.Padding(2);
            PattCh2Checkbox.Name = "PattCh2Checkbox";
            PattCh2Checkbox.Size = new System.Drawing.Size(79, 19);
            PattCh2Checkbox.TabIndex = 23;
            PattCh2Checkbox.Text = "Channel 2";
            PattCh2Checkbox.UseVisualStyleBackColor = true;
            PattCh2Checkbox.CheckedChanged += PattCh2Checkbox_CheckedChanged;
            // 
            // PattCh1Checkbox
            // 
            PattCh1Checkbox.AutoSize = true;
            PattCh1Checkbox.Location = new System.Drawing.Point(5, 5);
            PattCh1Checkbox.Margin = new System.Windows.Forms.Padding(2);
            PattCh1Checkbox.Name = "PattCh1Checkbox";
            PattCh1Checkbox.Size = new System.Drawing.Size(79, 19);
            PattCh1Checkbox.TabIndex = 22;
            PattCh1Checkbox.Text = "Channel 1";
            PattCh1Checkbox.UseVisualStyleBackColor = true;
            PattCh1Checkbox.CheckedChanged += PattCh1Checkbox_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(565, 355);
            Controls.Add(ToShare);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(2);
            Name = "Form1";
            Text = "Wavemeter sharing App";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RefreshRate).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RefreshRatio).EndInit();
            ToShare.ResumeLayout(false);
            Wavelengths.ResumeLayout(false);
            Wavelengths.PerformLayout();
            Patterns.ResumeLayout(false);
            Patterns.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button StartProcessButton;
        private System.Windows.Forms.Button StopProcessButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
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
        private System.Windows.Forms.TabControl ToShare;
        private System.Windows.Forms.TabPage Wavelengths;
        private System.Windows.Forms.CheckBox Ch8CheckBox;
        private System.Windows.Forms.CheckBox Ch4CheckBox;
        private System.Windows.Forms.CheckBox Ch1CheckBox;
        private System.Windows.Forms.CheckBox Ch7CheckBox;
        private System.Windows.Forms.CheckBox Ch2CheckBox;
        private System.Windows.Forms.CheckBox Ch3CheckBox;
        private System.Windows.Forms.CheckBox Ch6CheckBox;
        private System.Windows.Forms.CheckBox Ch5CheckBox;
        private System.Windows.Forms.TabPage Patterns;
        private System.Windows.Forms.CheckBox PattCh8Checkbox;
        private System.Windows.Forms.CheckBox PattCh7Checkbox;
        private System.Windows.Forms.CheckBox PattCh6Checkbox;
        private System.Windows.Forms.CheckBox PattCh5Checkbox;
        private System.Windows.Forms.CheckBox PattCh4Checkbox;
        private System.Windows.Forms.CheckBox PattCh3Checkbox;
        private System.Windows.Forms.CheckBox PattCh2Checkbox;
        private System.Windows.Forms.CheckBox PattCh1Checkbox;
    }
}

