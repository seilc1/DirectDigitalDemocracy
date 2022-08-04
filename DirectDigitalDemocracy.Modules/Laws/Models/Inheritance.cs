namespace DirectDigitalDemocracy.Modules.Laws.Models
{
    /// <summary>
    ///     Defines the Inheritance of a <see cref="Law"/>.
    /// </summary>
    public enum Inheritance
    {
        /// <summary>
        ///     The <see cref="Law"/> must also be applied on all child <see cref="Region"/>.
        /// </summary>
        Mandatory,

        /// <summary>
        ///     The <see cref="Law"/> can be revoked on child <see cref="Region"/>.
        /// </summary>
        Optional
    }
}