using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Services.LogServices
{
    /// <summary>
    ///     Класс обеспечивающий работу с конкретным логером, в данном случае NLog
    /// </summary>
    internal class NlogConfiguration : ILogService
    {
        #region Private Properties

        /// <summary>
        ///     Экземпляр логера
        /// </summary>
        private Logger Logger { get; set; }

        /// <summary>
        ///     Экземпляр конфигурации лога
        /// </summary>
        private LoggingConfiguration LoggingConfiguration { get; set; }

        /// <summary>
        ///     Экземпляр цели логирования (куда записывать лог)
        /// </summary>
        private Target Target { get; set; }

        #endregion

        #region Public Methods

        #region Controls

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void UpdateConfigurationLogLevel()
        {
            LoggingConfiguration.LoggingRules.Clear();
            switch ((LogLevel) SoftwareSettings.Settings.GetSettings.GetLogLevel)
            {
                case LogLevel.All:
                {
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Info, Target);
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Trace, Target);
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Warn, Target);
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Error, Target);
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Fatal, Target);
                    break;
                }

                case LogLevel.Main:
                {
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Info, Target);
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Warn, Target);
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Error, Target);
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Fatal, Target);
                    break;
                }

                case LogLevel.Error:
                {
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Info, Target);
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Debug, Target);
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Warn, Target);
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Error, Target);
                    LoggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Fatal, Target);
                    break;
                }

                case LogLevel.Debug:
                {
                    LoggingConfiguration.AddRuleForAllLevels(Target);
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException();
            }

            LogManager.ReconfigExistingLoggers();
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void CreateConfiguration()
        {
            LoggingConfiguration = new LoggingConfiguration();
            Target = new FileTarget
            {
                Name = "Log",
                FileName = SoftwareSettings.Settings.GetSettings.GetSystemPathLog + "\\${shortdate}-" +
                           Environment.UserName + ".log",
                Layout = "${longdate} | ${level:uppercsae=true} : ${message} ${exception}",
                Header = "User name: " + Environment.UserName + Environment.NewLine +
                         "Startup Path: " +
                         Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName) +
                         Environment.NewLine +
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
                ArchiveFileName = SoftwareSettings.Settings.GetSettings.GetSystemPathLog +
                                  "\\archive\\${longdate}.log",
                ArchiveNumbering = ArchiveNumberingMode.Rolling,
                ConcurrentWrites = true,
                AutoFlush = true
            };

            LoggingConfiguration.AddTarget(Target);
            UpdateConfigurationLogLevel();

            LogManager.Configuration = LoggingConfiguration;

            Logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Shutdown()
        {
            LogManager.Flush();
            LogManager.Shutdown();
        }

        #endregion

        #region Messages

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Fatal(object exception)
        {
            Logger.Fatal(exception);
            LogManager.Flush();
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Info(string message)
        {
            Logger.Info(message);
            LogManager.Flush();
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Trace(string message)
        {
            Logger.Trace(message);
            LogManager.Flush();
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Warn(string message)
        {
            Logger.Warn(message);
            LogManager.Flush();
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Debug(string message)
        {
            Logger.Debug(message);
            LogManager.Flush();
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Error(string message)
        {
            Logger.Error(message);
            LogManager.Flush();
        }

        #endregion

        #endregion
    }
}