namespace WPF_Library.Abstractions;

/// <summary>
/// Defines the basic structure of a model in the application.
/// </summary>
public interface IModel
{
    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    string FirstName { get; set; }
    
    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    string LastName { get; set; }

    /// <summary>
    /// Gets the full name, which is a concatenation of the first and last names.
    /// </summary>
    string FullName { get; }
}
