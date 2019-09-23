using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesktop.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        /// <summary>
        ///     Get description for enumerated type
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     Initialize new instance
        /// </summary>
        /// <param name="description">Description attribute value</param>
        public EnumDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}