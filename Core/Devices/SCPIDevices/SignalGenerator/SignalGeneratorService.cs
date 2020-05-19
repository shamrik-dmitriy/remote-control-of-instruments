using Services.ExchangeServices;

namespace Core.Devices.SCPIDevices.SignalGenerator
{
    /// <summary>
    ///     Содержит специфические для проекта ПС-3 методы для работы
    ///     с генератором сигналов
    /// </summary>
    public sealed class SignalGeneratorService : SignalGenerator, ISignalGeneratorService
    {
        #region Constructor

        /// <summary>
        ///     Передаёт в базовый класс экземпляр обмена
        /// </summary>
        /// <param name="exchange">Экземпляр класса обмена</param>
        public SignalGeneratorService(IExchangeService exchange) : base(exchange)
        {
        }

        #endregion
    }
}