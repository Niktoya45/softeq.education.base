using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using AutoMapper.Internal;
using IdentityServer4.EntityFramework.Mappers;
using System.Reflection;

namespace TrialsSystem.IdentityService.Infrastructure
{
    public static class InitializeData
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.EnsureCreated();

                using (var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>())
                {
                    context.Database.EnsureCreated();

                    if (!context.Clients.Any())
                    {
                        foreach (var client in IdentityConfig.Clients)
                        {
                            context.Clients.Add(client.ToEntity());
                        }
                        context.SaveChanges();
                    }

                    if (!context.IdentityResources.Any())
                    {
                        foreach (var resource in IdentityConfig.IdentityResources)
                        {
                            context.IdentityResources.Add(resource.ToEntity());
                        }
                        context.SaveChanges();
                    }

                    if (!context.ApiScopes.Any())
                    {
                        foreach (var scope in IdentityConfig.ApiScopes)
                        {
                            context.ApiScopes.Add(scope.ToEntity());
                        }
                        context.SaveChanges();
                    }
                }
            }
        }

        private static void OverrideIdentityMapper(Type mapperExtensionClass, Type mapperProfileClass)
        {
            IMapper mapper = new MapperConfiguration(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.AddProfile(mapperProfileClass);
                cfg.Internal().MethodMappingEnabled = false;

            }).CreateMapper();

            mapperExtensionClass.GetField("<Mapper>k__BackingField", BindingFlags.Static | BindingFlags.NonPublic)!.SetValue(null, mapper);
        }
    }
}
