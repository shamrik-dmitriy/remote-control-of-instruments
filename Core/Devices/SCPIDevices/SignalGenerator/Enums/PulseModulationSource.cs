namespace Core.Devices.SCPIDevices.SignalGenerator.Enums
{
    /// <summary>
    ///     Источник импульсной модуляции
    /// </summary>
    public enum PulseModulationSource
    {
        /// <summary>
        ///     Внутренний источник
        /// </summary>
        INT,

        /// <summary>
        ///     Внешний источник
        /// </summary>
        EXT,

        /// <summary>
        ///     Скалярный сетевой анализатор
        /// </summary>
        SCAL
    }
}