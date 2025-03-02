using TrialsSystem.GatewayService.Api.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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

            builder.Services
                .ConfigureApplicationCookie(options =>
                {
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.SlidingExpiration = true;
                });

            builder.Services.AddAuthentication(options => {

                options.DefaultScheme = OpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
               
                })
                .AddCookie()
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = builder.Configuration.GetValue<string>("AuthProviders:jwt:issuer");
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = false,
                        AuthenticationType = "at+jwt",
                        SaveSigninToken = true,

                    };
                })
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    var oidc = builder.Configuration.GetSection("AuthProviders:oidc");
                    options.Authority = oidc.GetValue<string>("server");
                    options.RequireHttpsMetadata = false;

                    options.ClientId = oidc.GetValue<string>("clientId");
                    options.ClientSecret = oidc.GetValue<string>("secret");
                    options.ResponseType = OpenIdConnectResponseType.Code;
                    options.Scope.Add("profile");
                    options.UsePkce = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.SaveTokens = true;

                    options.DisableTelemetry = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateAudience = false,
                        ValidateIssuer = false,
                        AuthenticationType = "at+jwt",
                        SaveSigninToken = true,
                        NameClaimType = "name",
                        RoleClaimType = "role"

                    };
                    options.ClaimActions.MapJsonKey("role", "role");
                    options.MapInboundClaims = false;
                });

            builder.Services.AddAuthorization(options => {
                options.AddPolicy("Authenticated", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
            });

            var app = builder.Build();
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();
            app.UseCookiePolicy(new CookiePolicyOptions { 
                MinimumSameSitePolicy = SameSiteMode.Lax,
                Secure = CookieSecurePolicy.Always
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapRazorPages();

            app.Run();
        }
    }
}
