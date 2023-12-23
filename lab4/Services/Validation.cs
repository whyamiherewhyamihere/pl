using laba4.Model;

namespace laba4.Services;

public class Validation : IValidation
{
    public void ValidateTask(TaskItem taskItem)
    {
        if (taskItem.Title=="" || taskItem.Description=="" || taskItem.Deadline.ToString() == "" ||
            taskItem.Tags=="")
            throw new Exception("Empty fields are not allowed");
    }
}
