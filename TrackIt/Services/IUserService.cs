using System.Threading.Tasks;
using TrackIt.Models;

namespace TrackIt.Services
{
    /// <summary>
    /// IUserService is an interface that defines the contract for user-related services such as registration and retrieval.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Asynchronously retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>A user object if found, otherwise null.</returns>
        Task<User?> GetUserByUsernameAsync(string username);

        /// <summary>
        /// Asynchronously registers a new user if the username is not already taken.
        /// </summary>
        /// <param name="user">The user object containing the registration details.</param>
        /// <returns>True if registration is successful, false if the username already exists.</returns>
        Task<bool> RegisterUser(User user);
    }
}