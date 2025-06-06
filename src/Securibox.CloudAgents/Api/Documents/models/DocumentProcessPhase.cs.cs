namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Enumeration specifying the document process phase
    /// </summary>
    public enum DocumentProcessPhase
    {
        /// <summary>
        /// The document is waiting to be parsed.
        /// </summary>
        ToParse,
        /// <summary>
        /// The document is waiting to be delivered.
        /// </summary>
        ToDeliver,
        /// <summary>
        /// The document has been packaged and ready to be delivered.
        /// </summary>
        Packaged,
        /// <summary>
        /// The document has been delivered.
        /// </summary>
        Delivered,
        /// <summary>
        /// The document has been acknowledged.
        /// </summary>
        Acknowledged,
        /// <summary>
        /// The document has been acknowledged but the acknowledgement has failed.
        /// </summary>
        AcknowledgementFailed,
        /// <summary>
        /// The document has been not been delivered successfully.
        /// </summary>
        DeliveryFailed,
        /// <summary>
        /// The document is still holding in the queue and has not been processed yet.
        /// </summary>
        Holding,
        /// <summary>
        /// The document is being parsed.
        /// </summary>
        Parsing,
        /// <summary>
        /// The document will be pack.
        /// </summary>
        ToPack
    }
}

