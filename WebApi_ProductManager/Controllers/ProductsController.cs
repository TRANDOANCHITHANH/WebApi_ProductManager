using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_ProductManager.Data;
using WebApi_ProductManager.Models;

namespace WebApi_ProductManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly MyDbContext _context;
		public ProductsController(MyDbContext context)
		{
			_context = context;
		}
		// GET: /api/products
		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			var products = await _context.Products
				.FromSqlRaw("EXEC sp_GetAllProducts")
				.ToListAsync();
			return Ok(products);
		}
		// GET: /api/products/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(int id)
		{
			var product = (await _context.Products
			.FromSqlRaw("EXEC sp_GetProductById @ProductId = {0}", id)
			.ToListAsync()).FirstOrDefault();

			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}
		// POST: /api/products
		[HttpPost]
		public async Task<IActionResult> Add(Product productmodel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				var product = new Product
				{
					ProductName = productmodel.ProductName,
					Price = productmodel.Price,
					StockQuantity = productmodel.StockQuantity,
				};
				_context.Add(product);
				await _context.SaveChangesAsync();
				return Ok(product);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		// PUT: /api/products/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProductById(int id, Product product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (id != product.ProductId)
			{
				return BadRequest("Product ID does not match.");
			}

			var existingProduct = await _context.Products.FindAsync(id);
			if (existingProduct == null)
			{
				return NotFound();
			}

			existingProduct.ProductName = product.ProductName;
			existingProduct.Price = product.Price;
			existingProduct.StockQuantity = product.StockQuantity;

			_context.Products.Update(existingProduct);
			await _context.SaveChangesAsync();
			return NoContent();
		}
		// DELETE: /api/products/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProductById(int id)
		{
			try
			{
				var product = await _context.Products.FindAsync(id);
				if (product == null)
				{
					return NotFound(new { message = $"Product with ID {id} not found." });
				}

				_context.Products.Remove(product);
				await _context.SaveChangesAsync();

				return Ok(new { message = $"Product with ID {id} deleted successfully." });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
