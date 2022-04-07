using Microsoft.EntityFrameworkCore;
using TodoMiniWebApi.Models;

namespace TodoMiniWebApi.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
