using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfficientTaskManager.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Note> Notes { get; set; }
        public ICollection<File> Files { get; set; }

        public Task()
        {
            Notes = new List<Note>();
            Files = new List<File>();
        }
    }
}
