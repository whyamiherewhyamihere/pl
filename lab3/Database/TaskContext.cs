using laba3.Model;
using Microsoft.EntityFrameworkCore;

namespace laba3.Database;

public class TaskContext:DbContext
{
    public DbSet<TaskItem>? Tasks { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Tasks.db");
    }
}
