using System.IO;
using Autofac;
using Autofac.Extension;
using Autofac.Extras.DynamicProxy;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace AutofacApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var logger = InitLogger();
            /*
             * Autofac
             * https://autofaccn.readthedocs.io/en/latest/index.html
             */
            var builder = new ContainerBuilder();
            // Json serializer
            builder.AddJsonSerializer();
            // configration
            builder.AddConfigration(config => config
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true)
                    .AddEnvironmentVariables("APP_")
                    .AddCommandLine(args));
            builder.Configure<AppSetting>();
            // log
            builder.RegisterInstance(logger)
                .As<ILogger>()
                .SingleInstance()
                .ExternallyOwned();
            // startup
            builder.RegisterType<Startup>()
                .AsSelf()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(AutoLoggerInterceptor));
            // AOP
            builder.RegisterType<AutoLoggerInterceptor>();
            // build
            var container = builder.Build();

            // Start
            using var scope = container.BeginLifetimeScope();
            var app = scope.Resolve<Startup>();
            app.Start();
        }

        private static ILogger InitLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            return Log.Logger;
        }
    }
}
