using StudyMate.Models;

namespace StudyMate.Services
{
    public class RecommendationService
    {
        private readonly TaskService _taskService;

        public RecommendationService(TaskService taskService)
        {
            _taskService = taskService;
        }

        public List<SmartRecommendation> GetRecommendations()
        {
            var tasks = _taskService.GetAll();

            return GenerateRecommendations(tasks);
        }

        public List<SmartRecommendation> GenerateRecommendations(
            IEnumerable<TaskItem> tasks)
        {
            return tasks
                .Where(t => t.Status != StudyTaskStatus.Completed)
                .Select(CreateRecommendation)
                .OrderByDescending(r => r.Score)
                .ThenBy(r => r.DueDate)
                .ToList();
        }

        private SmartRecommendation CreateRecommendation(TaskItem task)
        {
            int daysLeft = (task.DueDate.Date - DateTime.Today).Days;

            int score = 0;

            string urgency;
            string reason;
            string action;

            // PRIORITY SCORE
            score += task.Priority switch
            {
                StudyTaskPriority.High => 40,
                StudyTaskPriority.Medium => 25,
                StudyTaskPriority.Low => 10,
                _ => 0
            };

            // DEADLINE SCORE
            if (daysLeft < 0)
            {
                score += 60;

                urgency = "Overdue";
                reason = $"This task is {Math.Abs(daysLeft)} day(s) overdue.";
                action = "Complete this task as soon as possible.";
            }
            else if (daysLeft == 0)
            {
                score += 55;

                urgency = "Due Today";
                reason = "The deadline is today.";
                action = "Make this task your main focus today.";
            }
            else if (daysLeft == 1)
            {
                score += 45;

                urgency = "Due Tomorrow";
                reason = "The deadline is tomorrow.";
                action = "Start working on this task today.";
            }
            else if (daysLeft <= 3)
            {
                score += 30;

                urgency = "Upcoming";
                reason = $"Only {daysLeft} days remain.";
                action = "Schedule time to work on this task.";
            }
            else if (daysLeft <= 7)
            {
                score += 15;

                urgency = "This Week";
                reason = $"The deadline is in {daysLeft} days.";
                action = "Plan your study session in advance.";
            }
            else
            {
                score += 5;

                urgency = "Later";
                reason = $"You have {daysLeft} days until the deadline.";
                action = "Keep this task in your study plan.";
            }

            // STATUS SCORE
            if (task.Status == StudyTaskStatus.InProgress)
            {
                score += 10;

                reason += " You have already started working on it.";
            }

            // HIGH PRIORITY BONUS
            if (task.Priority == StudyTaskPriority.High)
            {
                reason += " This task has high priority.";
            }

            return new SmartRecommendation
            {
                TaskId = task.Id,
                Title = task.Title,
                Subject = task.Subject,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status,
                Score = score,
                UrgencyLevel = urgency,
                Reason = reason,
                SuggestedAction = action
            };
        }

        public List<SmartRecommendation> GetTopRecommendations(
            int count = 5)
        {
            return GetRecommendations()
                .Take(count)
                .ToList();
        }
    }
}