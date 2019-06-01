
using Microsoft.Extensions.DependencyInjection;

namespace CopaDoMundoDeFilmes.CrossCutting.Inicializador
{
    public class InjecaoDeDependencia
    {

        public static void RegisterServices(IServiceCollection services)
        {
            // Domain.Service
            //services.AddScoped<IUserService, UserService>();

            // Application
            //services.AddScoped<IUserAppService, UserAppService>();

        }
    }
}
