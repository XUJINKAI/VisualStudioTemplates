using System;
using Microsoft.Extensions.Configuration;

namespace Autofac.Extension
{
    public static class ContainerBuilderExtension
    {
        public static void Configure<T>(this ContainerBuilder builder, Func<IConfigurationBuilder, IConfigurationBuilder> func) where T : class
        {
            var configBuilder = func(new ConfigurationBuilder()).Build();

            var config = Activator.CreateInstance<T>();
            configBuilder.Bind(config);

            builder.RegisterInstance(config)
                .SingleInstance()
                .ExternallyOwned();
            builder.RegisterInstance<IConfiguration>(configBuilder)
                .SingleInstance()
                .ExternallyOwned();
        }

        public static void AddJsonSerializer(this ContainerBuilder builder)
        {
            builder.RegisterType<JsonSerialization>().As<ISerialization>();
        }
    }
}
