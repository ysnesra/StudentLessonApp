using StackExchange.Redis;


namespace StudentLessonApp.Redis.Services
{
    public class RedisService
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string url)
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(url);
        }

        // GetDb fonksiyonu Redisdeki hangi Db ye bağlanıyorsa onu getirir
        public IDatabase GetDb(int dbIndex)
        {
            return _connectionMultiplexer.GetDatabase(dbIndex);
        }
    }
}
