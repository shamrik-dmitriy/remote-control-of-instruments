using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDesktop.Models.ApplicationModels.SoftwareSettings;
using ServiceDesktop.Presenter.Common;
using ServiceDesktop.Presenter.Common.AbstractClasses;
using ServiceDesktop.Presenter.Common.Interfaces;
using ServiceDesktop.Presenter.Views;
using ServiceDesktop.Services.MessageServices;

namespace ServiceDesktop.Presenter.Presenters
{
    public class SoftwareSettingsPresenter : BasePresenter<ISoftwareSettingsView>
    {
        #region Private Properties

        /// <summary>
        ///     Instance of message service
        /// </summary>
        private IMessageService MessageService { get; set; }

        /// <summary>
        ///     Instance of model for software settings
        /// </summary>
        private ISoftwareSettingsModel SoftwareSettingsModel { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor of Software settings presenter
        /// </summary>
        /// <param name="controller">Interface of application controller</param>
        /// <param name="messageService">Interface of message service</param>
        /// <param name="view">Interface of software view</param>
        public SoftwareSettingsPresenter(IApplicationController controller, IMessageService messageService,
            ISoftwareSettingsView view) : base(
            controller, view)
        {
            MessageService = messageService;

            SoftwareSettingsModel = new SoftwareSettingsModel();

            SubscribeEvents();
        }

        #endregion

        #region Private Methods

        #region Subscribe / Unsubscribe

        /// <summary>
        ///     Subscribe events
        /// </summary>
        private void SubscribeEvents()
        {
            View.GetDevicesData += ViewOnGetDevicesData;
            View.GeLogLevels += ViewOnGeLogLevels;

            View.ShowingForm += ViewOnShowingForm;
            View.ChangeDevice += ViewOnChangeDevice;
            View.ChangeLogLevel += ViewOnChangeLogLevel;
            View.SaveSetting += ViewOnSaveDeviceSetting;
        }

        /// <summary>
        ///     Unsubscribe events
        /// </summary>
        private void UnSubscribeEvents()
        {
            View.GetDevicesData += ViewOnGetDevicesData;
            View.GeLogLevels += ViewOnGeLogLevels;

            View.ShowingForm -= ViewOnShowingForm;
            View.ChangeDevice -= ViewOnChangeDevice;
            View.ChangeLogLevel -= ViewOnChangeLogLevel;
            View.SaveSetting -= ViewOnSaveDeviceSetting;
        }

        #endregion

        #region Methods for save data in form

        /// <summary>
        ///     Save device network parameters
        /// </summary>
        /// <param name="typeDevice">Type of devices</param>
        /// <param name="ipAddress">Ip-address</param>
        /// <param name="port">Ip port</param>
        private void ViewOnSaveDeviceSetting(int typeDevice, string ipAddress, string port)
        {
            SoftwareSettingsModel.SaveDeviceSettings(typeDevice, ipAddress, port);
        }

        /// <summary>
        ///     Get Data Source for log levels
        /// </summary>
        /// <returns>Object, contains log levels</returns>
        private object ViewOnGeLogLevels()
        {
            return SoftwareSettingsModel.GetLogLevels();
        }

        /// <summary>
        ///     Get Data Source for devices
        /// </summary>
        /// <returns>Object, contains devices</returns>
        private object ViewOnGetDevicesData()
        {
            return SoftwareSettingsModel.GetDeviceData();
        }

        /// <summary>
        ///     Processing changed log level
        /// </summary>
        /// <param name="logLevelValue">Log level value</param>
        private void ViewOnChangeLogLevel(int logLevelValue)
        {
            SoftwareSettingsModel.ChangeLogLevel(logLevelValue);
        }

        #endregion

        #region Form Events

        /// <summary>
        ///     Processing changed device
        /// </summary>
        /// <param name="typeDevice">Device index value</param>
        private void ViewOnChangeDevice(int typeDevice)
        {
            try
            {
                switch (typeDevice)
                {
                    case 0:
                    {
                        var (ipAddress, ipPort) = SoftwareSettingsModel.GetNetworkParametersForSignalGenerator();
                        View.SetNetworkParameters(ipAddress, ipPort);
                        break;
                    }

                    case 1:
                    {
                        var (ipAddress, ipPort) = SoftwareSettingsModel.GetNetworkParametersForPowerSupply();
                        View.SetNetworkParameters(ipAddress, ipPort);

                        break;
                    }

                    default:
                    {
                        throw new Exception("Неверный код устройства");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageService.ShowExclamation(exception.Message);
            }
        }

        /// <summary>
        ///     Override event shown form
        /// </summary>
        private void ViewOnShowingForm()
        {
            View.SetDevicesCombobox(0);
            View.SetLogLevelCombobox(SoftwareSettingsModel.GetCurrentLogLevel());
        }

        #endregion

        #endregion
    }
}