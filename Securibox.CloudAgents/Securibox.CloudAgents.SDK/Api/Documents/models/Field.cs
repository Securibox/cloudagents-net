namespace Securibox.CloudAgents.SDK.Api.Documents.Models
{
    /// <summary>
    /// Field class.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public int Position { get; set; }
        /// <summary>
        /// Gets or sets the hint.
        /// </summary>
        /// <value>
        /// The hint.
        /// </value>
        public string Hint { get; set; }
        /// <summary>
        /// Gets or sets the place holder.
        /// </summary>
        /// <value>
        /// The place holder.
        /// </value>
        public string PlaceHolder { get; set; }
        /// <summary>
        /// Gets or sets the regex.
        /// </summary>
        /// <value>
        /// The regex.
        /// </value>
        public string Regex { get; set; }
        /// <summary>
        /// Gets or sets the type of the field input.
        /// </summary>
        /// <value>
        /// The type of the field input.
        /// </value>
        public FieldInputType FieldInputType { get; set; }
        /// <summary>
        /// Gets or sets the type of the field value.
        /// </summary>
        /// <value>
        /// The type of the field value.
        /// </value>
        public FieldValueType FieldValueType { get; set; }
    }
}
