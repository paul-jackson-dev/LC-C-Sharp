﻿using CodingEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingEvents.Data
{
    public class EventDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; } // DbContext is typically paired with DbSet which represents the collection of entities that we want to query through
                                                 // this allows us to query our Event objects

        public DbSet<EventCategory> EventCategories { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) // the constructor extends DbContextOptions which helps configure the data store
        {                                                                               // pass DbContextOptions of EventDbContext types to DbContext //allows us to inherit from DbContextOptions
        }
    }
}