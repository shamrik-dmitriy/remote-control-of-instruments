using System;
using System.Globalization;
using Shamrik.Dmitriy.Devices.SCPIDevices.SCPIData;
using Shamrik.Dmitriy.Devices.SCPIDevices.SignalGenerator.Enums;
using IExchangeService = Shamrik.Dmitriy.Devices.Exchanges.IExchangeService;

namespace Shamrik.Dmitriy.Devices.SCPIDevices.SignalGenerator
{
    /// <summary>
    ///     Класс предоставляет возможность взаимодействия с генератором сигналом Agilent / Keysight E8257D
    /// </summary>
    internal sealed class E8257D : ISignalGenerator
    {
        #region Constructor 

        /// <summary>
        ///     Конструктор класса. Инициализирует подключение к устройству
        ///     по заданному коннектору <see cref="exchange" />
        /// </summary>
        /// <param name="exchange">Коннектор</param>
        public E8257D(IExchangeService exchange)
        {
            ScpiDataExchanger = new ScpiDataExchanger(exchange);
        }

        #endregion

        #region Private Properties

        /// <summary>
        ///     Экземпляр вспомогательного класса для обмена
        /// </summary>
        private ScpiDataExchanger ScpiDataExchanger { get; }

        #endregion

        #region Public Methods

        #region Controls

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Reset()
        {
            ScpiDataExchanger.Request("*RST;");
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string Identification()
        {
            return ScpiDataExchanger.Request<string>("*IDN?;");
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public bool GetOpc()
        {
            return ScpiDataExchanger.Request<bool>("*OPC?;");
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetOpc(bool enabled)
        {
            ScpiDataExchanger.Request("*OPC;");
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public int Test()
        {
            return ScpiDataExchanger.Request<int>("*TST?;");
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string GetError()
        {
            return ScpiDataExchanger.Request<string>(":SYST:ERR?;");
        }

        #endregion

        #region Modulation Control

        /// <summary>
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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
        ///     <inheritdoc />
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