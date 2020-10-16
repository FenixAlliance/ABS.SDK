namespace FenixAlliance.Passport.Pocket.Services.Authentication
{
    public static class B2CConstants
    {
        // Azure AD B2C Coordinates
        public static string Tenant = "fenixallianceb2c.onmicrosoft.com";
        public static string AzureADB2CHostname = "login.microsoftonline.com";
        public static string ClientID = "0a203cf7-e8a0-4c56-9d83-1c769fc579df";
        public static string PolicySignUpSignIn = "B2C_1_AllianceID";
        public static string PolicyEditProfile = "B2C_1_Edit-AllianceID";
        public static string PolicyResetPassword = "B2C_1_AllianceID-Pass";

        public static string[] Scopes = { "https://fenixallianceb2c.onmicrosoft.com/web/api.read", "https://fenixallianceb2c.onmicrosoft.com/web/api.write", "https://fenixallianceb2c.onmicrosoft.com/web/user_impersonation", "https://fenixallianceb2c.onmicrosoft.com/web/app.write", "https://fenixallianceb2c.onmicrosoft.com/web/app.read" };

        public static string AuthorityBase = $"https://{AzureADB2CHostname}/tfp/{Tenant}/";
        public static string AuthoritySignInSignUp = $"{AuthorityBase}{PolicySignUpSignIn}";
        public static string AuthorityEditProfile = $"{AuthorityBase}{PolicyEditProfile}";
        public static string AuthorityPasswordReset = $"{AuthorityBase}{PolicyResetPassword}";
        public static string IOSKeyChainGroup = "com.microsoft.adalcache";
    }
}