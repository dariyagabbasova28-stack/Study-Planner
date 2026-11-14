using System;
using System.ComponentModel.DataAnnotations;

namespace StudyMate.Models
{
    public enum StudyTaskStatus
    {
        Pending,
        InProgress,
        Completed
    }

    public enum StudyTaskPriority
    {
        Low,
        Medium,
        High
    }

    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Task title is required")]
        public string Title { get; set; } = "";

        public string Subject { get; set; } = "";

        public string Description { get; set; } = "";

        public DateTime DueDate { get; set; } = DateTime.Today;

        public StudyTaskStatus Status { get; set; }
            = StudyTaskStatus.Pending;

        public StudyTaskPriority Priority { get; set; }
            = StudyTaskPriority.Medium;
    }
}