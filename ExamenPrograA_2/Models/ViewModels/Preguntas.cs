using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenPrograA_2.Models.ViewModels
{
    public class Preguntas
    {
        [Required]
        [Display(Name = "ID de Pregunta")]
        public int PreguntaID { get; set; }

        [Required]
        [Display(Name = "ID de Usuario")]
        public string UsuarioID { get; set; }

        [Required]
        [Display(Name = "Título de la pregunta")]
        [StringLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres.")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Descripción de la pregunta")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Fecha de la pregunta")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}