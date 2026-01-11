using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TodosAPI.Models
{
    public class TodosContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public TodosContext(DbContextOptions<TodosContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>()
                .HasData(new Todo { Id = 1, Title = "Store", Description = "Go to store after work", IsCompleted = false, CreatedDate = DateTime.Now },
                         new Todo { Id = 2, Title = "Meeting", Description = "4 pm in conference hall", IsCompleted = false, CreatedDate = DateTime.Now.AddDays(1) });
        }

        public DbSet<Todo> Todos { get; set; }


    }


}
