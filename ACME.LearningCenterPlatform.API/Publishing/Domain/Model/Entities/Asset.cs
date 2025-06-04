using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents a generic asset in the publishing context.
/// An asset can be any type of content that needs to be published, such as text content, images, or videos.
/// </summary>
/// <param name="type">
/// The type of the asset, which determines its specific characteristics and behavior.
/// </param>
public partial class Asset(EAssetType type) : IPublishable
{
    public int Id { get; }

    public AcmeAssetIdentifier AssetIdentifier { get; private set; } = new();
    public EPublishingStatus Status { get; private set; } = EPublishingStatus.Draft;
    public EAssetType Type { get; private set; } = type;
    public virtual bool Readable => false;
    public virtual bool Viewable => false;
    
    /// <summary>
    /// Sends the asset to the edit stage.
    /// </summary>
    public void SendToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Sends the asset to the approval stage.
    /// </summary>
    public void SendToApproval()
    {
        Status = EPublishingStatus.ReadyToApproval;
    }

    /// <summary>
    /// Approves the asset and locks it for further changes.
    /// </summary>
    public void ApproveAndLock()
    {
        Status = EPublishingStatus.ApprovedAndLocked;
    }

    /// <summary>
    /// Rejects the asset, returning it to the draft state.
    /// </summary>
    public void Reject()
    {
        Status = EPublishingStatus.Draft;
    }

    /// <summary>
    /// Returns the asset to the edit stage, allowing further modifications.
    /// </summary>
    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Returns the content of the asset. It can be overridden by derived classes to provide specific content.
    /// </summary>
    /// <returns></returns>
    public virtual object GetContent()
    {
        return string.Empty;
    }
}