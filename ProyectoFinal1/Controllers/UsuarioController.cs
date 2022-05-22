using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal1.Models;

namespace ProyectoFinal1.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private contextTienda db = new contextTienda();
        // GET: Usuario
        public ActionResult Index(string email)
        {
            if (User.Identity.IsAuthenticated)
            {
                string correo = email;
                string rol = "";

                using (db)
                {
                    var query = from st in db.Empleado
                                where st.Email == correo
                                select st;
                    var lista = query.ToList();
                    if (lista.Count > 0)
                    {
                        var empleado = query.FirstOrDefault<Empleado>();
                        string[] nombres = empleado.Nombre.ToString().Split(' ');
                        Session["name"] = nombres[0];
                        Session["usr"] = empleado.Nombre;
                        rol = empleado.Rol.ToString().TrimEnd();


                    }
                    else
                    {
                        var query1 = from st in db.Clientes
                                     where st.email == correo
                                     select st;
                        var lista1 = query.ToList();
                        if (lista1.Count > 0)
                        {
                            var cliente = query1.FirstOrDefault<Clientes>();
                            string[] nombres = cliente.nombre.ToString().Split(' ');
                            Session["name"] = nombres[0];
                            Session["usr"] = cliente.nombre;
                            rol = "cliente";

                        }
                    }

                    if (rol == "comprador")
                    {
                        return RedirectToAction("Index", "Compras");
                    }

                    if (rol == "chateador")
                    {
                        return RedirectToAction("Index", "Chat");
                    }

                    if (rol == "cliente")
                    {
                        return RedirectToAction("Contact", "Home");
                    }
                    if (rol == "admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return RedirectToAction("Contact", "Home");

                }
            }

            return View();
        }
    }
}