using System.Collections.Generic;
using Building_a_User_s_and_Tasks_API.Interface;
using Building_a_User_s_and_Tasks_API.Models;

namespace Building_a_User_s_and_Tasks_API.Implementation
{
    public class TasksService : ITasksService
    {
        private readonly List<Tasks> _tasks; // In a real-world scenario, you'd use a database or some storage mechanism.

        public TasksService()
        {
            // Initialize with some sample data. In a real scenario, you might fetch this from a database.
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
            // In a real scenario, you'd handle creating a new task in your database.
            newTask.ID = _tasks.Count + 1; // Simulating auto-incrementing ID.
            _tasks.Add(newTask);
            return newTask;
        }

        public void UpdateTask(Tasks updatedTask)
        {
            // In a real scenario, you'd handle updating a task in your database.
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
            // In a real scenario, you'd handle deleting a task from your database.
            var taskToDelete = _tasks.Find(task => task.ID == taskId);

            if (taskToDelete != null)
            {
                _tasks.Remove(taskToDelete);
            }
        }
    }
}
