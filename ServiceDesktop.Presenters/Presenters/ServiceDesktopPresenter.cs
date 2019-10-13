using System;
using Core.Devices.N5746A;
using Core.Devices.SMB100A;
using ServiceDesktop.Models.ApplicationModels.MainForm;
using ServiceDesktop.Presenter.Common;
using ServiceDesktop.Presenter.Common.AbstractClasses;
using ServiceDesktop.Presenter.Common.Interfaces;
using ServiceDesktop.Presenter.Views;
using ServiceDesktop.Services.MessageServices;

namespace ServiceDesktop.Presenter.Presenters
{
    public class ServiceDesktopPresenter : BasePresenter<IMainView>
    {
        #region Private Properties

        /// <summary>
        ///     Instance of interface model
        /// </summary>
        private IServiceDesktopModel ServiceDesktopModel { get; set; }

        /// <summary>
        ///     Instance of interface message services
        /// </summary>
        private IMessageService MessageService { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Presenter of main form
        /// </summary>
        /// <param name="applicationController"></param>
        /// <param name="mainMainForm">Instance of interface main form</param>
        /// <param name="serviceDesktopModel">Instance of interface model</param>
        /// <param name="messageService">Instance of interface message services</param>
        public ServiceDesktopPresenter(IApplicationController applicationController,
            IMainView mainMainForm, IServiceDesktopModel serviceDesktopModel,
            IMessageService messageService) : base(applicationController, mainMainForm)
        {
            ServiceDesktopModel = serviceDesktopModel;
            MessageService = messageService;

            SubscribeEvents();
        }

        #endregion

        #region Private Methods

        #region Control Subscribe Events

        /// <summary>
        ///     Subscribe of events
        /// </summary>
        private void SubscribeEvents()
        {
            View.ShowingForm += View_ShowingForm;
            View.ClosingForm += ViewOnClosingForm;

            View.GetVoltage += ViewOnGetVoltage;
            View.GetAmperage += ViewOnGetAmperage;
            View.GetFrequency += ViewOnGetFrequency;
            View.GetPow += ViewOnGetPow;
            View.GetPulseWidth += ViewOnGetPulseWidth;
            View.GetPulsePeriod += ViewOnGetPulsePeriod;
            View.GetDeviation += ViewOnGetDeviation;
            View.GetPulseDelay += ViewOnGetPulseDelay;

            View.SelectFrequencySignalGenerator +=
                ViewOnSelectFrequencySignalGenerator;
            View.SelectPowSignalGenerator += ViewOnSelectPowSignalGenerator;
            View.SelectPulseWidthSignalGenerator +=
                ViewOnSelectPulseWidthSignalGenerator;
            View.SelectPulsePeriodSignalGenerator +=
                ViewOnSelectPulsePeriodSignalGenerator;
            View.SelectDeviationSignalGenerator +=
                ViewOnSelectDeviationSignalGenerator;
            View.SelectPulseDelaySignalGenerator +=
                ViewOnSelectPulseDelaySignalGenerator;

            View.GetPowerSupplyPowerControl += ViewOnGetPowerSupplyPowerControl;
            View.GetSignalGeneratorRfControl += ViewOnGetSignalGeneratorRfControl;
            View.GetSignalGeneratorModulationControl +=
                ViewOnGetSignalGeneratorModulationControl;

            ServiceDesktopModel.GetDataPowerSupplyComplete += ServiceDesktopModelOnGetDataPowerSupplyComplete;
            ServiceDesktopModel.GetDataSignalGeneratorComplete += ServiceDesktopModelOnGetDataSignalGeneratorComplete;
            ServiceDesktopModel.GetStateConnectionSignalGenerator +=
                ServiceDesktopModelOnGetStateConnectionSignalGenerator;
            ServiceDesktopModel.GetStateConnectionPowerSupply += ServiceDesktopModelOnGetStateConnectionPowerSupply;

            View.CheckConnectionPowerSupply += ViewOnCheckConnectionPowerSupply;
            View.CheckConnectionSignalGenerator +=
                ViewOnCheckConnectionSignalGenerator;

            View.CallAboutSoftware += ViewOnCallAboutSoftware;
            View.CallSoftwareSettings += ViewOnCallSoftwareSettings;
        }

        /// <summary>
        ///     Get connection state power supply
        /// </summary>
        /// <returns>True - power supply is connection, False - power supply is not connection</returns>
        private bool ServiceDesktopModelOnGetStateConnectionPowerSupply()
        {
            /*  var deviceInit = new DevicesInitialization(DevicesInitialization.Devices.SignalGenerator);
              deviceInit.ShowDialog();
              return deviceInit.StatusSignalGenerator;*/
            return true;
        }

        /// <summary>
        ///     Get connection state signal generator
        /// </summary>
        /// <returns>True - signal generator is connection, False - signal generator is not connection</returns>
        private bool ServiceDesktopModelOnGetStateConnectionSignalGenerator()
        {
            return true;
            /*  var deviceInit = new DevicesInitialization(DevicesInitialization.Devices.PowerSupply);
              deviceInit.ShowDialog();
              return deviceInit.StatusPowerSupply;*/
        }

        /// <summary>
        ///     Unsubscribe of events
        /// </summary>
        private void UnSubscribeEvents()
        {
            View.ShowingForm -= View_ShowingForm;
            View.ClosingForm -= ViewOnClosingForm;

            View.GetVoltage -= ViewOnGetVoltage;
            View.GetAmperage -= ViewOnGetAmperage;
            View.GetFrequency -= ViewOnGetFrequency;
            View.GetPow -= ViewOnGetPow;
            View.GetPulseWidth -= ViewOnGetPulseWidth;
            View.GetPulsePeriod -= ViewOnGetPulsePeriod;
            View.GetDeviation -= ViewOnGetDeviation;
            View.GetPulseDelay -= ViewOnGetPulseDelay;

            View.SelectFrequencySignalGenerator -=
                ViewOnSelectFrequencySignalGenerator;
            View.SelectPowSignalGenerator -= ViewOnSelectPowSignalGenerator;
            View.SelectPulseWidthSignalGenerator -=
                ViewOnSelectPulseWidthSignalGenerator;
            View.SelectPulsePeriodSignalGenerator -=
                ViewOnSelectPulsePeriodSignalGenerator;
            View.SelectDeviationSignalGenerator -=
                ViewOnSelectDeviationSignalGenerator;
            View.SelectPulseDelaySignalGenerator -=
                ViewOnSelectPulseDelaySignalGenerator;

            View.GetPowerSupplyPowerControl -= ViewOnGetPowerSupplyPowerControl;
            View.GetSignalGeneratorRfControl -= ViewOnGetSignalGeneratorRfControl;
            View.GetSignalGeneratorModulationControl -=
                ViewOnGetSignalGeneratorModulationControl;

            ServiceDesktopModel.GetDataPowerSupplyComplete -= ServiceDesktopModelOnGetDataPowerSupplyComplete;
            ServiceDesktopModel.GetDataSignalGeneratorComplete -= ServiceDesktopModelOnGetDataSignalGeneratorComplete;
            ServiceDesktopModel.GetStateConnectionSignalGenerator -=
                ServiceDesktopModelOnGetStateConnectionSignalGenerator;
            ServiceDesktopModel.GetStateConnectionPowerSupply -= ServiceDesktopModelOnGetStateConnectionPowerSupply;

            View.CheckConnectionPowerSupply -= ViewOnCheckConnectionPowerSupply;
            View.CheckConnectionSignalGenerator -=
                ViewOnCheckConnectionSignalGenerator;

            View.CallAboutSoftware -= ViewOnCallAboutSoftware;
            View.CallSoftwareSettings -= ViewOnCallSoftwareSettings;
        }

        #endregion

        #region Form Actions

        /// <summary>
        ///     Override event closing forms
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ViewOnClosingForm(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    ServiceDesktopModel.DestroyOutputThreadSignalGenerator();
                }
                catch (Smb100AException smb100AException)
                {
                    MessageService.ShowError(smb100AException.Message,
                        "Error to finalization work with signal generator");
                }

                try
                {
                    ServiceDesktopModel.DestroyOutputThreadPowerSupply();
                }
                catch (N5746AException n5746AException)
                {
                    MessageService.ShowError(n5746AException.Message,
                        "Error to finalization work power supply");
                }
            }
            catch (Exception exception)
            {
                MessageService.ShowError(exception.Message);
            }
        }

