﻿using Library.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP - BPC41OM\\SQLEXPRESS; Database = Library; Trusted_Connection = True; MultipleActiveResultSets = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Book>()
                .HasMany(c => c.Authors)
                .WithMany(s => s.Books)
                .UsingEntity(j => j.ToTable("BookAuthors"));

            modelBuilder.Entity<Book>()
                .HasMany(c => c.Genres)
                .WithMany(s => s.Books)
                .UsingEntity(j => j.ToTable("BookGenres"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.Books)
                .WithMany(b => b.Users)
                .UsingEntity(j => j.ToTable("Favorites"));

            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole("Admin"),
                         new IdentityRole("User"));
  





        }
    }
}