using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FenixAlliance.Models.DTOs.Authorization;
using FenixAlliance.Tools.Helpers;
using FenixAlliance.Tools.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace FenixAlliance.Tools.Services
{
    public class AuthHelperService : IAuthorizationHelpers
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _env;
        private string PublicKey { get; set; }
        private string PrivateKey { get; set; }
        public bool IsAuthorized { get; set; }
        public HttpClient WebClient { get; set; }

        public AuthHelperService(IConfiguration configuration, IHostEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _env = hostingEnvironment;
            PublicKey = _configuration.GetSection("AllianceBusinessSuite").GetValue<string>("PublicKey");
            PrivateKey = _configuration.GetSection("AllianceBusinessSuite").GetValue<string>("PrivateKey");
            var handler = new HttpClientHandler();
            WebClient = new HttpClient(handler) { BaseAddress = new Uri("https://fenixalliance.com.co/api/v2/") };
            AuthorizeClient();
        }

        public async Task AuthorizeClient()
        {
            try
            {
                var TokenRequest = await WebClient.GetAsync($"OAuth2/Token?client_id={PublicKey}&client_secret={PrivateKey}&grant_type=client_credentials&requested_scopes=assets_read");
                TokenRequest.EnsureSuccessStatusCode();
                var Token = Deserialize.FromJson<JsonWebToken>(await TokenRequest.Content.ReadAsStringAsync());
                WebClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token.TokenType, Token.AccessToken);
                IsAuthorized = true;
            }
            catch (Exception e)
            {
                IsAuthorized = false;
                Console.WriteLine(e.ToString());
            }
        }

        public async Task AuthorizeClient(List<string> RequestedScopes)
        {
            try
            {
                var Scopes = string.Empty;
                RequestedScopes.ForEach(RequestedScope =>
                {
                    Scopes += RequestedScope + " ";
                });
                var TokenRequest = await WebClient.GetAsync($"OAuth2/Token?client_id={PublicKey}&client_secret={PrivateKey}&grant_type=client_credentials&requested_scopes={Scopes}");
                TokenRequest.EnsureSuccessStatusCode();
                var Token = Deserialize.FromJson<JsonWebToken>(await TokenRequest.Content.ReadAsStringAsync());
                IsAuthorized = true;
                WebClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token.TokenType, Token.AccessToken);

            }
            catch (Exception e)
            {
                IsAuthorized = false;
                Console.WriteLine(e.ToString());
            }
        }

    }
}