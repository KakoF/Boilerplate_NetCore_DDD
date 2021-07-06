using Api.Data.Context;
using Api.Data.Context.Interfaces;
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
            serviceCollection.AddTransient<IHash, Hash>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IStateService, StateService>();
            serviceCollection.AddTransient<IRegisterService, RegisterService>();
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}