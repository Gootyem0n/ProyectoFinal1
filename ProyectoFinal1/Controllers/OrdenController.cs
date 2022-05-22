using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal1.Models;

namespace ProyectoFinal1.Controllers
{
    public class OrdenController : Controller
    {
        private contextTienda db = new contextTienda();

        // GET: Orden
        public ActionResult Index()
        {
            var orden_productos = db.Orden_productos.Include(o => o.producto);
            return View(orden_productos.ToList());
        }

        public ActionResult Index1()
        {
            var orden_productos = db.Orden_productos.Include(o => o.producto);
            return View(orden_productos.ToList());
        }

        // GET: Orden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden_productos orden_productos = db.Orden_productos.Find(id);
            if (orden_productos == null)
            {
                return HttpNotFound();
            }
            return View(orden_productos);
        }

        // GET: Orden/Create
        public ActionResult Create()
        {
            ViewBag.Id_producto = new SelectList(db.producto, "Id_producto", "nombre");
            return View();
        }

        // POST: Orden/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Orden_Producto,Id_producto,cantidad")] Orden_productos orden_productos)
        {
            if (ModelState.IsValid)
            {
                db.Orden_productos.Add(orden_productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_producto = new SelectList(db.producto, "Id_producto", "nombre", orden_productos.Id_producto);
            return View(orden_productos);
        }

        // GET: Orden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden_productos orden_productos = db.Orden_productos.Find(id);
            if (orden_productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_producto = new SelectList(db.producto, "Id_producto", "nombre", orden_productos.Id_producto);
            return View(orden_productos);
        }

        // POST: Orden/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Orden_Producto,Id_producto,cantidad")] Orden_productos orden_productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden_productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_producto = new SelectList(db.producto, "Id_producto", "nombre", orden_productos.Id_producto);
            return View(orden_productos);
        }

        // GET: Orden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden_productos orden_productos = db.Orden_productos.Find(id);
            if (orden_productos == null)
            {
                return HttpNotFound();
            }
            return View(orden_productos);
        }

        // POST: Orden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orden_productos orden_productos = db.Orden_productos.Find(id);
            db.Orden_productos.Remove(orden_productos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
