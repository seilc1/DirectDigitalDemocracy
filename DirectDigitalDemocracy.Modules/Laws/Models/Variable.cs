namespace DirectDigitalDemocracy.Modules.Laws.Models
{
    /// <summary>
    ///     Configurable Variables in the <see cref="Law.LawTemplateText"/>.
    /// </summary>
    public record Variable(string Name, string Value, VariableType VariableType = VariableType.Double)
    {
        /// <summary>
        ///     Name of the <see cref="Variable"/> in the <see cref="Law.LawTemplateText"/>.
        /// </summary>
        public string Name { get; } = Name;

        /// <summary>
        ///     Value of the <see cref="Variable"/> for the given <see cref="Law"/>.
        /// </summary>
        public string Value { get; } = Value;

        /// <summary>
        ///     Optional Reference Type of the Variable, to allow additional validation.
        /// </summary>
        /// <example>
        ///     Could be `Region` to 
        /// </example>
        public VariableType VariableType { get; } = VariableType;

        /// <summary>
        ///     Returns the Value as a double value, if the <see cref="VariableType"/> allows it.
        /// </summary>
        public double ValueAsDouble() => VariableType == VariableType.Double || VariableType == VariableType.Credits ? double.Parse(Value) : -1;
    }
}