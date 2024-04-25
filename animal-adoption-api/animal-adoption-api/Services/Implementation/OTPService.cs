using System.Net.Mail;
using System.Net;

namespace animal.adoption.api.Services.Implementation
{
    public class OTPService
    {
        private readonly Dictionary<string, string> _otpCodes = new Dictionary<string, string>();

        public string GenerateOTP()
        {
            // Generate a random 6-digit OTP
            Random random = new Random();
            string otp = random.Next(100000, 999999).ToString();

            return otp;
        }

        public void SendOTP(string email, string otp)
        {
            // Configure SMTP client
            SmtpClient client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("abcde@gmail.com", "1234567890"),
                EnableSsl = true
            };

            // Compose email message
            MailMessage mailMessage = new MailMessage("abcde@gmail.com", email)
            {
                Subject = "OTP Verification",
                Body = $"Your OTP is: {otp}",
                IsBodyHtml = false
            };

            // Send email
            client.Send(mailMessage);
        }

        public bool VerifyOTP(string email, string otp)
        {
            // Verify the entered OTP
            if (_otpCodes.ContainsKey(email) && _otpCodes[email] == otp)
            {
                _otpCodes.Remove(email);
                return true;
            }

            return false;
        }

        public void AddOTP(string email, string otp)
        {
            // Store OTP in dictionary for verification
            _otpCodes[email] = otp;
        }
    }
}

