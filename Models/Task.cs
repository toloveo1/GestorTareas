using System.ComponentModel.DataAnnotations;

namespace GestorTareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsComplete { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
