using Autofac.Extension;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace AutofacApp
{
    public class Startup
    {
        private readonly ILogger _logger;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly AppSetting _appSetting;
        private readonly IConfiguration _configuration;

        public Startup(ILogger logger, IJsonSerializer jsonSerializer, AppSetting appSetting, IConfiguration iconfiguration)
        {
            _logger = logger;
            _jsonSerializer = jsonSerializer;
            _appSetting = appSetting;
            _configuration = iconfiguration;
        }

        public virtual void Start()
        {
            _logger.Information(_jsonSerializer.Serialize(_appSetting));
            _logger.Information(_configuration.GetValue<string>("NO_KEY"));
        }
    }
}
