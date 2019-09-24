namespace ServiceDesktop.Models.ComponentsAbstraction
{
    public abstract class AComponentModel
    {
        /// <summary>
        ///     Parameter Validator
        /// </summary>
        /// <returns>True - valid; False - not valid</returns>
        public abstract bool Validate();

        /// <summary>
        ///     Error message of validator
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Gets result valid
        /// </summary>
        /// <param name="valueOfCurrent">Current value</param>
        /// <param name="upper">Upper boundary</param>
        /// <param name="bottom">Bottom boundary</param>
        /// <returns></returns>
        protected bool Validate(string valueOfCurrent, double bottom, double upper)
        {
            var componentsValidator = new ComponentsValidator();
            if (componentsValidator.Validate(valueOfCurrent, bottom, upper)) return true;
            ErrorMessage = componentsValidator.ErrorMessage.ToString();
            return false;
        }
    }
}