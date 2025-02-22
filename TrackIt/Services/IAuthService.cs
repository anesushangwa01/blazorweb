using System.Threading.Tasks;

namespace TrackIt.Services
{
    /// <summary>
    /// IAuthService defines the contract for authentication services such as signing in and signing out users.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Asynchronously signs in a user with the provided username and compares the password to ensure that is the same from the database.
        /// </summary>
        /// <param name="username">The username of the user attempting to sign in.</param>
        /// <param name="password">The password of the user attempting to sign in.</param>
        /// <returns>A boolean indicating whether the sign-in was successful.</returns>
        Task<bool> SignInAsync(string username, string password);

        /// <summary>
        /// Asynchronously signs out the currently authenticated user.
        /// </summary>
        Task SignOutAsync();
    }
}