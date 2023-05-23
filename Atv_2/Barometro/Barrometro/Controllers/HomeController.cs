using Barrometro.Web.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Diagnostics;

namespace Barrometro.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

         public IActionResult Privacy()
        {
            
            string dados = "";
            var temperaturas = GetTemperaturasFromDatabase();
            foreach (var item in temperaturas)
            {
                dados += $"['{item.Data_dado.ToString("dd/MM/yyyy")}', {item.Temp_max.ToString("0")}, {item.Temp_atual.ToString("0")}],";
            }
            dados = dados.Substring(0, dados.Length - 1);
            ViewBag.GraficoLinha = Funcoes.GerarGraficoTemperatura("Temperatura (ºC)", dados);

            string dadosHumidade = "";
            var resultadoHumidade = GetHumidadeFromDatabase();
            
            foreach (var item in resultadoHumidade)

            {
                dadosHumidade += $"['{item.Data_dado.ToString("dd/MM")}', {item.Hum_atual.ToString("0")}],";
            }
            
            ViewBag.GraficoHumidade = Funcoes.GerarGraficoHumidade("Humidade", dadosHumidade);

            return View();
        }


        public List<Temperaturas> GetTemperaturasFromDatabase()
        {
            var connectionString = "Server = localhost; Port = 5432; Database = barrometro; User Id = postgres; Password = 217799;";
            var temperaturasList = new List<Temperaturas>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand("SELECT id, local_temperatura, data_dado, temp_at, temp_min, tem_max FROM temperatura;", connection))
                {

                   using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var temperatura = new Temperaturas
                            {
                                IdTemperatura = reader.GetInt32(0),
                                Cidade = reader.GetString(1),
                                Data_dado = reader.GetDateTime(2),
                                Temp_atual = reader.GetDouble(3),
                                Temp_max = reader.GetDouble(5),
                                Temp_min = reader.GetDouble(4)
                            };

                            temperaturasList.Add(temperatura);
                        }
                    }
                }
            }
            // j
            return temperaturasList;
        }

            public List<Humidade> GetHumidadeFromDatabase()
            {
                var connectionString = "Server = localhost; Port = 5432; Database = barrometro; User Id = postgres; Password = 217799;";
                var humidadeList = new List<Humidade>();

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("SELECT id, local_humidade, data_dado, hum_at, hum_min, hum_max FROM humidade;", connection))
                    {

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var Humidades = new Humidade
                                {
                                    IdHumidade = reader.GetInt32(0),
                                    Cidade = reader.GetString(1),
                                    Data_dado = reader.GetDateTime(2),
                                    Hum_atual = reader.GetDouble(3),
                                    Hum_max = reader.GetDouble(5),
                                    Hum_min = reader.GetDouble(4)
                                };

                            humidadeList.Add(Humidades);
                            }
                        }
                    }
                }

                return humidadeList;
            }


            public IActionResult Index()
        {
            return View();
        }
    
    }
}