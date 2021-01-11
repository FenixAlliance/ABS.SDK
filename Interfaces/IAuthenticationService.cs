using System.Threading.Tasks;
using FenixAlliance.ABS.SDK.Services.Authentication;

namespace FenixAlliance.ABS.SDK.Interfaces
{
    public interface IAuthenticationService
    {
        void SetParent(object parent);
        Task<UserContext> SignInAsync();
        Task<UserContext> SignOutAsync();
        Task<UserContext> EditProfileAsync();
        Task<UserContext> ResetPasswordAsync();
    }
}