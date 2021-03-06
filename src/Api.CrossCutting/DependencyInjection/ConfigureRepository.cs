using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
  public class ConfigureRepository
  {
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
      serviceCollection.AddScoped<IUserRepository, UserImplementation>();
      serviceCollection.AddScoped<IStateRepository, StateImplementation>();
      serviceCollection.AddDistributedRedisCache(options =>
        {
          options.Configuration = Environment.GetEnvironmentVariable("REDIS_CONNECTION");
          options.InstanceName = Environment.GetEnvironmentVariable("INSTANCE_REDIS_NAME"); ;
        });
      if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "MYSQL".ToLower())
      {
        serviceCollection.AddDbContext<MyContext>(
                  options => options.UseMySql(Environment.GetEnvironmentVariable("MYSQL_DB_CONNECTION"))
        );
      }
      else
      {
        serviceCollection.AddDbContext<MyContext>(
                    options => options.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRE_DB_CONNECTION"))
        );
      }

    }
  }
}