        /// <summary>
        ///     Override event shown form
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void View_ShowingForm(object sender, System.EventArgs e)
        {
            View.SetAllCombobox(0);
            try
            {
                SetUiSignalGenerator(ServiceDesktopModel.GetStateSignalGenerator());

                SetUiPowerSupply(ServiceDesktopModel.GetStatePowerSupply());
            }
            catch (Exception exception)
            {
                MessageService.ShowError(exception.Message);
            }
        }

        /// <summary>
        ///     Called form software settings
        /// </summary>
        private void ViewOnCallSoftwareSettings()
        {
            Controller.Run<SoftwareSettingsPresenter>();
        }

        /// <summary>
        ///     Called form about software
        /// </summary>
        private void ViewOnCallAboutSoftware()
        {
            Controller.Run<AboutSoftwarePresenter>();
        }

        #endregion

        #region Signal Generator

        #region Events Form

        #region Buttons

        /// <summary>
        ///     Control RF output
        /// </summary>
        /// <param name="state">True - Turn on (Turned off), False - Turn off (turned on)</param>
        private void ViewOnGetSignalGeneratorRfControl(bool state)
        {
            ServiceDesktopModel.SetSignalGeneratorRfControl(state);
        }

        /// <summary>
        ///     Control power output
        /// </summary>
        /// <param name="state">True - Turn on (Turned off), False - Turn off (turned on)</param>
        private void ViewOnGetSignalGeneratorModulationControl(bool state)
        {
            ServiceDesktopModel.SetSignalGeneratorModulationControl(state);
        }

