namespace Shamrik.Dmitriy.Devices.Exchanges
{
    public interface IExchangeService
    {
        #region Methods

        #region Connect / Disconnect

        /// <summary>
        ///     Открывает соединение
        /// </summary>
        void Connect();

        /// <summary>
        ///     Закрывает соединение
        /// </summary>
        void Disconnect();

        #endregion

        #region State Connection

        /// <summary>
        ///     Возвращает состояние соединения
        /// </summary>
        /// <returns>True - соединение активно, False - соединение не активно</returns>
        bool GetStateConnection();

        #endregion

        #region Write Data

        /// <summary>
        ///     Отправляет данные в виде массива байт на устройство
        /// </summary>
        /// <param name="data">Массив байт</param>
        void Send(byte[] data);

        #endregion

        #region Read Data

        /// <summary>
        ///     Принимает данные от устройства и возвращает результат в виде массива байт
        /// </summary>
        /// <returns>Массив байт, принятный от устройства</returns>
        byte[] Receive();

        #endregion

        #endregion
    }
}