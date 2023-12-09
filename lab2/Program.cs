using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static List<TaskItem> tasks = new List<TaskItem>();

    static void Main()
    {
        while (true)
        {
            ShowMenu();
            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    AddTask();
                    break;
                case 2:
                    SearchTasks();
                    break;
                case 3:
                    ShowLastTasks();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Add task");
        Console.WriteLine("2. Search task");
        Console.WriteLine("3. Last tasks");
        Console.WriteLine("4. Exit");
    }

    private static int GetChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Invalid input.Enter a number between 1 to 4.");
        }
        return choice;
    }

    private static void AddTask()
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
            if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out deadline))
                break;
            else
                Console.WriteLine("Invalid date format. Please enter a valid date.");
        }

        List<string> tags = new List<string>();
        Console.WriteLine("Tags (finish on empty line)");
        for (int i = 1; ; i++)
        {
            Console.Write($"{i}: ");
            string tag = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(tag))
                break;
            tags.Add(tag);
        }

        TaskItem newTask = new TaskItem(title, description, deadline, tags);
        tasks.Add(newTask);
    }

    private static void SearchTasks()
    {
        Console.Write("Search tasks by tag: ");
        string[] searchTags = Console.ReadLine().Split(' ');

        var matchingTasks = tasks
            .Where(task => searchTags.All(tag => task.Tags.Contains(tag)))
            .ToList();

        Console.WriteLine(matchingTasks.Count == 0 ? "No such tasks" : "Matching tasks:");
        foreach (var task in matchingTasks)
        {
            Console.WriteLine(task.ToString());
        }
    }

    private static void ShowLastTasks()
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
}

class TaskItem
{
    public string Title { get; }
    public string Description { get; }
    public DateTime Deadline { get; }
    public List<string> Tags { get; }

    public TaskItem(string title, string description, DateTime deadline, List<string> tags)
    {
        Title = title;
        Description = description;
        Deadline = deadline;
        Tags = tags;
    }

    public override string ToString()
    {
        return $"Title: {Title}\nDescription: {Description}\nDeadline: {Deadline:dd.MM.yyyy}\nTags: {string.Join(", ", Tags)}";
    }
}
