using PriorityDispatcher.Contracts.Models;

namespace PriorityDispatcher.Contracts.Interfaces
{
    public interface INotificationQueueService
    {
        public void Enqueue(NotificationTask notificationTask);
        public bool Dequeue(out NotificationTask? task);
        public int Count {  get; }

    }
}
