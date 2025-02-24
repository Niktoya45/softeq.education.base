using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrialsSystem.IdentityService.Infrastructure;
using TrialsSystem.IdentityService.Infrastructure.AggregatesModel;

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

            string? dbconn_str = builder.Configuration.GetConnectionString("SqlServer")
                .Replace("(Project)", ApplicationUserDbContext.DefinedIn.Replace("Api", "Infrastructure"))
                .Replace("(CurrentUser)", Environment.UserName);

            builder.Services.AddDbContext<ApplicationUserDbContext>(options =>
            {
                options.UseSqlServer(dbconn_str);
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationUserDbContext>()
            .AddDefaultTokenProviders();
            
            builder.Services.AddIdentityServer()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = ctxb =>
                    ctxb.UseSqlServer(dbconn_str,
                       sql => sql.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName.Replace("Api", "Infrastructure")));
            })
            .AddOperationalStore(options => {
                options.ConfigureDbContext = ctxb =>
                   ctxb.UseSqlServer(dbconn_str,
                      sql => sql.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName.Replace("Api", "Infrastructure")));
            })
            .AddAspNetIdentity<ApplicationUser>()
            .AddDeveloperSigningCredential();

            builder.Services.AddAuthentication()

                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = builder.Configuration.GetSection("AuthProviders:jwt").GetValue<string>("server");
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

                .AddGoogle("Google", "Google", options =>
                {
                    var providerInfo = builder.Configuration.GetSection("AuthProviders:google");

                    options.ClientId = providerInfo.GetValue<string>("clientId");
                    options.ClientSecret = providerInfo.GetValue<string>("secret");

                });

            builder.Services.AddAuthorization();

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

            app.UseCors();
            app.UseIdentityServer();

            app.UseAuthentication();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.InitializeDatabase();

            app.Run();
        }
    }
}
