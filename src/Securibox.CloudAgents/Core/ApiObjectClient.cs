namespace Securibox.CloudAgents.Core
{
    /// <summary>
    /// Abstract class to call each API method group.
    /// </summary>
    public abstract class ApiObjectClient
    {
        /// <summary>
        /// An authentication client
        /// </summary>
        protected AuthClient _authenticatedClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiObjectClient"/> class.
        /// </summary>
        /// <param name="authenticatedClient">An authentication API client</param>
        public ApiObjectClient(AuthClient authenticatedClient)
        {
            _authenticatedClient = authenticatedClient;
        }
    }
}
