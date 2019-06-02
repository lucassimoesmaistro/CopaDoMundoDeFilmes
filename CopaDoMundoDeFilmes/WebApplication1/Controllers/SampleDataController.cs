using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

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


        [HttpGet("[action]")]
        public void GerarCampeonato(IEnumerable<Filme> filmes)
        {
            string BaseUrl = @"http://localhost:52858";
            var selecionados = filmes;
            //using (HttpClient cliente = new HttpClient())
            //{
            //    List<Filme> filmes = new List<Filme>();

            //    cliente.BaseAddress = new Uri(BaseUrl);

            //    //definindo o formato dos dados no request
            //    MediaTypeWithQualityHeaderValue contentType = new
            //        MediaTypeWithQualityHeaderValue("application/json");

            //    cliente.DefaultRequestHeaders.Accept.Add(contentType);

            //    HttpResponseMessage response = cliente.GetAsync("/api/CopaDeFilmes/obterFilmes").Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var retorno = response.Content.ReadAsStringAsync().Result;
            //        filmes = JsonConvert.DeserializeObject<List<Filme>>(retorno);
            //    }

            //    return filmes;
            //}
        }
        

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
        public class Filme
        {
            public string Id { get; set; }
            public string Titulo { get; set; }
            public int Ano { get; set; }
            public decimal Nota { get; set; }

        }
    }
}
