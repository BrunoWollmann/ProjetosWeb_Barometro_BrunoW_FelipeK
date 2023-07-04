using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Barometro.Web.Filtros
{
    public class FiltroExcessao : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                Content = "Passou por aqui;",
            };
        }
    }
}
