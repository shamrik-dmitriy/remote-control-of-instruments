using System;
using System.Globalization;
using Shamrik.Dmitriy.Devices.SCPIDevices.SCPIData;
using IExchangeService = Shamrik.Dmitriy.Devices.Exchanges.IExchangeService;

namespace Shamrik.Dmitriy.Devices.SCPIDevices.PowerSupply
{
    /// <summary>
    ///     Класс предоставляет возможность взаимодействия с источником питания Agilent / Keysight N5766A
    /// </summary>
    internal sealed class N5766A : IPowerSupply
    {
        #region Constuctor / Destructor

        /// <summary>
        ///     Конструктор класса. Инициализирует подключение к устройству
        ///     по заданному коннектору <see cref="exchange" />
        /// </summary>
        /// <param name="exchange">Коннектор</param>
        public N5766A(IExchangeService exchange)
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

        #region Output

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public bool GetOutputState()
        {
            return ScpiDataExchanger.Request<bool>(":OUTP:STATE?;");
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetOutputState(bool state)
        {
            ScpiDataExchanger.Request(":OUTP:STAT " + (state ? "ON" : "OFF") + ";");
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetOutputProtectionClear()
        {
            try
            {
                ScpiDataExchanger.Request(":OUTP:PROT:CLE;");
            }
            catch (Exception exception)
            {
                throw new PowerSupplyException(exception.Message);
            }
        }

        #endregion

        #region Voltage

        #region Set

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetVoltageProtectionLevel(double level)
        {
            try
            {
                ScpiDataExchanger.Request(
                    ":VOLT:PROT:LEV " +
                    Convert.ToString(level, CultureInfo.CurrentCulture)
                        .Replace(",", ".") + ";");
            }
            catch (Exception exception)
            {
                throw new PowerSupplyException(exception.Message);
            }
        }

        public void SetVoltageLimitLow(double limit)
        {
            try
            {
                ScpiDataExchanger.Request(
                    ":VOLT:LIM:LOW " +
                    Convert.ToString(limit, CultureInfo.CurrentCulture)
                        .Replace(",", ".") + ";");
            }
            catch (Exception exception)
            {
                throw new PowerSupplyException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetVoltage(double voltage)
        {
            try
            {
                ScpiDataExchanger.Request(
                    ":VOLT " + Convert.ToString(voltage, CultureInfo.CurrentCulture)
                        .Replace(",", ".") + ";");
            }
            catch (Exception exception)
            {
                throw new PowerSupplyException(exception.Message);
            }
        }

        #endregion

        #region Get

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetVoltageProtectionLevel()
        {
            return ScpiDataExchanger.Request<double>(":VOLT:PROT:LEV?;");
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetVoltageLimitLow()
        {
            return ScpiDataExchanger.Request<double>(":VOLT:LIM:LOW?;");
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetVoltage()
        {
            return ScpiDataExchanger.Request<double>(":MEAS:VOLT?;");
        }

        #endregion

        #endregion

        #region Amperage

        #region Set

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetAmperageLimit(double limit)
        {
            try
            {
                ScpiDataExchanger.Request(":CURR " + limit + ";");
            }
            catch (Exception exception)
            {
                throw new PowerSupplyException(exception.Message);
            }
        }

        public void SetAmperageProtectionState(bool state)
        {
            ScpiDataExchanger.Request(":CURR:PROT:STAT " + (state ? "ON;" : "OFF") + ";");
        }

        #endregion

        #region Get

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetAmperageLimit()
        {
            return ScpiDataExchanger.Request<double>(":CURR?;");
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public bool GetAmperageProtectionState()
        {
            return ScpiDataExchanger.Request<bool>(":CURR:PROT:STAT?;");
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetAmperage()
        {
            return ScpiDataExchanger.Request<double>(":MEAS:CURR?;");
        }

        #endregion

        #endregion

        #endregion
    }
}