//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Orden_productos
    {
        public int Id_Orden_Producto { get; set; }
        public Nullable<int> Id_producto { get; set; }
        public string cantidad { get; set; }
    
        public virtual producto producto { get; set; }
    }
}
