using System;
using System.Globalization;
using Core.Exchange.LanExchange;

namespace Core.Devices.SMB100A
{
    /// <summary>
    ///     R&S SMB100A Signal Generator Class
    /// </summary>
    public sealed class Smb100A : IDevices
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
                _deviceExchanger = new DeviceExchanger(ipAddress, ipPort);
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
                _deviceExchanger.SendDataWithOutReturn("*RST;");
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
                _deviceExchanger.SendDataWithOutReturn(":SOUR:MOD:ALL:STAT ON;");
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
                _deviceExchanger.SendDataWithOutReturn(":SOUR:MOD:ALL:STAT OFF;");
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
                _deviceExchanger.SendDataWithOutReturn(":OUTPut:STAT ON;");
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
                _deviceExchanger.SendDataWithOutReturn(":OUTPut:STAT OFF;");
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
                _deviceExchanger.SendDataWithOutReturn(":FREQ " + Convert.ToString(freq) + " " + type + ";");
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
                _deviceExchanger.SendDataWithOutReturn(
                    ":POW " + Convert.ToString(level, CultureInfo.InvariantCulture).Replace(',', '.') + " " + type +
                    ";");
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
                _deviceExchanger.SendDataWithOutReturn(":PULM:POL NORM");
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
                _deviceExchanger.SendDataWithOutReturn(":PULM:TRIG:MODE EXT");
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
                _deviceExchanger.SendDataWithOutReturn("SOUR:PULM:TRIG:EXT:IMP G10K");
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
                _deviceExchanger.SendDataWithOutReturn("PULM:TRIG:EXT:GATE:POL NORM");
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
                _deviceExchanger.SendDataWithOutReturn("PULM:TRIG:EXT:SLOP POS");
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
                _deviceExchanger.SendDataWithOutReturn(":PULM:STAT ON;");
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
                _deviceExchanger.SendDataWithOutReturn(":PULM:STAT OFF;");
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
            var intOrExtString = internalOrExternal ? new Tuple<string, string>("internal", "INT") : new Tuple<string, string>("external", "EXT");

            try
            {
                _deviceExchanger.SendDataWithOutReturn(":PULM:SOUR " + intOrExtString.Item2 + ";");
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
                _deviceExchanger.SendDataWithOutReturn(":PULM:MODE SING;");
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
                _deviceExchanger.SendDataWithOutReturn(":PULM:WIDT " + width + " " + timeType + ";");
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
                _deviceExchanger.SendDataWithOutReturn(":PULM:DEL " + delay + " " + timeType + ";");
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
                _deviceExchanger.SendDataWithOutReturn(":PULM:TRA:REP " + Convert.ToString(num) + ";");
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
                _deviceExchanger.SendDataWithOutReturn(":PULM:PER " + period + " " + timeType + ";");
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
                _deviceExchanger.SendDataWithOutReturn(":FM:STAT ON;");
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
                _deviceExchanger.SendDataWithOutReturn(":FM:STAT OFF;");
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
                return _deviceExchanger.SendRequestDataInt(":FM:STAT?;") == 1;
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
                _deviceExchanger.SendDataWithOutReturn(":FM:SOUR INT;");
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
                _deviceExchanger.SendDataWithOutReturn(":FM:MODE NORM;");
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
                _deviceExchanger.SendDataWithOutReturn(":FM:MODE HIDEV");
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
                _deviceExchanger.SendDataWithOutReturn(":FM:DEV " + dev + " mHz;");
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
                _deviceExchanger.SendRequestDataString(":FM:DEV " + deviation + " " + typeHz + ";");
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
                _deviceExchanger.SendRequestDataDouble(":FM:MODE " + mode + ";");
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
                _deviceExchanger.SendDataWithOutReturn(":LFO ON;");
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
                _deviceExchanger.SendDataWithOutReturn(":LFO OFF;");
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
                _deviceExchanger.SendDataWithOutReturn(":LFO:VOLT " + volt + " V;");
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
                _deviceExchanger.SendDataWithOutReturn(":LFO1:FREQ " + hz + " hz;");
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
                _deviceExchanger.SendDataWithOutReturn(":LFO ON;");
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
                _deviceExchanger.SendDataWithOutReturn(":LFO OFF;");
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
                _deviceExchanger.SendDataWithOutReturn(":PM:STAT OFF;");
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
                _deviceExchanger.SendDataWithOutReturn(":PM:STAT ON;");
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
                _deviceExchanger.SendDataWithOutReturn(":AM:STAT ON;");
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
                _deviceExchanger.SendRequestDataString(":AM:STAT OFF;");
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