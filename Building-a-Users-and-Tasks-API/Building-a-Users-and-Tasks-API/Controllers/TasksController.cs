using Microsoft.AspNetCore.Mvc;
using Building_a_User_s_and_Tasks_API.Models;
using Building_a_User_s_and_Tasks_API.Interface;

namespace Building_a_User_s_and_Tasks_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _taskService; // Assuming you have an ITaskService interface

        public TasksController(ITasksService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/tasks
        [HttpGet]
        public IEnumerable<Tasks> GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return tasks;
        }

        // GET: api/tasks/{id}
        [HttpGet("{id}")]
        public ActionResult<Tasks> GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // POST: api/tasks
        [HttpPost]
        public ActionResult<Tasks> CreateTask([FromBody] Tasks newTask)
        {
            if (newTask == null)
            {
                return BadRequest("Invalid task data");
            }

            var createdTask = _taskService.CreateTask(newTask);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.ID }, createdTask);
        }

        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] Tasks updatedTask)
        {
            if (updatedTask == null || id != updatedTask.ID)
            {
                return BadRequest("Invalid task data");
            }

            var existingTask = _taskService.GetTaskById(id);

            if (existingTask == null)
            {
                return NotFound();
            }

            _taskService.UpdateTask(updatedTask);
            return NoContent();
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var taskToDelete = _taskService.GetTaskById(id);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
