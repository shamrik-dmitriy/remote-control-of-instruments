namespace Shamrik.Dmitriy.Devices.SCPIDevices
{
    /// <summary>
    ///     Интерфейс, содержащий общие команды для SCPI устройств
    /// </summary>
    public interface IScpiDevices
    {
        /// <summary>
        ///     Сброс устройства
        /// </summary>
        void Reset();

        /// <summary>
        ///     Идентифицирует устройство
        /// </summary>
        /// <returns>Строка-идентификатор</returns>
        string Identification();

        /// <summary>
        ///     Получает состояние обработки команды
        /// </summary>
        /// <returns>True - операция выполнена</returns>
        bool GetOpc();

        /// <summary>
        ///     Устанавливает бит "операция выполнена" в ESR
        /// </summary>
        /// <param name="enabled"></param>
        void SetOpc(bool enabled);

        /// <summary>
        ///     Проводит тест устройства
        /// </summary>
        /// <returns>Код состояния</returns>
        int Test();

        /// <summary>
        ///     Вернёт сообщение об ошибке
        /// </summary>
        /// <returns>Строка с сообщением об ошибке</returns>
        string GetError();
    }
}