using System.ComponentModel.DataAnnotations;

namespace laba3.Model;

public class TaskItem
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set;}
    public DateTime Deadline { get; set;}
    public string Tags { get; set;}

    public TaskItem(string title, string description, DateTime deadline, string tags)
    {
        Title = title;
        Description = description;
        Deadline = deadline;
        Tags = tags;
    }

    public override string ToString()
    {
        return $"Title: {Title}\nDescription: {Description}\nDeadline: {Deadline:dd.MM.yyyy}\nTags: {Tags}";
    }
}
