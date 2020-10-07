using Microsoft.EntityFrameworkCore;

namespace Test.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Hobby> Hobbies {get;set;}
        public DbSet<Intrest> Intrests {get;set;}
    }
}