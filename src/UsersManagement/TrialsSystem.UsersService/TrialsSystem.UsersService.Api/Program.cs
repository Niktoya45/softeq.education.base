using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TrialsSystem.UsersService.Infrastructure;
using TrialsSystem.UsersService.Infrastructure.Repositories;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;


namespace TrialsSystem.UsersService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var assembly = Assembly.GetExecutingAssembly();

            builder.Services.AddControllers();

            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddValidatorsFromAssembly(assembly);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "TrialsSystem.UsersService", Version = "v1" }

                    );
                var xmlFilename = $"{assembly.GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            builder.Services.AddMediatR(assembly);
            builder.Services.AddAutoMapper(cfg => cfg.AddMaps(assembly));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddDbContext<ServiceDbContext>(cfg =>
                {
                    cfg.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbConnectionString"));
                    cfg.AddInterceptors(new EntityInterceptor());
                }
            );

            var app = builder.Build();

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