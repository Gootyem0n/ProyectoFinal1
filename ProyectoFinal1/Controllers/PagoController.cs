using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal1.Models;

namespace ProyectoFinal1.Controllers
{
    public class PagoController : Controller
    {
        private contextTienda db = new contextTienda();
        private string NumConfirPago;
        
        // GET: Pago
        public ActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult CrearOrden()
        {
            if (User.Identity.IsAuthenticated)
            {
                Session["CrearOrden"] = "pend";
                return RedirectToAction("Login", "Account");

            }

            string correo = User.Identity.Name;

            string fechaCreacion = DateTime.Today.ToShortDateString();
            string fechaProbEntrega = DateTime.Today.AddDays(3).ToShortDateString();

            var cliente = (from c in db.Clientes
                           where c.email == correo
                           select c).ToList().FirstOrDefault();

            Session["dirCliente"] = cliente.calle + " " + cliente.colonia + " "+ cliente.estado;
            Session["fechaOrden"] = fechaCreacion;
            Session["fPEntreg"] = fechaProbEntrega;

            //CAMBIAR LA BASE DE DATOS DE INT A STRING
            //if (cliente.num_tarjeta_credito.StartsWith("4"))
            //    Session["tTarj"] = "1";
            //if (cliente.num_tarjeta _credito.StartsWith("5"))
            //    Session["tTarj"] = "2";
            //if (cliente.num_tarjeta _credito.StartsWith("3"))
            //    Session["tTarj"] = "3";
            //Session["tTarj"] = cliente.num_tarjeta_credito;

            return View();
        }

        public ActionResult Pagar(string tipoPago)
        {
            string correo = User.Identity.Name;

            string fechaCreacion = DateTime.Today.ToShortDateString();
            string fechaProbEntrega = DateTime.Today.AddDays(3).ToShortDateString();

            var cliente = (from c in db.Clientes
                           where c.email == correo
                           select c).ToList().FirstOrDefault();

            if (tipoPago.Equals("T"))
            {
                if (!validaPago(cliente))
                {
                    return RedirectToAction("pagoNoAceptado");
                }
                else
                {
                    var dirEnt = (from d in db.dirEntrega
                                  where d.id_cliente == cliente.id_cliente
                                  select d).ToList().FirstOrDefault();

                    int idDir = dirEnt.Id_dirEntrega;
                    return RedirectToAction("pagoAcepatado", routeValues: new { idC });
                }
            }

            return View();
        }
}