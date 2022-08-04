namespace DirectDigitalDemocracy.Modules.Laws.Models
{
    /// <summary>
    ///     Defines what the Variable references to, allowing additional logic or validation.
    /// </summary>
    public enum VariableType
    {
        /// <summary>
        ///     The Variable has no additional semantic, and represents a double number.
        /// </summary>
        Double,

        /// <summary>
        ///     The Variable represents an amount of credits.
        /// </summary>
        Credits,

        /// <summary>
        ///     The Variable references to a <see cref="Core.Regions.Region"/>.
        /// </summary>
        Region,

        /// <summary>
        ///     The Variable references to a Fund of a <see cref="Core.Regions.Region"/>.
        /// </summary>
        Fund
    }
}