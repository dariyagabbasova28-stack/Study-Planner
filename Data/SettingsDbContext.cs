using Microsoft.EntityFrameworkCore;
using StudyMate.Models;

namespace StudyMate.Data
{
    public class SettingsDbContext : DbContext
    {
        public SettingsDbContext(
            DbContextOptions<SettingsDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppSettings> Settings { get; set; }
    }
}