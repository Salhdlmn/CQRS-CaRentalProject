using CaRentalProject.Models;
using Newtonsoft.Json;

namespace CaRentalProject.AllServices
{
    public class RapidAPIAirportService
    {
        private readonly HttpClient _httpClient;

        public RapidAPIAirportService(HttpClient client)
        {
            _httpClient = client;
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "Your_API_Key");
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "geodatamaster.p.rapidapi.com");
        }

        public async Task<List<RapidApiCountryAndAirportViewModel>> GetAirportsAsync()
        {
            var response = await _httpClient.GetAsync("https://geodatamaster.p.rapidapi.com/api/v1/airport/?country_alpha2=TR");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            // API’den dönen JSON içinde "airports": [] var, o yüzden wrapper class lazım
            var root = JsonConvert.DeserializeObject<Root>(json);

            return root?.Airports ?? new List<RapidApiCountryAndAirportViewModel>();
        }
    }

    public class Root
    {
        [JsonProperty("airports")]
        public List<RapidApiCountryAndAirportViewModel> Airports { get; set; }
    }
}

