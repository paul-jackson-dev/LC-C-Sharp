using CodingEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CodingEvents.Data
{
    public class EventDbContext : IdentityDbContext<IdentityUser, IdentityRole, string> // : DbContext
    {
        public DbSet<Event> Events { get; set; } // DbContext is typically paired with DbSet which represents the collection of entities that we want to query through
                                                 // this allows us to query our Event objects

        public DbSet<EventCategory> EventCategories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) // the constructor extends DbContextOptions which helps configure the data store
        {                                                                               // pass DbContextOptions of EventDbContext types to DbContext //allows us to inherit from DbContextOptions
        }

        // set up many to many relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                  .HasMany(e => e.Tags)
                  .WithMany(e => e.Events)
                  .UsingEntity(j => j.ToTable("EventTags"));

            base.OnModelCreating(modelBuilder); // to invoke Identity's implementation

        }

    }
}

// example from book
//using CodingEvents.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//namespace CodingEvents.Data
//{
//    public class EventDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
//    {
//        public DbSet<Event> Events { get; set; }

//        public DbSet<EventCategory> Categories { get; set; }

//        public DbSet<Tag> Tags { get; set; }

//        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
//        {
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Event>()
//                .HasOne(p => p.Category)
//                .WithMany(b => b.events);

//            modelBuilder.Entity<Event>()
//                .HasMany(p => p.Tags)
//                .WithMany(p => p.Events)
//                .UsingEntity(j => j.ToTable("EventTags"));
//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}