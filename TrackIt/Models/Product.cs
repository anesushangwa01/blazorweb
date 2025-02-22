using System.ComponentModel.DataAnnotations;

namespace TrackIt.Models
{
    /// <summary>
    /// Represents a product in the system.
    /// Each product is associated with a category and contains details such as name, stock, and price.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// The name must be between 3 and 50 characters in length.
        /// </summary>
        [Required, MinLength(3, ErrorMessage = "Product name must be at least 3 characters long."), MaxLength(50, ErrorMessage = "Product name must be at most 50 characters long.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the stock quantity for the product.
        /// The stock must be between 1 and 200.
        /// </summary>
        [Required, Range(1, 200, ErrorMessage = "Stock must be between 1 and 200")]
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// The price must be between 0.01 and 200.
        /// </summary>
        [Required, Range(0.01, 200, ErrorMessage = "Price must be between 0.01 and 200")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category ID associated with the product.
        /// This is used to link the product to a specific category.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the image URL for the product.
        /// </summary>
        public string? ImgUrl { get; set; }

        /// <summary>
        /// Gets or sets the category associated with the product.
        /// </summary>
        public Category Category { get; set; } = new Category();

        /// <summary>
        /// Formats the price of the product as a string with two decimal places.
        /// </summary>
        /// <returns>The formatted price as a string.</returns>
        public string FormattedPrice() => Price.ToString("0.00");
    }
}