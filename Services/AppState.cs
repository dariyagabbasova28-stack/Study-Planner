using StudyMate.Models;

namespace StudyMate.Services
{
    public class AppState
    {
        private readonly SettingsService _settingsService;

        public AppSettings Settings { get; private set; } = new();

        public event Action? OnChange;

        public AppState(SettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public void LoadSettings()
        {
            Settings = Copy(_settingsService.GetSettings());
            NotifyStateChanged();
        }

        public void UpdateSettings(AppSettings updatedSettings)
        {
            var newSettings = Copy(updatedSettings);

            newSettings.FocusMinutes =
                Math.Clamp(newSettings.FocusMinutes, 1, 120);

            newSettings.ShortBreakMinutes =
                Math.Clamp(newSettings.ShortBreakMinutes, 1, 60);

            newSettings.LongBreakMinutes =
                Math.Clamp(newSettings.LongBreakMinutes, 1, 60);

            _settingsService.SaveSettings(newSettings);

            Settings = newSettings;

            NotifyStateChanged();
        }

        private static AppSettings Copy(AppSettings source)
        {
            return new AppSettings
            {
                Id = source.Id,
                StudentName = source.StudentName,
                University = source.University,
                Major = source.Major,
                Theme = source.Theme,
                FocusMinutes = source.FocusMinutes,
                ShortBreakMinutes = source.ShortBreakMinutes,
                LongBreakMinutes = source.LongBreakMinutes,
                ShowReminders = source.ShowReminders
            };
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}