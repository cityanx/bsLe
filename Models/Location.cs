using System.ComponentModel.DataAnnotations;

namespace bs.Models
{
    public class Location
    {
        [Key]
        [Display(Name = "Localidad")]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Departamento")]
        public string? DepartamentName { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Municipio")]
        public string? TownName { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Localidad")]
        public string? Locations { get; set; }



        public IEnumerable<Agency>? Agencies { get; set; }


    }
}
