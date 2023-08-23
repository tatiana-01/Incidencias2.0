using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.UnitOfwork;
using AspNetCoreRateLimit;
using Dominio.Interfaces;
using iText.Kernel.XMP.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace ApiIncidencias.Extensiones;
    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(Options => 
        {
            Options.AddPolicy("CorsPolicy" , builder =>
             builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());
        });
        public static void AddApplicationServices(this IServiceCollection services){
        services.AddScoped < IUnitOfWork,UnitOfWork > ();
        }
        public static void ConfigureRateLimiting(this IServiceCollection services){
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options=>{
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Period = "10s",
                        Limit = 2

                    }
                };
            });
        }

        public static void ConfigureApiVersioning(this IServiceCollection services){
            services.AddApiVersioning(options =>{
                options.DefaultApiVersion = new ApiVersion(1,0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("ver"),
                    new HeaderApiVersionReader("X-version")
                );
                options.ReportApiVersions = true;
            });
        }
    }

