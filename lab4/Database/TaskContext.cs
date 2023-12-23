using laba4.Model;
using Microsoft.EntityFrameworkCore;

namespace laba4.Database;

public sealed class TaskContext:DbContext
{
    public DbSet<TaskItem>? Tasks { get; set; }
    
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
