namespace animal.adoption.api.DTO.RequestModels.Auth
{
    public class ResetPasswordDto
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }

    }
}
