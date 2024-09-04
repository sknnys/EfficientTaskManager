using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EfficientTaskManager.Models;

namespace EfficientTaskManager.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
