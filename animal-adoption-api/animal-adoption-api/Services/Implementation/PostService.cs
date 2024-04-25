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

namespace animal.adoption.api.Services.Implementation
{

    public class PostService : IPostService
    {
        AppConfiguration config = new AppConfiguration();
        private readonly IRepository<POST> _posts;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PostService(
            IRepository<POST> posts,
            ILoggerManager logger,
            IConfiguration configuration,
            IMapper mapper)
        {
            _posts = posts;
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, PostDto model)
        {
            try
            {
                var post = _mapper.Map<POST>(model);
                post.CreatedAt = DateTime.Now;
                _posts.Insert(post);
                await _posts.SaveAsync();
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

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, PostDto model, int id)
        {
            try
            {
                var post = _mapper.Map<POST>(model);

                var postDb = await _posts.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                post.Id = id;
                post.UpdatedAt = DateTime.Now;
                post.CreatedAt = postDb.CreatedAt;

                _posts.Update(post);
                await _posts.SaveAsync();
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
                var post = await _posts.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _posts.Remove(post);
                await _posts.SaveAsync();
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

        public async Task<PostVM> GetByIdAsync(int id)
        {
            var db_model = await _posts.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<PostVM>(db_model);
        }

        public async Task<ResponseListTotal<PostVM>> GetAll(ResponseListTotal<PostVM> response, int page, int pageSize)
        {

            var db_data = await _posts.AllQuery.OrderByDescending(x => x.CreatedAt).ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<PostVM>>(db_data);
            return response;
        }
    }
}
