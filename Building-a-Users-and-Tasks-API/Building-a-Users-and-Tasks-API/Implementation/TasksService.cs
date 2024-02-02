using System.Collections.Generic;
using Building_a_User_s_and_Tasks_API.Interface;
using Building_a_User_s_and_Tasks_API.Models;

namespace Building_a_User_s_and_Tasks_API.Implementation
{
    public class TasksService : ITasksService
    {
        private readonly List<Tasks> _tasks;

        public TasksService()
        {
            _tasks = new List<Tasks>
            {
                new Tasks { ID = 1, Title = "Task 1", Description = "Description 1", Assignee = 1, DueDate = new System.DateTime(2024, 2, 1) },
                new Tasks { ID = 2, Title = "Task 2", Description = "Description 2", Assignee = 2, DueDate = new System.DateTime(2024, 2, 15) }
            };
        }

        public IEnumerable<Tasks> GetAllTasks()
        {
            return _tasks;
        }

        public Tasks GetTaskById(int taskId)
        {
            return _tasks.Find(task => task.ID == taskId);
        }

        public Tasks CreateTask(Tasks newTask)
        {
            newTask.ID = _tasks.Count + 1;
            _tasks.Add(newTask);
            return newTask;
        }

        public void UpdateTask(Tasks updatedTask)
        {
            var existingTask = _tasks.Find(task => task.ID == updatedTask.ID);

            if (existingTask != null)
            {
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.Assignee = updatedTask.Assignee;
                existingTask.DueDate = updatedTask.DueDate;
            }
        }

        public void DeleteTask(int taskId)
        {
            var taskToDelete = _tasks.Find(task => task.ID == taskId);

            if (taskToDelete != null)
            {
                _tasks.Remove(taskToDelete);
            }
        }
    }
}
