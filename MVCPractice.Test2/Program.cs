using MVCPractice.Config;
using System;

namespace MVCPractice.Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConfigHelper.ReadSetting("key"));
            ConfigHelper.WriteUpdateSetting("redis", "redisconneciton");

            Console.ReadKey();
        }
    }
}
