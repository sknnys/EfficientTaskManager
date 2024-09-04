using Microsoft.EntityFrameworkCore;
using EfficientTaskManager.Models;

namespace EfficientTaskManager.Data
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais dos modelos (opcional)
            modelBuilder.Entity<Task>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Task)
                .WithMany(t => t.Notes)
                .HasForeignKey(n => n.TaskId);

            modelBuilder.Entity<File>()
                .HasOne(f => f.Task)
                .WithMany(t => t.Files)
                .HasForeignKey(f => f.TaskId);

            // Exemplo de dados iniciais (opcional)
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "admin", Email = "admin@example.com" }
            );
        }
    }
}
