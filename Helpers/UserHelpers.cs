using System.Security.Claims;

namespace FenixAlliance.ABS.SDK.Helpers
{
    public class UserHelpers
    {


        public string GetActiveDirectoryName(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                //CheckValues
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Type.ToString().Equals("name"))
                    {
                        return claim.Value.ToString();
                    }
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
                    if (claim.Type.ToString().Contains("nameidentifier"))
                    {
                        return claim.Value.ToString();
                    }
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
                    if (claim.Type.ToString().Contains("newUser"))
                    {
                        return claim.Value;
                    }
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
                    {
                        return claim.Value.ToString();
                    }
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
                    {
                        return claim.Value.ToString();
                    }
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
                    {
                        return claim.Value.ToString();
                    }
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
                    {
                        return claim.Value.ToString();
                    }
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
                    {
                        return claim.Value.ToString();
                    }
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
                    {
                        return claim.Value.ToString();
                    }
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
                    {
                        return claim.Value.ToString();
                    }
                }
            }
            return "";
        }
    }
}