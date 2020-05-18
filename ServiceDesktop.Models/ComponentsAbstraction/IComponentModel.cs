namespace RCLD.Models.ComponentsAbstraction
{
    public interface IComponentModel
    {
        /// <summary>
        ///     Parameter Validator
        /// </summary>
        /// <returns>True - valid; False - not valid</returns>
        bool Validate();
    }
}
