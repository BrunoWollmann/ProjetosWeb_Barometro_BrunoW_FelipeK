using atv_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace atv_2.Controllers
{
    public class AlunosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Listar()
        {
            ViewBag.Message = "Listar Alunos!";
            return View();
        }

        public ActionResult Gravar()
        {
            ViewBag.Message = "Gravar Alunos!";
            return View();
        }

        public ActionResult Excluir()
        {
            ViewBag.Message = "Excluir Alunos!";
            return View();
        }

        public ActionResult Procurar()
        {
            ViewBag.Message = "Procurar Alunos!";
            return View();
        }
    }
}