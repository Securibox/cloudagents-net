namespace Securibox.CloudAgents.Api.Documents.Models
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

