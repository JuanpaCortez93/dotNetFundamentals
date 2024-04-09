using _001_Basics.DTOs;
using _001_Basics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {

        private IAlbumsService _albumsService;

        public AlbumsController(IAlbumsService albumsService) => _albumsService = albumsService;

        [HttpGet("get")]
        public Task<IEnumerable<AlbumsDTO>> GetAlbums() => _albumsService.GetAlbums();

    }
}
