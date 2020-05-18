using System;
using Services.LogServices;

namespace Services
{
    /// <summary>
    ///     Класс предоставляет возможность работы с разделяемыми ресурсами
    ///     Например лог, вывод сообщений
    /// </summary>
    public sealed class Services
    {
        #region Public Properties

        /// <summary>
        ///     Возвращает экземпляр служб
        /// </summary>
        public static Services GetServices => ServicesLazy.Value;

        /// <summary>
        ///     Службы логирования
        /// </summary>
        public ILogService GetLogService => _logService ?? (_logService = new LogService());

        #endregion

        #region Private Member Variables

        private static LogService _logService;

        #region Signletone

        private static readonly Lazy<Services> ServicesLazy = new Lazy<Services>(() => new Services());

        #endregion

        #endregion
    }
}