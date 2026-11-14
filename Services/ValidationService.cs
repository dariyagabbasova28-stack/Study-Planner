using StudyMate.Models;

namespace StudyMate.Services
{
    public class ValidationService
    {
        public ValidationResult ValidateTask(TaskItem task)
        {
            if (task == null)
            {
                return ValidationResult.Failure(
                    "Task cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(task.Title))
            {
                return ValidationResult.Failure(
                    "Task title is required.");
            }

            if (task.Title.Trim().Length < 3)
            {
                return ValidationResult.Failure(
                    "Task title must contain at least 3 characters.");
            }

            if (task.Title.Length > 100)
            {
                return ValidationResult.Failure(
                    "Task title cannot exceed 100 characters.");
            }

            if (string.IsNullOrWhiteSpace(task.Subject))
            {
                return ValidationResult.Failure(
                    "Please enter a subject.");
            }

            if (task.DueDate == default)
            {
                return ValidationResult.Failure(
                    "Please select a valid deadline.");
            }

            if (!Enum.IsDefined(typeof(StudyTaskPriority), task.Priority))
            {
                return ValidationResult.Failure(
                    "Invalid task priority.");
            }

            if (!Enum.IsDefined(typeof(StudyTaskStatus), task.Status))
            {
                return ValidationResult.Failure(
                    "Invalid task status.");
            }

            return ValidationResult.Success();
        }
    }

    public class ValidationResult
    {
        public bool IsValid { get; set; }

        public string ErrorMessage { get; set; } = "";

        public static ValidationResult Success()
        {
            return new ValidationResult
            {
                IsValid = true
            };
        }

        public static ValidationResult Failure(string message)
        {
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = message
            };
        }
    }
}