using System.ComponentModel.DataAnnotations;

namespace EfficientTaskManager.Models
{
    public class File
    {
        public int Id { get; set; }

        [Required]
        public string FilePath { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
