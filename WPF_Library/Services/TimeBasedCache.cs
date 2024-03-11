using System.Runtime.Caching;
using WPF_Library.Models;

namespace WPF_Library.Services;

/// <summary>
/// Provides a time-based caching mechanism for PersonModel objects.
/// </summary>
internal static class TimeBasedCache
{
    /// <summary>
    /// The cache key for accessing the PersonModel objects.
    /// </summary>
    private const string CacheKey = "PersonModels";
    
    /// <summary>
    /// The MemoryCache instance used to store cached data.
    /// </summary>
    private static readonly MemoryCache Cache = MemoryCache.Default;

    /// <summary>
    /// Retrieves the cached PersonModel objects from the memory cache.
    /// </summary>
    /// <returns>A list of PersonModel objects if found in the cache; otherwise, an empty list.</returns>
    public static List<PersonModel> GetItems()
    {
        if (Cache.Get(key: CacheKey) is PersonModel[] cachedItems)
        {
            return new List<PersonModel>(cachedItems);
        }

        return new List<PersonModel>();
    }

    /// <summary>
    /// Saves the provided array of PersonModel objects to the memory cache with an absolute expiration.
    /// </summary>
    /// <param name="items">The array of PersonModel objects to cache.</param>
    /// <returns>true if the operation is successful; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the provided array of items is null.</exception>
    public static bool SaveItems(PersonModel[] items)
    {
        ArgumentNullException.ThrowIfNull(items);
        
        if (items.Length == 0)
        {
            return false;
        }
        
        CacheItemPolicy policy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
        };
        
        try
        {
            Cache.Set(key: CacheKey, value: items, policy: policy);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
