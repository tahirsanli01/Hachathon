namespace Appointment.Common.Business.Abstract.Cache
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        //List<string> GetKeysByPattern(string pattern);
        object Get(string key);
        object GetRandomKey();
        List<string> GetWholeKeys();
        void Add(string key, object data, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        //void RemoveByPattern(string pattern);
    }
}
