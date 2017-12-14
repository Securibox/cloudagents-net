using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.SDK.Api.Documents.Models
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

