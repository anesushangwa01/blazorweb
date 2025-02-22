using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TrackIt.Data; // Make sure you have this using statement
using TrackIt.Models;

namespace TrackIt.Services
{
    public class ProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Gets Products from the associated database.
        /// Can additionally filter the Products based on a search parameter.
        /// </summary>
        /// <param name="searchString">The filter parameter for the database. Can be null</param>
        /// <returns>A list of Products.</returns>
        public async Task<List<Product>> Index(string? searchString = null)
        {
            var products = await _db.Products.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                products = await _db.Products.Where(s => s.Name!.ToUpper().Contains(searchString.ToUpper())).ToListAsync();
            }

            return products;
        }

        /// <summary>
        /// Gets a specific Product from the database.
        /// </summary>
        /// <param name="id">The id of a specific Product</param>
        /// <returns>A single Product.</returns>
        public async Task<Product> GetProductById(int id)
        {
            var product = await _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {id} not found.");
            }
            return product;
        }

        /// <summary>
        /// Edits the data for a specific.
        /// </summary>
        /// <param name="product">Takes the values of a single Product</param>
        /// <returns>A single Product.</returns>
        public async Task<Product> UpdateProduct(Product product)
        {
            var updatedProduct = await _db.Products.FindAsync(product.Id);
            if (updatedProduct == null)
            {
                throw new KeyNotFoundException($"Product with id {product.Id} not found.");
            }
            updatedProduct.Name = product.Name;
            updatedProduct.StockQuantity = product.StockQuantity;
            updatedProduct.Price = product.Price;
            updatedProduct.CategoryId = product.CategoryId;
            updatedProduct.ImgUrl = product.ImgUrl;
            await _db.SaveChangesAsync();
            return updatedProduct;
        }

        /// <summary>
        /// Deletes a specific Product from the database.
        /// </summary>
        /// <param name="id">The id of a specific Product</param>
        /// <returns>Has no return value.</returns>
        public async Task DeleteProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {id} not found.");
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }
        /// <summary>
        /// Gets Products from the associated database.
        /// </summary>
        /// <returns>A list of Products.</returns>
        public async Task<List<Product>> GetAllProducts()
        {
            return await _db.Products.Include(p => p.Category).ToListAsync();
        }
        /// <summary>
        /// Adds a new Product to the database.
        /// </summary>
        /// <param name="product">A Product object</param>
        /// <returns>Has no return value.</returns>
        public async Task AddProduct(Product product)
        {
            var category = await _db.Categories.FindAsync(product.CategoryId);
            if (category != null)
            {
                product.Category = category;
            }
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
        }
    }
}