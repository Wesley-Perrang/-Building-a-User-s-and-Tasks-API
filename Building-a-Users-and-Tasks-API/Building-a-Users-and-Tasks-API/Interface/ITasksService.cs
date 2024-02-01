using Building_a_User_s_and_Tasks_API.Models;

namespace Building_a_User_s_and_Tasks_API.Interface
{
    public interface ITasksService
    {
        IEnumerable<Tasks> GetAllTasks();

        Tasks GetTaskById(int taskId);

        Tasks CreateTask(Tasks newTask);

        void UpdateTask(Tasks updatedTask);

        void DeleteTask(int taskId);
    }
}
