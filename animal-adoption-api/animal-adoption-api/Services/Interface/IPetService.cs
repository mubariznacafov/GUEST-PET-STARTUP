using animal.adoption.api.DTO.RequestModels;
using animal.adoption.api.DTO.ResponseModels.Inner;
using animal.adoption.api.DTO.ResponseModels.Main;
using animal.adoption.api.Enums;
using animal.adoption.api.Models;

namespace animal.adoption.api.Services.Interface
{
    public interface IPetService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, PetDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, PetDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<PetVM> GetByIdAsync(int id);
        Task<ResponseListTotal<PetVM>> GetAll(ResponseListTotal<PetVM> response, int page, int pageSize);
        
    }
}
