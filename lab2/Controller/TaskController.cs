using laba2.Model;
using laba2.View;

namespace laba2.Controller;

public class TaskController
{
    private readonly List<TaskItem> _tasks;
    private readonly TaskView _taskView;
    
    public TaskController(List<TaskItem> tasks, TaskView taskView)
    {
        _tasks = tasks;
        _taskView = taskView;
    }

    public void AddTask(TaskItem taskItem)
    {
        _tasks.Add(taskItem);
    }

    public void SearchTasks(string[] searchTags)
    {

        var matchingTasks = _tasks.Where(task => searchTags.All(tag => task.Tags.Contains(tag)))
            .ToList();

        Console.WriteLine(matchingTasks.Count == 0 ? "No such tasks" : "Matching tasks:");
        foreach (var task in matchingTasks)
        {
            Console.WriteLine(task.ToString());
        }
    }

    public void Run()
    {
        var active = true;
        while (active)
        {
           TaskView.ShowMenu();
            int choice = TaskView.GetChoice();

            switch (choice)
            {
                case 1:
                    AddTask(TaskView.GetTask());
                    break;
                case 2:
                    SearchTasks(TaskView.GetSearchTags());
                    break;
                case 3:
                   TaskView.ShowLastTasks(_tasks);
                    break;
                case 4:
                    active = !active;
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
