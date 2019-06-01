
using CopaDoMundoDeFilmes.Core.Dominio.Interfaces;
using CopaDoMundoDeFilmes.Core.Dominio.Servicos;
using CopaDoMundoDeFilmes.Core.ServicoDeAplicacao.Interfaces;
using CopaDoMundoDeFilmes.Core.ServicoDeAplicacao.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace CopaDoMundoDeFilmes.CrossCutting.Inicializador
{
    public class InjecaoDeDependencia
    {

        public static void RegistrarServicos(IServiceCollection services)
        {
            // Dominio
            services.AddScoped<ICampeonato, Campeonato>();

            // Servicos De Aplicacao
            services.AddScoped<ICopaDeFilmes, CopaDeFilmes>();

        }
    }
}
