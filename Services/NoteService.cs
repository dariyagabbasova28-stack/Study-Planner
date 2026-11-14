using Microsoft.EntityFrameworkCore;
using StudyMate.Models;

namespace StudyMate.Services
{
    public class NoteService
    {
        private readonly NoteDbContext _context;

        public NoteService(NoteDbContext context)
        {
            _context = context;
        }

        public List<StudyNote> GetAll()
        {
            return _context.Notes
                .AsNoTracking()
                .OrderByDescending(n => n.UpdatedAt)
                .ToList();
        }

        public void Add(StudyNote note)
        {
            note.Id = 0;
            note.CreatedAt = DateTime.Now;
            note.UpdatedAt = DateTime.Now;

            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void Update(StudyNote note)
        {
            var existing = _context.Notes.Find(note.Id);

            if (existing == null)
                return;

            existing.Title = note.Title;
            existing.Content = note.Content;
            existing.Subject = note.Subject;
            existing.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var note = _context.Notes.Find(id);

            if (note == null)
                return;

            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
    }

    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudyNote> Notes => Set<StudyNote>();
    }
}