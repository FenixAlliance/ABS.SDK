namespace FenixAlliance.ABS.SDK.Services.Authentication
{
    public static class B2CConstants
    {
        // Azure AD B2C Coordinates
        public static string PolicySignUpSignIn { get; set; } = "B2C_1_AllianceID";
        public static string Tenant { get; set; } = "fenixallianceb2c.onmicrosoft.com";
        public static string PolicyEditProfile { get; set; } = "B2C_1_Edit-AllianceID";
        public static string PolicyResetPassword { get; set; } = "B2C_1_AllianceID-Pass";
        public static string AzureADB2CHostname { get; set; } = "login.microsoftonline.com";
        public static string ClientID { get; set; } = "0a203cf7-e8a0-4c56-9d83-1c769fc579df";

        public static string[] Scopes { get; set; } = { "https://fenixallianceb2c.onmicrosoft.com/web/api.read", "https://fenixallianceb2c.onmicrosoft.com/web/api.write", "https://fenixallianceb2c.onmicrosoft.com/web/user_impersonation", "https://fenixallianceb2c.onmicrosoft.com/web/app.write", "https://fenixallianceb2c.onmicrosoft.com/web/app.read" };

        public static string AuthorityBase { get; set; } = $"https://{AzureADB2CHostname}/tfp/{Tenant}/";
        public static string AuthoritySignInSignUp { get; set; } = $"{AuthorityBase}{PolicySignUpSignIn}";
        public static string AuthorityEditProfile { get; set; } = $"{AuthorityBase}{PolicyEditProfile}";
        public static string AuthorityPasswordReset { get; set; } = $"{AuthorityBase}{PolicyResetPassword}";
        public static string IOSKeyChainGroup { get; set; } = "com.microsoft.adalcache";
    }
}