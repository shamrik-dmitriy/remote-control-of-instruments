using System;

namespace Services.AttributesServices.EnumDescriptionAttributes
{
    /// <summary>
    ///     Класс атрибутов предназначенный для перечислений
    ///     Позволяет задавать описание к элементу перечисления и получать его
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        #region Public properties

        /// <summary>
        ///     Get description for enumerated type
        /// </summary>
        public string Description { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Initialize new instance
        /// </summary>
        /// <param name="description">Description attribute value</param>
        public EnumDescriptionAttribute(string description)
        {
            Description = description;
        }

        #endregion
    }
}