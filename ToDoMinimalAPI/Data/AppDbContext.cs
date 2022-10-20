namespace ToDoMinimalAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using ToDoMinimalAPI.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos => Set<ToDo>();
    }
}
