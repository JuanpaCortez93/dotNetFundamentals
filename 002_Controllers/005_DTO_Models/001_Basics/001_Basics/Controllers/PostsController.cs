using _001_Basics.DTOs;
using _001_Basics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("posts")]
        public async Task<IEnumerable<PostDTO>> GetMyPosts() => await _postService.GetPost();

    }
}
