﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class contextTienda : DbContext
    {
        public contextTienda()
            : base("name=contextTienda")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Paqueteria> Paqueteria { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<dirEntrega> dirEntrega { get; set; }
        public virtual DbSet<Orden_productos> Orden_productos { get; set; }
        public virtual DbSet<OrdenCliente> OrdenCliente { get; set; }
    }
}