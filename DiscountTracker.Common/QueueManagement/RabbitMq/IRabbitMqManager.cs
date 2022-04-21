using DiscountTracker.Entities;

namespace DiscountTracker.Common.QueueManagement.RabbitMq
{
    public interface IRabbitMqManager
    {
        bool SendDataToQueue(QueueType queueType, object data);
    }
}
