﻿using Bookstore.Data.DataObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-BookstoreDB;Trusted_Connection=True;MultipleActiveResultSets=true");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Book>()
			//	.HasOne(x => x.Author)
			//	.WithMany(x => x.Books)
			//	.OnDelete(DeleteBehavior.S);

			//modelBuilder.Entity<Book>()
			//	.HasOne(x => x.Genre)
			//	.WithMany()
			//	.OnDelete(DeleteBehavior.Restrict);

			//modelBuilder.Entity<Author>()
			//	.HasMany(x => x.Books)
			//	.WithOne(x => x.Author)
			//	.OnDelete(DeleteBehavior.Cascade);

			//modelBuilder.Entity<Genre>().HasData(
			//	new Genre { Id = 1, Name = "Thriller" },
			//	new Genre { Name = "Horror", Id = 2 },
			//	new Genre { Id = 3, Name ="Science"},
			//	new Genre { Id = 4, Name="Detective"},
			//	new Genre { Id = 5, Name = "Fantasy"}
			//	);

			//modelBuilder.Entity<Book>().HasData(
			//	new Book { AuthorId = 3, Format = (Cover)1, Title = "q", GenreId = 1, Id = 1, ImageURL = "1", ISBN13 = "q", Pages = 1, Price = 1 }
			//	);

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderLines> OrderLines { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
        public ApplicationDbContext()
    :	base()
        {
        }
    }
}