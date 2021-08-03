using Api.Data.Context;
using Api.Data.Context.Interfaces;
using Api.Domain.Interfaces.Services.Order;
using Api.Domain.Interfaces.Services.State;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Interfaces.Utils;
using Api.Service.Services;
using Api.Service.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
  public class ConfigureService
  {
    public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped<IHash, Hash>();
      serviceCollection.AddScoped<IRedis, Redis>();
      serviceCollection.AddScoped<IUserService, UserService>();
      serviceCollection.AddScoped<ILoginService, LoginService>();
      serviceCollection.AddScoped<IStateService, StateService>();
      serviceCollection.AddScoped<IRegisterService, RegisterService>();
      serviceCollection.AddScoped<IOrderService, OrderService>();
      serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
  }
}