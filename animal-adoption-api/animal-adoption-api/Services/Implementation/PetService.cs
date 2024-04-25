using animal.adoption.api.DTO.HelperModels.Const;
using animal.adoption.api.DTO.ResponseModels.Main;
using animal.adoption.api.Extensions;
using animal.adoption.api.Infrastructure.Repository;
using animal.adoption.api.Services.Interface;
using animal.adoption.api.DTO.RequestModels;
using animal.adoption.api.DTO.ResponseModels.Inner;
using animal.adoption.api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using animal.adoption.api.Enums;

namespace animal.adoption.api.Services.Implementation
{

    public class PetService : IPetService
    {
        AppConfiguration config = new AppConfiguration();
        private readonly IRepository<PET> _pets;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PetService(
            IRepository<PET> pets,
            ILoggerManager logger,
            IConfiguration configuration,
            IMapper mapper)
        {
            _pets = pets;
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, PetDto model)
        {
            try
            {
                var pet = _mapper.Map<PET>(model);
                pet.CreatedAt = DateTime.Now;
                _pets.Insert(pet);
                await _pets.SaveAsync();
                response.Status.Message = "Uğurla əlavə olundu!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, PetDto model, int id)
        {
            try
            {
                var pet = _mapper.Map<PET>(model);

                var petDb = await _pets.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                pet.Id = id;
                pet.UpdatedAt = DateTime.Now;
                pet.CreatedAt = petDb.CreatedAt;

                _pets.Update(pet);
                await _pets.SaveAsync();
                response.Status.Message = "Uğurla yeniləndi!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

        public async Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id)
        {
            try
            {
                var pet = await _pets.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _pets.Remove(pet);
                await _pets.SaveAsync();
                response.Status.Message = "Uğurla silindi!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(DeleteAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

        public async Task<PetVM> GetByIdAsync(int id)
        {
            var db_model = await _pets.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<PetVM>(db_model);
        }

        public async Task<ResponseListTotal<PetVM>> GetAll(ResponseListTotal<PetVM> response, int page, int pageSize)
        {

            var db_data = await _pets.AllQuery.OrderByDescending(x => x.CreatedAt).ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<PetVM>>(db_data);
            return response;
        }
    }
}

