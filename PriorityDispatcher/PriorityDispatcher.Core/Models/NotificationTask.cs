using PriorityDispatcher.Contracts.Enums;

namespace PriorityDispatcher.Contracts.Models
{
    public class NotificationTask
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string Recipient { get; set; } = string.Empty; 
        public string Content { get; set; } = string.Empty;
        public PriorityLevel Priority { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
