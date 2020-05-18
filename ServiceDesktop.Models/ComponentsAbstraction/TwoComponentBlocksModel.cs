using System;
using System.Collections.Generic;
using System.Linq;

namespace RCLD.Models.ComponentsAbstraction
{
    public class TwoComponentBlocksModel : IComponentModel
    {
        #region Private Member Variables

        /// <summary>
        ///     Range value for frequency
        /// </summary>
        private readonly Dictionary<string, List<double>> _frequencyDictionary =
            new Dictionary<string, List<double>>()
            {
                {"Гц", new List<double>() {100000, 10000000999}},
                {"кГц", new List<double>() {100, 10000004}},
                {"мГц", new List<double>() {1, 99999}},
                {"Ггц", new List<double>() {1, 12}},
            };

        /// <summary>
        ///     Range values for pow
        /// </summary>
        private readonly Dictionary<string, List<double>> _powDictionary =
            new Dictionary<string, List<double>>()
            {
                {"дБм", new List<double>() {-145, 30}},
                {"дБмкВ", new List<double>() {-38, -146}},
                {"нВ", new List<double>() {13, 2000000000}},
                {"мкВ", new List<double>() {1, 999999}},
                {"мВ", new List<double>() {1, 7009}},
                {"В", new List<double>() {1, 7}}
            };

        /// <summary>
        ///     Range value for pulse width
        /// </summary>
        private readonly Dictionary<string, List<double>> _pulseWidthDictionary =
            new Dictionary<string, List<double>>()
            {
                {"с", new List<double>() {1, 100}},
                {"нс", new List<double>() {0, 100000000004}},
                {"мс", new List<double>() {0, 100000}},
                {"мкс", new List<double>() {0, 100000000}}
            };

        /// <summary>
        ///     Range values for pulse period
        /// </summary>
        private readonly Dictionary<string, List<double>> _pulsePeriodDictionary =
            new Dictionary<string, List<double>>()
            {
                {"с", new List<double>() {0, 100}},
                {"нс", new List<double>() {0, 100000000004}},
                {"мс", new List<double>() {0, 100000}},
                {"мкс", new List<double>() {0, 100000000}}
            };

        /// <summary>
        ///     Range values for deviation
        /// </summary>
        private readonly Dictionary<string, List<double>> _deviationDictionary =
            new Dictionary<string, List<double>>()
            {
                {"Гц", new List<double>() {0, 29999999}},
                {"кГц", new List<double>() {0, 29999}},
                {"мГц", new List<double>() {0, 32}}
            };

        /// <summary>
        ///     Range values for pulse delay
        /// </summary>
        private readonly Dictionary<string, List<double>> _pulseDelayDictionary =
            new Dictionary<string, List<double>>()
            {
                {"с", new List<double>() {0, 100}},
                {"нс", new List<double>() {0, 100000000000}},
                {"мс", new List<double>() {0, 100000}},
                {"мкс", new List<double>() {0, 100000000}}
            };

        #endregion

        #region Private Properties

        /// <summary>
        ///     Value of selector component
        /// </summary>
        private string ValueOfSelector { get; set; }

        /// <summary>
        ///     Value of name component
        /// </summary>
        private string ValueOfName { get; set; }

        /// <summary>
        ///     Value of field component
        /// </summary>
        private string ValueOfCurrent { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor for two components parameter
        /// </summary>
        /// <param name="valueOfName">Value of field name</param>
        /// <param name="currentValue">Value of component</param>
        /// <param name="valueOfSelector">Value of selector component</param>
        public TwoComponentBlocksModel(string valueOfName, string currentValue, string valueOfSelector)
        {
            ValueOfName = valueOfName;
            ValueOfCurrent = currentValue;
            ValueOfSelector = valueOfSelector;
        }

        #endregion

        #region Public Methods

        public bool Validate()
        {
            var componentsValidator = new ComponentsValidator();
            switch (ValueOfName)
            {
                case "InputFrequency":
                {
                    return componentsValidator.Validate(ValueOfCurrent, _frequencyDictionary[ValueOfSelector].First(),
                        _frequencyDictionary[ValueOfSelector].Last());
                }

                case "InputPow":
                {
                    return componentsValidator.Validate(ValueOfCurrent, _powDictionary[ValueOfSelector].First(),
                        _powDictionary[ValueOfSelector].Last());
                }

                case "InputPulseWidth":
                {
                    return componentsValidator.Validate(ValueOfCurrent, _pulseWidthDictionary[ValueOfSelector].First(),
                        _pulseWidthDictionary[ValueOfSelector].Last());
                }

                case "InputPulsePeriod":
                {
                    return componentsValidator.Validate(ValueOfCurrent, _pulsePeriodDictionary[ValueOfSelector].First(),
                        _pulsePeriodDictionary[ValueOfSelector].Last());
                }

                case "InputDeviation":
                {
                    return componentsValidator.Validate(ValueOfCurrent, _deviationDictionary[ValueOfSelector].First(),
                        _deviationDictionary[ValueOfSelector].Last());
                }

                case "InputPulseDelay":
                {
                    return componentsValidator.Validate(ValueOfCurrent, _pulseDelayDictionary[ValueOfSelector].First(),
                        _pulseDelayDictionary[ValueOfSelector].Last());
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