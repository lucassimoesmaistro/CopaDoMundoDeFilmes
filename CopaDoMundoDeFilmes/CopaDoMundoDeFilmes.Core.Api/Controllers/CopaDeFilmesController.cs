using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaDoMundoDeFilmes.Core.Dominio.Interfaces;
using CopaDoMundoDeFilmes.Core.Dominio.Modelos;
using CopaDoMundoDeFilmes.Core.Dominio.ObjetosDeValor;
using CopaDoMundoDeFilmes.Core.ServicoDeAplicacao.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CopaDoMundoDeFilmes.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopaDeFilmesController : ControllerBase
    {
        private readonly ICampeonato _campeonato;
        private readonly ICopaDeFilmes _servicoCopaDeFilmes;
        public CopaDeFilmesController(ICampeonato campeonato, ICopaDeFilmes servicoCopaDeFilmes)
        {
            _campeonato = campeonato;
            _servicoCopaDeFilmes = servicoCopaDeFilmes;
        }

        [HttpGet("obterFilmes")]
        public IEnumerable<Filme> Get()
        {
            return _servicoCopaDeFilmes.ObterFilmes();
        }

        [HttpPost("gerar")]
        public ResultadoFinal Post([FromBody] IEnumerable<Filme> filmesSelecionados)
        {
            return _campeonato.GerarCampeonato(filmesSelecionados.ToList());
        }
    }
}
