using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudagents_csharp.cloudagents.api.documents.models
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
