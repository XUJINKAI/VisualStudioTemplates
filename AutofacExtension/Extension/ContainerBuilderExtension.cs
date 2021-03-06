﻿using System;
using Microsoft.Extensions.Configuration;

namespace Autofac.Extension
{
    public static class ContainerBuilderExtension
    {
        public static IConfiguration AddConfigration(this ContainerBuilder builder, Func<IConfigurationBuilder, IConfigurationBuilder> @delegate)
        {
            if (@delegate == null) throw new ArgumentNullException();

            var configBuilder = @delegate(new ConfigurationBuilder()).Build();

            builder.RegisterInstance<IConfiguration>(configBuilder)
                .SingleInstance()
                .ExternallyOwned();

            return configBuilder;
        }

        public static T Configure<T>(this ContainerBuilder builder, Func<IConfiguration, IConfiguration> @delegate = null) where T : class
        {
            var option = Activator.CreateInstance<T>();

            builder.Register(c =>
                {
                    var iconfig = c.Resolve<IConfiguration>();
                    (@delegate == null ? iconfig : @delegate(iconfig)).Bind(option);
                    return option;
                })
                .SingleInstance()
                .ExternallyOwned();

            return option;
        }

        public static void AddJsonSerializer(this ContainerBuilder builder)
        {
            builder.RegisterType<JsonSerializer>()
                .As<IJsonSerializer>();
        }
    }
}
