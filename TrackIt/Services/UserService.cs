using TrackIt.Data;
using TrackIt.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace TrackIt.Services
{
    /// <summary>
    /// UserService is a class that handles user-related operations such as registration and retrieval.
    /// Implements the IUserService interface.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        /// <summary>
        /// Constructor that initializes the UserService with the provided database context.
        /// </summary>
        /// <param name="db">The database context used for accessing the Users table.</param>
        public UserService(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Registers a new user if the username is not already taken.
        /// The user's password is hashed before being saved to the database.
        /// </summary>
        /// <param name="user">The user object containing the registration details.</param>
        /// <returns>True if registration is successful, false if the username already exists.</returns>
        public async Task<bool> RegisterUser(User user)
        {
            var userFromDb = await _db.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

            /// If the username already exists, return false.
            if (userFromDb != null)
            {
                return false;
            }

            /// Create a new user object, hash the password, and save it to the database.
            var userToSave = new User();
            userToSave.Username = user.Username;
            userToSave.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _db.Users.Add(userToSave);
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>The user object if found, otherwise null.</returns>
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            // Find and return the user by their username
            return await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}