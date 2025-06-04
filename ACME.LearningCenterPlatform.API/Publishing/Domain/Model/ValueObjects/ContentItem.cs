namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Represents a content item in the publishing domain.
/// </summary>
/// <param name="Type"></param>
/// <param name="Content"></param>
public record ContentItem(string Type, string Content);