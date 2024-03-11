using WPF_Library.Abstractions;

namespace WPF_Library.Services;

/// <summary>
/// Implements validation for models implementing the IModel interface.
/// </summary>
public class Validator : IValidator
{
    /// <summary>
    /// Validates the provided model by checking the FirstName and LastName properties.
    /// </summary>
    /// <param name="model">The model to validate.</param>
    /// <exception cref="ArgumentNullException">Thrown when the provided model is null.</exception>
    /// <exception cref="ArgumentException">Thrown when either FirstName or LastName is null, empty, or consists only of white-space characters.</exception>
    public void Validate(IModel model)
    {
        ArgumentNullException.ThrowIfNull(model);
        
        if (string.IsNullOrWhiteSpace(model.FirstName))
        {
            throw new ArgumentException(
                message: "FirstName cannot be null, empty, or consist only of white-space characters.",
                paramName: nameof(model));
        }
        
        if (string.IsNullOrWhiteSpace(model.LastName))
        {
            throw new ArgumentException(
                message: "LastName cannot be null, empty, or consist only of white-space characters.",
                paramName: nameof(model));
        }
    }
}
