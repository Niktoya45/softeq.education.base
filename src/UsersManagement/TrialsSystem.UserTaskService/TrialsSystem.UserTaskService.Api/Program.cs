using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using TrialsSystem.UserTaskService.Api.Middlewares;

namespace TrialsSystem.UserTaskService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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