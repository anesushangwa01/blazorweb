using TrackIt.Data;
using TrackIt.Models;
using Microsoft.EntityFrameworkCore;

namespace TrackIt.Services
{
    /// <summary>
    /// CategoryService provides operations related to categories, such as retrieving all categories or a category by ID.
    /// </summary>
    public class CategoryService
    {
        private readonly AppDbContext _db;

        /// <summary>
        /// Initializes a new instance of the CategoryService class with the provided database context.
        /// </summary>
        /// <param name="db">The database context used for accessing the Categories table.</param>
        public CategoryService(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Asynchronously retrieves a list of all categories.
        /// </summary>
        /// <returns>A list of categories.</returns>
        public async Task<List<Category>> GetAllCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <returns>The category with the specified ID, or null if no such category exists.</returns>
        public async Task<Category> GetCategoryById(int id)
        {
            return await _db.Categories.FindAsync(id);
        }
    }
}