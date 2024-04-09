
using _001_Basics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _001_Basics.Services
{
    public class PostService : IPostService
    {

        private HttpClient _httpClient;

        //public PostService() => _httpClient = new HttpClient();
        public PostService(HttpClient httpClient) { _httpClient = httpClient; }

        public async Task<IEnumerable<PostDTO>> GetPost()
        {
            //string url = @"https://jsonplaceholder.typicode.com/posts";
            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var post = JsonSerializer.Deserialize<IEnumerable<PostDTO>>(body, options);
            return post;

        }
    }
}
