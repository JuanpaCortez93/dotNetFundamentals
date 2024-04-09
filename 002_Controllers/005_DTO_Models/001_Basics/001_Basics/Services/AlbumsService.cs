using _001_Basics.DTOs;
using System.Text.Json;

namespace _001_Basics.Services
{
    public class AlbumsService : IAlbumsService
    {

        private HttpClient _httpClient;

        public AlbumsService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<IEnumerable<AlbumsDTO>> GetAlbums()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var albums = JsonSerializer.Deserialize<IEnumerable<AlbumsDTO>>(body, options);

            return albums;
        }

    }
}
