using atv_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace atv_2.Controllers
{
    public class FuncionariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Listar()
        {
            ViewBag.Message = "Listar funcionario!";
            return View();
        }

        public ActionResult Gravar()
        {
            ViewBag.Message = "Gravar funcionario!";
            return View();
        }

        public ActionResult Excluir()
        {
            ViewBag.Message = "Excluir funcionario!";
            return View();
        }

        public ActionResult Procurar()
        {
            ViewBag.Message = "Procurar funcionario!";
            return View();
        }
    }
}