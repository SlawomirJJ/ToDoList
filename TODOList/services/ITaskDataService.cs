using TODOList.Models;

namespace TODOList.services
{
    public interface ITaskDataService
    {
        List<TaskModel> GetAllTasksForDay(DateOnly date);
        TaskModel GetTask(int Id);
        int Insert(TaskModel task);
        int Update(TaskModel task);
        int Delete(int Id);
    }
}
