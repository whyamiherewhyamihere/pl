using laba4.Model;
using laba4.Repository;
using laba4.Services;
using Microsoft.AspNetCore.Mvc;

namespace laba4.Controller;

[ApiController]
public class BookController : ControllerBase
{
    private readonly ITaskRepository _taskRepository;

    public BookController(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [HttpPost]
    [Route("/add-task")]
    public Task Add([FromBody] string fake, string title, string description, DateTime deadline, string tags)
    {
        var validator = new Validation();
        var storeTask = new StoreTask(validator);
        var book = storeTask.SetTaskItem(title, description, deadline, tags);

        return _taskRepository.Add(book);
    }

    [HttpGet]
    [Route("/search-task")]
    public Task<List<TaskItem>> SearchTasks(string keyword)
    {
        return _taskRepository.SearchTasks(keyword);
    }
}
