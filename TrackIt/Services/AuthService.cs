using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using TrackIt.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace TrackIt.Services
{
    /// <summary>
    /// AuthService handles user authentication, including signing in and signing out.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the AuthService class.
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor for accessing the HTTP context during authentication operations.</param>
        /// <param name="userService">The user service to interact with user data for authentication.</param>
        public AuthService(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        /// <summary>
        /// Asynchronously signs in a user using their username and password.
        /// </summary>
        /// <param name="username">The username of the user attempting to sign in.</param>
        /// <param name="password">The password of the user attempting to sign in.</param>
        /// <returns>A boolean indicating whether the sign-in was successful or not.</returns>
        public async Task<bool> SignInAsync(string username, string password)
        {
            /// Get the user with the given username param.
            var user = await _userService.GetUserByUsernameAsync(username);

            // Check if user exists and if password matches
            if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return false;
            }

            // Create claims for the authenticated user
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.Role, user.Role) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // Sign in the user by setting the authentication cookie
            await _httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });

            return true;

        }

        /// <summary>
        /// Asynchronously signs out the currently authenticated user.
        /// </summary>
        public async Task SignOutAsync()
        {
            // Sign out by removing the authentication cookie
            await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}