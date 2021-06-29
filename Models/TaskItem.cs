using System;

namespace WebAPI1.Models{
    public class TaskItem{
        public Guid Id {get; set;}
        public string Title {get; set;}
        public bool isCompleted {get; set;}
    }
}