namespace WPF_Library.Abstractions;

/// <summary>
/// Provides a mechanism for validating models.
/// </summary>
public interface IValidator
{
    /// <summary>
    /// Validates the specified model.
    /// </summary>
    /// <param name="model">The model instance to validate.</param>
    void Validate(IModel model);
}
