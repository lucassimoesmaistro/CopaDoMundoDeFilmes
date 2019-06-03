using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        [HttpGet("[action]")]
        public IEnumerable<Filme> ObterFilmes()
        {
            string BaseUrl = @"http://localhost:52858";
            using (HttpClient cliente = new HttpClient())
            {
                List<Filme> filmes = new List<Filme>();

                cliente.BaseAddress = new Uri(BaseUrl);

                //definindo o formato dos dados no request
                MediaTypeWithQualityHeaderValue contentType = new
                    MediaTypeWithQualityHeaderValue("application/json");

                cliente.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = cliente.GetAsync("/api/CopaDeFilmes/obterFilmes").Result;
                if (response.IsSuccessStatusCode)
                {
                    var retorno = response.Content.ReadAsStringAsync().Result;
                    filmes = JsonConvert.DeserializeObject<List<Filme>>(retorno);
                }

                return filmes;
            }
        }


        [HttpPost("[action]")]
        public async Task<ResultadoFinal> GerarCampeonato([FromBody]Filme[] filmes)
        {
            string BaseUrl = @"http://localhost:52858";

            using (HttpClient cliente = new HttpClient())
            {
               
                cliente.BaseAddress = new Uri(BaseUrl);

                //definindo o formato dos dados no request
                MediaTypeWithQualityHeaderValue contentType = new
                    MediaTypeWithQualityHeaderValue("application/json");

                cliente.DefaultRequestHeaders.Accept.Add(contentType);
                var teste = JsonConvert.SerializeObject(filmes);
                var content = new StringContent(teste, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.PostAsync("/api/CopaDeFilmes/gerar", content);
                ResultadoFinal resultadoFinal = new ResultadoFinal();
                if (response.IsSuccessStatusCode)
                {
                    var retorno = response.Content.ReadAsStringAsync().Result;
                    resultadoFinal = JsonConvert.DeserializeObject<ResultadoFinal>(retorno);
                }

                return resultadoFinal;
            }
        }

        public class Filme
        {
            public string Id { get; set; }
            public string Titulo { get; set; }
            public int Ano { get; set; }
            public decimal Nota { get; set; }
        }
        public class ResultadoFinal
        {
            public Filme Campeao { get; set; }

            public Filme ViceCampeao { get; set; }
        }
    }
}
