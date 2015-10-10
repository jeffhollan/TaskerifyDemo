using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taskerify.Models
{
    public class User
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public IList<Task> myTasks { get; set; }
        public IList<Task> assignedTasks { get; set; }
        public IList<User> friends { get; set; }
    }

    public class NewUserModel
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}