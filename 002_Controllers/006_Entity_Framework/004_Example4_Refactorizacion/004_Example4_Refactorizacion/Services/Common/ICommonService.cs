using _004_Example4_Refactorizacion.DTOs.Clients;
using Microsoft.AspNetCore.Mvc;

namespace _004_Example4_Refactorizacion.Services.Common
{
    public interface ICommonService <TGetDTO, TPostDTO, TPutDTO>
    {

        Task<IEnumerable<TGetDTO>> GetElements();
        Task<TGetDTO> GetElementById(Guid id);
        IEnumerable<TGetDTO> GetElementByName(string name);
        Task<TGetDTO> AddElement(TPostDTO elementsPostDTO);
        Task<TGetDTO> UpdateElement(Guid id, TPutDTO elementsPutDTO);
        Task<TGetDTO> DeleteElement(Guid id);

    }
}
