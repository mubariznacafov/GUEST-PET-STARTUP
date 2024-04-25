using animal.adoption.api.DTO.ResponseModels.Main;
using animal.adoption.api.DTO.RequestModels;
using animal.adoption.api.DTO.ResponseModels.Inner;

namespace animal.adoption.api.Services.Interface
{
    public interface IPostService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, PostDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, PostDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<PostVM> GetByIdAsync(int id);
        Task<ResponseListTotal<PostVM>> GetAll(ResponseListTotal<PostVM> response, int page, int pageSize);
    }
}
