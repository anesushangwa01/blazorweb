using Microsoft.EntityFrameworkCore;
using TrackIt.Components;
using TrackIt.Models;

namespace TrackIt.Data
{
    /// <summary>
    /// Represents the application's database context, used to interact with the underlying database.
    /// </summary>
    public class AppDbContext : DbContext
    {
        // <summary>
        /// Initializes a new instance of the AppDbContext class with the specified options.
        /// </summary>
        /// <param name="options">The options to be used for configuring DbContext</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the collection of users in the database.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the collection of products in the database.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the collection of categories in the database.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Configures the model and relationships for the entities in the database.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the database schema.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between Product and Category.
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category) // A product has one category
                .WithMany(c => c.Products) // A category can have many products
                .HasForeignKey(p => p.CategoryId); // Foreign key on Product for CategoryId
        }
    }
}
