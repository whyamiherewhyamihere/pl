using laba3.Model;
using laba3.Database;
using Newtonsoft.Json;

namespace laba3.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly string _jsonFilePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tasks.json");

    private readonly TaskContext _context = new();

    public TaskRepository()
    {
        _context.Database.EnsureCreated();
    }

    public void SaveToDb(List<TaskItem> tasks)
    {
        _context.Tasks?.RemoveRange(_context.Tasks);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.Tasks?.AddRange(tasks);
        _context.SaveChanges();
    }

    public List<TaskItem> LoadFromDb()
    {
        return _context.Tasks!.ToList();
    }

    public void SaveToJson(List<TaskItem> tasks)
    {
        var jsonData = JsonConvert.SerializeObject(tasks, Formatting.Indented);
        File.WriteAllText(_jsonFilePath, jsonData);
    }

    public List<TaskItem> LoadFromJson()
    {
        var temp = new List<TaskItem>();
        File.Create(_jsonFilePath).Close();

        var jsonData = File.ReadAllText(_jsonFilePath);
        var data = JsonConvert.DeserializeObject<List<TaskItem>>(jsonData) ?? new List<TaskItem>();
        foreach (var task in data)
        {
            temp.Add(new TaskItem(task.Title, task.Description, task.Deadline, task.Tags));
        }

        return temp;
    }
}
