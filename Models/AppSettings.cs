namespace StudyMate.Models
{
    public class AppSettings
    {
        public int Id { get; set; }

        public string StudentName { get; set; } = "";

        public string University { get; set; } = "";

        public string Major { get; set; } = "";

        public string Theme { get; set; } = "Purple";

        public int FocusMinutes { get; set; } = 25;

        public int ShortBreakMinutes { get; set; } = 5;

        public int LongBreakMinutes { get; set; } = 15;

        public bool ShowReminders { get; set; } = true;
    }
}