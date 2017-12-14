using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.SDK.Api.Documents.Models
{
    /// <summary>
    /// SynchronizationState cenum
    /// </summary>
    public enum SynchronizationState
    {
        NewAccount,
        Created,
        Running,
        AgentFailed,
        Delivering,
        PendingAcknowledgement,
        Completed,
        ReportFailed
    }
}
