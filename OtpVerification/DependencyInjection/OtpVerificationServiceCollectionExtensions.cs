﻿using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Session;
using MyntraBacked.Options;
using MyntraBacked.otpVerification;

namespace OtpVerification.DependencyInjection
{
    public static class OtpVerificationServiceCollectionExtensions
    {
        public static IServiceCollection AddOtpVerification(this IServiceCollection services, Action<OtpVerificationOptions> options = default)
        {
            services.AddDataProtection();
            services.AddHttpContextAccessor();
            services.AddSingleton<IOtpVerification, OtpVerifications>();
            services.Configure(options ??= (o => { }));
            OtpVerificationOptions _options = new();
            options(_options);

            if (_options.IsInMemoryCache)
                return services.AddMemoryCache();

            return services.AddStackExchangeRedisCache(options => options.Configuration = "localhost");
        }
    }
    public static class EndpointRouteBuilderExtensions
    {
        public static void MapOtpVerification(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet($"/{nameof(OtpVerifications)}/{{*key}}",
               (string key) =>
               {
                   var otp = endpoints.ServiceProvider.GetRequiredService<IOtpVerification>();
                   if (otp.Scan(key))
                       return "Verify";
                   return "Un-Verify";
               });
        }
    }
}
