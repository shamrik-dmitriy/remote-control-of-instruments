using System.Text;

namespace RCLD.Models.ComponentsAbstraction
{
    /// <summary>
    ///     Validator Components Class
    /// </summary>
    public sealed class ComponentsValidator
    {
        #region Public properties

        /// <summary>
        ///     Error Message
        /// </summary>
        public StringBuilder ErrorMessage { get; set; }

        #endregion

        #region Private properties

        /// <summary>
        ///     Value for work
        /// </summary>
        private double OriginalValue { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Create Components Validator and initialize field
        /// </summary>
        public ComponentsValidator()
        {
            ErrorMessage = new StringBuilder();
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Validating Value
        /// </summary>
        /// <param name="original">Value for work</param>
        /// <param name="bottom">Bottom boundary value</param>
        /// <param name="upper">Upper Boundary value</param>
        /// <returns>True - value is valid, False - value is not valid</returns>
        public bool Validate(string original, double bottom, double upper)
        {
            if (!string.IsNullOrWhiteSpace(original))
            {
                return CheckType(original) && CheckBoundary(bottom, upper);
            }

            ErrorMessage.Append("Empty field");
            return false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Check, contains range value parameter
        /// </summary>
        /// <param name="bottom">Bottom boundary value</param>
        /// <param name="upper">Upper Boundary value</param>
        /// <returns>True - value is valid, False - value is not valid</returns>
        private bool CheckBoundary(double bottom, double upper)
        {
            if (OriginalValue < bottom)
            {
                ErrorMessage.Append("Minimal value is " + bottom);
                return false;
            }

            if (OriginalValue > upper)
            {
                ErrorMessage.Append("Maximal value is " + upper);
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Check is Type
        /// </summary>
        /// <param name="valueOfCheck">Value for check</param>
        /// <returns>True - value is double, False - value is not double</returns>
        private bool CheckType(string valueOfCheck)
        {
            if (double.TryParse(valueOfCheck, out var result))
            {
                OriginalValue = result;
                return true;
            }
            else
            {
                ErrorMessage.Append("Value is not double");
                return false;
            }
        }

        #endregion
    }
}