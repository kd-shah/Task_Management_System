using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        
        public required string Title { get; set; }

        public required string Description { get; set; }

        public TaskStatus Status { get; set; }

        public DateTime Due_Date { get; set; }

        public TaskPriority Priority { get; set; }
    }

    public enum TaskStatus
    {
        Todo, 
        InProgress,
        Done
    }

    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }


}
