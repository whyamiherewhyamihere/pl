using laba4.Model;

namespace laba4.Services;

public interface IStoreTask
{
    TaskItem SetTaskItem(string title, string description, DateTime dateTime, string tags);
}
