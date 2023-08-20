using asp.netCoreIntro.Models;
using Microsoft.EntityFrameworkCore;


namespace asp.netCoreIntro.DBContext
{
    public class TutorialDBContext:DbContext
    {

        public TutorialDBContext(DbContextOptions<TutorialDBContext> options):base(options)
        {
        }

        public DbSet<Tutorial> Tutorial { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the one-to-many relationship between Parent and Child
            modelBuilder.Entity<Child>()
                .HasOne(c => c.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(c => c.ParentId);

            base.OnModelCreating(modelBuilder);
        }

        //public async Task< List<Tutorial>> Tutorials()
        //{
        //    return dataSource();
        //}

    }
}
