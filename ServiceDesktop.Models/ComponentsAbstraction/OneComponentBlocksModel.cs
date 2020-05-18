using System;
using System.Collections.Generic;
using System.Linq;

namespace RCLD.Models.ComponentsAbstraction
{
    public class OneComponentBlocksModel : IComponentModel
    {
        #region Private member variable

        /// <summary>
        ///     Parameters for voltage values
        /// </summary>
        private static readonly Dictionary<string, List<double>> VoltsDictionary =
            new Dictionary<string, List<double>>()
            {
                {"V", new List<double>() {0, 41.92}},
            };

        /// <summary>
        ///     Parameters for amperage values
        /// </summary>
        private static readonly Dictionary<string, List<double>> AmperageDictionary =
            new Dictionary<string, List<double>>()
            {
                {"A", new List<double>() {0, 19.95}},
            };

        #endregion

        #region Private Properties

        /// <summary>
        ///     Value of component
        /// </summary>
        private string ValueOfComponent { get; set; }

        /// <summary>
        ///     Value of name field
        /// </summary>
        private string ValueOfName { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor one component parameter
        /// </summary>
        /// <param name="valueOfName">Value of field name</param>
        /// <param name="valueOfComponent">Value of component</param>
        public OneComponentBlocksModel(string valueOfName, string valueOfComponent)
        {
            ValueOfName = valueOfName;
            ValueOfComponent = valueOfComponent;
        }

        #endregion

        #region Public Methods

        public bool Validate()
        {
            var componentsValidator = new ComponentsValidator();
            switch (ValueOfName)
            {
                case "InputVoltageConstAmperage":
                {
                    return componentsValidator.Validate(ValueOfComponent, VoltsDictionary["V"].First(),
                        VoltsDictionary["V"].Last());
                }

                case "InputMaxAmperageConsumption":
                {
                    return componentsValidator.Validate(ValueOfComponent, AmperageDictionary["A"].First(),
                        AmperageDictionary["A"].Last());
                }

                default:
                {
                    throw new ArgumentException("Type of input parameter unknown: " + ValueOfName);
                }
            }
        }

        #endregion
    }
}