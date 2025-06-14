using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;

public partial class Tutorial : IPublishable
{
    public ICollection<Asset> Assets { get; }
    public EPublishingStatus Status { get; protected set; }
    public bool HasReadableAssets => Assets.Any(asset => asset.Readable);
    public bool HasViewableAssets => Assets.Any(asset => asset.Viewable);
    public bool Readable => HasReadableAssets;
    public bool Viewable => HasViewableAssets;
    
    public Tutorial()
    {
        Title = string.Empty;
        Summary = string.Empty;
        Assets = new List<Asset>();
    }
    
    private bool HasAllAssetsWithStatus(EPublishingStatus status)
    {
        return Assets.All(asset => asset.Status == status);
    }
    
    public void SendToEdit()
    {
        if(HasAllAssetsWithStatus(EPublishingStatus.ReadyToEdit))
            Status = EPublishingStatus.ReadyToEdit;
    }

    public void SendToApproval()
    {
        if(HasAllAssetsWithStatus(EPublishingStatus.ReadyToApproval))
            Status = EPublishingStatus.ReadyToApproval;
    }

    public void ApproveAndLock()
    {
        if(HasAllAssetsWithStatus(EPublishingStatus.ApprovedAndLocked))
            Status = EPublishingStatus.ApprovedAndLocked;
    }

    public void Reject()
    {
        Status = EPublishingStatus.Draft;
    }

    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    private bool ExistsImageWithUrl(string imageUrl)
    {
        return Assets.Any(asset => asset.Type == EAssetType.Image &&
                                   (string)asset.GetContent() == imageUrl);
    }

    private bool ExistsVideoWithUrl(string videoUrl)
    {
        return Assets.Any(asset => asset.Type == EAssetType.Video &&
                                   (string)asset.GetContent() == videoUrl);
    }

    private bool ExistsReadableContent(string content)
    {
        return Assets.Any(asset => asset.Readable &&
                                   (string)asset.GetContent() == content);
    }

    public void AddImage(string imageUrl)
    {
        if(ExistsImageWithUrl(imageUrl)) return;
        Assets.Add(new ImageAsset(imageUrl));
    }
    
    public void AddVideo(string videoUrl)
    {
        if(ExistsVideoWithUrl(videoUrl)) return;
        Assets.Add(new VideoAsset(videoUrl));
    }
}