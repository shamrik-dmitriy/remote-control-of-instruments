using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;
using System.Windows.Forms;

namespace Core.SystemLogging
{
    /// <summary>
    ///     Working with Nlog
    /// </summary>
    public sealed class SystemLogging
    {
        #region Private Variables

        /// <summary>
        ///     Словарь, содержащий расшифровку кодов уровней логирования
        /// </summary>
        private readonly Dictionary<int, string> _dataDictionary = new Dictionary<int, string>()
        {
            {0, "All"},
            {1, "Main"},
            {2, "Error"},
            {3, "Debug"}
        };

        #endregion

        #region Public Methods

        /// <summary>
        ///     Устанавливает конфигурацию журнала в соответствии с заданным уровнем логирования
        /// </summary>
        /// <param name="logLevel">Уровень логирования</param>
        /// <returns>Логер с последней конфигурацией</returns>
        public Logger SetLogConfigration(int logLevel)
        {
            var loggingConfiguration = new LoggingConfiguration();

            var target = new FileTarget()
            {
                Name = "Log",
                FileName = Properties.Directory.Default.DEFAULT_SYSTEM_PATH_LOG + "\\${shortdate}-" +
                           _dataDictionary[Properties.Software.Default.LOG_LEVEL] + ".log",
                Layout = "${longdate} | ${level:uppercsae=true} : ${message}",
                Header = "User name: " + Environment.UserName + Environment.NewLine +
                         "Startup Path: " + Application.StartupPath + Environment.NewLine +
                         "OS Version: " + Environment.OSVersion +
                         " ${when:when='${environment:PROCESSOR_ARCHITECTURE}'='X86':inner=32:else=64} bit system on " +
                         Environment.MachineName + Environment.NewLine
                         + "CLR: " + Environment.Version + Environment.NewLine + "Start timestamp ${longdate}" +
                         Environment.NewLine,
                Footer = "\nStop timestamp ${longdate}",
                Encoding = Encoding.UTF8,
                LineEnding = LineEndingMode.CRLF,
                FileAttributes = Win32FileAttributes.Hidden,
                DeleteOldFileOnStartup = true,
                MaxArchiveFiles = 10,
                ArchiveEvery = FileArchivePeriod.Day,
                ArchiveFileName = Properties.Directory.Default.DEFAULT_SYSTEM_PATH_LOG + "\\archive\\${longdate}.log",
                ArchiveNumbering = ArchiveNumberingMode.Rolling,
                ConcurrentWrites = true,
                AutoFlush = true
            };

            loggingConfiguration.AddTarget(target);
            switch (Properties.Software.Default.LOG_LEVEL)
            {
                case 0:
                    {
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Trace, target);
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Info, target);
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Warn, target);
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Error, target);
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Fatal, target);
                        break;
                    }
                case 1:
                    {
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Info, target);
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Warn, target);
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Error, target);
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Fatal, target);
                        break;
                    }
                case 2:
                    {
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Warn, target);
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Error, target);
                        loggingConfiguration.AddRuleForOneLevel(LogLevel.Fatal, target);
                        break;
                    }
                case 3:
                    {
                        loggingConfiguration.AddRuleForAllLevels(target);
                        break;
                    }
            }

            LogManager.Configuration = loggingConfiguration;
            return LogManager.GetCurrentClassLogger();
        }

        #endregion
    }
}
