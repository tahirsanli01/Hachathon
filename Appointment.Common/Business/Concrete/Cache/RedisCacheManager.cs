using Appointment.Common.Business.Abstract.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Appointment.Common.Business.Concrete.Cache
{
    public class RedisCacheManager : IRedisCacheManagerIndexes0,
        IRedisCacheManagerForComingAppointmentLessOneHour1,
        IRedisCacheManagerForComingAppointmentUpperOneHour2,
        IRedisCacheManagerForComingAppointmentFirstSmsLessOneHour3,
        IRedisCacheManagerForComingAppointmentFirstSmsUpperOneHour4,
        IRedisSmsCheck14,
        IRedisTracking15,
        IRedisOrderHelper5,
        IRedisRequestDirectorateCode6,
        IRedisAuthorizedUserAccount7

    {
        private IDatabase _database;
        private RedisCacheOptions options;
        private string defaultConnectionString { get; set; }
        private static ConnectionMultiplexer _connectionMultiplexer;
        RedisCache redisCache;
        int _databaseIndex = 0;
        public RedisCacheManager(int db)
        {
            _databaseIndex = db;

            #region Set ConnectionString
            defaultConnectionString = "127.0.0.1:6379";
            #endregion


            options = new RedisCacheOptions
            {
                Configuration = defaultConnectionString
            };
            _connectionMultiplexer = ConnectionMultiplexer.Connect(defaultConnectionString);

            redisCache = new RedisCache(options);

            _database = _connectionMultiplexer.GetDatabase(db);

        }
        public void Add(string key, object data, int duration)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(duration)
            };

            var valueString = JsonConvert.SerializeObject(data);
            _database.StringSet(key, valueString);
        }

        public T Get<T>(string key)
        {
            var valueString = _database.StringGet(key);

            if (!string.IsNullOrEmpty(valueString))
            {
                var valueObject = JsonConvert.DeserializeObject<T>(valueString);

                return (T)valueObject;
            }

            return default(T);
        }


        public object Get(string key)
        {
            var valueString = _database.StringGet(key);

            return valueString;
        }

        public object GetRandomKey()
        {
            var valueString = _database.KeyRandom(CommandFlags.None);

            return valueString.ToString();
        }
        public List<string> GetWholeKeys()
        {
            return _connectionMultiplexer.GetServer(defaultConnectionString).Keys(_databaseIndex).Select(x => x.ToString()).ToList();
        }

        public bool IsAdd(string key)
        {
            RedisKey k = key;
            return _database.KeyExists(k);
        }

        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }
    }
}
