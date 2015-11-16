using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTienda.Models;

namespace MVCTienda.Controllers
{
    public class AlmacenController : Controller
    {
        //Conexión a la BD
        private Tienda09Entities db = new Tienda09Entities();

        //Las acciones a realizar, si no se indican una instruccion
        //HTTPPOST u otra, siempre las toma como de tipo GET.

        // GET: Almacen
        public ActionResult Index()
        {
            var data = db.Almacen;
            return View(data);
        }

        public ActionResult Detalle(int id)
        {
            var data = db.Almacen.Find(id);
            return View(data);
        }

        //Si no se usa AJAX, el modificar se hace en dos pasos. Por eso hay dos instrucciones.
        public ActionResult Modificar(int id)
        {
            var data = db.Almacen.Find(id);
            return View(data);
        }

        [HttpPost]
        //Esta linea es para añadir un sistema de seguridad (tipo captcha pero invisible)
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(Almacen objetoAlmacen)
        {
            if (ModelState.IsValid)
            {
                //Al indicar que el estado del objeto es modificado, el programa por si solo
                //ya sabe que hacer, buscando el objeto que coincida con los datos que tiene
                //y actualiza el solo. Otra opción sería actualizar a mano, campo a campo.
                //En este caso no hay problema porque es poco, pero con una tabla de 200 campos
                //es un horror.
                db.Entry(objetoAlmacen).State=EntityState.Modified;
                db.SaveChanges();
                //Con esto se redirige a la acción que queremos que se lleve a cabo.
                return RedirectToAction("Index");
            }
            return View(objetoAlmacen);
        }

        public ActionResult Borrar(int id)
        {
            var data = db.Almacen.Find(id);
            if (data.AlmacenProducto.Any())
            {
                db.AlmacenProducto.RemoveRange(data.AlmacenProducto);
            }

            db.Almacen.Remove(data);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}