using MeteorologiaProva.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MeteorologiaProva.Services
{
    public class ClimaServices
    {
        private HttpClient httpClient;
        private JsonSerializerOptions jsonSerializerOptions;
        private ObservableCollection<ObservableCollection<Cidade>> wheaters;

        public ClimaServices()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }
        public async Task<ObservableCollection<ObservableCollection<Cidade>>> getClimate(string nome)
        {
            Uri uri = new Uri("https://api.openweathermap.org/data/2.5/weather?lat=35.6894&lon=139.692&appid=be27c497896358e6817faedba76c9a9f");
            try
            {

                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {

                    string content = await response.Content.ReadAsStringAsync();
                    var meteorology = JsonSerializer.Deserialize<ObservableCollection<Cidade>>(content, jsonSerializerOptions);
                    Debug.WriteLine(meteorology);
                    if (meteorology != null)
                    {
                        wheaters.Add(meteorology);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return wheaters;
        }
    }
}
