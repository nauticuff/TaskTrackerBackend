using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models
{
    public class TaskModel
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string? PublishedName { get; set; }
        public string? TaskDate { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public bool isPosted { get; set; }
        public bool isDeleted { get; set; }

        public TaskModel(){}
    }
}