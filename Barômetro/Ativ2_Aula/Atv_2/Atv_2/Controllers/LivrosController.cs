using atv_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace atv_2.Controllers
{
    public class LivrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Listar()
        {
            ViewBag.Message = "Listar Livros!";
            return View();
        }

        public ActionResult Gravar()
        {
            ViewBag.Message = "Gravar Livros!";
            return View();
        }

        public ActionResult Excluir()
        {
            ViewBag.Message = "Excluir Livros!";
            return View();
        }

        public ActionResult Procurar()
        {
            ViewBag.Message = "Procurar Livros!";
            return View();
        }
    }
}