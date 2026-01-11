using System.ComponentModel.DataAnnotations;

namespace TodosAPI.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(800)]
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
