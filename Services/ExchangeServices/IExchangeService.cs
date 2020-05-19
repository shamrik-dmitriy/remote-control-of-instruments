using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExchangeServices
{
    /// <summary>
    ///     Интерфейс для всех классов обмена данными с устройствами
    /// </summary>
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