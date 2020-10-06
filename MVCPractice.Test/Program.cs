using System;
using MVCPractice.Cache.Redis;
using MVCPractice.MessageQueue.RabbitMQ;

namespace MVCPractice.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(ConfigHelper.ReadSetting("connectionstring:redis"));

            var cache = RedisHelper.StringService;

            cache.StringSet("333222111", new { name = 123, id = 321 });

            RabbitManager.Add();


            Console.ReadKey();
        }
    }
}
