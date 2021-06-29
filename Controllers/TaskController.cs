using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI1.Models;
namespace WebAPI1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class TaskController : ControllerBase
    {

        List<TaskItem> taskList = new List<TaskItem>{
             new TaskItem() {Id= Guid.NewGuid(), Title="dsa", isCompleted=false},
             new TaskItem() {Id= Guid.NewGuid(), Title="ewq", isCompleted=false},
             new TaskItem() {Id= Guid.NewGuid(), Title="cxz", isCompleted=false},
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public TaskController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public List<TaskItem> TaskList(){
            return taskList;
        }
    
        [HttpGet("title")]
        public TaskItem Task(string title){
            return taskList.FirstOrDefault(x => x.Title == title);
        }


        [HttpPost]
        public List<TaskItem> Create(TaskItem task){
            task.Id = Guid.NewGuid();
            taskList.Add(task);
            return taskList;
        }

        [HttpPut("title")]
        public List<TaskItem> Update(TaskItem task, string title){
            var updateTask = taskList.FirstOrDefault(x => x.Title == title);
            updateTask.Title = task.Title;
            updateTask.isCompleted = task.isCompleted; 
            return taskList;
        }

        [HttpDelete]
        public List<TaskItem> Delete(string title){
            var deleteTask = taskList.FirstOrDefault(x => x.Title == title);
            taskList.Remove(deleteTask);
            return taskList;
        }

        [HttpPost("multiTask")]
        public List<TaskItem> MutilCreate(TaskItem[] listTaskAdd){
            for(int i=0; i< listTaskAdd.Count(); i++){
                listTaskAdd[i].Id = Guid.NewGuid();
                taskList.Add(listTaskAdd[i]);
            }
            return taskList;
        }

        [HttpDelete("multiTask")]
        public List<TaskItem> MutilDelete(string[] titles){
            for(int i=0; i< titles.Count(); i++){
                var deleteTask = taskList.FirstOrDefault(x => x.Title == titles[i]);
                taskList.Remove(deleteTask);
            }
            return taskList;
        }

    }
}
