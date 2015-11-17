using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTienda.Filtros;
using MVCTienda.Models;

namespace MVCTienda.Controllers
{
    public class EtiquetaController : Controller
    {
        //Conexión a la BD
        Tienda09Entities db = new Tienda09Entities();

        // GET: Etiqueta
        [FiltroHora]
        public ActionResult Index()
        {
            ViewData["Titulo"] = "Listado de Etiquetas";
            ViewBag.Almacen = db.Almacen;
            var data = db.Etiqueta;
            return View(data);

        }
    }
}