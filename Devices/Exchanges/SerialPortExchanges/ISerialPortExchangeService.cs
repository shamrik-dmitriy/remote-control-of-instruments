namespace Shamrik.Dmitriy.Devices.Exchanges.SerialPortExchanges
{
    public interface ISerialPortExchangeService : IExchangeService
    {
        /// <summary>
        ///     Отправляет данные в последовательный порт с 0-го смещения, заданной длины <see cref="count" />
        /// </summary>
        /// <param name="data">Данные в виде массива байт</param>
        /// <param name="count">Заданная длина с 0-го смещения</param>
        void Send(byte[] data, int count);

        /// <summary>
        ///     Отправляет данные в последовательный порт с <see cref="offset" />-смещения длиной <see cref="count" />
        /// </summary>
        /// <param name="data">Данные в виде массива байт</param>
        /// <param name="offset">Смещение с которого производить запись</param>
        /// <param name="count">Длина отсчитываемая от смещения</param>
        void Send(byte[] data, int offset, int count);

        /// <summary>
        ///     Отправляет указанную строку в последовательный порт
        /// </summary>
        /// <param name="data">Строка для вывода</param>
        void Send(string data);

        /// <summary>
        ///     Принимает данные от устройства и возвращает результат в виде строки
        /// </summary>
        /// <returns>Строка, принятая от устройства</returns>
        string ReceiveString();
    }
}