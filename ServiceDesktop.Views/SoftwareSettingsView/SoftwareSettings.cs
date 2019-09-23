using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceDesktop.Models.ApplicationModels.SoftwareSettings;
using ServiceDesktop.Presenter.Common;
using ServiceDesktop.Presenter.Common.Interfaces.BaseInterfaces;
using ServiceDesktop.Presenter.Views;

namespace ServiceDesktop.Views.SoftwareSettingsView
{
    public partial class SoftwareSettings : Form, ISoftwareSettingsView
    {
        #region Public Events, Properties

        public event Func<object> GetDevicesData;
        public event Func<object> GeLogLevels;
        public event Action ShowingForm;
        public event Action ClosingForm;

        public event Action<int> ChangeDevice;
        public event Action<int> ChangeLogLevel;
        public event Action<int, string, string> SaveDeviceSetting;

        #endregion

        #region Constructor

        public SoftwareSettings()
        {
            InitializeComponent();
            Text = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Icon = Properties.Resources.monitor;
        }

        #endregion

        #region Public Methods

        #region Form Events

        /// <summary>
        ///     Override Show method
        /// </summary>
        public new void Show()
        {
            ShowDialog();
        }

        #endregion

        #region

        public void SetNetworkParameters(string ipAddress, int ipPort)
        {
            textBoxIpAddressSelectedDevice.Text = ipAddress;
            textBoxIpPortSelectedDevice.Text = ipPort.ToString();
        }


        /// <summary>
        ///     Method for set device combobox selected index at value
        /// </summary>
        /// <param name="value">Value for select index</param>
        public void SetDevicesCombobox(int value)
        {
            comboBoxSelectDevices.SelectedIndex = value;
        }

        /// <summary>
        ///     Method for set log level combobox selected index at value
        /// </summary>
        /// <param name="value">Value for select index</param>
        public void SetLogLevelCombobox(int value)
        {
            comboBoxLevelLog.SelectedIndex = value;
        }

        #endregion

        #endregion

        #region Private Methods

        private void SoftwareSettings_Shown(object sender, EventArgs e)
        {
            ShowingForm?.Invoke();
        }

        #endregion

        private void comboBoxSelectDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDevice?.Invoke(comboBoxSelectDevices.SelectedIndex);
        }

        private void comboBoxLevelLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLogLevel?.Invoke(comboBoxLevelLog.SelectedIndex);
        }

        private void SoftwareSettings_Load(object sender, EventArgs e)
        {
            comboBoxSelectDevices.DataSource = GetDevicesData?.Invoke();
            comboBoxLevelLog.DataSource = GeLogLevels?.Invoke();
        }

        private void buttonSaveSelectedDeviceSettings_Click(object sender, EventArgs e)
        {
            SaveDeviceSetting?.Invoke(comboBoxSelectDevices.SelectedIndex, textBoxIpAddressSelectedDevice.Text,
                textBoxIpPortSelectedDevice.Text);
        }
    }
}