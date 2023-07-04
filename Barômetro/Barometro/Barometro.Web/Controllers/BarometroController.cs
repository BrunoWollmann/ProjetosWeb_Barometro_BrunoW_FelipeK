using Barometro.Web.Factory;
using Barometro.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Barometro.Web.Filtros;
using Barometro.Web.API;

namespace Barometro.Web.Controllers
{
    
    public class BarometroController : Controller
    {
        private APIHttpClient httpClient;

        public BarometroController()
        {
            httpClient = new APIHttpClient(@"http://localhost:5267/api/");
        }
        public IActionResult Index()
        {
            var BarometrosModel = httpClient.Get<List<BarometroModel>>("Barometro");

            return View(BarometrosModel);
        }


        public IActionResult Inserir()
        {
           var categias = TEMPBarometroFactory.GeradorMoqTEMPBarometros(5);
            ViewBag.TEMPs = categias;
            return View();
        }

        [HttpPost]
        public IActionResult Gravar(BarometroModel Barometro)
        {
             BarometroAplicacao BarometroAplicacao = new BarometroAplicacao(); 


             decimal valor = 10;

            if (ModelState.IsValid)
             {

                 if (Barometro.HUMIDITY < valor)
                 {
                     ModelState.AddModelError("erroHumidade", "O HUMIDITY não pode ser menor que 30");
                     var categias = TEMPBarometroFactory.GeradorMoqTEMPBarometros(5);
                     ViewBag.TEMPs = categias;
                     return View("Inserir");
                 }

                 BarometroAplicacao.Inserir(new Dominio.Entidades.Barometro()
                 {
                     Id= Barometro.Id,
                     TEMPId = Barometro.TEMPId,
                     PRESSURE= Barometro.PRESSURE,
                     ALTITUDE = Barometro.ALTITUDE,
                     HUMIDITY= Barometro.HUMIDITY,
                     DATE = Barometro.DATE
                 });

                 
                 return RedirectToAction("Index");
             }
             else
             {
                 var categias = TEMPBarometroFactory.GeradorMoqTEMPBarometros(5);
                 ViewBag.TEMPs = categias;
                 return View("Inserir");
             }
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Alterar(BarometroModel Barometro)
        {
            BarometroAplicacao BarometroAplicacao = new BarometroAplicacao();

            decimal valor = 10;

            if (ModelState.IsValid)
            {

                if (Barometro.HUMIDITY < valor)
                {
                    ModelState.AddModelError("erroValor", "O HUMIDITY não pode ser menor que o valor");
                    var categias = TEMPBarometroFactory.GeradorMoqTEMPBarometros(5);
                    ViewBag.TEMPs = categias;
                    return View("Editar");
                }

                BarometroAplicacao.Alterar(new Dominio.Entidades.Barometro()
                {
                    Id = Barometro.Id,
                    TEMPId = Barometro.TEMPId,
                    PRESSURE = Barometro.PRESSURE,
                    ALTITUDE = Barometro.ALTITUDE,
                    HUMIDITY = Barometro.HUMIDITY,
                    DATE = Barometro.DATE
                });

                
                return RedirectToAction("Index");
            }
            else
            {
                var categias = TEMPBarometroFactory.GeradorMoqTEMPBarometros(5);
                ViewBag.TEMPs = categias;
                return View("Editar");
            }
            throw new NotImplementedException();
        }

        public IActionResult Excluir(Guid id)
        {
            BarometroAplicacao BarometroAplicacao = new BarometroAplicacao();
           
            BarometroAplicacao.Excluir(id);
            
            return RedirectToAction("Index");
            throw new NotImplementedException();
        }

        public IActionResult DiminuirValores(Guid id)
        {
            BarometroAplicacao BarometroAplicacao = new BarometroAplicacao();
            var prod = BarometroAplicacao.DiminuirValores(id);
            
            
            var BarometroRetorno = new BarometroModel()
            {
                Id = prod.Id,
                ALTITUDE = prod.ALTITUDE
            };

            return Json(BarometroRetorno);
            throw new NotImplementedException();
        }


        public IActionResult Editar(Guid id)
        {
             BarometroAplicacao BarometroAplicacao = new BarometroAplicacao();

             Barometro prod = BarometroAplicacao.SelecionarPorId(id);

            
             var Barometro = new BarometroModel()
             {
                 Id = prod.Id,
                 TEMPId = prod.TEMPId,
                 PRESSURE = prod.PRESSURE,
                 HUMIDITY = prod.HUMIDITY,
                 ALTITUDE = prod.ALTITUDE,
                 DATE = prod.DATE
             };

             ViewBag.Barometro = Barometro;
             ViewBag.TEMPs = TEMPBarometroFactory.GeradorMoqTEMPBarometros(5);
             return View();*/
            throw new NotImplementedException();
        }
    }
}
