using IdentityServer4;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using TrialsSystem.IdentityService.Infrastructure.AggregatesModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
            .AddEntityFrameworkStores<ApplicationUserDbContext>();
            
            builder.Services.AddIdentityServer()
            .AddInMemoryApiScopes(IdentityConfig.ApiScopes)
            .AddInMemoryIdentityResources(IdentityConfig.IdentityResources)
            .AddInMemoryClients(IdentityConfig.Clients)
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
                })
                
                .AddGoogle("Google", "Google", options =>
                {
                    var providerInfo = builder.Configuration.GetSection("AuthProviders:google");

                    options.ClientId = providerInfo.GetValue<string>("clientId");
                    options.ClientSecret = providerInfo.GetValue<string>("secret");

                });


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
