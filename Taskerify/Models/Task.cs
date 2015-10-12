using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taskerify.Models
{
    public class Task
    {
        [Key]
        public Guid taskId { get; set; }
        public Guid ownerId { get; set; }
        public Guid createdById { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTimeOffset? dueDate { get; set; }

        [ForeignKey("ownerId")]
        public virtual User owner { get; set; }

        public virtual User createdBy { get; set; }

        public int? processed { get; set; }
        public DateTime? processedTime { get; set; }

    }

    public class NewTaskModel
    {
        public Guid createdById { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}