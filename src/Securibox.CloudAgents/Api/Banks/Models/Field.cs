using System;

namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// A class representing an agent login field.
    /// </summary>
    [Obsolete("This class is deprecated.")]
    public class Field
    {
        /// <summary>
        /// The field name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The field position.
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// The field hint.
        /// </summary>
        public string Hint { get; set; }
        /// <summary>
        /// The field place holder.
        /// </summary>
        public string PlaceHolder { get; set; }
        /// <summary>
        /// The regex that can be used to validate the field value.
        /// </summary>
        public string Regex { get; set; }
        /// <summary>
        /// The type of input that can be used to display the field.
        /// </summary>
        public FieldInputType FieldInputType { get; set; }
        /// <summary>
        /// The type of the value that this field should hold.
        /// </summary>
        public FieldValueType FieldValueType { get; set; }
    }
}
