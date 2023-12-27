using BussinesLayer.AuthLogic.Abstracts;
using BussinesLayer.AuthLogic.Implements;
using CommonsLayer.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Infrastructure.Helpers
{
    public static class ServiceExtension
    {
        public static void AddCorsService(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAnyOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });
        }
        public static void AddJsonTokenProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();
            services.Configure<JwtTokenProviderOptions>(configuration.GetSection("JwtToken"));
        }

        public static void AddAuthenticationService(this IServiceCollection services, IConfiguration configuration)
        {
            var bataApiSecrectKey = configuration.GetSection("JwtToken:SecretKey").Value;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(bataApiSecrectKey))
                };
            });
        }
    }
}
