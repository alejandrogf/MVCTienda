using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTienda.Models;

namespace MVCTienda.Controllers
{
    public class ProductoAjaxController : Controller
    {
        //Conexión a la BD
        Tienda09Entities db = new Tienda09Entities();
        // GET: ProductoAjax
        public ActionResult Index()
        {
            return View(db.Producto);
        }
        [OutputCache(Duration = 0, VaryByParam = "*")]

        public ActionResult Buscar(string nombre)
        {
            var data = db.Producto.Where(o => o.Nombre.Contains(nombre));

            return PartialView("_listadoProducto", data);
        }

        [HttpPost]
        public ActionResult Alta(Producto modeloProducto)
        {
            db.Producto.Add(modeloProducto);
            db.SaveChanges();
            return Json(modeloProducto);
        }
    }
}