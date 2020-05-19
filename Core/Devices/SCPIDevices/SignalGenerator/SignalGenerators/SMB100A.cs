using System;
using System.Globalization;
using Core.Devices.SCPIDevices.SCPIData;
using Core.Devices.SCPIDevices.SignalGenerator.Enums;
using Core.Exchange.LanExchange;
using Services.ExchangeServices;

namespace Core.Devices.SCPIDevices.SignalGenerator.SignalGenerators
{
    /// <summary>
    ///     R&S SMB100A Signal Generator Class
    /// </summary>
    public sealed class Smb100A : ISMB100A
    {
        #region Private Properties

        /// <summary>
        ///     Экземпляр вспомогательного класса для обмена
        /// </summary>
        private ScpiDataExchanger ScpiDataExchanger { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor R&S SMB100A
        /// </summary>
        /// <param name="exchange">Instance of exchange</param>
        public Smb100A(IExchangeService exchange)
        {
            ScpiDataExchanger = new ScpiDataExchanger(exchange);
        }

        #endregion

        #region Public Methods

        #region Setting radiation parameter

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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to set modulation polarity value " +
                                                   ": " + signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to select trigger mode for pulse modulation " +
                                                   ": " + signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to select impedance for external pulse trigger " +
                                                   ": " + signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to select output polarity " +
                                                   ": " + signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to set polarity of the active slice to Positive " +
                                                   ": " + signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to enable pulse modulation of the signal: " +
                                                   signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to turn off pulse modulation of the signal: " +
                                                   signalGeneratorException.Message);
            }
        }

        /// <summary>
        ///     Selects a source for pulse modulation.
        /// </summary>
        /// <param name="internalOrExternal">True - to select the internal source, false - for the external</param>
        public void PulseModulationSelectInternalSource(bool internalOrExternal = true)
        {
            var intOrExtString = internalOrExternal
                ? new Tuple<string, string>("internal", "INT")
                : new Tuple<string, string>("external", "EXT");

            try
            {
                _deviceExchanger.SendDataWithOutReturn(":PULM:SOUR " + intOrExtString.Item2 + ";");
            }
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to select " + intOrExtString.Item1 +
                                                   " source for modulating the signal: " +
                                                   signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to set pulse generator mode: " +
                                                   signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to set the number of repetitions in " + num + ": " +
                                                   signalGeneratorException.Message);
            }
        }

        #endregion

        #region Frequency Modulation | LFOutput

        /// <summary>
        ///     Trun On frequency modulation
        /// </summary>
        public void SetFrequencyModulationState(bool state)
        {
            try
            {
                _deviceExchanger.SendDataWithOutReturn(":FM:STAT ON;");
            }
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to enable frequency modulation: " +
                                                   signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException(
                    "Failed to fulfill the request for the current state of frequency modulation: " +
                    signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException(
                    "Failed to set the LF generator as a frequency modulation source: " +
                    signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to set Normal Mode value in frequency modulation: " +
                                                   signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to set High deviation value in frequency modulation: " +
                                                   signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to set signal deviation value to " + dev +
                                                   " mHz: " +
                                                   signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to set signal deviation value to " + deviation +
                                                   " " +
                                                   typeHz + ": " + signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to set signal deviation value to " + mode + ": " +
                                                   signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to enable LF output: " + signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to turn off LF output: " + signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException(
                    "Failed to set output voltage value at output LF to " +
                    volt + ": " + signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to set generator frequency LFO1 to " + hz +
                                                   ": " +
                                                   signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to query for LFO status: " +
                                                   signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to turn off LFO: " + signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to turn off LFO: " + signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException(
                    "The request to obtain the phase modulation state of the signal failed: " +
                    signalGeneratorException.Message);
            }
        }

        /// <summary>
        ///     Turns on phase modulation
        /// </summary>
        public void SetPhaseModulationState(bool state)
        {
            try
            {
                _deviceExchanger.SendDataWithOutReturn(":PM:STAT ON;");
            }
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to enable phase modulation of the signal: " +
                                                   signalGeneratorException.Message);
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
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException(
                    "Failed to complete the request for the amplitude modulation state: " +
                    signalGeneratorException.Message);
            }
        }


        /// <summary>
        ///     Turn off amplitude modulation
        /// </summary>
        public void SetAmplitudeModulationState(bool state)
        {
            try
            {
                throw new NotImplementedException();
                //TODO: Added on/off _deviceExchanger.SendRequestDataString(":AM:STAT OFF;");
            }
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to turn off amplitude modulation: " +
                                                   signalGeneratorException.Message);
            }
        }

        #endregion

        #endregion

        #region Request and return parameters of the signal generator radiation

        /// <summary>
        ///     Returns the value of deviation
        /// </summary>
        /// <returns>Double precision deviation value</returns>
        public double GetFrequencyModulationDeviation()
        {
            try
            {
                return _deviceExchanger.SendRequestDataDouble(":FM:DEV?;");
            }
            catch (SignalGeneratorException signalGeneratorException)
            {
                throw new SignalGeneratorException("Failed to complete the request for deviation value: " +
                                                   signalGeneratorException.Message +
                                                   ".");
            }
        }

        #endregion

        #endregion


        #region Public Methods

        #region Controls

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Reset()
        {
            ScpiDataExchanger.Request("*RST;");
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public string Identification()
        {
            return ScpiDataExchanger.Request<string>("*IDN?;");
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public bool GetOpc()
        {
            return ScpiDataExchanger.Request<bool>("*OPC?;");
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetOpc(bool enabled)
        {
            ScpiDataExchanger.Request("*OPC;");
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public int Test()
        {
            return ScpiDataExchanger.Request<int>("*TST?;");
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public string GetError()
        {
            return ScpiDataExchanger.Request<string>(":SYST:ERR?;");
        }

        #endregion

        #region Modulation Control

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetModulationState(bool state)
        {
            try
            {
                ScpiDataExchanger.Request(":SOUR:MOD:ALL:STAT " + (state ? "ON" : "OFF") + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public bool GetModulationState()
        {
            try
            {
                return ScpiDataExchanger.Request<bool>(":SOUR:MOD:ALL:STAT?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        #endregion

        #region RF Control

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetRfOutputState(bool state)
        {
            try
            {
                ScpiDataExchanger.Request(":OUTP:STAT " + (state ? "ON" : "OFF") + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public bool GetRfOutputState()
        {
            try
            {
                return ScpiDataExchanger.Request<bool>(":OUTP:STAT?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        #endregion

        #region Pulse Modulation

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPulseModulationExternalPolarity(PulseModulationExternalPolarity pulseModulationExternalPolarity)
        {
            try
            {
                ScpiDataExchanger.Request(":PULM:EXT:POL " + pulseModulationExternalPolarity + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public string GetPulseModulationExternalPolarity()
        {
            try
            {
                return ScpiDataExchanger.Request<string>(":PULM:EXT:POL?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPulseModulationInternalDelay(double delay, PulseDelay pulseDelay)
        {
            try
            {
                ScpiDataExchanger.Request(":PULM:INT:DEL " + Convert.ToString(delay, CultureInfo.InvariantCulture) +
                                          " " + pulseDelay +
                                          ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public double GetPulseModulationInternalDelay()
        {
            try
            {
                return ScpiDataExchanger.Request<double>(":PULM:INT:DEL?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPulseModulationInternalFrequency(double freq, Frequency type = Frequency.Mhz)
        {
            try
            {
                ScpiDataExchanger.Request(":PULM:INT:FREQ " + Convert.ToString(freq, CultureInfo.InvariantCulture) +
                                          " " + type + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public double GetPulseModulationInternalFrequency()
        {
            try
            {
                return ScpiDataExchanger.Request<double>(":PULM:INT:FREQ?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPulseModulationInternalPeriod(double pulsePeriod, PulsePeriod type)
        {
            try
            {
                ScpiDataExchanger.Request(":PULM:INT:PER " +
                                          Convert.ToString(pulsePeriod, CultureInfo.InvariantCulture) + " " + type +
                                          ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public double GetPulseModulationInternalPeriod()
        {
            try
            {
                return ScpiDataExchanger.Request<double>(":PULM:INT:PER?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPulseModulationInternalPulseWidth(double width, PulseWidth type)
        {
            try
            {
                ScpiDataExchanger.Request(":PULM:INT:PWID " + Convert.ToString(width, CultureInfo.InvariantCulture) +
                                          " " + type + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public double GetPulseModulationInternalPulseWidth()
        {
            try
            {
                return ScpiDataExchanger.Request<double>(":PULM:INT:PWID?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        //TODO: FIX TEST Несовпадение типов
        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPulseModulationInternal(PulseModulationInternal type)
        {
            try
            {
                ScpiDataExchanger.Request(":PULM:SOUR:INT " + type + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        //TODO: FIX TEST Несовпадение типов
        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public double GetPulseModulationInternal()
        {
            try
            {
                return ScpiDataExchanger.Request<double>(":PULM:SOUR:INT?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPulseModulationInternalSource(PulseModulationSource pulseModulationSource)
        {
            try
            {
                ScpiDataExchanger.Request(":PULM:SOUR " + pulseModulationSource + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public string GetPulseModulationInternalSource()
        {
            try
            {
                return ScpiDataExchanger.Request<string>(":PULM: SOUR?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPulseModulationState(bool state)
        {
            try
            {
                ScpiDataExchanger.Request(":PULM:STAT " + (state ? "ON" : "OFF") + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public bool GetPulseModulationState()
        {
            try
            {
                return ScpiDataExchanger.Request<bool>(":PULM:STAT?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        #endregion

        #region Set Data

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetFrequency(double frequency, Frequency type = Frequency.Mhz)
        {
            try
            {
                ScpiDataExchanger.Request(":FREQ " + Convert.ToString(frequency, CultureInfo.InvariantCulture) + " " +
                                          type + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPowLevel(double powLevel, Pow type = Pow.Dbm)
        {
            try
            {
                ScpiDataExchanger.Request(
                    ":POW " + Convert.ToString(powLevel, CultureInfo.InvariantCulture).Replace(',', '.') + " " +
                    type +
                    ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPulseWidth(double width, PulseWidth pulseWidth)
        {
            try
            {
                ScpiDataExchanger.Request(":PULM:WIDT " + width + " " + pulseWidth + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPulsePeriod(double period, PulsePeriod pulsePeriod)
        {
            try
            {
                ScpiDataExchanger.Request(":PULM:PER " + period + " " + pulsePeriod + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void SetPulseDelay(double delay, PulseDelay pulseDelay)
        {
            try
            {
                ScpiDataExchanger.Request(":PULM:DEL " + delay + " " + pulseDelay + ";");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        #endregion

        #region Get Data

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public double GetFrequency()
        {
            try
            {
                return ScpiDataExchanger.Request<double>(":FREQ?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public double GetPowLevel()
        {
            try
            {
                return ScpiDataExchanger.Request<double>(":POW?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public double GetPulseWidth()
        {
            try
            {
                return ScpiDataExchanger.Request<double>(":PULM:WIDT?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public double GetPulsePeriod()
        {
            try
            {
                return ScpiDataExchanger.Request<double>(":PULM:PER?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public double GetPulseDelay()
        {
            try
            {
                return ScpiDataExchanger.Request<double>(":PULM:DEL?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public double GetFrequencyDeviation()
        {
            try
            {
                return ScpiDataExchanger.Request<double>(":FM:DEV?;");
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        #endregion

        #endregion
    }
}