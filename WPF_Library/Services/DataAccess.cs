using System.IO;
using WPF_Library.Abstractions;
using WPF_Library.Models;

namespace WPF_Library.Services;

/// <summary>
/// Provides data access services for PersonModel objects, allowing them to be retrieved
/// from and stored in a file-based repository.
/// </summary>
public class DataAccess : IDataAccess
{
    private const string PersonTextFile = "PersonText.txt";
    private readonly IValidator? _validator;

    /// <summary>
    /// Initializes a new instance of the DataAccess class with dependency injection for the IValidator.
    /// </summary>
    /// <param name="validator">The validator to use for data validation.</param>
    public DataAccess(IValidator validator) : this()
    { 
        _validator = validator;
    }

    /// <summary>
    /// Default constructor that initializes data from the PersonText.txt file.
    /// </summary>
    public DataAccess()
    {
        InitializeData();
    }

    /// <summary>
    /// Reads person data from a file and loads it into the cache. If the PersonText.txt
    /// file does not exist, no data is loaded.
    /// </summary>
    private void InitializeData()
    {
        if (!File.Exists(path: PersonTextFile))
        {
            return;
        }

        try
        {
            var output = new List<PersonModel>();
            string[] content = File.ReadAllLines(path: PersonTextFile);

            foreach (string line in content)
            {
                string[] data = line.Split(separator: ',');
                if (data.Length >= 2)
                {
                    output.Add(item: new PersonModel
                    {
                        FirstName = data[0],
                        LastName = data[1]
                    });
                }
            }

            TimeBasedCache.SaveItems(items: output.ToArray());
        }
        catch (Exception)
        {
            // Handle or log exceptions as needed.
        }
    }

    /// <summary>
    /// Adds a new person model to the cache after validation. If the model is not a PersonModel
    /// or fails validation, it is not added.
    /// </summary>
    /// <param name="model">The model to add, expected to be a PersonModel instance.</param>
    public void AddData(IModel model)
    {
        if (model is PersonModel personModel)
        {
            try
            {
                _validator?.Validate(model: personModel);
                List<PersonModel> cachedItems = TimeBasedCache.GetItems();
                cachedItems.Add(personModel);
                TimeBasedCache.SaveItems(items: cachedItems.ToArray());
            }
            catch (Exception)
            {
                // Handle or log exceptions as needed.
            }
        }
    }

    /// <summary>
    /// Retrieves all person models from the cache.
    /// </summary>
    /// <returns>An array of IModel instances representing the person models in the cache.</returns>
    public IModel[] GetList()
    {
        List<PersonModel> cachedItems = TimeBasedCache.GetItems();
        return cachedItems.Cast<IModel>().ToArray();
    }
}
