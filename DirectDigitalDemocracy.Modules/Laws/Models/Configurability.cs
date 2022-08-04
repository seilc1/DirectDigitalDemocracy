namespace DirectDigitalDemocracy.Modules.Laws.Models
{
    /// <summary>
    ///     Defines the Configurability of <see cref="Variable"/> in the <see cref="Law"/>.
    /// </summary>
    public enum Configurability
    {
        /// <summary>
        ///     The <see cref="Variable"/> can be changed in any way.
        /// </summary>
        All,

        /// <summary>
        ///     The value of the <see cref="Variable"/> can only be increased.
        /// </summary>
        Increase,

        /// <summary>
        ///     The value of the <see cref="Variable"/> can only be decreased.
        /// </summary>
        Decrease
    }
}