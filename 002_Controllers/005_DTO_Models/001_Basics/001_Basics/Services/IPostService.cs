using _001_Basics.DTOs;

namespace _001_Basics.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> GetPost(); 
    }
}
