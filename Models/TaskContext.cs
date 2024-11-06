using Microsoft.EntityFrameworkCore;

namespace GestorTareas.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
            
        {
        }

        public DbSet<Tarea> Tasks { get; set; }
    }
}
