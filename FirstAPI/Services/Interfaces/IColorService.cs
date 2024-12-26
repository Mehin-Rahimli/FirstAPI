using FirstAPI.DTOs.Color;

namespace FirstAPI.Services.Interfaces
{
    public interface IColorService
    {
        Task<IEnumerable<GetColorDTO>> GetAllAsync(int page, int take);
        Task<GetColorDetailDTO> GetByIdAsync(int id);
        Task<bool>CreateAsync(CreateColorDTO colorDTO);
        Task UpdateAsync(int id,UpdateColorDTO colorDTO); 
        Task DeleteAsync(int id);
    }
}
