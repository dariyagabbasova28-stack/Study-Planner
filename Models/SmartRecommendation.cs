using System;

namespace StudyMate.Models
{
    public class SmartRecommendation
    {
        public int TaskId { get; set; }

        public string Title { get; set; } = "";

        public string Subject { get; set; } = "";

        public DateTime DueDate { get; set; }

        public StudyTaskPriority Priority { get; set; }

        public StudyTaskStatus Status { get; set; }

        public int Score { get; set; }

        public string UrgencyLevel { get; set; } = "";

        public string Reason { get; set; } = "";

        public string SuggestedAction { get; set; } = "";
    }
}