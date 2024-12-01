using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenPrograA_2.Models.ViewModels
{
    public class CListaProductos
    {
        public int ProductoID   {get; set;}
        public string Nombre { get; set;}

        public string Descripcion { get; set;}

        public decimal Precio { get; set;}

        public int  Stock { get; set; }
    
    }
}