namespace animal.adoption.api.Services.Interface
{
    public interface IOTPService
    {
        void SendOTP(string email, string otp);
        bool VerifyOTP(string email, string otp);
        void AddOTP(string email, string otp);
        string GenerateOTP();
    }
}
