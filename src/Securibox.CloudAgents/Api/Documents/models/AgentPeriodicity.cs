namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Enumeration to define the agent synchronization periodicity.
    /// </summary>
    public enum AgentPeriodicity
    {
        /// <summary>
        /// The agent never synchronizes automatically.
        /// </summary>
        None,
        /// <summary>
        /// The agent synchronizes automatically once a day.
        /// </summary>
        Daily,
        /// <summary>
        /// The agent synchronizes automatically once a week.
        /// </summary>
        Weekly,
        /// <summary>
        /// The agent synchronizes automatically once every two weeks.
        /// </summary>
        Biweekly,
        /// <summary>
        /// The agent synchronizes automatically once a month.
        /// </summary>
        Monthly,
        /// <summary>
        /// The agent synchronizes automatically once every two monthes.
        /// </summary>
        Bimonthly,
        /// <summary>
        /// The agent synchronizes automatically once every three monthes.
        /// </summary>
        Trimonthly,
        /// <summary>
        /// The agent synchronizes automatically once every six monthes.
        /// </summary>
        Sixmonthly,
        /// <summary>
        /// The agent synchronizes automatically once a year.
        /// </summary>
        Yearly
    }
}
