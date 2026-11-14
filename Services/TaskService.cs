using Microsoft.EntityFrameworkCore;
using StudyMate.Data;
using StudyMate.Models;

namespace StudyMate.Services
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public List<TaskItem> GetAll()
        {
            return _context.Tasks.AsNoTracking().ToList();
        }

        public void Add(TaskItem task)
        {
            task.Id = 0;
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public void MarkCompleted(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task != null)
            {
                task.Status = StudyTaskStatus.Completed;
                _context.SaveChanges();
            }
        }

        public void Update(TaskItem updatedTask)
        {
            var task = _context.Tasks.Find(updatedTask.Id);

            if (task != null)
            {
                task.Title = updatedTask.Title;
                task.Subject = updatedTask.Subject;
                task.Description = updatedTask.Description;
                task.DueDate = updatedTask.DueDate;
                task.Priority = updatedTask.Priority;
                task.Status = updatedTask.Status;

                _context.SaveChanges();
            }
        }
    }
}