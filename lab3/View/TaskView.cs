using laba3.Model;

namespace laba3.View;

public class TaskView
{
    public static void ShowMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Add task");
        Console.WriteLine("2. Search task");
        Console.WriteLine("3. Last tasks");
        Console.WriteLine("4. Exit");
    }
    
    public static void ShowOptions()
    {
        Console.WriteLine("Choose save and load method:");
        Console.WriteLine("1. Database");
        Console.WriteLine("2. JSON");
    }

    public static int GetOptionsChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
        {
            Console.WriteLine("Invalid input. Enter a number between 1 to 2.");
        }
        return choice;
    }
    
    public static int GetChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Invalid input. Enter a number between 1 to 4.");
        }
        return choice;
    }
    
    public static void ShowLastTasks(List<TaskItem> tasks)
    {
        Console.WriteLine("Actual tasks:");
        var actualTasks = tasks
            .OrderBy(task => task.Deadline)
            .Take(3)
            .ToList();

        foreach (var task in actualTasks)
        {
            Console.WriteLine(task.ToString());
        }
    }
    
    public static TaskItem GetTask()
    {
        Console.WriteLine("New task");
        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        DateTime deadline;
        while (true)
        {
            Console.Write("Deadline (dd.MM.yyyy): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null,
                    System.Globalization.DateTimeStyles.None, out deadline))
                break;
            Console.WriteLine("Invalid date format. Please enter a valid date.");
        }

        Console.Write("Tags: ");
        string tags = Console.ReadLine();

        return new TaskItem(title, description, deadline, tags);
    }

    public static string GetSearchTags()
    {
        Console.Write("Search tasks by tag: ");
        var searchTags = Console.ReadLine();
        return searchTags;
    }

    public static void PrintTasks(List<TaskItem> taskItems)
    {
        foreach (var task in taskItems)
        {
            Console.WriteLine(task);
        }
    }
}
