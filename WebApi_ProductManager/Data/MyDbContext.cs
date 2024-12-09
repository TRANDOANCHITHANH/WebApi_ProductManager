using Microsoft.EntityFrameworkCore;
using WebApi_ProductManager.Models;

namespace WebApi_ProductManager.Data
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
		{
		}
		#region DbSet
		public DbSet<Product> Products { get; set; }
		#endregion
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Product>()
				.Property(p => p.Price)
				.HasColumnType("decimal(18, 2)");
		}
	}
}
