using System;
using System.Globalization;
using Core.Exchange.LanExchange;

namespace Core.Devices.SMB100A
{
    /// <summary>
    ///     R&S SMB100A Signal Generator Class
    /// </summary>
    public sealed class Smb100A
    {
        #region Private Members Variable

        /// <summary>
        ///     LAN class instance
        /// </summary>
        private readonly DeviceExchanger _deviceExchanger;

        #endregion

        #region Public Enums

        /// <summary>
        ///     Contains the frequency dimension supported by the signal generator
        /// </summary>
        public enum Frequency
        {
            Hz,
            KHz,
            Mhz,
            Ghz,
        }

        /// <summary>
        ///     Contains the dimension of power supported by the signal generator
        /// </summary>
        public enum Pow
        {
            Dbm,
            DBuV,
            Nv,
            Uv,
            Mv,
            V
        }

        /// <summary>
        ///     Contains the dimension of the pulse duration supported by the signal generator
        /// </summary>
        public enum PulseWidth
        {
            S,
            Ns,
            Ms,
            Us
        }

        /// <summary>
        ///     Contains the dimension of the pulse delay supported by the signal generator
        /// </summary>
        public enum PulseDelay
        {
            S,
            Ns,
            Ms,
            Us
        }

        /// <summary>
        ///     Contains the dimension of the pulse period supported by the signal generator
        /// </summary>
        public enum PulsePeriod
        {
            S,
            Ns,
            Ms,
            Us
        }

        /// <summary>
        ///     Contains the dimension of the pulse deviation supported by the signal generator.
        /// </summary>
        public enum Deviation
        {
            Hz,
            KHz,
            MHz
        }

        /// <summary>
        ///     Contains the types of modes supported by the signal generator
        /// </summary>
        public enum SelectMode
        {
            Norm,
            Lno,
            Hdev
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor R&S SMB100A
        /// </summary>
        /// <param name="ipAddress">IP address of the device</param>
        /// <param name="ipPort">Device port</param>
        public Smb100A(string ipAddress, int ipPort)
        {
            try
            {
                ApplicationModel.Logger.Debug("Initializing LAN Signal Generator exchange");

                _deviceExchanger = new DeviceExchanger(ipAddress, ipPort);
                ApplicationModel.Logger.Debug("LAN exchange with Signal Generator initialized");
            }
            catch (Exception smb100AException)
            {
                throw new Smb100AException("Failed to initialize LAN exchange for signal generator: " +
                                           smb100AException.Message);
            }
        }

        #endregion

        #region Public Methods

        #region Identification, Power On/Off, Reset, Test

