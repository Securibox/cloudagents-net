using Newtonsoft.Json;
using Securibox.CloudAgents.Api.Banks.Serializers;

namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// The account working mode.
    /// </summary>
    [JsonConverter(typeof(AccountModeSerializer))]
    public enum AccountMode
    {
        /// <summary>
        /// Account disabled and will not synchronize at all.
        /// </summary>
        Disabled,
        /// <summary>
        /// Account is enabled and will synchronise manually as well as automatically.
        /// </summary>
        Enabled,
        /// <summary>
        /// Account will only synchronise manually through the API.
        /// </summary>
        NoAutomaticSynch
    }
}
