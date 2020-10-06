using System;
using System.Collections.Generic;
using System.Text;

namespace MVCPractice.MessageQueue.RabbitMQ
{
    public enum ExchangeTypes
    {
        fanout,
        headers,
        direct,
        topic
    }
}
