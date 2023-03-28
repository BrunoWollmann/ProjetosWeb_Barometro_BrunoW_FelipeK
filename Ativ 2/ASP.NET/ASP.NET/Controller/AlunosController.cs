using Microsoft.AspNetCore.Mvc;

public class AlunosController : Controller
{

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