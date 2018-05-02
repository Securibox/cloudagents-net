namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// Enumeration specifying the type of inputs that could be used to ask for the field value.
    /// </summary>
    public enum FieldInputType
    {
        /// <summary>
        /// Type of input that allows one to see the value entered in the field.
        /// </summary>
        Public,
        /// <summary>
        /// Type of input that should hide the value entered in the field.
        /// </summary>
        Private,
        /// <summary>
        /// Type of input that should only allow numeric values.
        /// </summary>
        NumberPad
    }
}
