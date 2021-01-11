using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using FenixAlliance.ABS.SDK.Interfaces;
using FenixAlliance.Models.DTOs.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace FenixAlliance.ABS.SDK.Services
{
    public class AuthHelperService : IAuthorizationHelpers
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _env;
        private string PublicKey { get; set; }
        private string PrivateKey { get; set; }
        private string Scopes { get; set; }
        private string BaseEndpoint { get; set; } = "rest.absuite.net";
        private string AuthEndpoint { get; set; }
        public bool IsAuthorized { get; set; }
        public HttpClient WebClient { get; set; }

        public AuthHelperService(IConfiguration configuration, IHostEnvironment hostingEnvironment)
        {
            _env = hostingEnvironment;
            _configuration = configuration;
            Scopes = _configuration.GetSection("ABS").GetValue<string>("Scopes");
            PublicKey = _configuration.GetSection("ABS").GetValue<string>("PublicKey");
            PrivateKey = _configuration.GetSection("ABS").GetValue<string>("PrivateKey");
            BaseEndpoint = _configuration.GetSection("ABS").GetValue<string>("BaseEndpoint");
            AuthEndpoint = $"https://{BaseEndpoint}/api/v2/OAuth2/Token?client_id={PublicKey}&client_secret={PrivateKey}&grant_type=client_credentials&requested_scopes={Scopes}";
            WebClient = new HttpClient() { BaseAddress = new Uri($"https://{BaseEndpoint}/api/v2/") };
            WebClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task AuthorizeClient()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var TokenRequest = await client.GetAsync(AuthEndpoint);
                    TokenRequest.EnsureSuccessStatusCode();
                    var TokenString = await TokenRequest.Content.ReadAsStringAsync();
                    var Token = JsonSerializer.Deserialize<JsonWebToken>(TokenString);
                    WebClient.DefaultRequestHeaders.Add("Authorization", $"{Token.TokenType} {Token.AccessToken}");
                    IsAuthorized = true;
                }
            }
            catch (Exception e)
            {
                IsAuthorized = false;
                Console.WriteLine(e.ToString());
            }
        }

        public async Task<JsonWebToken> GetToken()
        {
            JsonWebToken Response = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var TokenRequest = await client.GetAsync(AuthEndpoint);
                    TokenRequest.EnsureSuccessStatusCode();
                    var TokenString = await TokenRequest.Content.ReadAsStringAsync();
                    Response = JsonSerializer.Deserialize<JsonWebToken>(TokenString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return Response;
        }

        public async Task<JsonWebToken> RefreshToken(JsonWebToken JsonWebToken)
        {
            try
            {
                if (JsonWebToken == null || String.IsNullOrEmpty(JsonWebToken.AccessToken) || String.IsNullOrEmpty(JsonWebToken.TokenType))
                {
                    JsonWebToken = await GetToken();
                }
                else
                {
                    //TODO:_ Check Token Header for Expiration and renew if expired.
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return JsonWebToken;
        }

        public async Task AuthorizeClient(List<string> RequestedScopes)
        {
            try
            {
                var Token = await GetToken();

                this.IsAuthorized = true;

                WebClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token.TokenType, Token.AccessToken);
            }
            catch (Exception e)
            {
                this.IsAuthorized = false;
                Console.WriteLine(e.ToString());
            }
        }

    }
}