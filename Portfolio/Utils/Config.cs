namespace Portfolio.Utils
{
    public class Config
    {
        private readonly IConfiguration _configuration;

        public Config(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConfig(string path, bool? file = null)
        {
            if (file is true)
            {
                return _configuration[path];
            }
            if (file is false)
            {
                return Environment.GetEnvironmentVariable(path) ?? string.Empty;
            }
            string? envConfig = Environment.GetEnvironmentVariable(path);
            if (envConfig is null)
            {
                return _configuration[path];
            }
            return envConfig;
        }

        public string this[string path] { get => GetConfig(path); }
    }
}
