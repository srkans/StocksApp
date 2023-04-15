using System.Text.Json;

namespace StocksApp.Services
{
    public class MyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task Method()
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://finnhub.io/api/v1/quote?symbol=AAPL&token=cgtb5n9r01qoiqvoupt0cgtb5n9r01qoiqvouptg"),
                    Method = HttpMethod.Get
                };

                 HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                 Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync();

                 StreamReader streamReader = new StreamReader(stream);

                 string response = streamReader.ReadToEnd();

                Dictionary<string,object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string,object>>(response);
            }
        }
    }
}
