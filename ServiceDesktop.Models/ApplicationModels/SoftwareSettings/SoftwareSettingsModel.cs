using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDesktop.Models.Attributes;

namespace ServiceDesktop.Models.ApplicationModels.SoftwareSettings
{
    public class SoftwareSettingsModel : ISoftwareSettingsModel
    {
        /// <summary>
        ///     Log level auto property
        /// </summary>
        private int LogLevel { get; set; }

        /// <summary>
        ///     Devices list
        /// </summary>
        private enum Devices
        {
            [EnumDescription("Signal Generator")] SignalGenerator,
            [EnumDescription("Power Supply")] PowerSupply
        }

        /// <summary>
        ///     Log levels list
        /// </summary>
        private enum LogLevels
        {
            [EnumDescription("All")] LVL1,
            [EnumDescription("Main")] LVL2,
            [EnumDescription("Only error")] LVL3,
        }

        public object GetDeviceData()
        {
            return typeof(Devices).ToList();
        }

        public object GetLogLevels()
        {
            return typeof(LogLevels).ToList();
        }

        public Tuple<string, int> GetNetworkParametersForSignalGenerator()
        {
            return new Tuple<string, int>(Core.Properties.Device.Default.IP_ADDR_SIGNAL_GEN,
                Core.Properties.Device.Default.PORT_SIGNAL_GEN);
        }

        public Tuple<string, int> GetNetworkParametersForPowerSupply()
        {
            return new Tuple<string, int>(Core.Properties.Device.Default.IP_ADDR_POWER_SUP,
                Core.Properties.Device.Default.PORT_POWER_SUP);
        }

        public void ChangeLogLevel(int logLevel)
        {
            LogLevel = logLevel;
        }

        public void SaveDeviceSettings(int typeDevice, string ipAddress, string port)
        {
            switch (typeDevice)
            {
                case 0:
                {
                    Core.Properties.Device.Default.IP_ADDR_SIGNAL_GEN = ipAddress;
                    Core.Properties.Device.Default.PORT_SIGNAL_GEN = Convert.ToInt32(port);

                    break;
                }

                case 1:
                {
                    Core.Properties.Device.Default.IP_ADDR_POWER_SUP = ipAddress;
                    Core.Properties.Device.Default.PORT_POWER_SUP = Convert.ToInt32(port);
                    break;
                }
            }

            Core.Properties.Software.Default.LOG_LEVEL = LogLevel;

            Core.Properties.Software.Default.Save();
            Core.Properties.Device.Default.Save();
        }

        public int GetCurrentLogLevel()
        {
            return Core.Properties.Software.Default.LOG_LEVEL;
        }
    }
}