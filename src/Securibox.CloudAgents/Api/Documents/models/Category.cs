namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Class representing a category of agents.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// The category identifier
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The category name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The category description
        /// </summary>
        public string Description { get; set; }
    }
}
