namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Represents the status of a publishing item.
/// </summary>
public enum EPublishingStatus
{
    Draft,
    ReadyToEdit,
    ReadyToApproval,
    ApprovedAndLocked
}