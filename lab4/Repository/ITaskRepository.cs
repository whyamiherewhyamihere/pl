using laba4.Model;

namespace laba4.Repository;

public interface ITaskRepository
{
    Task Add(TaskItem taskItem);
    Task<List<TaskItem>> SearchTasks(string keywords);

}
