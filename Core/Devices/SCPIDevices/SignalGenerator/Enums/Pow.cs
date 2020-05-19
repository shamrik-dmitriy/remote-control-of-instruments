namespace Core.Devices.SCPIDevices.SignalGenerator.Enums
{
    /// <summary>
    ///     Содержит размерность мощности, поддерживаемой генератором сигналов
    /// </summary>
    public enum Pow
    {
        /// <summary>
        ///     дБм
        /// </summary>
        Dbm,

        /// <summary>
        ///     дБм мкВ
        /// </summary>
        DBuV,

        /// <summary>
        ///     нВ
        /// </summary>
        Nv,

        /// <summary>
        ///     мкВ
        /// </summary>
        Uv,

        /// <summary>
        ///     мВ
        /// </summary>
        Mv,

        /// <summary>
        ///     В
        /// </summary>
        V
    }
}