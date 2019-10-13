namespace Core.Devices
{
    public interface IDevices
    {
        /// <summary>
        ///     Get ОРС
        /// </summary>
        /// <returns>True - OPC Complete, False - OPC Not complete</returns>
        bool Opc();

        /// <summary>
        ///     Device identification
        /// </summary>
        /// <returns>Device Identifier String</returns>
        string Identification();

        /// <summary>
        ///     Resets devices
        /// </summary>
        void Reset();
    }
}