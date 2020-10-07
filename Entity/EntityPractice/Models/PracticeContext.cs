using Microsoft.EntityFrameworkCore;

namespace EntityPractice.Models
{
    public class PracticeContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public PracticeContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
    }
}