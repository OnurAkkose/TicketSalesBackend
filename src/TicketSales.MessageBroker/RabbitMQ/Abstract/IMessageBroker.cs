using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSales.MessageBroker.RabbitMQ.Abstract
{
    public interface IMessageBroker
    {
        Task Publish(string exchangeName, string? routingKey, object message);
    }
}
