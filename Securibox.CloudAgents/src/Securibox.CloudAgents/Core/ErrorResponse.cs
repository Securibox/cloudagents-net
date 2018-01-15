namespace Securibox.CloudAgents.Core
{
    /// <summary>
    /// Class reprsenting a response Error returned by the API.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// The error code
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// The error name
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// The error description
        /// </summary>
        public string Description { get; set; }
    }
}
