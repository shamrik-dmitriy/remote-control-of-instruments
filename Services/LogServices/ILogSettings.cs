namespace Services.LogServices
{
    public interface ILogSettings
    {
        /// <summary>
        ///     Обновляет конфигурацию уровня логирования
        /// </summary>
        void UpdateConfigurationLogLevel();

        /// <summary>
        ///     Создаёт конфигурацию логера 
        /// </summary>
        void CreateConfiguration();
    }
}