using System.ComponentModel.DataAnnotations;

namespace ExamenPrograA_2.Models.ViewModels
{
    public class EditMaquinaria
    {
        [Required]
        [Display(Name = "ID Maquinaria")]
        public int MaquinariaID { get; set; }

        [Required]
        [Display(Name = "Nombre de Maquinaria")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion de Maquinaria")]
        public string Descripcion { get; set; }

        [Display(Name = "Marca de Maquinaria")]
        public string Marca { get; set; }

        [Display(Name = "Modelo de Maquinaria")]
        public string Modelo { get; set; }

    }
}