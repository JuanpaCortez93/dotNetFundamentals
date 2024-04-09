using _001_Basics.DTOs;
using System.Text.Json;

namespace _001_Basics.Services
{
    public class CommentsService : ICommentsService
    {

        private HttpClient _httpClient;

        public CommentsService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<IEnumerable<CommentsDTO>> GetComments()
        {
            //string url = @"https://jsonplaceholder.typicode.com/comments";
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var comments = JsonSerializer.Deserialize<IEnumerable<CommentsDTO>>(body, options);

            return comments;

        }

    }
}
