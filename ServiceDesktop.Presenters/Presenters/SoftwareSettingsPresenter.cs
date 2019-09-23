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

        private IMessageService MessageService { get; set; }

        private ISoftwareSettingsModel SoftwareSettingsModel { get; set; }

        #endregion

        public SoftwareSettingsPresenter(IApplicationController controller, IMessageService messageService,
            ISoftwareSettingsView view) : base(
            controller, view)
        {
            MessageService = messageService;

            SoftwareSettingsModel = new SoftwareSettingsModel();

            SubscribeEvenets();
        }

        private void SubscribeEvenets()
        {
            View.GetDevicesData += ViewOnGetDevicesData;
            View.GeLogLevels += ViewOnGeLogLevels;

            View.ShowingForm += ViewOnShowingForm;
            View.ChangeDevice += ViewOnChangeDevice;
            View.ChangeLogLevel += ViewOnChangeLogLevel;
            View.SaveDeviceSetting += ViewOnSaveDeviceSetting;
        }

        private void ViewOnSaveDeviceSetting(int typeDevice, string ipAddress, string port)
        {
            SoftwareSettingsModel.SaveDeviceSettings(typeDevice, ipAddress, port);
        }

        private object ViewOnGeLogLevels()
        {
            return SoftwareSettingsModel.GetLogLevels();
        }

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
                        var settings = SoftwareSettingsModel.GetNetworkParametersForSignalGenerator();
                        View.SetNetworkParameters(settings.Item1, settings.Item2);
                        break;
                    }

                    case 1:
                    {
                        var settings = SoftwareSettingsModel.GetNetworkParametersForPowerSupply();
                        View.SetNetworkParameters(settings.Item1, settings.Item2);

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

        #region Form Events

        #endregion
    }
}