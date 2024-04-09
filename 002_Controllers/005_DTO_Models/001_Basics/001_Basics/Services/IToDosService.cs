using _001_Basics.DTOs;

namespace _001_Basics.Services
{
    public interface IToDosService
    {
        Task<IEnumerable<ToDosDTO>> GetToDos();
    }
}
