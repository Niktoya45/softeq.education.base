using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using IdentityServer4.Services;
using TrialsSystem.IdentityService.Infrastructure;
using TrialsSystem.IdentityService.Infrastructure.AggregatesModel;
using TrialsSystem.IdentityService.Api.Profiles;
using FluentValidation;



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

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            string? dbconn_str = builder.Configuration.GetConnectionString("SqlServer")
                .Replace("(Project)", ApplicationUserDbContext.DefinedIn.Replace("Api", "Infrastructure"))
                .Replace("(CurrentUser)", Environment.UserName);

            builder.Services.ConfigureApplicationCookie(options => {
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

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
                    options.LoginPath = "/Home/Index";
                });

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
            .AddProfileService<ApplicationUserProfile>()
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
                    var google = builder.Configuration.GetSection("AuthProviders:google");

                    options.ClientId = google.GetValue<string>("clientId");
                    options.ClientSecret = google.GetValue<string>("secret");

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
            app.UseCookiePolicy(new CookiePolicyOptions { 
                MinimumSameSitePolicy = SameSiteMode.Lax,
                Secure = CookieSecurePolicy.Always
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.UseIdentityServer();
            app.InitializeDatabase();

            app.Run();
        }
    }
}
