using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace CaRentalProject.AllServices
{
    public class RapiApiChatBotService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "Your_API_Key";
        private readonly string _apiUrl = "https://chat-gpt26.p.rapidapi.com/";

        public RapiApiChatBotService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "chat-gpt26.p.rapidapi.com");
        }

        public async Task<string> GetAnswerAsync(string prompt)
        {
            var requestData = new
            {
                model = "GPT-5-mini",
                messages = new object[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            using var response = await _httpClient.PostAsync(_apiUrl, content);

  
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"API Error: {response.StatusCode} - {error}");
            }

            var json = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(json);

            
            return result.choices[0].message.content.ToString();
        }
    }
}
