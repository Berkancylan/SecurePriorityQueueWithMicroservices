using Microsoft.AspNetCore.Mvc;
using PriorityDispatcher.Contracts.Interfaces;
using PriorityDispatcher.Contracts.Models;

namespace PriorityDispatcher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IEncryptionService _encryptionService;
        private readonly INotificationQueueService _notificationQueue;

        public NotificationController(IEncryptionService encryptionService, INotificationQueueService notificationQueue)
        {
            _encryptionService = encryptionService;
            _notificationQueue = notificationQueue;
        }

        [HttpPost("send")]
        public IActionResult SendNotification([FromBody] NotificationTask task)
        {
            task.Content = _encryptionService.Encryption(task.Content);

            _notificationQueue.Enqueue(task);

            return Ok(new { Message = "Kuyruğa alındı", TaskId = task.Id, DecryptMessage = task.Content });
        }

        [HttpGet("count")]
        public IActionResult GetQueueCount()
        {
            var count = _notificationQueue.Count;
            return Ok(new { QueueLength = count });
        }
    }
}
