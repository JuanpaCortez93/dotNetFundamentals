using _001_Basics.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Services
{
    public interface ICommonService <T, TI, TU>
    {

        public List<string> Errors { get; }

        Task<IEnumerable<T>> GetBeers();
        Task<T> GetBeer(int id);
        Task<T> AddBeer(TI beerInsertDTO);
        Task<T> UpdateBeer(int id, TU beerUpdateDTO);
        Task<T> DeleteBeer(int id);

        //Validations
        bool Validate(TI dto);
        bool Validate(TU dto);

    }
}
