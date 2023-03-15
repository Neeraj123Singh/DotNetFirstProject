using System;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApi.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext > options):base(options)
		{
		}
		public DbSet<Category> Categories { get; set; }
	}
}

