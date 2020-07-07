using System;
using Core.Devices.N5746A;
using RCLD.Models.ApplicationModels.MainForm;
using RCLD.Presenter.Common;
using RCLD.Presenter.Views;
using Services.MessagesServices.MessageBoxServices;

namespace RCLD.Presenter.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        #region Private Properties

        /// <summary>
        ///     Instance of interface main form
        /// </summary>
        private IMainView MainView { get; }

        /// <summary>
        ///     Instance of interface model
        /// </summary>
        private IMainModel MainModel { get; }

        /// <summary>
        ///     Instance of interface message services
        /// </summary>
        private IMessageBoxService MessageBoxService { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Presenter of main form, subscribe events
        /// </summary>
        /// <param name="mainView">Instance of interface main form</param>
        /// <param name="mainModel">Instance of interface model</param>
        /// <param name="messageBoxService">Instance of interface message services</param>
        public MainPresenter(IMainView mainView,
            IMainModel mainModel, IMessageBoxService messageBoxService)
        {
            MainView = mainView;
            MainModel = mainModel;
            MessageBoxService = messageBoxService;

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
            MainView.ShowingForm += ServiceDesktopMainForm_ShowingForm;
            MainView.ClosingForm += ServiceDesktopMainFormOnClosingForm;

            MainView.GetVoltage += ServiceDesktopMainFormOnGetVoltage;
            MainView.GetAmperage += ServiceDesktopMainFormOnGetAmperage;
            MainView.GetFrequency += ServiceDesktopMainFormOnGetFrequency;
            MainView.GetPow += ServiceDesktopMainFormOnGetPow;
            MainView.GetPulseWidth += ServiceDesktopMainFormOnGetPulseWidth;
            MainView.GetPulsePeriod += ServiceDesktopMainFormOnGetPulsePeriod;
            MainView.GetDeviation += ServiceDesktopMainFormOnGetDeviation;
            MainView.GetPulseDelay += ServiceDesktopMainFormOnGetPulseDelay;

            MainView.SelectFrequencySignalGenerator +=
                ServiceDesktopMainFormOnSelectFrequencySignalGenerator;
            MainView.SelectPowSignalGenerator += ServiceDesktopMainFormOnSelectPowSignalGenerator;
            MainView.SelectPulseWidthSignalGenerator +=
                ServiceDesktopMainFormOnSelectPulseWidthSignalGenerator;
            MainView.SelectPulsePeriodSignalGenerator +=
                ServiceDesktopMainFormOnSelectPulsePeriodSignalGenerator;
            MainView.SelectDeviationSignalGenerator +=
                ServiceDesktopMainFormOnSelectDeviationSignalGenerator;
            MainView.SelectPulseDelaySignalGenerator +=
                ServiceDesktopMainFormOnSelectPulseDelaySignalGenerator;

            MainView.GetPowerSupplyPowerControl += ServiceDesktopMainFormOnGetPowerSupplyPowerControl;
            MainView.GetSignalGeneratorRfControl += ServiceDesktopMainFormOnGetSignalGeneratorRfControl;
            MainView.GetSignalGeneratorModulationControl +=
                ServiceDesktopMainFormOnGetSignalGeneratorModulationControl;

            MainModel.GetDataPowerSupplyComplete += ServiceDesktopModelOnGetDataPowerSupplyComplete;
            MainModel.GetDataSignalGeneratorComplete += ServiceDesktopModelOnGetDataSignalGeneratorComplete;
            MainModel.GetStateConnectionSignalGenerator +=
                ServiceDesktopModelOnGetStateConnectionSignalGenerator;
            MainModel.GetStateConnectionPowerSupply += ServiceDesktopModelOnGetStateConnectionPowerSupply;

            MainView.CheckConnectionPowerSupply += ServiceDesktopMainFormOnCheckConnectionPowerSupply;
            MainView.CheckConnectionSignalGenerator +=
                ServiceDesktopMainFormOnCheckConnectionSignalGenerator;
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
            MainView.ShowingForm -= ServiceDesktopMainForm_ShowingForm;
            MainView.ClosingForm -= ServiceDesktopMainFormOnClosingForm;

            MainView.GetVoltage -= ServiceDesktopMainFormOnGetVoltage;
            MainView.GetAmperage -= ServiceDesktopMainFormOnGetAmperage;
            MainView.GetFrequency -= ServiceDesktopMainFormOnGetFrequency;
            MainView.GetPow -= ServiceDesktopMainFormOnGetPow;
            MainView.GetPulseWidth -= ServiceDesktopMainFormOnGetPulseWidth;
            MainView.GetPulsePeriod -= ServiceDesktopMainFormOnGetPulsePeriod;
            MainView.GetDeviation -= ServiceDesktopMainFormOnGetDeviation;
            MainView.GetPulseDelay -= ServiceDesktopMainFormOnGetPulseDelay;

            MainView.SelectFrequencySignalGenerator -=
                ServiceDesktopMainFormOnSelectFrequencySignalGenerator;
            MainView.SelectPowSignalGenerator -= ServiceDesktopMainFormOnSelectPowSignalGenerator;
            MainView.SelectPulseWidthSignalGenerator -=
                ServiceDesktopMainFormOnSelectPulseWidthSignalGenerator;
            MainView.SelectPulsePeriodSignalGenerator -=
                ServiceDesktopMainFormOnSelectPulsePeriodSignalGenerator;
            MainView.SelectDeviationSignalGenerator -=
                ServiceDesktopMainFormOnSelectDeviationSignalGenerator;
            MainView.SelectPulseDelaySignalGenerator -=
                ServiceDesktopMainFormOnSelectPulseDelaySignalGenerator;

            MainView.GetPowerSupplyPowerControl -= ServiceDesktopMainFormOnGetPowerSupplyPowerControl;
            MainView.GetSignalGeneratorRfControl -= ServiceDesktopMainFormOnGetSignalGeneratorRfControl;
            MainView.GetSignalGeneratorModulationControl -=
                ServiceDesktopMainFormOnGetSignalGeneratorModulationControl;

            MainModel.GetDataPowerSupplyComplete -= ServiceDesktopModelOnGetDataPowerSupplyComplete;
            MainModel.GetDataSignalGeneratorComplete -= ServiceDesktopModelOnGetDataSignalGeneratorComplete;
        }

        #endregion

        #region Form Actions

        /// <summary>
        ///     Override event closing forms
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ServiceDesktopMainFormOnClosingForm(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    MainModel.DestroyOutputThreadSignalGenerator();
                }
                catch (Smb100AException smb100AException)
                {
                    MessageBoxService.ShowError(smb100AException.Message,
                        "Error to finalization work with signal generator");
                }

                try
                {
                    MainModel.DestroyOutputThreadPowerSupply();
                }
                catch (N5746AException n5746AException)
                {
                    MessageBoxService.ShowError(n5746AException.Message,
                        "Error to finalization work power supply");
                }
            }
            catch (Exception exception)
            {
                MessageBoxService.ShowError(exception.Message);
            }
        }

        /// <summary>
        ///     Override event shown form
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ServiceDesktopMainForm_ShowingForm(object sender, System.EventArgs e)
        {
            MainView.SetAllCombobox(0);
            try
            {
                SetUiSignalGenerator(MainModel.GetStateSignalGenerator());

                SetUiPowerSupply(MainModel.GetStatePowerSupply());
            }
            catch (Exception exception)
            {
                MessageBoxService.ShowError(exception.Message);
            }
        }

        #endregion

        #region Signal Generator

        #region Events Form

        #region Buttons

        /// <summary>
        ///     Control RF output
        /// </summary>
        /// <param name="state">True - Turn on (Turned off), False - Turn off (turned on)</param>
        private void ServiceDesktopMainFormOnGetSignalGeneratorRfControl(bool state)
        {
            MainModel.SetSignalGeneratorRfControl(state);
        }

        /// <summary>
        ///     Control power output
        /// </summary>
        /// <param name="state">True - Turn on (Turned off), False - Turn off (turned on)</param>
        private void ServiceDesktopMainFormOnGetSignalGeneratorModulationControl(bool state)
        {
            MainModel.SetSignalGeneratorModulationControl(state);
        }

        /// <summary>
        ///     Processing set frequency
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetFrequency(string nameField, string valueField, string valueSelector)
        {
            if (MainModel.Validate(nameField, valueField, valueSelector))
            {
                MainModel.SendToDevice(
                    Models.ApplicationModels.MainForm.MainModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //     MainView.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pow
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetPow(string nameField, string valueField, string valueSelector)
        {
            if (MainModel.Validate(nameField, valueField, valueSelector))
            {
                MainModel.SendToDevice(
                    Models.ApplicationModels.MainForm.MainModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        MainView.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pulse width
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetPulseWidth(string nameField, string valueField, string valueSelector)
        {
            if (MainModel.Validate(nameField, valueField, valueSelector))
            {
                MainModel.SendToDevice(
                    Models.ApplicationModels.MainForm.MainModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        MainView.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pulse period
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetPulsePeriod(string nameField, string valueField, string valueSelector)
        {
            if (MainModel.Validate(nameField, valueField, valueSelector))
            {
                MainModel.SendToDevice(
                    Models.ApplicationModels.MainForm.MainModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        MainView.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set deviation
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetDeviation(string nameField, string valueField, string valueSelector)
        {
            if (MainModel.Validate(nameField, valueField, valueSelector))
            {
                MainModel.SendToDevice(
                    Models.ApplicationModels.MainForm.MainModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        MainView.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pulse delay
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetPulseDelay(string nameField, string valueField, string valueSelector)
        {
            if (MainModel.Validate(nameField, valueField, valueSelector))
            {
                MainModel.SendToDevice(
                    Models.ApplicationModels.MainForm.MainModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        MainView.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Checked connection with signal generator
        /// </summary>
        private void ServiceDesktopMainFormOnCheckConnectionSignalGenerator()
        {
            SetUiSignalGenerator(ServiceDesktopModelOnGetStateConnectionSignalGenerator());
        }

        #endregion

        #region Comboboxes

        /// <summary>
        ///     Processing selection selector of frequency
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectFrequencySignalGenerator(Smb100A.Frequency selector)
        {
            MainModel.FrequencySelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pow
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectPowSignalGenerator(Smb100A.Pow selector)
        {
            MainModel.PowSelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pulse width
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectPulseWidthSignalGenerator(Smb100A.PulseWidth selector)
        {
            MainModel.PulseWidthSelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pulse delay
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectPulseDelaySignalGenerator(Smb100A.PulseDelay selector)
        {
            MainModel.PulseDelaySelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of deviation
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectDeviationSignalGenerator(Smb100A.Deviation selector)
        {
            MainModel.DeviationSelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pulse period
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectPulsePeriodSignalGenerator(Smb100A.PulsePeriod selector)
        {
            MainModel.PulsePeriodSelector = selector;
        }

        #endregion

        #endregion

        #region Events on Model

        /// <summary>
        ///     Processing events of Model of complete data output for signal generator
        /// </summary>
        private void ServiceDesktopModelOnGetDataSignalGeneratorComplete()
        {
            MainView.SetOutputData("FrequencyOutput", MainModel.OutputFrequency.ToString());
            MainView.SetOutputData("PowOutput", MainModel.OutputPow.ToString());
            MainView.SetOutputData("PulseWidthOutput", MainModel.OutputPulseWidth.ToString());
            MainView.SetOutputData("PulsePeriodOutput", MainModel.OutputPulsePeriod.ToString());
            MainView.SetOutputData("DeviationOutput",
                MainModel.OutputPulseDeviation.ToString());
            MainView.SetOutputData("PulseDelayOutput", MainModel.OutputPulseDelay.ToString());

            MainView.SetOutputData("OutControlSignalGeneratorRf", MainModel.OutputRfState);
            MainView.SetOutputData("OutControlSignalGeneratorModulation",
                MainModel.OutputModulationState);
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
        private void ServiceDesktopMainFormOnGetPowerSupplyPowerControl(bool state)
        {
            MainModel.SetPowerSupplyPowerControl(state);
        }

        /// <summary>
        ///     Processing set maximal amperage
        /// </summary>
        /// <param name="nameField">Value of name field</param>
        /// <param name="valueField">Value of field</param>
        private void ServiceDesktopMainFormOnGetAmperage(string nameField, string valueField)
        {
            if (MainModel.Validate(nameField, valueField))
            {
                MainModel.SendToDevice(Models.ApplicationModels.MainForm.MainModel.DeviceList
                    .PowerSupply);
            }
            else
            {
                //        MainView.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set voltage
        /// </summary>
        /// <param name="nameField">Value of name field</param>
        /// <param name="valueField">Value of field</param>
        private void ServiceDesktopMainFormOnGetVoltage(string nameField, string valueField)
        {
            if (MainModel.Validate(nameField, valueField))
            {
                MainModel.SendToDevice(Models.ApplicationModels.MainForm.MainModel.DeviceList
                    .PowerSupply);
            }
            else
            {
                //        MainView.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Checked connection with power supply
        /// </summary>
        private void ServiceDesktopMainFormOnCheckConnectionPowerSupply()
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
            MainView.SetOutputData("VoltageConstAmperageOutput",
                MainModel.OutputVoltage.ToString());
            MainView.SetOutputData("AmperageOutput", MainModel.OutputAmperage.ToString());
            MainView.SetOutputData("MaxAmperageConsumptionOutput",
                MainModel.OutputMaxAmperage.ToString());
            MainView.SetOutputData("OutControlPowerSupply",
                MainModel.OutputOutState);
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
                    MainView.SetEnabledGroupBoxSignalGenerator(false);
                    MainView.SetEnabledGroupBoxSignalGenerator(true);
                    MainModel.CreateInstanceSignalGenerator();
                    MainModel.CreateOutputThreadSignalGenerator();
                }
                else
                {
                    MainView.SetEnabledGroupBoxSignalGenerator(true);
                    MainView.SetEnabledGroupBoxSignalGenerator(false);
                }
            }
            catch (Smb100AException smb100AException)
            {
                MessageBoxService.ShowError(smb100AException.Message,
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
                    MainView.SetStateButtonCheckPowerSupply(false);
                    MainView.SetEnabledGroupBoxPowerSupply(true);
                    MainModel.CreateInstancePowerSupply();
                    MainModel.CreateOutputThreadPowerSupply();
                }
                else
                {
                    MainView.SetStateButtonCheckPowerSupply(true);
                    MainView.SetEnabledGroupBoxPowerSupply(false);
                }
            }
            catch (N5746AException n5746AException)
            {
                MessageBoxService.ShowError(n5746AException.Message,
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
            MainView.Show();
        }

        #endregion
    }
}