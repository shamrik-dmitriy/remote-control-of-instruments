using System;
using Core.Devices.SMB100A;

namespace ServiceDesktop.Presenter.Views
{
    public interface IServiceDesktopMainForm
    {
        /// <summary>
        ///     Override show event form
        /// </summary>
        event EventHandler ShowingForm;

        /// <summary>
        ///     Override closing event form
        /// </summary>
        event EventHandler ClosingForm;

        /// <summary>
        ///     Event for set voltage
        /// </summary>
        event Action<string, string> GetVoltage;

        /// <summary>
        ///     Event for set amperage
        /// </summary>
        event Action<string, string> GetAmperage;

        /// <summary>
        ///     Event for set frequency
        /// </summary>
        event Action<string, string, string> GetFrequency;

        /// <summary>
        ///     Event for set pow
        /// </summary>
        event Action<string, string, string> GetPow;

        /// <summary>
        ///     Event for set pulse width
        /// </summary>
        event Action<string, string, string> GetPulseWidth;

        /// <summary>
        ///     Event for set pulse period
        /// </summary>
        event Action<string, string, string> GetPulsePeriod;

        /// <summary>
        ///     Event for set deviation
        /// </summary>
        event Action<string, string, string> GetDeviation;

        /// <summary>
        ///     Event for set pulse delay
        /// </summary>
        event Action<string, string, string> GetPulseDelay;

        /// <summary>
        ///     Event for changed power control state
        /// </summary>
        event Action<bool> GetPowerSupplyPowerControl;

        /// <summary>
        ///     Event for changed rf control state
        /// </summary>
        event Action<bool> GetSignalGeneratorRfControl;

        /// <summary>
        ///     Event for changed modulation control
        /// </summary>
        event Action<bool> GetSignalGeneratorModulationControl;

        /// <summary>
        ///     Event for reset signal generator
        /// </summary>
        event Action GetSignalGeneratorReset;

        /// <summary>
        ///     Event for select combobox value for frequency
        /// </summary>
        event Action<Smb100A.Frequency> SelectFrequencySignalGenerator;

        /// <summary>
        /// Event for select combobox value for pow
        /// </summary>
        event Action<Smb100A.Pow> SelectPowSignalGenerator;

        /// <summary>
        ///     Event for select combobox value for deviation
        /// </summary>
        event Action<Smb100A.Deviation> SelectDeviationSignalGenerator;

        /// <summary>
        ///     Event for select combobox value for pulse delay
        /// </summary>
        event Action<Smb100A.PulseDelay> SelectPulseDelaySignalGenerator;

        /// <summary>
        ///     Event for select combobox value for pulse period
        /// </summary>
        event Action<Smb100A.PulsePeriod> SelectPulsePeriodSignalGenerator;

        /// <summary>
        ///     Event for select combobox value for pulse width
        /// </summary>
        event Action<Smb100A.PulseWidth> SelectPulseWidthSignalGenerator;

        /// <summary>
        ///     Event for select combobox value for select mode
        /// </summary>
        event Action<Smb100A.SelectMode> SelectModeSignalGenerator;

        /// <summary>
        ///     Event for check connection power supply
        /// </summary>
        event Action CheckConnectionPowerSupply;

        /// <summary>
        ///     Event for check connection signal generator
        /// </summary>
        event Action CheckConnectionSignalGenerator;

        void SetErrorField(string fieldName);

        /// <summary>
        ///     Set value of index for all combobox
        /// </summary>
        /// <param name="number">Selected value</param>
        void SetAllCombobox(int number);

        /// <summary>
        ///     Set Enabled property groupbox signal generator
        /// </summary>
        /// <param name="isEnabled">True - active, False - unactive</param>
        void SetEnabledGroupBoxSignalGenerator(bool isEnabled);

        /// <summary>
        ///     Set Enabled property groupbox power supply
        /// </summary>
        /// <param name="isEnabled">True - active, False - unactive</param>
        void SetEnabledGroupBoxPowerSupply(bool isEnabled);

        /// <summary>
        ///     Changed UI in tool strip check connection power supply
        /// </summary>
        /// <param name="statePowerSupply">True - element is active, False - element is unactive</param>
        void SetStateButtonCheckPowerSupply(bool statePowerSupply);

        /// <summary>
        ///     Changed UI in tool strip check connection signal generator
        /// </summary>
        /// <param name="stateSignalGenerator">True - element is active, False - element is unactive</param>
        void SetStateButtonCheckSignalGenerator(bool stateSignalGenerator);

        /// <summary>
        ///     Set value of properties in inside class
        /// </summary>
        /// <param name="fieldName">Name of property</param>
        /// <param name="fieldValue">Value for property</param>
        void SetOutputData(string fieldName, string fieldValue);

        /// <summary>
        ///     Set value of properties in inside class
        /// </summary>
        /// <param name="fieldName">Name of property</param>
        /// <param name="fieldState">Value for property</param>
        void SetOutputData(string fieldName, bool fieldState);

        /// <summary>
        ///     Running software and Show form
        /// </summary>
        void Show();

        void Close();
    }
}