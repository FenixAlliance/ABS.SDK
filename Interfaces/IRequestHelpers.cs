using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using FenixAlliance.Models.DTOs.Components.CRM;
using FenixAlliance.Models.DTOs.Components.Social;
using FenixAlliance.Models.DTOs.Components.Commons;

namespace FenixAlliance.Tools.Interfaces
{
    public interface IRequestHelpers
    {
        Task<Contact> GetCurrentContactAsync(ClaimsPrincipal CurrentUser);
        Task<Contact> ReportCurrentContactSession(ClaimsPrincipal CurrentUser);
        Task<List<Wallet>> GetCurrentContactWallet(ClaimsPrincipal CurrentUser);
        Task<List<FollowRecord>> GetCurrentContactFollows(ClaimsPrincipal CurrentUser);
        Task<List<PrivateMessage>> GetCurrentContactMessages(ClaimsPrincipal CurrentUser);
        Task<List<FollowRecord>> GetCurrentContactFollowers(ClaimsPrincipal CurrentUser);
        Task<List<Notification>> GetCurrentContactNotifications(ClaimsPrincipal CurrentUser);
    }
}
