using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents a category in the publishing context.
/// </summary>
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// Default constructor for Category.
    /// </summary>
    public Category()
    {
        Name = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class with a specified name.
    /// </summary>
    /// <param name="name">
    /// The name of the category.
    /// </param>
    public Category(string name)
    {
        Name = name;
    }

    public Category(CreateCategoryCommand command)
    {
        Name = command.Name;
    }
}