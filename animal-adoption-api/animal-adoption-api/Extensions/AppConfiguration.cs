namespace animal.adoption.api.Extensions
{
    public class AppConfiguration
    {
        private readonly string _jwtSecret = string.Empty;
        private readonly string _mail_username = string.Empty;
        private readonly string _mail_password = string.Empty;
        private readonly string _mail_host = string.Empty;
        private readonly int _mail_port;
        private readonly string _url;
        private readonly string _appFilePath = string.Empty;
        private readonly string _connectionString = string.Empty;

        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();

            _connectionString = root.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            _jwtSecret = root.GetSection("ApplicationSettings").GetSection("jwt_secret").Value;
            _appFilePath = root.GetSection("Template").GetSection("appFile").Value;
            _mail_username = root.GetSection("Mail").GetSection("Username").Value;
            _mail_password = root.GetSection("Mail").GetSection("Password").Value;
            _mail_host = root.GetSection("Mail").GetSection("Host").Value;
            _url = root.GetSection("Mail").GetSection("Url").Value;
            int.TryParse(root.GetSection("Mail").GetSection("Port").Value, out _mail_port);
        }
        public string JWTSecret  => _jwtSecret;
        public string AppFilePath => _appFilePath;
        public string MailUsername => _mail_username;
        public string MailPassword => _mail_password;
        public string MailHost => _mail_host;
        public string MailUrl => _url;
        public int MailPort => _mail_port;
        public string ConnectionString => _connectionString;     
    }
}
