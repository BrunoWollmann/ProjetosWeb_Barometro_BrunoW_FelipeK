using Microsoft.AspNetCore.Mvc;

public class FuncionariosController : Controller
{
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