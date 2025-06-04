namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Represents an Identifier for an ACME Asset.
/// </summary>
/// <param name="Identifier">
/// The unique identifier for the ACME Asset.
/// </param>
public record AcmeAssetIdentifier(Guid Identifier)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AcmeAssetIdentifier"/> record with a specified identifier.
    /// </summary>
    public AcmeAssetIdentifier() : this(Guid.Empty) { }
};