using MVCPractice.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCPractice.MessageQueue.RabbitMQ
{
    public static class RabbitManager
    {
        private static string HostName = ConfigHelper.ReadSetting("RabbitMQ:HostName");

        static RabbitManager()
        {
            
        }

        public static void Add()
        {
            
        }
    }
}
