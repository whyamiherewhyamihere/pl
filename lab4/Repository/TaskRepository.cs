using laba4.Model;
using laba4.Database;
using Microsoft.EntityFrameworkCore;

namespace laba4.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly TaskContext _context;

    public TaskRepository(TaskContext context)
    {
        _context = context;
    }
    
    public Task Add(TaskItem taskItem)
    {
        if (!_context.Tasks!.Any(b => b.Title == taskItem.Title))
        {
            _context.Tasks?.Add(taskItem);
            return _context.SaveChangesAsync();
        }

        throw new Exception("Задача уже добавлена.");
    }
    
    public Task<List<TaskItem>> SearchTasks(string keyword) // Реализация поиска по ключевым словам
    {
        // Разбиваем введенные ключевые слова на отдельные части
        string[] keywords = keyword.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Выполняем запрос поиска только по полю Tags
        IQueryable<TaskItem> query = _context.Tasks;
        foreach (string key in keywords)
        {
            query = query.Where(t => EF.Functions.Like(t.Tags, $"%{key}%"));
        }

        // Выполняем запрос к базе данных и возвращаем результат
        return query.ToListAsync();
    }
    
}
