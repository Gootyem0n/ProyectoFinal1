using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal1.Models;


namespace ProyectoFinal1.Controllers
{
    public class CatalogoController : Controller
    {
        private contextTienda db = new contextTienda();
        // GET: Catalogo
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult BuscaProd(string nomBuscar)
        //{
        //    ViewBag.SearchKey = nomBuscar;
        //    using (db)
        //    {
        //        var query = from st in db.producto
        //                    where st.nombre.Contains(nomBuscar)
        //                    select st;

        //        var listProd = query.ToList();
        //        ViewBag.Listado = listProd;
        //    }

            
            
        //}
    }
}