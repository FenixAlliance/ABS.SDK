using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FenixAlliance.ABM.Models.DTOs.Components.Accounting.Billing;
using FenixAlliance.ABM.Models.DTOs.Components.Contacts;
using FenixAlliance.ABM.Models.DTOs.Components.Social;
using FenixAlliance.ABM.Models.DTOs.Components.Store.Carts;


namespace FenixAlliance.ABS.SDK.Interfaces
{
    public interface IRequestHelpers
    {
        Task<Contact> GetCurrentContactAsync(ClaimsPrincipal CurrentUser);
        Task<Contact> ReportCurrentContactSession(ClaimsPrincipal CurrentUser);
        Task<List<Wallet>> GetCurrentContactWallet(ClaimsPrincipal CurrentUser);
        Task<Cart> GetCurrentCart(ClaimsPrincipal CurrentUser, string CurrentIP);
        Task<List<FollowRecord>> GetCurrentContactFollows(ClaimsPrincipal CurrentUser);
        Task<List<PrivateMessage>> GetCurrentContactMessages(ClaimsPrincipal CurrentUser);
        Task<List<FollowRecord>> GetCurrentContactFollowers(ClaimsPrincipal CurrentUser);
        Task<List<Notification>> GetCurrentContactNotifications(ClaimsPrincipal CurrentUser);
    }
}
