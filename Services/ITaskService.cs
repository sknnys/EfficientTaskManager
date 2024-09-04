using System.Collections.Generic;
using System.Threading.Tasks; // Importa o namespace correto
using TaskModel = EfficientTaskManager.Models.Task; // Alias para o modelo de tarefa

namespace EfficientTaskManager.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetAllTasksAsync(); // Usando o alias TaskModel para o tipo da sua aplicação
        Task<TaskModel> GetTaskByIdAsync(int id); // Usando o alias TaskModel para o tipo da sua aplicação
        Task CreateTaskAsync(TaskModel task); // Usando o alias TaskModel para o tipo da sua aplicação
        Task UpdateTaskAsync(TaskModel task); // Usando o alias TaskModel para o tipo da sua aplicação
        Task DeleteTaskAsync(int id); // Usando o alias TaskModel para o tipo da sua aplicação
    }
}
