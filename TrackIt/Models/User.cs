using System.ComponentModel.DataAnnotations;

namespace TrackIt.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// This class contains user credentials and role information.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// This field is required and must be a valid email format.
        /// </summary>
        [Required(ErrorMessage = "Please provide your email."), EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password for the user.
        /// The password must be between 8 and 20 characters in length.
        /// </summary>
        [Required(ErrorMessage = "Please provide your password."), MinLength(8, ErrorMessage = "Password must be at least 8 characters long."), MaxLength(20, ErrorMessage = "Password must be at most 20 characters long.")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the role of the user.
        /// The default role is "Admin".
        /// </summary>
        public string Role { get; set; } = "Admin";
    }
}