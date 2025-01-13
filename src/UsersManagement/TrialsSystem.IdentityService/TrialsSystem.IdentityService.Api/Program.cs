using IdentityServer4;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace TrialsSystem.IdentityService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
            builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            string? dbconn_str = builder.Configuration.GetConnectionString("SqlServer");
            builder.Services.AddIdentityServer()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = ctxb =>
                    ctxb.UseSqlServer(dbconn_str,
                       sql => sql.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
            })
            .AddOperationalStore(options => {
                options.ConfigureDbContext = ctxb =>
                   ctxb.UseSqlServer(dbconn_str,
                      sql => sql.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
            })
            .AddDeveloperSigningCredential();

            builder.Services.AddAuthentication()

                .AddOpenIdConnect("oidc", "OIDC", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.SignOutScheme = IdentityServerConstants.SignoutScheme;
                    options.SaveTokens = true;

                    var providerInfo = builder.Configuration.GetSection("AuthProviders:oidc");

                    options.Authority = providerInfo.GetValue<string>("server");
                    options.ClientId  = providerInfo.GetValue<string>("clientId");
                    options.ClientSecret = providerInfo.GetValue<string>("secret");

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                })
                
                .AddGoogle("Google", "Google", options =>
                {
                    var providerInfo = builder.Configuration.GetSection("AuthProviders:google");

                    options.ClientId = providerInfo.GetValue<string>("clientId");
                    options.ClientSecret = providerInfo.GetValue<string>("secret");

                });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<IdentityRole>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}
