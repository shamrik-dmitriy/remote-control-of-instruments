using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Devices.N5746A;
using Core.Devices.SMB100A;
using Core.Properties;
using NLog;

namespace Core
{
    public sealed class ApplicationModel
    {
        #region Private Static Variables

        /// <summary>
        ///     Instance of Singletone
        /// </summary>
        private static readonly Lazy<ApplicationModel> _applicationModel =
            new Lazy<ApplicationModel>(() => new ApplicationModel());

        #endregion

        #region Private Properties

        /// <summary>
        ///     Instance of SMB100A Signal Generator
        /// </summary>
        private static Smb100A Smb100A { get; set; }

        /// <summary>
        ///     Instance of N5746 Power Supple
        /// </summary>
        private static N5746A N5746A { get; set; }

        #endregion

        #region Public static variables

        /// <summary>
        ///     Instance of Application Model
        /// </summary>
        public static ApplicationModel GetApplicationModel => _applicationModel.Value;

        /// <summary>
        ///     Instance of Log
        /// </summary>
        public static Logger Logger;

        #endregion

        #region Constructor

        ApplicationModel()
        {
        }

        #endregion

        #region Log

        /// <summary>
        ///     Create instance of Log configuration
        /// </summary>
        public Logger CreateLoggingConfiguration()
        {
            try
            {
                Directory.Default.DEFAULT_SYSTEM_PATH_LOG = Application.StartupPath + "\\logs\\RemoteDesktop";
                var systemLogging = new SystemLogging.SystemLogging();
                return systemLogging.SetLogConfigration(Software.Default.LOG_LEVEL);
            }
            catch (Exception exception)
            {
                throw new Exception("Error initializing logging: " + exception.Message);
            }
        }

        #endregion

        #region Power Supply

        /// <summary>
        ///     Get instance of power supply
        /// </summary>
        /// <returns>Instance of power supply</returns>
        public N5746A GetConnectionPowerSupply()
        {
            try
            {
                return N5746A ?? (N5746A =
                           new N5746A(Device.Default.IP_ADDR_POWER_SUP, Device.Default.PORT_POWER_SUP));
            }
            catch (Exception exception)
            {
                throw new N5746AException("Failed to connect to power source: \n" + exception.Message);
            }
        }

        #endregion

        #region Segnal Generetor

        /// <summary>
        ///     Get instance of signal generator
        /// </summary>
        /// <returns>Instance of signal generator</returns>
        public Smb100A GetConnectionSignalGenerator()
        {
            try
            {
                return Smb100A ?? (Smb100A =
                           new Smb100A(Device.Default.IP_ADDR_SIGNAL_GEN, Device.Default.PORT_SIGNAL_GEN));
            }
            catch (Exception exception)
            {
                throw new Smb100AException("Failed to connect to the signal generator: \n" + exception.Message);
            }
        }

        #endregion
    }
}