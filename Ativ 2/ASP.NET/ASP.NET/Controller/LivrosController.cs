using Microsoft.AspNetCore.Mvc;

public class LivrosController : Controller
{
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