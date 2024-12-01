using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenPrograA_2.Models.ViewModels
{
    public class CProducto
    {
        [Display(Name = " ID Producto")]
        public int ProductoID { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion Producto")]
        public string Descripcion { get; set; }

        [Display(Name = "Precio Producto")]
        public decimal Precio { get; set; }

        [Display(Name = "Cantidad Producto")]
        public int Stock { get; set; }

    }
}