using _001_Basics.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Services
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentsDTO>> GetComments();
    }
}
