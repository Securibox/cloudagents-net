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

