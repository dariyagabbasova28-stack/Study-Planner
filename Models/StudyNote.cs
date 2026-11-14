using System;
using System.ComponentModel.DataAnnotations;

namespace StudyMate.Models
{
    public class StudyNote
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(100)]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Please enter note content.")]
        public string Content { get; set; } = "";

        public string Subject { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}