using DirectDigitalDemocracy.Core.Regions;

namespace DirectDigitalDemocracy.Modules.Laws.Models
{
    /// <summary>
    ///     Defined Law with Text and Variables.
    /// </summary>
    public record Law(string LawTemplateText, Region ActiveRegion, DateTimeOffset ActiveFrom)
    {
        /// <summary>
        ///     Parent  <see cref="Law"/>, if this <see cref="Law"/> is an amendment to another <see cref="Law"/>.
        /// </summary>
        public Law? Parent { get; init; }

        /// <summary>
        ///     Index characters for this <see cref="Law"/> on the current Level.
        /// </summary>
        /// <remarks>
        ///     assume: we have a top Fee Law: T120 with an amendment I and this is the fourthed extension,
        ///     the Index would be `4`.
        ///     <b>Must be unique per Layer</b>
        /// </remarks>
        public string Index { get; init; }

        /// <summary>
        ///     Full Index identifier for this <see cref="Law"/>.
        /// </summary>
        /// <remarks>
        ///     assume: we have a top Fee Law: T120 with an amendment I and this is the fourthed extension,
        ///     the FullIndex would be `T120.I.4`.
        ///     <b>Must be globally unique</b>
        /// </remarks>
        public string FullIndex => Parent?.FullIndex + "." + Index;

        /// <summary>
        ///     Law Text with templated variables present.
        /// </summary>
        public string LawTemplateText { get; } = LawTemplateText;

        /// <summary>
        ///     <see cref="Core.Regions.Region"/> where the <see cref="Law"/> is active.
        /// </summary>
        public Region ActiveRegion { get; } = ActiveRegion;

        /// <summary>
        ///     Start of validity of this <see cref="Law"/>
        /// </summary>
        public DateTimeOffset ActiveFrom { get; } = ActiveFrom;

        /// <summary>
        ///     End of validity of this <see cref="Law"/>.
        /// </summary>
        /// <remarks>
        ///     To be set, when a <see cref="Law"/> has been voted to be revoked.
        /// </remarks>
        public DateTimeOffset? ActiveTo { get; init; } = null;

        /// <summary>
        ///     Defines the <see cref="Models.Inheritance"/> of the Law.
        /// </summary>
        public Inheritance Inheritance { get; init; } = Inheritance.Mandatory;

        /// <summary>
        ///     Defines the <see cref="Models.Configurability"/> of the Law incase of inheritance
        /// </summary>
        public Configurability Configurability { get; init; } = Configurability.All;

        /// <summary>
        ///     Parsed <see cref="Variable"/> from the <see cref="LawTemplateText"/>.
        /// </summary>
        public IEnumerable<Variable> Variables { get; } = TemplateTextParser.Parse(LawTemplateText);
    }
}