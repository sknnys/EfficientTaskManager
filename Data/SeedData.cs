using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EfficientTaskManager.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EfficientTaskManager.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<User> userManager)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Verifica se já existem dados no banco de dados
                if (context.Users.Any())
                {
                    return; // O banco de dados já está populado
                }

                // Cria um usuário de exemplo
                var user = new User { UserName = "exampleuser", Email = "example@example.com" };
                var result = await userManager.CreateAsync(user, "Password123!");

                if (result.Succeeded)
                {
                    // Cria algumas tarefas de exemplo
                    context.Tasks.AddRange(
                        new Task { Title = "Sample Task 1", Description = "This is a sample task.", UserId = user.Id, DueDate = DateTime.Now.AddDays(1) },
                        new Task { Title = "Sample Task 2", Description = "This is another sample task.", UserId = user.Id, DueDate = DateTime.Now.AddDays(2) }
                    );

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
