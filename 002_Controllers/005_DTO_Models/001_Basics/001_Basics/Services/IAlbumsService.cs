using _001_Basics.DTOs;

namespace _001_Basics.Services
{
    public interface IAlbumsService
    {
        Task<IEnumerable<AlbumsDTO>> GetAlbums();
    }
}
