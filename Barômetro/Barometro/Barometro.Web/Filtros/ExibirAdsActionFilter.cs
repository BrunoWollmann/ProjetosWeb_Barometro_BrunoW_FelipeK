using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Barometro.Web.Filtros
{
    public class ExibirAdsActionFilter : IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller is Controller controller)
                controller.ViewBag.ConteudoAd = GerarConteudoAD();
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            AtualizarExibicaoAD();
        }

        private string GerarConteudoAD()
	    {
	        return "<hr/><h2>Propaganda Aqui!<h2 /><hr/>";
	    }

        private void AtualizarExibicaoAD()
        {
            GerarConteudoAD();
        }
    }
}
