using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using animal.adoption.api.DTO.HelperModels;
using animal.adoption.api.DTO.HelperModels.Const;
using animal.adoption.api.DTO.HelperModels.Jwt;
using animal.adoption.api.DTO.RequestModels.Auth;
using animal.adoption.api.DTO.ResponseModels.Main;
using animal.adoption.api.Services.Interface;
using System.Diagnostics;
using animal.adoption.api.Models;
using animal.adoption.api.Services.Implementation;

namespace animal.adoption.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidationCommon _validation;
        private readonly ILoggerManager _logger;
        private readonly IOTPService _otpService;

        public AuthController(
            IAuthService authService,
            IOTPService otpService,
            IValidationCommon validation,
            ILoggerManager logger)
        {
            _authService = authService;
            _validation = validation;
            _otpService = otpService;
            _logger = logger;
        }

        [HttpPost]
        [Route("register-user")]
        public async Task<IActionResult> RegisterUserAsync(RegisterDto model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _authService.RegisterUserAsync(response, model);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(RegisterUserAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = e.Message;
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }


        [HttpPost]
        [Route("login-user")]
        public async Task<IActionResult> LoginUserAsync(LoginDto model)
        {
            ResponseObject<JwtResponse> response = new ResponseObject<JwtResponse>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _authService.LoginAsync(response, model);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(LoginUserAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(string email)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _authService.ForgotPasswordAsync(response, email);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(ForgotPasswordAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }


        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordDto model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _authService.ResetPasswordAsync(response, model);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(ResetPasswordAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpPost]
        [Route("change-password")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDto model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                var userId = Convert.ToInt32(User.Claims.First(x => x.Type == "UserId").Value);
                model.UserId = userId;
                response = await _authService.ChangePasswordAsync(response, model);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(ChangePasswordAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        } 
          


            [HttpPost]
        [Route("request-otp")]
            public IActionResult RequestOTP([FromBody] EmailRequest request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string otp = _otpService.GenerateOTP();
                _otpService.SendOTP(request.Email, otp);
                _otpService.AddOTP(request.Email, otp); // Add generated OTP to dictionary for verification
                return Ok();
            }

            [HttpPost]
        [Route("verify-otp")]
            public IActionResult VerifyOTP([FromBody] OTPVerification verification)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool isVerified = _otpService.VerifyOTP(verification.Email, verification.OTP);
                if (isVerified)
                {
                    // Authentication successful
                    return Ok(new { message = "Authentication successful" });
                }
                else
                {
                    // Authentication failed
                    return Unauthorized(new { message = "Invalid OTP" });
                }
            }
        }
    }

