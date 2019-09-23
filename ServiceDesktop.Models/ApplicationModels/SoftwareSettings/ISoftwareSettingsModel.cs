using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesktop.Models.ApplicationModels.SoftwareSettings
{
    public interface ISoftwareSettingsModel
    {
        /// <summary>
        ///     Get Data Source for devices
        /// </summary>
        /// <returns>Object, contains devices</returns>
        object GetDeviceData();

        /// <summary>
        ///     Get Data Source for log levels
        /// </summary>
        /// <returns>Object, contains log levels</returns>
        object GetLogLevels();

        /// <summary>
        ///     Get network parameters for signal generator
        /// </summary>
        /// <returns>Tuple, Item1 - ip address, item2 - ip port</returns>
        Tuple<string, int> GetNetworkParametersForSignalGenerator();

        /// <summary>
        ///     Get network parameters for power supply
        /// </summary>
        /// <returns>Tuple, Item1 - ip address, item2 - ip port</returns>
        Tuple<string, int> GetNetworkParametersForPowerSupply();

        /// <summary>
        ///     Changed Log Level
        /// </summary>
        /// <param name="logLevel">Value of index in log level</param>
        void ChangeLogLevel(int logLevel);

        /// <summary>
        ///     Saved device parameters
        /// </summary>
        /// <param name="typeDevice">Type of Device</param>
        /// <param name="ipAddress">Ip address</param>
        /// <param name="port">Ip port</param>
        void SaveDeviceSettings(int typeDevice, string ipAddress, string port);

        int GetCurrentLogLevel();
    }
}