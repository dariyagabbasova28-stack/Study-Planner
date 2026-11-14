using Microsoft.EntityFrameworkCore;
using StudyMate.Models;

namespace StudyMate.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }

        public DbSet<PomodoroSession> PomodoroSessions { get; set; }
    }
}