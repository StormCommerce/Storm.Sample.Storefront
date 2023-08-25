using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Integration.Storm.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Integration.Storm.Managers
{
    public class Authentication
    {
        public IMemoryCache Cache { get; }

        public Authentication(IMemoryCache cache)
        {
            Cache = cache;
        }

        public async Task<string> GetUncachedAccessToken()
        {
            var auth = Cache.Get<Auth>("accessTokenKey");
            if (auth is null)
            {
                var httpClient = new HttpClient();
                var oauthClientId = "";
                var oauthClientSecret = "";
                var environment = "lab";

                var requestBody = $"client_id={oauthClientId}&client_secret={oauthClientSecret}&grant_type=client_credentials&scope={environment}";
                var tokenRequest = new HttpRequestMessage
                                   {
                                       RequestUri = new Uri("https://identity.storm.io/1.0/connect/token"),
                                       Content = new StringContent(requestBody,
                                           Encoding.UTF8,
                                           "application/x-www-form-urlencoded"),
                                       Method = HttpMethod.Post
                                   };
                var httpResponse = await httpClient.SendAsync(tokenRequest);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    // Handle error
                    return null;
                }

                auth = JsonSerializer.Deserialize<Auth>(httpResponse.Content.ReadAsStringAsync().Result);
                Cache.Set("accessTokenKey", auth, DateTimeOffset.Now.AddSeconds(auth.expires_in - 1));
            }

            return auth.access_token;
        }
    }

    public class Auth
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
    }

    public class NorceConnectionManager : IStormConnectionManager
    {
        IConfiguration _configuration;
        private string AppId;
        private string StormBaseUrl;
        private static HttpClient httpClient = new HttpClient();
        private readonly Authentication _authentication;

        public NorceConnectionManager(IConfiguration configuration, IMemoryCache cache)
        {
            AppId = configuration["Storm:ApplicationId"];
            StormBaseUrl = configuration["Storm:ApiUrl"];
            _configuration = configuration;
            _authentication = new Authentication(cache);
        }

        private async Task<TR> SendRequest<TR>(HttpRequestMessage request)
        {
            var accessToken = await _authentication.GetUncachedAccessToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            request.Headers.Add("applicationId", AppId);

            var response = await httpClient.SendAsync(request);
            var result = response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                if ((int)response.StatusCode >= 400 && (int)response.StatusCode <= 499)
                {
                    throw new BadRequestException((int)response.StatusCode, response.ReasonPhrase);
                }

                if ((int)response.StatusCode >= 500 && (int)response.StatusCode <= 599)
                {
                    throw new ServerErrorException((int)response.StatusCode, response.ReasonPhrase);
                }

                throw new Exception("Invalid request status " + (int)response.StatusCode + ", reason=" + response.ReasonPhrase);
            }

            var r = JsonSerializer.Deserialize<TR>(result.Result);
            return r;
        }

        public async Task<TR> GetResult<TR>(string url)
        {
            var httpMethod = HttpMethod.Get;
            var request = new HttpRequestMessage(httpMethod, prepareUrl(url));
            return await SendRequest<TR>(request);
        }

        public async Task<TR> PostResult<TR>(string url)
        {
            var httpMethod = HttpMethod.Post;
            var request = new HttpRequestMessage(httpMethod, prepareUrl(url));
            request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

            return await SendRequest<TR>(request);
        }

        public async Task<TR> PostResult<TR>(string url, object content)
        {
            var data = JsonSerializer.Serialize(content, new JsonSerializerOptions
                                                         {
                                                             DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                                                         });

            var httpMethod = HttpMethod.Post;
            var request = new HttpRequestMessage(httpMethod, prepareUrl(url));
            request.Content = new StringContent(data, Encoding.UTF8, "application/json");

            return await SendRequest<TR>(request);
        }

        public async Task<TR> FormPostResult<TR>(string url, Dictionary<string, string> formDictionary)
        {
            throw new System.NotImplementedException();
        }

        // private async Task<string> GetAccess(string url)
        // {
        //     var cache = new CachingService();
        //     var httpClient = new HttpClient();
        //     var oauthClientId = "<OAuth User Id>";
        //     var oauthClientSecret = "<OAuth User Secret>";
        //     var environment = "<lab | production>";
        //
        //     string accessToken = cache.GetOrAdd("AuthorizationToken", () =>
        //     {
        //
        //     }, DateTimeOffset.Now.AddSeconds(500));
        //
        //     return accessToken;
        // }

        private string prepareUrl(string url)
        {
            var finalUrl = url;
            if (!url.StartsWith("http"))
            {
                finalUrl = StormBaseUrl + url;
                if (!finalUrl.Contains("format=json"))
                {
                    if (!finalUrl.Contains("?"))
                    {
                        finalUrl += "?format=json";
                    }
                    else
                    {
                        finalUrl += "&format=json";
                    }
                }
            }

            return finalUrl;
        }
    }
}