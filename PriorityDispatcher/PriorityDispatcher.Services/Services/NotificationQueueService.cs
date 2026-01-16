using PriorityDispatcher.Contracts.Models;
using PriorityDispatcher.Contracts.Interfaces;

namespace PriorityDispatcher.Services
{
    public class NotificationQueueService : INotificationQueueService
    {
        private readonly PriorityQueue<NotificationTask, int>? _queue = new();
        private readonly object? _lock = new();
        public void Enqueue(NotificationTask notificationTask)
        {
            lock (_lock!)
            {
                int priorityValue = 3 - (int)notificationTask.Priority;//Sayı küçüldükçe önemi artar(.NET'de)

                _queue!.Enqueue(notificationTask, priorityValue);
            }
        }
        public bool Dequeue(out NotificationTask? task)
        {
            lock (_lock!)
            {
                return _queue!.TryDequeue(out task, out _);//Queue boşsa false döner.
                
            }
        }

        public int Count
        {
            get { lock (_lock!) return _queue!.Count; }
        }
    }
}