        /// <summary>
        ///     Processing set frequency
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ViewOnGetFrequency(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //     View.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pow
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ViewOnGetPow(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        View.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pulse width
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ViewOnGetPulseWidth(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        View.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pulse period
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ViewOnGetPulsePeriod(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        View.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set deviation
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ViewOnGetDeviation(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        View.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pulse delay
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ViewOnGetPulseDelay(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        View.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Checked connection with signal generator
        /// </summary>
        private void ViewOnCheckConnectionSignalGenerator()
        {
            SetUiSignalGenerator(ServiceDesktopModelOnGetStateConnectionSignalGenerator());
        }

        #endregion

        #region Comboboxes

        /// <summary>
        ///     Processing selection selector of frequency
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ViewOnSelectFrequencySignalGenerator(Smb100A.Frequency selector)
        {
            ServiceDesktopModel.FrequencySelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pow
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ViewOnSelectPowSignalGenerator(Smb100A.Pow selector)
        {
            ServiceDesktopModel.PowSelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pulse width
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ViewOnSelectPulseWidthSignalGenerator(Smb100A.PulseWidth selector)
        {
            ServiceDesktopModel.PulseWidthSelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pulse delay
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ViewOnSelectPulseDelaySignalGenerator(Smb100A.PulseDelay selector)
        {
            ServiceDesktopModel.PulseDelaySelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of deviation
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ViewOnSelectDeviationSignalGenerator(Smb100A.Deviation selector)
        {
            ServiceDesktopModel.DeviationSelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pulse period
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ViewOnSelectPulsePeriodSignalGenerator(Smb100A.PulsePeriod selector)
        {
            ServiceDesktopModel.PulsePeriodSelector = selector;
        }

        #endregion

        #endregion

        #region Events on Model

        /// <summary>
        ///     Processing events of Model of complete data output for signal generator
        /// </summary>
        private void ServiceDesktopModelOnGetDataSignalGeneratorComplete()
        {
            View.SetOutputData("FrequencyOutput", ServiceDesktopModel.OutputFrequency.ToString());
            View.SetOutputData("PowOutput", ServiceDesktopModel.OutputPow.ToString());
            View.SetOutputData("PulseWidthOutput", ServiceDesktopModel.OutputPulseWidth.ToString());
            View.SetOutputData("PulsePeriodOutput", ServiceDesktopModel.OutputPulsePeriod.ToString());
            View.SetOutputData("DeviationOutput",
                ServiceDesktopModel.OutputPulseDeviation.ToString());
            View.SetOutputData("PulseDelayOutput", ServiceDesktopModel.OutputPulseDelay.ToString());

            View.SetOutputData("OutControlSignalGeneratorRf", ServiceDesktopModel.OutputRfState);
            View.SetOutputData("OutControlSignalGeneratorModulation",
                ServiceDesktopModel.OutputModulationState);
        }

        #endregion

        #endregion

        #region Power Supply

        #region Events Form

        #region Buttons

        /// <summary>
        ///     Control power output
        /// </summary>
        /// <param name="state">True - Turn on (Turned off), False - Turn off (Turned on)</param>
        private void ViewOnGetPowerSupplyPowerControl(bool state)
        {
            ServiceDesktopModel.SetPowerSupplyPowerControl(state);
        }

        /// <summary>
        ///     Processing set maximal amperage
        /// </summary>
        /// <param name="nameField">Value of name field</param>
        /// <param name="valueField">Value of field</param>
        private void ViewOnGetAmperage(string nameField, string valueField)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField))
            {
                ServiceDesktopModel.SendToDevice(Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList
                    .PowerSupply);
            }
            else
            {
                //        View.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set voltage
        /// </summary>
        /// <param name="nameField">Value of name field</param>
        /// <param name="valueField">Value of field</param>
        private void ViewOnGetVoltage(string nameField, string valueField)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField))
            {
                ServiceDesktopModel.SendToDevice(Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList
                    .PowerSupply);
            }
            else
            {
                //        View.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Checked connection with power supply
        /// </summary>
        private void ViewOnCheckConnectionPowerSupply()
        {
            SetUiPowerSupply(ServiceDesktopModelOnGetStateConnectionPowerSupply());
        }

        #endregion

        #endregion

        #region Events on Model

        /// <summary>
        ///     Processing events of Model of complete data output for power supply
        /// </summary>
        private void ServiceDesktopModelOnGetDataPowerSupplyComplete()
        {
            View.SetOutputData("VoltageConstAmperageOutput",
                ServiceDesktopModel.OutputVoltage.ToString());
            View.SetOutputData("AmperageOutput", ServiceDesktopModel.OutputAmperage.ToString());
            View.SetOutputData("MaxAmperageConsumptionOutput",
                ServiceDesktopModel.OutputMaxAmperage.ToString());
            View.SetOutputData("OutControlPowerSupply",
                ServiceDesktopModel.OutputOutState);
        }

        #endregion

        #endregion

        #region Helper UI Methods

        /// <summary>
        ///     Set UI Signal Generator elements on active/unactive
        /// </summary>
        /// <param name="stateSignalGenerator">State Signal Generator</param>
        private void SetUiSignalGenerator(bool stateSignalGenerator)
        {
            try

            {
                if (stateSignalGenerator)
                {
                    View.SetEnabledGroupBoxSignalGenerator(false);
                    View.SetEnabledGroupBoxSignalGenerator(true);
                    ServiceDesktopModel.CreateInstanceSignalGenerator();
                    ServiceDesktopModel.CreateOutputThreadSignalGenerator();
                }
                else
                {
                    View.SetEnabledGroupBoxSignalGenerator(true);
                    View.SetEnabledGroupBoxSignalGenerator(false);
                }
            }
            catch (Smb100AException smb100AException)
            {
                MessageService.ShowError(smb100AException.Message,
                    "Error to work with signal generator");
            }
        }

        /// <summary>
        ///     Set UI Power Supply elements on active/unactive
        /// </summary>
        /// <param name="statePowerSupply">State Power Supply</param>
        private void SetUiPowerSupply(bool statePowerSupply)
        {
            try
            {
                if (statePowerSupply)
                {
                    View.SetStateButtonCheckPowerSupply(false);
                    View.SetEnabledGroupBoxPowerSupply(true);
                    ServiceDesktopModel.CreateInstancePowerSupply();
                    ServiceDesktopModel.CreateOutputThreadPowerSupply();
                }
                else
                {
                    View.SetStateButtonCheckPowerSupply(true);
                    View.SetEnabledGroupBoxPowerSupply(false);
                }
            }
            catch (N5746AException n5746AException)
            {
                MessageService.ShowError(n5746AException.Message,
                    "Error to work with power supply");
            }
        }

        #endregion

        #endregion

        #region Public Methods

        /// <summary>
        ///     Running Software
        /// </summary>
        public void Run()
        {
            View.Show();
        }

        #endregion
    }
}