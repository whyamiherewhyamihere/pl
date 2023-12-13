using laba2.Controller;
using laba2.Model;
using laba2.View;

namespace laba2;

public static class Program
{
    public static void Main(string[] args)
    {
        var tasks = new List<TaskItem>();
        var view = new TaskView();
        var controller = new TaskController(tasks, view);
        controller.Run();
    }
}
