using Services.AttributesServices.EnumDescriptionAttributes;

namespace Services.LogServices
{
    /// <summary>
    ///     Enum for log level
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        ///     Журналирование всех событий и действий
        /// </summary>
        [EnumDescription("Журналирование всех событий и действий")]
        All,

        /// <summary>
        ///     Журналирование основных событий и действий
        /// </summary>
        [EnumDescription("Журналирование основных событий и действий")]
        Main,

        /// <summary>
        ///     Журналирование ошибок
        /// </summary>
        [EnumDescription("Журналирование ошибок")]
        Error,

        /// <summary>
        ///     Журналирование в режиме отладки
        /// </summary>
        [EnumDescription("Журналирование в режиме отладки")]
        Debug
    }
}