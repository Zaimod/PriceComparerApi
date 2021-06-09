using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAuthenticationManager
    {
        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="userForAuth">The user for authentication.</param>
        /// <returns></returns>
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);

        /// <summary>
        /// Determines whether [is email confirmed] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<bool> IsEmailConfirmed(string userName);

        /// <summary>
        /// Confirms the email.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<bool> ConfirmEmail(string userName);

        /// <summary>
        /// Creates the token.
        /// </summary>
        /// <returns></returns>
        Task<string> CreateToken();

        /// <summary>
        /// Gets the name of the email by user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<string> GetEmailByUserName(string userName);
        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<bool> UpdateUser(UserDto user);
     }
}
