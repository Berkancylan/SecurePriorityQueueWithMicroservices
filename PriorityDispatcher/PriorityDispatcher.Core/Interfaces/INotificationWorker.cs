using PriorityDispatcher.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityDispatcher.Contracts.Interfaces
{
    public interface INotificationWorker
    {
        Task ProcessTaskAsync(NotificationTask task);
    }
}
