using CopaDoMundoDeFilmes.Core.Dominio.Interfaces;
using CopaDoMundoDeFilmes.Core.Dominio.Servicos;
using CopaDoMundoDeFilmes.Core.ServicoDeAplicacao.Interfaces;
using CopaDoMundoDeFilmes.Core.ServicoDeAplicacao.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace CopaDoMundoDeFilmes.CrossCutting.Inicializador
{
    public static class InicializadorMiddlewareExtensions
    {

        public static IServiceCollection AddInicializador(this IServiceCollection services)
        {
            services.AddScoped<ICampeonato, Campeonato>();

            // Servicos De Aplicacao
            services.AddScoped<ICopaDeFilmes, CopaDeFilmes>();
            return services;
        }
    }
}
