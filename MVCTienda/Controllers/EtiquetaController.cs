using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTienda.Models;

namespace MVCTienda.Controllers
{
    public class EtiquetaController : Controller
    {
        //Conexión a la BD
        private Tienda09Entities db = new Tienda09Entities();

        // GET: Etiqueta
        public ActionResult Index()
        {
            //var info = db.Etiqueta;
            //ViewBag.etiquetas = info.ToList();
            ViewData["Titulo"] = "Listado de Etiquetas";
            var data = db.Etiqueta;
            return View(data);

        }
    }
}