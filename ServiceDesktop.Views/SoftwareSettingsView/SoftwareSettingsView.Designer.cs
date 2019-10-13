namespace ServiceDesktop.Views.SoftwareSettingsView
{
    partial class SoftwareSettingsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxLevelLog = new System.Windows.Forms.ComboBox();
            this.comboBoxSelectDevices = new System.Windows.Forms.ComboBox();
            this.buttonSaveSelectedDeviceSettings = new System.Windows.Forms.Button();
            this.textBoxIpPortSelectedDevice = new System.Windows.Forms.TextBox();
            this.textBoxIpAddressSelectedDevice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxLevelLog
            // 
            this.comboBoxLevelLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevelLog.FormattingEnabled = true;
            this.comboBoxLevelLog.Items.AddRange(new object[] {
            "Выберите уровень логирования",
            "Уровень 1",
            "Уровень 2",
            "Уровень 3"});
            this.comboBoxLevelLog.Location = new System.Drawing.Point(6, 19);
            this.comboBoxLevelLog.Name = "comboBoxLevelLog";
            this.comboBoxLevelLog.Size = new System.Drawing.Size(250, 21);
            this.comboBoxLevelLog.TabIndex = 7;
            this.comboBoxLevelLog.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevelLog_SelectedIndexChanged);
            // 
            // comboBoxSelectDevices
            // 
            this.comboBoxSelectDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectDevices.FormattingEnabled = true;
            this.comboBoxSelectDevices.Items.AddRange(new object[] {
            "Выберите устройство",
            "Источник питания",
            "Генератор сигналов"});
            this.comboBoxSelectDevices.Location = new System.Drawing.Point(6, 19);
            this.comboBoxSelectDevices.Name = "comboBoxSelectDevices";
            this.comboBoxSelectDevices.Size = new System.Drawing.Size(250, 21);
            this.comboBoxSelectDevices.TabIndex = 8;
            this.comboBoxSelectDevices.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectDevices_SelectedIndexChanged);
            // 
            // buttonSaveSelectedDeviceSettings
            // 
            this.buttonSaveSelectedDeviceSettings.Location = new System.Drawing.Point(12, 142);
            this.buttonSaveSelectedDeviceSettings.Name = "buttonSaveSelectedDeviceSettings";
            this.buttonSaveSelectedDeviceSettings.Size = new System.Drawing.Size(264, 23);
            this.buttonSaveSelectedDeviceSettings.TabIndex = 6;
            this.buttonSaveSelectedDeviceSettings.Text = "Сохранить";
            this.buttonSaveSelectedDeviceSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSelectedDeviceSettings.Click += new System.EventHandler(this.buttonSaveSelectedDeviceSettings_Click);
            // 
            // textBoxIpPortSelectedDevice
            // 
            this.textBoxIpPortSelectedDevice.Location = new System.Drawing.Point(171, 44);
            this.textBoxIpPortSelectedDevice.Name = "textBoxIpPortSelectedDevice";
            this.textBoxIpPortSelectedDevice.Size = new System.Drawing.Size(85, 20);
            this.textBoxIpPortSelectedDevice.TabIndex = 5;
            this.textBoxIpPortSelectedDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxIpAddressSelectedDevice
            // 
            this.textBoxIpAddressSelectedDevice.Location = new System.Drawing.Point(5, 44);
            this.textBoxIpAddressSelectedDevice.Name = "textBoxIpAddressSelectedDevice";
            this.textBoxIpAddressSelectedDevice.Size = new System.Drawing.Size(160, 20);
            this.textBoxIpAddressSelectedDevice.TabIndex = 4;
            this.textBoxIpAddressSelectedDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxSelectDevices);
            this.groupBox1.Controls.Add(this.textBoxIpAddressSelectedDevice);
            this.groupBox1.Controls.Add(this.textBoxIpPortSelectedDevice);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 70);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Netwrok Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxLevelLog);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 48);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log Settings";
            // 
            // SoftwareSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 172);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSaveSelectedDeviceSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoftwareSettings";
            this.Text = "SoftwareSettings";
            this.Load += new System.EventHandler(this.SoftwareSettings_Load);
            this.Shown += new System.EventHandler(this.SoftwareSettings_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLevelLog;
        private System.Windows.Forms.ComboBox comboBoxSelectDevices;
        private System.Windows.Forms.Button buttonSaveSelectedDeviceSettings;
        private System.Windows.Forms.TextBox textBoxIpPortSelectedDevice;
        private System.Windows.Forms.TextBox textBoxIpAddressSelectedDevice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}