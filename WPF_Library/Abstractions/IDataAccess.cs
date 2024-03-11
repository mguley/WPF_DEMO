namespace WPF_Library.Abstractions;

/// <summary>
/// Defines an interface for data access operations.
/// </summary>
public interface IDataAccess
{
    /// <summary>
    /// Adds a data model to the data store.
    /// </summary>
    /// <param name="model">The data model to add.</param>
    void AddData(IModel model);

    /// <summary>
    /// Retrieves an array of all data models from the data store.
    /// </summary>
    /// <returns>An array of IModel instances representing the data models in the data store.</returns>
    IModel[] GetList();
}
