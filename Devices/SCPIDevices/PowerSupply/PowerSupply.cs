using IExchangeService = Shamrik.Dmitriy.Devices.Exchanges.IExchangeService;

namespace Shamrik.Dmitriy.Devices.SCPIDevices.PowerSupply
{
    /// <summary>
    ///     Предоставляет программное управление источником питания
    /// </summary>
    public sealed class PowerSupply : IPowerSupply
    {
        #region Constructor

        /// <summary>
        ///     Конструктор, создаёт источнк питания.
        ///     Для соединения используется коннектор <see cref="exchange" />
        /// </summary>
        /// <param name="exchange">Коннектор</param>
        public PowerSupply(IExchangeService exchange)
        {
            N5766A = new N5766A(exchange);
        }

        #endregion

        #region Private properties

        /// <summary>
        ///     Экземпляр источника питания
        /// </summary>
        private N5766A N5766A { get; }

        #endregion

        #region Public Methods

        #region Controls

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Reset()
        {
            N5766A.Reset();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string Identification()
        {
            return N5766A.Identification();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public bool GetOpc()
        {
            return N5766A.GetOpc();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetOpc(bool enabled)
        {
            N5766A.SetOpc(enabled);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public int Test()
        {
            return N5766A.Test();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string GetError()
        {
            return N5766A.GetError();
        }

        #endregion

        #region Output

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public bool GetOutputState()
        {
            return N5766A.GetOutputState();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetOutputState(bool state)
        {
            N5766A.SetOutputState(state);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetOutputProtectionClear()
        {
            N5766A.SetOutputProtectionClear();
        }

        #endregion

        #region Voltage

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetVoltage(double voltage)
        {
            N5766A.SetVoltage(voltage);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetVoltage()
        {
            return N5766A.GetVoltage();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetVoltageProtectionLevel(double level)
        {
            N5766A.SetVoltageProtectionLevel(level);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetVoltageProtectionLevel()
        {
            return N5766A.GetVoltageProtectionLevel();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetVoltageLimitLow(double limit)
        {
            N5766A.SetVoltageLimitLow(limit);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetVoltageLimitLow()
        {
            return N5766A.GetVoltageLimitLow();
        }

        #endregion

        #region Amperage

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetAmperage()
        {
            return N5766A.GetAmperage();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetAmperageLimit(double limit)
        {
            N5766A.SetAmperageLimit(limit);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetAmperageLimit()
        {
            return N5766A.GetAmperageLimit();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public bool GetAmperageProtectionState()
        {
            return N5766A.GetAmperageProtectionState();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetAmperageProtectionState(bool state)
        {
            N5766A.SetAmperageProtectionState(state);
        }

        #endregion

        #endregion
    }
}