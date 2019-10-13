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
    public partial class SoftwareSettingsView : Form, ISoftwareSettingsView
    {
        #region Public Events, Properties

        public event Func<object> GetDevicesData;
        public event Func<object> GeLogLevels;
        public event Action ShowingForm;
        public event Action ClosingForm;

        public event Action<int> ChangeDevice;
        public event Action<int> ChangeLogLevel;
        public event Action<int, string, string> SaveSetting;

        #endregion

        #region Constructor

        public SoftwareSettingsView()
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

        /// <summary>
        ///     Override Close Method
        /// </summary>
        public new void Close()
        {
        }

        #endregion

        #region Set Network setting

        public void SetNetworkParameters(string ipAddress, int ipPort)
        {
            textBoxIpAddressSelectedDevice.Text = ipAddress;
            textBoxIpPortSelectedDevice.Text = ipPort.ToString();
        }


        public void SetDevicesCombobox(int value)
        {
            comboBoxSelectDevices.SelectedIndex = value;
        }

        public void SetLogLevelCombobox(int value)
        {
            comboBoxLevelLog.SelectedIndex = value;
        }

        #endregion

        #endregion

        #region Private Methods

        #region Form Action

        /// <summary>
        ///     Override load action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoftwareSettings_Load(object sender, EventArgs e)
        {
            comboBoxSelectDevices.DataSource = GetDevicesData?.Invoke();
            comboBoxLevelLog.DataSource = GeLogLevels?.Invoke();
        }

        private void SoftwareSettings_Shown(object sender, EventArgs e)
        {
            ShowingForm?.Invoke();
        }

        #endregion

        #region Other form action

        /// <summary>
        ///     Override event for action combobox selected index changed in selected device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSelectDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDevice?.Invoke(comboBoxSelectDevices.SelectedIndex);
        }

        /// <summary>
        ///     Override event for action combobox selected index changed in selected changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxLevelLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLogLevel?.Invoke(comboBoxLevelLog.SelectedIndex);
        }

        /// <summary>
        ///     Save data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveSelectedDeviceSettings_Click(object sender, EventArgs e)
        {
            SaveSetting?.Invoke(comboBoxSelectDevices.SelectedIndex, textBoxIpAddressSelectedDevice.Text,
                textBoxIpPortSelectedDevice.Text);
        }

        #endregion

        #endregion
    }
}