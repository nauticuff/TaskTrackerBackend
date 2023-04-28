using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models
{
    public class TaskItemModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string? Title { get; set; }
        public string? Attachments { get; set; }
        public string? Description { get; set; }
        public string? Comments { get; set; }
        public string? LinkedTasks { get; set; }
        public string? Assignee { get; set; }
        public string? Reporter { get; set; }
        public bool isPublished { get; set; }
        public bool isDeleted { get; set; }
        public bool isInProgress { get; set; }
        public bool isComplete { get; set; }

        public TaskItemModel(){}
        
    }
}