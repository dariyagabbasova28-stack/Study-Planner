using StudyMate.Data;
using StudyMate.Models;

namespace StudyMate.Services
{
    public class SettingsService
    {
        private readonly SettingsDbContext _context;

        public SettingsService(SettingsDbContext context)
        {
            _context = context;
        }

        public AppSettings GetSettings()
        {
            var settings = _context.Settings.FirstOrDefault();

            if (settings == null)
            {
                settings = new AppSettings();

                _context.Settings.Add(settings);
                _context.SaveChanges();
            }

            return settings;
        }

        public void SaveSettings(AppSettings settings)
        {
            var existing = _context.Settings.FirstOrDefault();

            if (existing == null)
            {
                _context.Settings.Add(settings);
            }
            else
            {
                existing.StudentName = settings.StudentName;
                existing.University = settings.University;
                existing.Major = settings.Major;
                existing.Theme = settings.Theme;
                existing.FocusMinutes = settings.FocusMinutes;
                existing.ShortBreakMinutes = settings.ShortBreakMinutes;
                existing.LongBreakMinutes = settings.LongBreakMinutes;
                existing.ShowReminders = settings.ShowReminders;
            }

            _context.SaveChanges();
        }
    }
}