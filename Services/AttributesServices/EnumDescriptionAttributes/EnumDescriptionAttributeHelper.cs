using System;
using System.Collections;

namespace Services.AttributesServices.EnumDescriptionAttributes
{
    /// <summary>
    ///     Класс предоставляет вспомогательные методы для работы с атрибутами 
    /// </summary>
    public static class EnumDescriptionAttributeHelper
    {
        #region Public Methods

        /// <summary>
        ///     Возвращает текстовое описание значения перечисления <see cref="valueOfEnum"/>
        /// </summary>
        /// <param name="valueOfEnum">Значение перечисления</param>
        /// <returns>Строковое представление значения перечисления</returns>
        public static string GetDescription(this Enum valueOfEnum)
        {
            if (valueOfEnum == null) throw new ArgumentNullException("valueOfEnum");

            var description = valueOfEnum.ToString();
            var fieldInfo = valueOfEnum.GetType().GetField(description);

            var attributes =
                (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attributes.Length > 0) description = attributes[0].Description;

            return description;
        }

        /// <summary>
        ///     Возвращает универсальную коллекцию объектов типа перечисления
        /// </summary>
        /// <param name="type">Тип</param>
        /// <returns>Универсальная коллекция объектов типа перечисления</returns>
        public static IList ToList(this Type type)
        {
            if (type == null) throw new ArgumentNullException("type");

            var list = new ArrayList();

            foreach (Enum value in Enum.GetValues(type)) list.Add(GetDescription(value));

            return list;
        }

        #endregion
    }
}