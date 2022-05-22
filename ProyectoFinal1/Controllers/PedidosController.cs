using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal1.Models;

namespace ProyectoFinal1.Controllers
{
    //[Authorize]
    public class PedidosController : Controller
    {
        contextTienda db = new contextTienda();
        // GET: Pedidos
        public ActionResult Index()
        {
            string correo = User.Identity.Name;
            Clientes cl=(from c in db.Clientes
             where c.email == correo
             select c).ToList().FirstOrDefault();

            int id = cl.id_cliente;

            var query = from o in db.OrdenCliente
                        where o.id_cliente == id
                        orderby o.fecha_creacion ascending
                        select o;

            List<OrdenCliente> ordenes = query.ToList();

            //List<PedidoCliente> pedidos = new List<PedidoCliente>();
            //PedidoCliente pedido;
            //List<orden_productos>
           
            return View();
        }
    }
}