        /// <summary>
        ///     Get ОРС
        /// </summary>
        /// <returns>True - OPC Complete, False - OPC Not complete</returns>
        public bool Opc()
        {
            try
            {
                return _deviceExchanger.SendRequestDataInt("*OPC?;") == 1;
            }
            catch (Smb100AException smb100AException)
            {
                ApplicationModel.Logger.Error(": " + smb100AException.Message);
                throw new Smb100AException(": " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Device identification
        /// </summary>
        /// <returns>Device Identifier String</returns>
        public string Identification()
        {
            try
            {
                return _deviceExchanger.SendRequestDataString("*IDN?;");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to identify signal generator source: " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Resets signal generator
        /// </summary>
        public void Reset()
        {
            try
            {
                ApplicationModel.Logger.Debug("Reset signal generator");
                _deviceExchanger.SendDataWithOutReturn("*RST;");
                ApplicationModel.Logger.Debug("Signal generator reset");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to reset the signal generator: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Testing SMB100A
        /// </summary>
        public string Test()
        {
            try
            {
                ApplicationModel.Logger.Debug("Signal Generator Test");
                return _deviceExchanger.SendRequestDataString("*TST?;");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to run signal generator test: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turns on modulation
        /// </summary>
        public void ModulationStateOn()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turn on signal modulation");
                _deviceExchanger.SendDataWithOutReturn(":SOUR:MOD:ALL:STAT ON;");
                ApplicationModel.Logger.Debug("Signal Modulation Enabled");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to enable signal modulation: " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turns off modulation
        /// </summary>
        public void ModulationStateOff()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turn off signal modulation");
                _deviceExchanger.SendDataWithOutReturn(":SOUR:MOD:ALL:STAT OFF;");
                ApplicationModel.Logger.Debug("Signal Modulation Off");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to turn off signal modulation: " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turn on RF output
        /// </summary>
        public void RfOutputStateOn()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turn on RF output");
                _deviceExchanger.SendDataWithOutReturn(":OUTPut:STAT ON;");
                ApplicationModel.Logger.Debug("RF output enabled");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to enable RF output: " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turn off RF output
        /// </summary>
        public void RfOutputStateOff()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turn off RF output");
                _deviceExchanger.SendDataWithOutReturn(":OUTPut:STAT OFF;");
                ApplicationModel.Logger.Debug("Signal RF output Off");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to disable RF output: " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Returns the current modulation state
        /// </summary>
        /// <returns>True - is on, False - is off</returns>
        public bool GetModulationState()
        {
            try
            {
                ApplicationModel.Logger.Debug("Checking the current modulation state");
                return _deviceExchanger.SendRequestDataInt(":MOD:STAT?;") == 1;
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to check the current modulation state: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Requests the current status of the RF output
        /// </summary>
        public bool GetRfOutputState()
        {
            try
            {
                ApplicationModel.Logger.Debug("Check RF output state");
                return _deviceExchanger.SendRequestDataInt(":OUTPut:STAT?;") == 1;
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to check RF output state: " + smb100AException.Message);
            }
        }

        #endregion

        #region Setting radiation parameters

        #region General

        /// <summary>
        ///     Sets the value of the frequency of the output signal in the specified format
        /// </summary>
        /// <param name="freq">Frequency value</param>
        /// <param name="type">Dimension value</param>
        public void SetFreq(double freq, Frequency type = Frequency.Mhz)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the signal frequency to " + freq + " " + type);
                _deviceExchanger.SendDataWithOutReturn(":FREQ " + Convert.ToString(freq) + " " + type + ";");
                ApplicationModel.Logger.Debug("Signal frequency value is set to " + freq + " " + type);
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set signal frequency to " + freq + " " + type + ": " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Sets the value of the output power of the output signal in the specified format
        /// </summary>
        /// <param name="level">Output power value</param>
        /// <param name="type">Dimension value</param>
        public void SetPow(double level, Pow type = Pow.Dbm)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting signal pow to " + level + " " + type);
                _deviceExchanger.SendDataWithOutReturn(
                    ":POW " + Convert.ToString(level, CultureInfo.InvariantCulture).Replace(',', '.') + " " + type +
                    ";");
                ApplicationModel.Logger.Debug("Signal pow value is set to " + level + " " + type);
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set signal pow to " + level + " " + type +
                                           ": " + smb100AException.Message);
            }
        }

        #endregion

        #region Pulse Modulation | Pulse Generator

        /// <summary>
        ///     Sets the polarity of the modulated signal.
        /// </summary>
        public void PulseSetPolarity()
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the polarity of the modulated signal");
                _deviceExchanger.SendDataWithOutReturn(":PULM:POL NORM");
                ApplicationModel.Logger.Debug(
                    "Modulated signal polarity set");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set modulation polarity value " +
                                           ": " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Selects EXT trigger mode for pulse modulation
        /// </summary>
        public void PulseSetTriggerModeExternal()
        {
            try
            {
                ApplicationModel.Logger.Debug("Select trigger mode for pulse modulation");
                _deviceExchanger.SendDataWithOutReturn(":PULM:TRIG:MODE EXT");
                ApplicationModel.Logger.Debug("Pulse modulation trigger mode selected");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to select trigger mode for pulse modulation " +
                                           ": " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Selects the impedance for an external pulse trigger.
        /// </summary>
        public void PulseSetExternalImpedance()
        {
            try
            {
                ApplicationModel.Logger.Debug("Impedance selection for external pulse trigger");
                _deviceExchanger.SendDataWithOutReturn("SOUR:PULM:TRIG:EXT:IMP G10K");
                ApplicationModel.Logger.Debug("Impedance selected for external pulse trigger");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to select impedance for external pulse trigger " +
                                           ": " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Selects the polarity of the output signal. This signal is supported on the PusleExt input.
        /// </summary>
        public void PulseSetPolarityGateSignal()
        {
            try
            {
                ApplicationModel.Logger.Debug("Output polarity selection");
                _deviceExchanger.SendDataWithOutReturn("PULM:TRIG:EXT:GATE:POL NORM");
                ApplicationModel.Logger.Debug("Output polarity selected");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to select output polarity " +
                                           ": " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Sets the polarity of the active slice, applies to the trigger, at the output of PulseExt
        /// </summary>
        public void PulseSetInputSlopPolarity()
        {
            try
            {
                ApplicationModel.Logger.Debug("Установка полярности активного среза в Positive");
                _deviceExchanger.SendDataWithOutReturn("PULM:TRIG:EXT:SLOP POS");
                ApplicationModel.Logger.Debug("The polarity of the active slice is set to Positive");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set polarity of the active slice to Positive " +
                                           ": " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Includes pulse modulation
        /// </summary>
        public void PulseModulationOn()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turn on pulse modulation");
                _deviceExchanger.SendDataWithOutReturn(":PULM:STAT ON;");
                ApplicationModel.Logger.Debug("Pulse Modulation Enabled");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to enable pulse modulation of the signal: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turns off pulse modulation
        /// </summary>
        public void PulseModulationOff()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turn off pulse modulation");
                _deviceExchanger.SendDataWithOutReturn(":PULM:STAT OFF;");
                ApplicationModel.Logger.Debug("Pulse modulation off");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to turn off pulse modulation of the signal: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Returns the state of pulse modulation
        /// </summary>
        /// <returns>True if pulse modulation is enabled, otherwise false</returns>
        public bool GetPulseModulationState()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request for the current state of pulse modulation of a signal");
                return _deviceExchanger.SendRequestDataInt(":PULM:STAT?;") == 1;
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to get the current state of the pulse modulation of the signal: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Selects a source for pulse modulation.
        /// </summary>
        /// <param name="internalOrExternal">True - to select the internal source, false - for the external</param>
        public void PulseModulationSelectInternalSource(bool internalOrExternal = true)
        {
            Tuple<string, string> intOrExtString;
            if (internalOrExternal)
            {
                intOrExtString = new Tuple<string, string>("internal", "INT");
            }
            else
            {
                intOrExtString = new Tuple<string, string>("external", "EXT");
            }

            try
            {
                ApplicationModel.Logger.Debug("Selection " + intOrExtString.Item1 + " signal modulation source");
                _deviceExchanger.SendDataWithOutReturn(":PULM:SOUR " + intOrExtString.Item2 + ";");
                ApplicationModel.Logger.Debug("Selection" + intOrExtString.Item2 + " source completed");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to select " + intOrExtString.Item1 +
                                           " source for modulating the signal: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Sets the pulse generator mode
        /// </summary>
        public void PulseModulationSetSingleMode()
        {
            try
            {
                ApplicationModel.Logger.Debug("Sets the pulse generator mode");
                _deviceExchanger.SendDataWithOutReturn(":PULM:MODE SING;");
                ApplicationModel.Logger.Debug("Pulse generator mode set");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set pulse generator mode: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Sets the pulse duration according to the specified parameters
        /// </summary>
        /// <param name="width">Pulse Duration</param>
        /// <param name="timeType">Dimension type</param>
        public void SetPulseWidth(double width, PulseWidth timeType)
        {
            try
            {
                ApplicationModel.Logger.Debug(
                    "Setting the pulse width of the signal to " + width + " " + timeType);
                _deviceExchanger.SendDataWithOutReturn(":PULM:WIDT " + width + " " + timeType + ";");
                ApplicationModel.Logger.Debug("The value of the pulse duration of the signal is set to " + width + " " +
                                              timeType);
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set signal pulse width to " + width +
                                           " " +
                                           timeType + ": " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Sets the delay between pulses, according to the specified parameters
        /// </summary>
        /// <param name="delay">Delay between pulses</param>
        /// <param name="timeType">Dimension type</param>
        public void SetPulseDelay(double delay, PulseDelay timeType)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the delay between pulses in " + delay + " " + timeType);
                _deviceExchanger.SendDataWithOutReturn(":PULM:DEL " + delay + " " + timeType + ";");
                ApplicationModel.Logger.Debug("The delay between pulses is set to " + delay + " " + timeType);
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set delay between pulses in " + delay + " " +
                                           timeType +
                                           ": " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Sets the number of repetitions for each pair of on / off values.
        ///     The maximum number of repetitions for all pairs of values is 1023 values
        /// </summary>
        /// <param name="num">The value of the number of repetitions</param>
        private void FreqRepeat(int num)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the number of repetitions in " + num);
                _deviceExchanger.SendDataWithOutReturn(":PULM:TRA:REP " + Convert.ToString(num) + ";");
                ApplicationModel.Logger.Debug("The number of repetitions is set to " + num);
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set the number of repetitions in " + num + ": " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Sets the pulse generation period, according to the specified parameters
        /// </summary>
        /// <param name="period">The value of the pulse generation period</param>
        /// <param name="timeType">Dimension type</param>
        public void SetPulsePeriod(double period, PulsePeriod timeType)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the pulse generation period to " + period + " " + timeType);
                _deviceExchanger.SendDataWithOutReturn(":PULM:PER " + period + " " + timeType + ";");
                ApplicationModel.Logger.Debug("The frequency of the pulse generation period is set to " + period + " " +
                                              timeType);
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set pulse generation period to " + period + " " +
                                           timeType +
                                           " : " + smb100AException.Message);
            }
        }

        #endregion

        #region Frequency Modulation | LFOutput

        /// <summary>
        ///     Trun On frequency modulation
        /// </summary>
        public void FrequencyModulationStateOn()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turn on frequency modulation");
                _deviceExchanger.SendDataWithOutReturn(":FM:STAT ON;");
                ApplicationModel.Logger.Debug("Frequency Modulation Enabled");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to enable frequency modulation: " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turns off frequency modulation
        /// </summary>
        public void FrequencyModulationStateOff()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turn off frequency modulation");
                _deviceExchanger.SendDataWithOutReturn(":FM:STAT OFF;");
                ApplicationModel.Logger.Debug("Frequency Modulation Off");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to turn off frequency modulation: " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Returns the frequency modulation state
        /// </summary>
        /// <returns>True if pulse modulation is enabled, otherwise false</returns>
        public bool GetFrequencyModulationState()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request the current state of frequency modulation");
                if (_deviceExchanger.SendRequestDataInt(":FM:STAT?;") == 1)
                {
                    ApplicationModel.Logger.Debug("Frequency Modulation Enabled");
                    return true;
                }

                ApplicationModel.Logger.Debug("Frequency Modulation Disabled");
                return false;
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException(
                    "Failed to fulfill the request for the current state of frequency modulation: " +
                    smb100AException.Message);
            }
        }

        /// <summary>
        ///     Selects as a frequency modulation source LF-gen/LFOutput
        /// </summary>
        public void FmSelectInternalSource()
        {
            try
            {
                ApplicationModel.Logger.Debug("Installation as a source of frequency modulation of the LF generator");
                _deviceExchanger.SendDataWithOutReturn(":FM:SOUR INT;");
                ApplicationModel.Logger.Debug("LF generator installed as a frequency modulation source");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException(
                    "Failed to set the LF generator as a frequency modulation source: " +
                    smb100AException.Message);
            }
        }

        /// <summary>
        ///     Selects Normal mode in frequency modulation.
        /// </summary>
        public void FmSelectNormalMode()
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting Normal mode in frequency modulation");
                _deviceExchanger.SendDataWithOutReturn(":FM:MODE NORM;");
                ApplicationModel.Logger.Debug("The value of Normal mode in the frequency modulation is set");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set Normal Mode value in frequency modulation: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Chooses High Deviation in Frequency Modulation
        /// </summary>
        public void FmSelectHighDeviationMode()
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting High Deviation in Frequency Modulation");
                _deviceExchanger.SendDataWithOutReturn(":FM:MODE HIDEV");
                ApplicationModel.Logger.Debug("Frequency Modulation High Deviation Set");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set High deviation value in frequency modulation: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///    Sets the signal deviation in MHz
        /// </summary>
        /// <param name="dev">The value of deviation is set in the format 5 - 5 mhz</param>
        public void FmDeviationMhz(int dev)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the signal deviation value to" + dev + " mHz");
                _deviceExchanger.SendDataWithOutReturn(":FM:DEV " + dev + " mHz;");
                ApplicationModel.Logger.Debug("Signal deviation value is set to" + dev + " mHz");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set signal deviation value to " + dev +
                                           " mHz: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Sets the signal deviation according to the given parameters
        /// </summary>
        /// <param name="deviation">Fm Deviation</param>
        /// <param name="typeHz">Dimension type</param>
        public void SetFmDeviation(double deviation, Deviation typeHz)
        {
            try
            {
                ApplicationModel.Logger.Debug(
                    "Setting the signal deviation value to " + deviation + " " + typeHz);
                _deviceExchanger.SendRequestDataString(":FM:DEV " + deviation + " " + typeHz + ";");
                ApplicationModel.Logger.Debug("Signal deviation value is set to " + deviation + " " +
                                              typeHz);
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set signal deviation value to " + deviation +
                                           " " +
                                           typeHz + ": " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Sets the signal deviation according to the specified parameters
        /// </summary>
        /// <param name="mode">Pulse Duration</param>
        public void SetFmSelectMode(SelectMode mode)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the signal deviation value to" + mode);
                _deviceExchanger.SendRequestDataDouble(":FM:MODE " + mode + ";");
                ApplicationModel.Logger.Debug("Signal deviation set to" + mode);
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set signal deviation value to " + mode + ": " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turn on LF-output
        /// </summary>
        public void FmLfoStateOn()
        {
            try
            {
                ApplicationModel.Logger.Debug("Enable LF Output");
                _deviceExchanger.SendDataWithOutReturn(":LFO ON;");
                ApplicationModel.Logger.Debug("LF output on");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to enable LF output: " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turn off LF-output
        /// </summary>
        public void FmLfoStateOff()
        {
            try
            {
                ApplicationModel.Logger.Debug("Disable LF Output");
                _deviceExchanger.SendDataWithOutReturn(":LFO OFF;");
                ApplicationModel.Logger.Debug("LF output off");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to turn off LF output: " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Sets the output voltage value at the LF output
        /// </summary>
        /// <param name="volt">The value of voltage</param>
        public void FmlfOutputVoltage(int volt)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the output voltage value at the LF output to " + volt);
                _deviceExchanger.SendDataWithOutReturn(":LFO:VOLT " + volt + " V;");
                ApplicationModel.Logger.Debug("The output voltage value at the LF output is set to " + volt);
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException(
                    "Failed to set output voltage value at output LF to " +
                    volt + ": " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Sets the oscillator frequency for LFO1
        /// </summary>
        /// <param name="hz">Integer Hz</param>
        public void FmlfOutGenFreq(int hz)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the frequency of the LFO1 generator to " + hz);
                _deviceExchanger.SendDataWithOutReturn(":LFO1:FREQ " + hz + " hz;");
                ApplicationModel.Logger.Debug("The frequency of the LFO1 generator is set to" + hz);
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to set generator frequency LFO1 to " + hz +
                                           ": " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Returns LFO Status
        /// </summary>
        /// <returns>True - LFO ON, False - LFO Off</returns>
        public bool FmLfOutState()
        {
            try
            {
                ApplicationModel.Logger.Debug("LFO Status Request");
                return _deviceExchanger.SendRequestDataInt(":LFO:STAT?;") == 1;
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to query for LFO status: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turn On LFO
        /// </summary>
        public void FmlfoStateOn()
        {
            try
            {
                ApplicationModel.Logger.Debug("Enabled LFO");
                _deviceExchanger.SendDataWithOutReturn(":LFO ON;");
                ApplicationModel.Logger.Debug("LFO Enabled");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to turn off LFO: " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turn off LFO 
        /// </summary>
        public void SourceSignalFmlfoStateOff()
        {
            try
            {
                ApplicationModel.Logger.Debug("Disabled LFO");
                _deviceExchanger.SendDataWithOutReturn(":LFO OFF;");
                ApplicationModel.Logger.Debug("LFO Disabled");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to turn off LFO: " + smb100AException.Message);
            }
        }

        #endregion

        #region Phase Modulation

        /// <summary>
        ///     Returns the phase modulation state
        /// </summary>
        /// <returns>True - is On, False - is off</returns>
        public bool GetPhaseModulationState()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request for receiving phase modulation state of a signal");
                return _deviceExchanger.SendRequestDataInt(":PM:STAT?;") == 1;
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException(
                    "The request to obtain the phase modulation state of the signal failed: " +
                    smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turns off phase modulation
        /// </summary>
        public void PhaseModulationStateOff()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turn off phase modulation");
                _deviceExchanger.SendDataWithOutReturn(":PM:STAT OFF;");
                ApplicationModel.Logger.Debug("Signal phase modulation off");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException(
                    "Failed to turn off phase modulation: " + smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turns on phase modulation
        /// </summary>
        public void PhaseModulationStateOn()
        {
            try
            {
                ApplicationModel.Logger.Debug("Enabling Phase Modulation");
                _deviceExchanger.SendDataWithOutReturn(":PM:STAT ON;");
                ApplicationModel.Logger.Debug("Signal Phase Modulation Enabled");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to enable phase modulation of the signal: " +
                                           smb100AException.Message);
            }
        }

        #endregion

        #region Amplitude Modulation

        /// <summary>
        ///     Returns the state of amplitude modulation
        /// </summary>
        /// <returns>True - is On, False - is Off</returns>
        public bool GetAmplitudeModulationState()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request for amplitude modulation state");
                return _deviceExchanger.SendRequestDataInt(":AM:STAT?;") == 1;
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException(
                    "Failed to complete the request for the amplitude modulation state: " +
                    smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turn on amplitude modulation
        /// </summary>
        public void AmplitudeModulationStateOn()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turn on amplitude modulation");
                _deviceExchanger.SendDataWithOutReturn(":AM:STAT ON;");
                ApplicationModel.Logger.Debug("Amplitude Modulation Enabled");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to enable amplitude modulation of the signal: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Turn off amplitude modulation
        /// </summary>
        public void AmplitudeModulationStateOff()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turn off amplitude modulation");
                _deviceExchanger.SendRequestDataString(":AM:STAT OFF;");
                ApplicationModel.Logger.Debug("Amplitude Modulation Off");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to turn off amplitude modulation: " +
                                           smb100AException.Message);
            }
        }

        #endregion

        #endregion

        #region Request and return parameters of the signal generator radiation

        /// <summary>
        ///     Returns power value
        /// </summary>
        /// <returns>Radiation power value in double precision format</returns>
        public double GetPowdBm()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request for radiation power value");
                return _deviceExchanger.SendRequestDataDouble(":POW?;");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to fulfill the request for obtaining the radiation power value: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Returns frequency value
        /// </summary>
        /// <returns>Frequency value in double precision format</returns>
        public double GetFreqMhz()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request for frequency value");
                return _deviceExchanger.SendRequestDataDouble(":FREQ?;");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to query for the frequency value: " +
                                           smb100AException.Message +
                                           ".");
            }
        }

        /// <summary>
        ///     Returns the pulse width
        /// </summary>
        /// <returns>Double Accuracy Pulse Width</returns>
        public double GetPulseWidth()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request for Pulse Width");
                return _deviceExchanger.SendRequestDataDouble(":PULM:WIDT?;");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to complete the request for the pulse width value: " +
                                           smb100AException.Message);
            }
        }

        /// <summary>
        ///     Returns the value of the pulse generation period
        /// </summary>
        /// <returns>Pulse generation period value in double precision format</returns>
        public double GetPulsePeriod()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request for the value of the pulse generation period");
                return _deviceExchanger.SendRequestDataDouble(":PULM:PER?;");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException(
                    "The request to obtain the value of the pulse generation period failed: " +
                    smb100AException.Message);
            }
        }

        /// <summary>
        ///     Returns the value of deviation
        /// </summary>
        /// <returns>Double precision deviation value</returns>
        public double GetFreqDeviation()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request for deviation value");
                return _deviceExchanger.SendRequestDataDouble(":FM:DEV?;");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException("Failed to complete the request for deviation value: " +
                                           smb100AException.Message +
                                           ".");
            }
        }

        /// <summary>
        ///     Returns the delay value between pulses
        /// </summary>
        /// <returns>Double precision delay between pulses</returns>
        public double GetPulseDelay()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request the delay value between pulses");
                return _deviceExchanger.SendRequestDataDouble(":PULM:DEL?;");
            }
            catch (Smb100AException smb100AException)
            {
                throw new Smb100AException(
                    "The request to obtain the delay value between pulses failed: " +
                    smb100AException.Message);
            }
        }

        #endregion

        #endregion
    }
}