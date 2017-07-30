using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text;
using System.Web;

namespace Todo
{
    public class TestQueryService : ITestQueryService
    {
        IAuthenticationService authenticationService;

        public TestQueryService(IAuthenticationService authService)
        {
            authenticationService = authService;
        }

        public async Task<string> TestQueryAsync(string text)
        {
            string url = GenerateRequestUri(Constants.TestQueryEndpoint, text, "en", "de");
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> TestQueryAsync_std(string text)
        {
            if (string.IsNullOrWhiteSpace(authenticationService.GetAccessToken()))
            {
                await authenticationService.InitializeAsync();
            }

            string requestUri = GenerateRequestUri(Constants.TestQueryEndpoint, text, "en", "de");
            string accessToken = authenticationService.GetAccessToken();
            var response = await SendRequestAsync(requestUri, accessToken);
            var xml = XDocument.Parse(response);
            return xml.Root.Value;
        }

        string GenerateRequestUri(string endpoint, string text, string from, string to)
        {
            string requestUri = endpoint;
            requestUri += string.Format("?text={0}", Uri.EscapeUriString(text));
            //requestUri += string.Format("&from={0}", from);
            //requestUri += string.Format("&to={0}", to);
            return requestUri;
        }

        async Task<string> SendRequestAsync(string url, string bearerToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
