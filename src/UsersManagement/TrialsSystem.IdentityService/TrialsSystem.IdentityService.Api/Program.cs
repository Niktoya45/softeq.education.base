using IdentityServer4;
using Microsoft.EntityFrameworkCore;
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

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
