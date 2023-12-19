using laba3.Model;

namespace laba3.Repository;

public interface ITaskRepository
{
    void SaveToDb(List<TaskItem> tasks);

    List<TaskItem> LoadFromDb();
    void SaveToJson(List<TaskItem> tasks);
    List<TaskItem> LoadFromJson();
}
