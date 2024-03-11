using WPF_Library.Abstractions;

namespace WPF_Library.Models;

/// <summary>
/// Represents a person, implementing the IModel interface.
/// </summary>
public class PersonModel : IModel
{
    /// <summary>
    /// Gets or sets the first name of the person.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the last name of the person.
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets the full name by concatenating the first name and the last name.
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";
}
