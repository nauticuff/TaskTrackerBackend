using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Services;

namespace TaskTrackerBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        // private readonly TaskService _data;
        // public TaskController(TaskService dataFromService){
        //     _data = dataFromService;
        // }

        // [HttpPost]
        // [Route("AddTaskItem")]
        // public bool AddTaskItem(TaskItemModel newTaskItem){
        //     return _data.AddTaskItem(newTaskItem);
        // }
    }
}