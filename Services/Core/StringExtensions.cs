using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Services.Core
{
    public static class StringExtensions
    {
        private static IConfiguration config;
        static StringExtensions()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            config = builder.Build();
        }

        public static String? GetConfigValue(this String key)
        {
            return config[key];
        }
    }
}
