using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoMVC.Models;

namespace demoMVC.Controllers
{
    public class ProductoController : Controller
    {


        private Tienda21Entities db = new Tienda21Entities();

        public ActionResult Index()
        {
            var data = db.Producto;
            return View(data);
        }


        public ActionResult Detalle(int id)
        {
            var data = db.Producto.Find(id);
            return View(data);
        }
        
        // GET: Producto
        public ActionResult Alta()
        {
            return View(new Producto()); // AQUI SE PASA UN OBJETO DE TIPO PRODUCTO HACIA EL HTML //
        }

        [HttpPost]
        public ActionResult Alta(Producto model)         // AQUÍ NO HAY SOBRECARGA DE MÉTODOS PORQUE EL PRIMER ACTIONRESULT ESTÁ EN GET Y ÉSTE EN POST //
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(model);
                db.SaveChanges();
                return View(new Producto());
            }

            return View(model);
        }

    }
}