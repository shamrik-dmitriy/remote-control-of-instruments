using System;
using Core.Devices.SMB100A;

namespace ServiceDesktop.Models.ApplicationModels.MainForm
{
    public interface IServiceDesktopModel
    {
        #region Message

        string ErrorValidatingMessage { get; set; }

        #endregion

        #region Signal Generator

        #region Events and Properties

        /// <summary>
        ///     Event complete data from signal generator
        /// </summary>
        event Action GetDataSignalGeneratorComplete;

        /// <summary>
        ///     Event with return bool get state connection signal generator    
        /// </summary>
        event Func<bool> GetStateConnectionSignalGenerator;

        /// <summary>
        ///     Rf output state
        /// </summary>
        bool OutputRfState { get; set; }

        /// <summary>
        ///     Power output state
        /// </summary>
        bool OutputModulationState { get; set; }

        /// <summary>
        ///     Frequency value, read from signal generator
        /// </summary>
        double OutputFrequency { get; set; }

        /// <summary>
        ///     Pow value, read from signal generator
        /// </summary>
        double OutputPow { get; set; }

        /// <summary>
        ///     Pulse period value, read from signal generator
        /// </summary>
        double OutputPulsePeriod { get; set; }

        /// <summary>
        ///     Pulse delay value, read from signal generator
        /// </summary>
        double OutputPulseDelay { get; set; }

        /// <summary>
        ///     Pulse width value, read from signal generator
        /// </summary>
        double OutputPulseWidth { get; set; }

        /// <summary>
        ///     Pulse deviation value, read from signal generator
        /// </summary>
        double OutputPulseDeviation { get; set; }

        /// <summary>
        ///     Value of selector frequency
        /// </summary>
        Smb100A.Frequency FrequencySelector { get; set; }

        /// <summary>
        ///     Value of selector pow
        /// </summary>
        Smb100A.Pow PowSelector { get; set; }

        /// <summary>
        ///     Value of selector pulse width
        /// </summary>
        Smb100A.PulseWidth PulseWidthSelector { get; set; }

        /// <summary>
        ///     Value of selector pulse period
        /// </summary>
        Smb100A.PulsePeriod PulsePeriodSelector { get; set; }

        /// <summary>
        ///     Value of selector deviation
        /// </summary>
        Smb100A.Deviation DeviationSelector { get; set; }

        /// <summary>
        ///     Value of selector pulse delay
        /// </summary>
        Smb100A.PulseDelay PulseDelaySelector { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Get state of signal generator
        /// </summary>
        /// <returns>True - Signal generator is access done, False - Signal generator is access denied</returns>
        bool GetStateSignalGenerator();

        /// <summary>
        ///     Create instance of signal generator
        /// </summary>
        void CreateInstanceSignalGenerator();

        /// <summary>
        ///     Create Task exchange data for output from signal generator
        /// </summary>
        void CreateOutputThreadSignalGenerator();

        /// <summary>
        ///     Task exchange data for output from signal generator stopped
        /// </summary>
        void DestroyOutputThreadSignalGenerator();

        /// <summary>
        ///     control Rf-output
        /// </summary>
        /// <param name="state">True - Turn on (Turned off), False - Turn off (Turned on)</param>
        void SetSignalGeneratorRfControl(bool state);

        /// <summary>
        ///     control modulation state
        /// </summary>
        /// <param name="state">True - Turn on (Turned off), False - Turn off (Turned on)</param>
        void SetSignalGeneratorModulationControl(bool state);

        #endregion

        #endregion

        #region Power Supply

        #region Events and Properties

        /// <summary>
        ///     Event of complete data from power supply
        /// </summary>
        event Action GetDataPowerSupplyComplete;

        /// <summary>
        ///     Event with return bool get state connection power supply    
        /// </summary>
        event Func<bool> GetStateConnectionPowerSupply;

        /// <summary>
        ///     State power output
        /// </summary>
        bool OutputOutState { get; set; }

        /// <summary>
        ///     Value of voltage, read from power supply
        /// </summary>
        double OutputVoltage { get; set; }

        /// <summary>
        ///     Value of amperage, read from power supply
        /// </summary>
        double OutputAmperage { get; set; }

        /// <summary>
        ///     Value of maximal current, read from power supply
        /// </summary>
        double OutputMaxAmperage { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Get state of power supply
        /// </summary>
        /// <returns>True - power supply is access done, False - power supply is access denied</returns>
        bool GetStatePowerSupply();

        /// <summary>
        ///     Create instance of power supply
        /// </summary>
        void CreateInstancePowerSupply();

        /// <summary>
        ///     Create and running Task for exchange data output from power supply
        /// </summary>
        void CreateOutputThreadPowerSupply();

        /// <summary>
        ///     Task for exchange data output from power supply stopped
        /// </summary>
        void DestroyOutputThreadPowerSupply();

        /// <summary>
        ///     Control power output
        /// </summary>
        /// <param name="state">True - Turn on (Turned off), False - Turn off (Turned on)</param>
        void SetPowerSupplyPowerControl(bool state);

        #endregion

        #endregion

        /// <summary>
        ///     Validating form field with/without analysis selector type
        ///     and writing result from current value
        /// </summary>
        /// <param name="nameField">Value of name field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="comboboxValue">Value of selector, default = null</param>
        /// <returns>True - data is valid, complete for send data to device, False - data is not valid</returns>
        bool Validate(string nameField, string valueField, string comboboxValue = null);

        /// <summary>
        ///     Send parameters to device
        /// </summary>
        /// <param name="device">Device</param>
        /// <param name="valueSelector">Value of selector</param>
        void SendToDevice(ServiceDesktopModel.DeviceList device, string valueSelector = null);
    }
}