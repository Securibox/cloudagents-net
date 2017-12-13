using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudagents_csharp.cloudagents.api.documents.models
{
    public enum DocumentProcessPhase
    {
        ToParse,
        ToDeliver,
        Packaged,
        Delivered,
        Acknowledged,
        AcknowledgementFailed,
        DeliveryFailed
    }
}

