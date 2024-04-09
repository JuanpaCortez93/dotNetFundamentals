using _001_Basics.DTOs;
using System.Text.Json;

namespace _001_Basics.Services
{
    public class ToDosService : IToDosService
    {

        private HttpClient _httpClient;

        public ToDosService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<IEnumerable<ToDosDTO>> GetToDos()
        {

            //string url = @"https://jsonplaceholder.typicode.com/todos";
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
               PropertyNameCaseInsensitive = true,
            };

            var todos = JsonSerializer.Deserialize<IEnumerable<ToDosDTO>>(body,options);

            return todos;
        }

    }
}
