using Microsoft.AspNetCore.Components.Authorization;
using StudiousWeb.Models;
using System.Security.Claims;
using System.Text.Json.Nodes;
using System.Net.Http.Headers;

namespace StudiousWeb.Components.Services
{
    /// <summary>
    /// Provides information about the authentication state of the current user.
    /// </summary>
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;

        public CustomAuthStateProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // A non-authenticated user
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            try
            {
                // Sends a GET HTTP method to the Web API to obtain authenticated user info.
                var response = await httpClient.GetAsync("manage/info");

                // If the HTTP status code is in a range of 200 -> 299, then the response is successful.
                if (response.IsSuccessStatusCode)
                {
                    var responseAsStr = await response.Content.ReadAsStringAsync();
                    var responseAsJson = JsonNode.Parse(responseAsStr);
                    var email = responseAsJson!["email"]!.ToString();

                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, email),
                        new(ClaimTypes.Email, email)
                    };

                    var identity = new ClaimsIdentity(claims, "Token");
                    user = new ClaimsPrincipal(identity);

                    return new AuthenticationState(user);
                }
            }
            catch(Exception ex)
            {
            }

            return new AuthenticationState(user);
        }

        /// <summary>
        /// Asyncronusly performs a user login interaction through an HTTP request.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>An HTTP response if the user is authenticated or not.</returns>
        public async Task<FormResult> LoginAsync(string email, string password)
        {
            FormResult result = new FormResult();

            try
            {
                // Sends the POST HTTP request to the Web API using the /login URL.
                var response = await httpClient.PostAsJsonAsync("login", new { email, password });

                // If the HTTP status code is in a range of 200 -> 299, then the response is successful.
                if (response.IsSuccessStatusCode)
                {
                    var responseAsString = await response.Content.ReadAsStringAsync();
                    var responseAsJson = JsonNode.Parse(responseAsString);
                    var accessToken = responseAsJson?["accessToken"]?.ToString();
                    var refreshToken = responseAsJson?["refreshToken"]?.ToString();

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

                    result.Succeeded = true;
                }
                else
                {
                    result.Succeeded = false;
                    result.Errors = ["Unable to authenticate with the provide credentials."];
                }
            }
            catch
            {
                result.Succeeded = false;
                result.Errors = ["Connection issue with the provider.\nPlease try again, or contact your administrator."];
            }

            return result;
        }
    }
}
