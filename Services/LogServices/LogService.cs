namespace Services.LogServices
{
    /// <summary>
    ///     Класс-адаптер для службы логирования
    /// </summary>
    public class LogService : ILogService
    {
        #region Private Member Variables

        /// <summary>
        ///     Экземпляр класс конфигурации лога
        /// </summary>
        private readonly NlogConfiguration _nlogConfiguration;

        #endregion

        #region Constructor

        /// <summary>
        ///     Инициализирует экземпляр класса конфигурации лога
        /// </summary>
        public LogService()
        {
            _nlogConfiguration = new NlogConfiguration();
        }

        #endregion

        #region Public Methods

        #region Messages 

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Fatal(object exception)
        {
            _nlogConfiguration.Fatal(exception);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Info(string message)
        {
            _nlogConfiguration.Info(message);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Trace(string message)
        {
            _nlogConfiguration.Trace(message);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Warn(string message)
        {
            _nlogConfiguration.Warn(message);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Debug(string message)
        {
            _nlogConfiguration.Debug(message);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Error(string message)
        {
            _nlogConfiguration.Error(message);
        }

        #endregion

        #region Control

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Shutdown()
        {
            _nlogConfiguration.Shutdown();
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void UpdateConfigurationLogLevel()
        {
            _nlogConfiguration.UpdateConfigurationLogLevel();
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void CreateConfiguration()
        {
            _nlogConfiguration.CreateConfiguration();
        }

        #endregion

        #endregion
    }
}