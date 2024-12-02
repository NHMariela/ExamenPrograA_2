using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenPrograA_2.Models.ViewModels
{

    public class Usuario
    {
        [Key]
        public string UsuarioID { get; set; }

        [Required]
        [StringLength(150)]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(50)]
        public string Rol { get; set; }
    }

}