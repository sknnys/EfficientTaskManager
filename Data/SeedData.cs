using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using EfficientTaskManager.Data; // Adicione o namespace correto
using Microsoft.EntityFrameworkCore; // Adicione o pacote EF Core
using EfficientTaskManager.Models;

namespace EfficientTaskManager.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User { UserName = "admin", Email = "admin@example.com" }
                );

                context.SaveChanges();
            }
        }
    }
}