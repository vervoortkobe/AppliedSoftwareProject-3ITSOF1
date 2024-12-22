using AP.MyGameStore.Domain;
using AP.MyGameStore.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AP.MyGameStore.Infrastructure.Contexts
{
    public class MyGameStoreContext : DbContext
    {
        public MyGameStoreContext(DbContextOptions<MyGameStoreContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Store>().Seed();
            modelBuilder.Entity<Person>().Seed();

        }
    }
}
