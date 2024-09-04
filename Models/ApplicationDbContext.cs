using Microsoft.EntityFrameworkCore;
using EfficientTaskManager.Data;

namespace EfficientTaskManager.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
