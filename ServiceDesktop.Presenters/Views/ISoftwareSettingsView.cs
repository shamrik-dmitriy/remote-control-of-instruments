using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDesktop.Presenter.Common.Interfaces.BaseInterfaces;

namespace ServiceDesktop.Presenter.Views
{
    public interface ISoftwareSettingsView : IView
    {
        #region Events

        /// <summary>
        ///     Event for shown form
        /// </summary>
        event Action ShowingForm;

        /// <summary>
        ///     Event for closing form
        /// </summary>
        event Action ClosingForm;

        /// <summary>
        ///     Event for changed device in combobox
        /// </summary>
        event Action<int> ChangeDevice;

        /// <summary>
        ///     Event for changed log level in combobox
        /// </summary>
        event Action<int> ChangeLogLevel;

        /// <summary>
        ///     Get Data Source for devices
        /// </summary>
        /// <returns>Object, contains devices</returns>
        event Func<object> GetDevicesData;

        /// <summary>
        ///     Get Data Source for log levels
        /// </summary>
        /// <returns>Object, contains log levels</returns>
        event Func<object> GeLogLevels;

        /// <summary>
        ///     Save network settings for device
        /// </summary>
        event Action<int, string, string> SaveDeviceSetting;

        #endregion

        #region Methods

        /// <summary>
        ///     Method for set device combobox selected index at value
        /// </summary>
        /// <param name="value">Value for select index</param>
        void SetDevicesCombobox(int value);
        
        /// <summary>
        ///     Method for set device combobox selected index at value
        /// </summary>
        /// <param name="value">Value for select index</param>
        void SetLogLevelCombobox(int value);

        /// <summary>
        ///     Sets network parameters
        /// </summary>
        void SetNetworkParameters(string ipAddress, int port);

        #endregion
    }
}