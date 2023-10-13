// using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class CineFlexContext: DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }

    public CineFlexContext(DbContextOptions<CineFlexContext> options): base (options)
    {

    } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure entity relationships, constraints, etc., if needed
        
        // Add more configurations as needed
    }
}

