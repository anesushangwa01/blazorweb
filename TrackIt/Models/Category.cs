using System.ComponentModel.DataAnnotations;

namespace TrackIt.Models
{
    /// <summary>
    /// Represents a product category in the system.
    /// Each category can have multiple associated products.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of products associated with this category.
        /// </summary>
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}