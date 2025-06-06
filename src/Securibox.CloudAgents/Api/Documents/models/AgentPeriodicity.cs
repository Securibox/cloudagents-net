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
        HardWeekly = 0,
        /// <summary>
        /// The agent synchronizes automatically once a week.
        /// </summary>
        HardMonthly = 1,
        /// <summary>
        /// The agent synchronizes automatically once a month.
        /// </summary>
        Daily = 2,
        /// <summary>
        /// The agent synchronizes automatically once a week.
        /// </summary>
        Weekly = 3,
        /// <summary>
        /// The agent synchronizes automatically once every two weeks.
        /// </summary>
        Biweekly = 4,
        /// <summary>
        /// The agent synchronizes automatically once a month.
        /// </summary>
        Monthly = 5,
        /// <summary>
        /// The agent synchronizes automatically once every two monthes.
        /// </summary>
        Bimonthly = 6,
        /// <summary>
        /// The agent synchronizes automatically once every three monthes.
        /// </summary>
        Trimonthly = 7,
        /// <summary>
        /// The agent synchronizes automatically once every six monthes.
        /// </summary>
        Sixmonthly = 8,
        /// <summary>
        /// The agent synchronizes automatically once a year.
        /// </summary>
        Yearly = 9,
        /// <summary>
        /// The agent synchronizes automatically once every two weeks.
        /// </summary>
        HardBiweekly = 10,
        /// <summary>
        /// The agent synchronizes automatically once every two months.
        /// </summary>
        HardBimonthly = 11,
        /// <summary>
        /// The agent synchronizes automatically once every three months.
        /// </summary>
        HardTrimonthly = 12,
        /// <summary>
        /// The agent synchronizes automatically once every six months.
        /// </summary>
        HardSixmonthly = 13,
        /// <summary>
        /// The agent synchronizes automatically once a year.
        /// </summary>
        HardYearly = 14
    }
}
