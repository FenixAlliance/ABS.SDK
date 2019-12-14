﻿using FenixAlliance.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FenixAlliance.Models.DTOs.Components.Billing;
using FenixAlliance.Models.DTOs.Components.CRM;
using FenixAlliance.Models.DTOs.Components.Social;
using FenixAlliance.Models.DTOs.Components.Commons;

namespace FenixAlliance.Tools.Services
{
    public class RequestHelpers : IRequestHelpers
    {
        private static HttpClient HttpClient { get; set; }
        public RequestHelpers(HttpClient AuthorizedHTTPClient)
        {
            HttpClient = AuthorizedHTTPClient;
        }

        public async Task<Contact> GetCurrentContactAsync(ClaimsPrincipal User)
        {

            var lastName = GetActiveDirectorySurName(User);
            var publicName = GetActiveDirectoryName(User);
            Contact Response = null;

            var ContactRequest = new Contact()
            {
               // CountryID = GetActiveDirectoryCountry(User), // TODO: Convert Country Name to ISO3 by calling countries api
                Email = GetActiveDirectoryEmail(User),
                Name = GetActiveDirectoryGivenName(User),
                ActiveDirectoryID = GetActiveDirectoryNameIdentifier(User),
                IdentityProvider = GetActiveDirectoryIdentityProvider(User),
                IdP_AccessToken = GetActiveDirectoryIdentityProviderToken(User),
            };

            try
            {
                HttpContent ContactPOSTRequest = new StringContent(ContactRequest.ToJson(), Encoding.UTF8, "application/json");
                var ContactPOSTResponse = await HttpClient.PostAsync("crm/contacts", ContactPOSTRequest);
                ContactPOSTResponse.EnsureSuccessStatusCode();
                Response = Contact.FromJson(await ContactPOSTResponse.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                var ContactGETRequest = await HttpClient.GetAsync($"crm/contacts/{ContactRequest.ActiveDirectoryID}");
                ContactGETRequest.EnsureSuccessStatusCode();
                Response = Contact.FromJson(await ContactGETRequest.Content.ReadAsStringAsync());
            }

            return Response;
        }

        public Task<List<FollowRecord>> GetCurrentContactFollowers(ClaimsPrincipal CurrentUser)
        {
            throw new NotImplementedException();
        }

        public Task<List<FollowRecord>> GetCurrentContactFollows(ClaimsPrincipal CurrentUser)
        {
            throw new NotImplementedException();
        }

        public Task<List<PrivateMessage>> GetCurrentContactMessages(ClaimsPrincipal CurrentUser)
        {
            throw new NotImplementedException();
        }

        public Task<List<Notification>> GetCurrentContactNotifications(ClaimsPrincipal CurrentUser)
        {
            throw new NotImplementedException();
        }

        public Task<List<Wallet>> GetCurrentContactWallet(ClaimsPrincipal CurrentUser)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> ReportCurrentContactSession(ClaimsPrincipal CurrentUser)
        {
            throw new NotImplementedException();
        }



        public string GetActiveDirectoryName(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                //CheckValues
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Type.Equals("name"))
                        return claim.Value;
                }
            }
            return "";
        }


        public string GetActiveDirectoryNameIdentifier(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                //CheckValues
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Type.Contains("nameidentifier"))
                        return claim.Value;

                }
            }
            return "";
        }

        public string IsNewTenant(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                //CheckValues
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Type.Contains("newUser"))
                        return claim.Value;
                }
            }
            return "";
        }

        public string GetActiveDirectorySurName(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                //CheckValues
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Type.ToString().Contains("surname"))
                        return claim.Value.ToString();

                }
            }
            return "";
        }

        public string GetActiveDirectoryGivenName(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                //CheckValues
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Type.ToString().Contains("givenname"))
                        return claim.Value.ToString();

                }
            }
            return "";
        }

        public string GetActiveDirectoryJobTitle(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                //CheckValues
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Type.ToString().Contains("jobTitle"))
                        return claim.Value.ToString();

                }
            }
            return "";
        }

        public string GetActiveDirectoryCountry(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                //CheckValues
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Type.ToString().Contains("country"))
                        return claim.Value.ToString();

                }
            }
            return "";
        }


        public string GetActiveDirectoryEmail(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                //CheckValues
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Type.ToString().Contains("email"))
                        return claim.Value.ToString();
                }
            }
            return "";
        }

        public string GetActiveDirectoryIdentityProvider(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                //CheckValues
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Type.ToString().ToLower().Contains("identityprovider"))
                        return claim.Value.ToString();
                }
            }
            return "";
        }


        public string GetActiveDirectoryIdentityProviderToken(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                //CheckValues
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Type.ToString().ToLower().Contains("token"))
                        return claim.Value.ToString();
                }
            }
            return "";
        }


    }
}
