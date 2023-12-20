using laba3.Controller;
using laba3.Model;
using laba3.Repository;

namespace laba3;

public static class Program
{
    public static void Main(string[] args)
    {
        var repo = new TaskRepository();
        var tasks = new List<TaskItem>();
        var controller = new TaskController(tasks, repo);
        controller.Run();
    }
}
