using laba4.Model;

namespace laba4.Services;

public class StoreTask : IStoreTask
{
    private readonly IValidation _validator;
    public StoreTask(IValidation validator)
    {
        _validator = validator;
    }
    
    public TaskItem SetTaskItem(string title, string description, DateTime dateTime, string tags)
    {
        var taskItem = new TaskItem(title, description, dateTime, tags);

        _validator.ValidateTask(taskItem);
        return taskItem;

    }
}
