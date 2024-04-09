namespace _004_Example5_Complete.Services.Common
{
    public interface ICommonService<TGetDTO, TPostDTO, TPutDTO>
    {
        Task<IEnumerable<TGetDTO>> GetElements();
        Task<TGetDTO> GetElement(Guid id);
        Task<TGetDTO> AddElement(TPostDTO tPostDTO);
        Task<TGetDTO> UpdateElement(Guid id, TPutDTO tPutDTO);
        Task<TGetDTO> DeleteElement(Guid id);
    }
}
