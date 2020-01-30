using System;
using System.IO;
using Autofac;
using Autofac.Extension;
using Microsoft.Extensions.Configuration;

namespace AutofacApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * Autofac
             * https://autofaccn.readthedocs.io/en/latest/index.html
             */
            var builder = new ContainerBuilder();

            builder.AddConfigration(config => config
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true)
                    .AddEnvironmentVariables("APP_")
                    .AddCommandLine(args));
            builder.Configure<Configuration>();
            builder.AddJsonSerializer();

            var container = builder.Build();

            /*
             * Test
             */
            var serializer = container.Resolve<ISerialization>();
            var config = container.Resolve<Configuration>();
            Console.WriteLine(serializer.Serialize(config));
        }
    }
}
