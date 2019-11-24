using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone4.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required]
        public string UserId { get; set; }
        [MaxLength(75)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Complete { get; set; }

        public Tasks() { }

        public Tasks(int id, string userId, string desc, DateTime due, bool complete)
        {
            TaskId = id;
            UserId = userId;
            Description = desc;
            DueDate = due;
            Complete = complete;
        }

    }
}
