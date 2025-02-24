using TrialsSystem.GatewayService.Api.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using Microsoft.CodeAnalysis.Elfie.Extensions;

namespace TrialsSystem.GatewayService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Add services to the container.

            builder.Services.AddRazorPages();

            builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
            builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            builder.Services.AddCors(options => 
                options.AddDefaultPolicy(policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    }
                )
            );

            builder.Services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = builder.Configuration.GetSection("AuthProviders:jwt").GetValue<string>("server");
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateAudience = false,
                        ValidateIssuer = false,
                        AuthenticationType = "at+jwt",
                        SaveSigninToken = true,

                    };
                });

            builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, TestAuthorizationMiddlewareResultHandler>();
            builder.Services.AddAuthorization();

            var app = builder.Build();
           
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();
            app.MapRazorPages();

            app.Run();
        }
    }
}
