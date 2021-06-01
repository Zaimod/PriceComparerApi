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
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<bool> IsEmailConfirmed(string userName);
        Task<bool> ConfirmEmail(string userName);
        Task<string> CreateToken();
        Task<string> GetEmailByUserName(string userName);
     }
}
