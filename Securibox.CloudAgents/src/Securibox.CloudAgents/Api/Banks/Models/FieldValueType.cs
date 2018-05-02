namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// Enumeration specifying the type of values expected by this field.
    /// </summary>
    public enum FieldValueType
    {
        /// <summary>
        /// Any kind of textual value
        /// </summary>
        Fulltext,
        /// <summary>
        /// Any kind of secured string
        /// </summary>
        Password,
        /// <summary>
        /// An email formated string
        /// </summary>
        Email,
        /// <summary>
        /// A phone formated string
        /// </summary>
        Telephone
    }
}
