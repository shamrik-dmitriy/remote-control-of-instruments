namespace Services.LogServices
{
    public interface ILogService : ILogSettings
    {
        /// <summary>
        ///     Логирует сообщение с пометкой "Критическая ошибка"
        /// </summary>
        /// <param name="exception">Объект исключения</param>
        void Fatal(object exception);

        /// <summary>
        ///     Логирует сообщение с пометкой "Информация"
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void Info(string message);

        /// <summary>
        ///     Логирует сообщение с пометкой "Детальная информация"
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void Trace(string message);

        /// <summary>
        ///     Логирует сообщение с пометкой "Внимание"
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void Warn(string message);

        /// <summary>
        ///     Логирует сообщение с пометкой "Отладка"
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void Debug(string message);

        /// <summary>
        ///     Логирует сообщение с пометкой "Ошибка"
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void Error(string message);

        /// <summary>
        ///     Освобождает все ресурсы лога и прекращает логирование
        /// </summary>
        void Shutdown();
    }
}