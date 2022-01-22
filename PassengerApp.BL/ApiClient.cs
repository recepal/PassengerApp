using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PassengerApp.BL
{
    public class ApiClient
    {
        public HttpClient _client { get; set; }

        public ApiClient()
        {
            _client = GetClient();
        }

        public async Task<T> Get<T>(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                string error = $"{response.StatusCode}";
                throw new HttpRequestException(error);
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(content))
                {
                    return default;
                }
                else
                {
                    return JsonSerializer.Deserialize<T>(content, JsonContent.GetJssOption())!;
                }
            }
        }

        public async Task<T> Post<T>(string url, object entity)
        {
            HttpResponseMessage response = await _client.PostAsync(url, new JsonContent(entity));
            if (!response.IsSuccessStatusCode)
            {
                string hata = $"{response.StatusCode}";
                throw new HttpRequestException(hata);
            }
            else if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return default;
            }
            else
            {
                string contentAsString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(contentAsString, JsonContent.GetJssOption())!;
            }

        }

        private HttpClient GetClient()
        {
            HttpClient client = new();
            client.BaseAddress = new Uri("http://localhost:5133");
            return client;
        }

    }

    public class JsonContent : StringContent
    {
        public JsonContent(object entity) : base(JsonSerializer.Serialize(entity, GetJssOption()), Encoding.UTF8, "application/json")
        {

        }

        public static JsonSerializerOptions GetJssOption()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                AllowTrailingCommas = true,
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
            };

            return options;
        }
    }
}
