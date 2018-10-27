using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public class ClockworkApi
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string SendPoint = "https://api.clockworksms.com/http/send.aspx";

        private readonly string _key;

        public ClockworkApi()
        {
            _key = Environment.GetEnvironmentVariable("ClockworkKey");
        }

        public async Task SendMessage(string to, string content)
        {
            using (var msg = new HttpRequestMessage(HttpMethod.Post, $"{SendPoint}?to={to}&content={content}&key={_key}"))
            {
                var result = await _httpClient.SendAsync(msg);

                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to send message to {to}");
                }
            }
        }
    }
}
