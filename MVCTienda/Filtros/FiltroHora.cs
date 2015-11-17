using System;
using System.Web.Mvc;

namespace MVCTienda.Filtros
{
    //Los filtros, si quieres que afecte a todas las acciones de un controller, 
    //hay que definirlo en el propio controller.
    //Si quieres tener filtros de autenticación, por ejemplo, 
    //se define una clase BaseFiltro, de la que heredan todos los controllers
    public class FiltroHora:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var hora = DateTime.Now;
            if (hora.Minute < 30 || hora.Minute > 35)
            {
                filterContext.Result = 
                    new HttpUnauthorizedResult("Servicio no disponible en este momento, fistrorrrrll!!");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
