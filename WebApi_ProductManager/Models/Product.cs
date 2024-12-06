using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_ProductManager.Models
{
	[Table("Products")]
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
		[Required]
		[MaxLength(100)]
		public string ProductName { get; set; }

		[Required]
		[Range(0, (double)decimal.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
		public decimal Price { get; set; }

		[Required]
		[Range(0, int.MaxValue, ErrorMessage = "StockQuantity must be a non-negative integer.")]
		public int StockQuantity { get; set; }
	}
}
