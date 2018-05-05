using Microsoft.EntityFrameworkCore;
using ToDoApp_netCore.Model;

namespace ToDoApp_netCore.Database
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
           : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
