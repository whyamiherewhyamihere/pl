namespace laba2.Model;

public class TaskItem
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
