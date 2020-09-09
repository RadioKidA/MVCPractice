using MVCPractice.Config;
using System;
using System.Configuration;

namespace MVCPractice.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConfigManager.ReadSetting("redis"));
            
        }
    }
}
