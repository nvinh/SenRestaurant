using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text;
using System.Web;

namespace Todo
{
    public class TextAnalyticService : ITextAnalyticService
    {
        IAuthenticationService authenticationService;

        public TextAnalyticService(IAuthenticationService authService)
        {
            authenticationService = authService;
        }

        public async Task<string> AnalyticTextAsync_std(string text)
        {
            var client = new HttpClient();
            //string queryString = Constants.TextAnalyticEndpoint;
            //queryString += string.Format("?text={0}", Uri.EscapeUriString(text));
            //var queryString = HttpUtility.ParseQueryString(text);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "5170c8e160254d5284fe6387d9dc38f7");
            var uri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment?" + text; //+ queryString;

            HttpResponseMessage response;
            //var response;

            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }
            var xml = XDocument.Parse(response.ToString());
            return xml.Root.Value;
        }

        public async Task<string> AnalyticTextAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(authenticationService.GetAccessToken()))
            {
                await authenticationService.InitializeAsync();
            }

            string requestUri = GenerateRequestUri(Constants.TextAnalyticEndpoint, text, "en", "de");
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
