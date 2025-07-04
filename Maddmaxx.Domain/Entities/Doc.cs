namespace Maddmaxx.Domain.Entities;

/// <summary>
/// Represents a document in the Docs table.
/// </summary>
public class Doc
{
    /// <summary>
    /// The unique identifier for the document.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// The JSON content of the document.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// The content type of the document (e.g. application/json).
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    /// The date/time the document was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Whether the document has been processed.
    /// </summary>
    public bool Processed { get; set; }

    /// <summary>
    /// The date/time the document was processed, if any.
    /// </summary>
    public DateTime? ProcessedDate { get; set; }
}
