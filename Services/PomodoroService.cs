using Microsoft.EntityFrameworkCore;
using StudyMate.Data;
using StudyMate.Models;

namespace StudyMate.Services
{
    public class PomodoroService
    {
        private readonly AppDbContext _context;

        public PomodoroService(AppDbContext context)
        {
            _context = context;
        }

        public List<PomodoroSession> GetAll()
        {
            return _context.Set<PomodoroSession>()
                .AsNoTracking()
                .OrderByDescending(s => s.CompletedAt)
                .ToList();
        }

        public void AddSession(int minutes)
        {
            if (minutes <= 0)
                return;

            var session = new PomodoroSession
            {
                DurationMinutes = minutes,
                CompletedAt = DateTime.Now
            };

            _context.Set<PomodoroSession>().Add(session);
            _context.SaveChanges();
        }

        public int GetTotalSessions()
        {
            return _context.Set<PomodoroSession>().Count();
        }

        public int GetTotalMinutes()
        {
            return _context.Set<PomodoroSession>()
                .Sum(s => (int?)s.DurationMinutes) ?? 0;
        }
    }
}