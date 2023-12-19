using laba3.Model;
using laba3.Repository;
using laba3.View;

namespace laba3.Controller;

public class TaskController
{
    private List<TaskItem> _tasks;
    private readonly ITaskRepository _taskRepository;
    public TaskController(List<TaskItem> tasks, ITaskRepository taskRepository)
    {
        _tasks = tasks;
        _taskRepository = taskRepository;
    }

    public void AddTask(TaskItem taskItem)
    {
        _tasks.Add(taskItem);
    }

    public List<TaskItem> SearchTasks(string tags)
    {
        var searchTags = tags.Split(' ');
        var matchingTasks = _tasks.Where(task => searchTags.All(tag => task.Tags.Contains(tag)))
            .ToList();

        Console.WriteLine(matchingTasks.Count == 0 ? "No such tasks" : "Matching tasks:");
        return matchingTasks;
    }

    public void Run()
    {
        TaskView.ShowOptions();
        int option = TaskView.GetOptionsChoice();
        
        switch (option)
        {
            case 1:
                _tasks = _taskRepository.LoadFromDb();
                break;
            case 2:
                _tasks = _taskRepository.LoadFromJson();
                break;
        }
        
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
                    TaskView.PrintTasks(SearchTasks(TaskView.GetSearchTags()));
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
        
        switch (option)
        {
            case 1:
                _taskRepository.SaveToDb(_tasks);
                break;
            case 2:
                _taskRepository.SaveToJson(_tasks);
                break;
        }
    }
}
