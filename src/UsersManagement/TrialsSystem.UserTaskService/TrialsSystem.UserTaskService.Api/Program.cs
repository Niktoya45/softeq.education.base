using System.Reflection;
using MediatR;
using Microsoft.OpenApi.Models;
using TrialsSystem.UserTaskService.Api.Middlewares;
using TrialsSystem.UserTaskService.Infrastructure.Context;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.Implementations;

namespace TrialsSystem.UserTaskService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Add services to the container.

            builder.Services.AddControllers();


            //   [] - add validation vv

            //   builder.Services.AddFluentValidationAutoValidation();
            //   builder.Services.AddValidatorsFromAssemblyContaining<TypeValidator>();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "TrialsSystem.UserTaskService", Version = "v1" }

                    );
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

            builder.Services.AddSingleton(builder.Configuration.GetSection("mongodb").Get<DbContextConfig>()
                ?? throw new Exception("Missing section: \"mongdodb\" in app configuration file."));

            builder.Services.AddDbContext<UserTaskDbContext>();
            builder.Services.AddScoped<IUserTaskRepository, UserTaskRepository>();
            builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
            builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            var app = builder.Build();

            
            app.UseMiddleware<ExceptionUserTaskMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}