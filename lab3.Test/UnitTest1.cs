using laba3.Repository;
using laba3.Controller;
using laba3.Model;
using Moq;

namespace laba3.Test;

public class UnitTest1
{
    [Theory]
    [InlineData ("prikol", "rofls", "12.12.2112", "qwe asd zxc", "asd")]
    public void SearchTasksTest(string title, string description, DateTime dateTime, string tags, string searchTag)
    {
        var mock = new Mock<ITaskRepository>();
        mock.Setup(r => r.LoadFromDb()).Returns(new List<TaskItem>());
        mock.Setup(j => j.LoadFromJson()).Returns(new List<TaskItem>());
        var tasks = new List<TaskItem>
        {
            new (title, description, dateTime, tags)
        };
        var controller = new TaskController(tasks, mock.Object);
        Assert.Equal(tasks[0], controller.SearchTasks(searchTag)[0]);
    }
    
    [Theory]
    [InlineData ("prikol", "rofls", "12.12.2112", "qwe asd zxc")]
    public void AddTaskTest(string title, string description, DateTime dateTime, string tags)
    {
        var mock = new Mock<ITaskRepository>();
        mock.Setup(r => r.LoadFromDb()).Returns(new List<TaskItem>());
        mock.Setup(j => j.LoadFromJson()).Returns(new List<TaskItem>());
        var tasks = new List<TaskItem>();
        var controller = new TaskController(tasks, mock.Object);
        var task = new TaskItem(title, description, dateTime, tags);
        controller.AddTask(task);
        Assert.Equal(task, tasks[0]);
    }
}
