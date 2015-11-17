using System;
using System.Web.Mvc;

namespace MVCTienda.Filtros
{
    //Hereda de actionfilterattribute para que sea un atributo (lo que va ente corchetes) y 
    //que solo afecta a lo que va debajo escrito y asi poder aplicarlo sólo a lo que yo quiero, 
    //no a todas las operaciones
    public class FiltroId : ActionFilterAttribute
    {
        //FILTROS
        //fintercontext tiene toda la información relativa a la petición donde, cuando, etc
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //filterContext tiene varios metodos:
            //ActionParameters devuelve información del parámetro que se indica
            string id = null;
            try
            {
                id = filterContext.ActionParameters["id"].ToString();
            }
            catch (Exception)
            {
            }
            //ActionName contiene el nombre de la acción (el nombre del formulario en SAP)
            var peticion = filterContext.ActionDescriptor.ActionName;
            if (id == null && peticion != "Index")
            {
                filterContext.Result = new HttpStatusCodeResult(404); //EmptyResult();
            }
            //El ultimo paso es llamar al padre, pasando el filtercontext modificado.
            base.OnActionExecuting(filterContext);
        }
    }
}