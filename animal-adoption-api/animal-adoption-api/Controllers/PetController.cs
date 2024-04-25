using Microsoft.AspNetCore.Mvc;
using animal.adoption.api.DTO.HelperModels.Const;
using animal.adoption.api.DTO.HelperModels;
using animal.adoption.api.DTO.ResponseModels.Main;
using System.Diagnostics;
using animal.adoption.api.Services.Interface;
using animal.adoption.api.DTO.ResponseModels.Inner;
using animal.adoption.api.Enums;
using animal.adoption.api.Models;
using animal.adoption.api.DTO.RequestModels;
using System.Drawing;


namespace animal.adoption.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IValidationCommon _validation;
        private readonly ILoggerManager _logger;
        public PetController(
            IPetService petService,
            IValidationCommon validation,
            ILoggerManager logger
            )
        {
            _petService = petService;
            _validation = validation;
            _logger = logger;
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePostAsync(PetDto model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _petService.CreateAsync(response, model);
                if (response.Status.ErrorCode != 0)
                {
                    return StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreatePostAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            ResponseObject<PetVM> response = new ResponseObject<PetVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response.Response = await _petService.GetByIdAsync(id);
                if (response.Response == null)
                {
                    response.Status.Message = "Məlumat tapılmadı!";
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetById)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            ResponseListTotal<PetVM> response = new ResponseListTotal<PetVM>();
            response.Response = new ResponseTotal<PetVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _petService.GetAll(response, page, pageSize);
                if (response.Response.Data == null)
                {
                    response.Status.Message = "Məlumat tapılmadı!";
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetAll)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        //[HttpGet]
        //[Route("get-all-filtered")]
        //public async Task<IActionResult> GetAllFiltered(int page, int pageSize, string sortBy)
        //{
        //    ResponseListTotal<PetVM> response = new ResponseListTotal<PetVM>();
        //    response.Response = new ResponseTotal<PetVM>();
        //    response.Status = new StatusModel();
        //    response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
        //    try
        //    {
        //        // Sorting logic
        //        Func<IEnumerable<PET>, IOrderedEnumerable<PET>> sortingFunc;
        //        switch (sortBy)
        //        {
        //            case "name":
        //                sortingFunc = pets => pets.OrderBy(p => p.Name);
        //                break;
        //            case "color":
        //                sortingFunc = pets => pets.OrderBy(p => p.Color);
        //                break;
        //            case "age":
        //                sortingFunc = pets => pets.OrderBy(p => p.Age);
        //                break;
        //            case "hair_length":
        //                sortingFunc = pets => pets.OrderBy(p => p.Hair);
        //                break;
        //            case "size":
        //                sortingFunc = pets => pets.OrderBy(p => p.Size);
        //                break;
        //            case "shelter":
        //                sortingFunc = pets => pets.OrderBy(p => p.Shelter);
        //                break;
        //            case "type":
        //                sortingFunc = pets => pets.OrderBy(p => p.Type);
        //                break;
        //            default:
        //                sortingFunc = pets => pets.OrderBy(p => p.Name); 
        //                break;
        //        }

        //        var filteredPets = await _petService.GetAllFiltered(page, pageSize);
        //        var sortedPets = sortingFunc(filteredPets);

        //        response.Response.Data = (List<PetVM>)sortedPets;
        //        return Ok(response);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetAll)}: " + $"{e}");
        //        response.Status.ErrorCode = ErrorCodes.SYSTEM;
        //        response.Status.Message = "Sistemdə xəta baş verdi.";
        //        return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
        //    }
        //}
    }
}

