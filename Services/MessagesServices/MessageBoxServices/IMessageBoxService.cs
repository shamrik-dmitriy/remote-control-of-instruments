namespace Services.MessagesServices.MessageBoxServices
{
    public interface IMessageBoxService
    {
        /// <summary>
        ///     Отображает диалоговое окно с заданным текстом <see cref="message"/> и значком информации
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void ShowMessage(string message);

        /// <summary>
        ///     Отображает диалоговое окно с заданным текстом <see cref="message"/>, заголовком окна <see cref="caption"/> и значком информации
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="caption">Текст заголовка окна</param>
        void ShowMessage(string message, string caption);

        /// <summary>
        ///     Отображает диалоговое окно с заданным текстом <see cref="message"/> и значком опасности
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void ShowExclamation(string message);

        /// <summary>
        ///     Отображает диалоговое окно с заданным текстом <see cref="message"/>, заголовком окна <see cref="caption"/> и значком опасности
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="caption">Текст заголовка окна</param>
        void ShowExclamation(string message, string caption);

        /// <summary>
        ///     Отображает диалоговое окно с заданным текстом <see cref="message"/> и значком ошибки
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void ShowError(string message);

        /// <summary>
        ///     Отображает диалоговое окно с заданным текстом <see cref="message"/>, заголовком окна <see cref="caption"/> и значком ошибки
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="caption">Текст заголовка окна</param>
        void ShowError(string message, string caption);

        /// <summary>
        ///     Отображает диалоговое окно с заданным текстом <see cref="message"/> и значком внимания
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void ShowWarning(string message);

        /// <summary>
        ///     Отображает диалоговое окно с заданным текстом <see cref="message"/>, заголовком окна <see cref="caption"/> и значком внимания
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="caption">Текст заголовка окна</param>
        void ShowWarning(string message, string caption);
    }
}