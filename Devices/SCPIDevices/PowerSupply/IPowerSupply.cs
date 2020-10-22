namespace Shamrik.Dmitriy.Devices.SCPIDevices.PowerSupply
{
    /// <summary>
    ///     Класс обеспечивает работу с генератором сигналов
    /// </summary>
    public interface IPowerSupply : IScpiDevices
    {
        #region Methods

        #region Output

        /// <summary>
        ///     Возвращает состояние выхода источника питания
        /// </summary>
        /// <returns>True - выход источника питания включён, False - выход источника питания выключен</returns>
        bool GetOutputState();

        /// <summary>
        ///     Устанавливает состояние выхода источника питания в <see cref="state" />
        /// </summary>
        /// <param name="state">True - включить выход, False - выключить выход</param>
        void SetOutputState(bool state);

        /// <summary>
        ///     Очищает заблокированные сигналы которые откоючили прерывание.
        /// </summary>
        void SetOutputProtectionClear();

        #endregion

        #region Voltage

        /// <summary>
        ///     Устанавливает значение напряжения в <see cref="voltage" /> В
        /// </summary>
        /// <param name="voltage">Значение напряжения в В</param>
        void SetVoltage(double voltage);

        /// <summary>
        ///     Возвращает измеренное значение напряжения
        /// </summary>
        /// <returns>Значение напряжения, В</returns>
        double GetVoltage();

        /// <summary>
        ///     Задаёт значение защиты (OVP) по напряжению в соответствии с <see cref="level" />
        /// </summary>
        /// <param name="level">Значение защиты по напряжению, в диапазоне от 29.5 до 44.1 В</param>
        void SetVoltageProtectionLevel(double level);

        /// <summary>
        ///     Возвращает значение защиты (OVP) по напряжению
        /// </summary>
        /// <returns>Значение защиты по напряжению, в диапазоне от 29.5 до 44.1 В</returns>
        double GetVoltageProtectionLevel();

        /// <summary>
        ///     Устанавливает нижнее предельное значение (UVL) напряжения в соответствии с <see cref="limit" /> А
        /// </summary>
        /// <param name="limit">Предельное значение напряжения в диапазоне от 0 до 26.6 А</param>
        void SetVoltageLimitLow(double limit);

        /// <summary>
        ///     Возвращает нижнее предельное значение (UVL) напряжения
        /// </summary>
        double GetVoltageLimitLow();

        #endregion

        #region Amperage

        /// <summary>
        ///     Возвращает измеренное значение тока потребления
        /// </summary>
        /// <returns>Значение тока потребления, А</returns>
        double GetAmperage();

        /// <summary>
        ///     Устанавливает предельное значение тока потребления
        /// </summary>
        /// <param name="limit">Предельное значение тока потребления</param>
        void SetAmperageLimit(double limit);

        /// <summary>
        ///     Возвращает предельное значение тока потребления
        /// </summary>
        /// <returns>Предельное значение тока потребления, А</returns>
        double GetAmperageLimit();

        /// <summary>
        ///     Возвращает состояние защиты по току
        /// </summary>
        /// <returns>True - защита по току включена, False - защита по току выключена</returns>
        bool GetAmperageProtectionState();

        /// <summary>
        ///     Включает или выключает состояние защиты по току в соответствии с <see cref="state" />
        /// </summary>
        /// <param name="state">True - включить защиту, False - выключить защиту</param>
        void SetAmperageProtectionState(bool state);

        #endregion

        #endregion
    }
}