﻿using Appointment.Common.Business.Abstract.Cache;
using Microsoft.Extensions.Caching.Memory;
using System.Text.RegularExpressions;

namespace Appointment.Common.Business.Concrete.Cache
{
    //public class MemoryCacheManager : IMemoryCacheManager
    //{
    //    private IMemoryCache _cache;
    //    public MemoryCacheManager(IMemoryCache cache)
    //    {
    //        _cache = cache;
    //    }
    //    public T Get<T>(string key)
    //    {
    //        return _cache.Get<T>(key);
    //    }

    //    public object Get(string key)
    //    {
    //        return _cache.Get(key);
    //    }

    //    public void Add(string key, object data, int duration)
    //    {
    //        _cache.Set(key, data, TimeSpan.FromMinutes(duration));
    //    }

    //    public bool IsAdd(string key)
    //    {
    //        return _cache.TryGetValue(key, out _);
    //    }

    //    public void Remove(string key)
    //    {
    //        _cache.Remove(key);
    //    }

    //    public void RemoveByPattern(string pattern)
    //    {
    //        var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    //        var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_cache) as dynamic;
    //        List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

    //        foreach (var cacheItem in cacheEntriesCollection)
    //        {
    //            ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
    //            cacheCollectionValues.Add(cacheItemValue);
    //        }

    //        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
    //        var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

    //        foreach (var key in keysToRemove)
    //        {
    //            _cache.Remove(key);
    //        }
    //    }

    //    public List<string> GetKeysByPattern(string pattern)
    //    {
    //        var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    //        var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_cache) as dynamic;
    //        List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

    //        foreach (var cacheItem in cacheEntriesCollection)
    //        {
    //            ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
    //            cacheCollectionValues.Add(cacheItemValue);
    //        }

    //        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
    //        return cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key.ToString()).ToList();
    //    }
    //}
}
