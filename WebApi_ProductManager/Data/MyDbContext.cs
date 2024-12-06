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
		public DbSet<Product> products { get; set; }
		#endregion
	}
}
