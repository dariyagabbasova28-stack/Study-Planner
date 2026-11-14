using System;

namespace StudyMate.Models
{
    public class PomodoroSession
    {
        public int Id { get; set; }

        public DateTime CompletedAt { get; set; } = DateTime.Now;

        public int DurationMinutes { get; set; }
    }
}