using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareSettings
{
    /// <summary>
    ///     Класс обеспечивает взаимодействие с настройками приложения
    /// </summary>
    public class Settings
    {
        #region Public Properties

        /// <summary>
        ///     Возвращает экземпляр настроек
        /// </summary>
        public static Settings GetSettings => SettingsLazy.Value;

        #region Network

        public string GetIpAddressPowerSupply => Network.Default.IP_ADDRESS_POWER_SUPPLY;

        public string SetIpAddressPowerSupply
        {
            set
            {
                try
                {
                    Network.Default.IP_ADDRESS_POWER_SUPPLY = value;
                    Network.Default.Save();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }

        public string GetIpAddressSignalGenerator => Network.Default.IP_ADDRESS_SOURCE_SIGNAL;

        public string SetIpAddressSignalGenerator
        {
            set
            {
                try
                {
                    Network.Default.IP_ADDRESS_SOURCE_SIGNAL = value;
                    Network.Default.Save();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }

        #endregion

        #region Log

        /// <summary>
        ///     Возвращает уровень логирования
        /// </summary>
        public int GetLogLevel => Log.Default.LEVEL;

        /// <summary>
        ///     Устанавливает уровень логирования
        /// </summary>
        public int SetLogLevel
        {
            set
            {
                try
                {
                    Log.Default.LEVEL = value;
                    Log.Default.Save();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }

        #endregion

        #region Directory

        public string GetSystemPathLog => Directories.Default.SYSTEM_PATH_LOG;

        #endregion

        #endregion


        #region Private Properties

        #region Signletone

        /// <summary>
        ///     Экземпляр класса настроек
        /// </summary>
        private static readonly Lazy<Settings> SettingsLazy = new Lazy<Settings>(() => new Settings());

        #endregion

        #endregion
    }
}