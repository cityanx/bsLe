using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bs.Models
{
    public class Uninterruptible
    {
        [Key]
        public int UpsId { get; set; }



        // Clave foránea
        [Display(Name = "Agencia")]
        public int AgencyId { get; set; }

        [ForeignKey("AgencyId")]
        [Display(Name = "Agencia")]
        public Agency? Agency { get; set; }

        



        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Nombre del UPS")]
        public string? UpsName { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Modelo del UPS")]
        public string? UpsModel { get; set; }

        

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "KVA")]
        public float UpsPower { get; set; }

        
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "UPS Administrable")]
        public bool UpsManageable { get; set; }


        [Range(0, 100, ErrorMessage = "El valor debe ser de excede el límite.")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "No es un número válido")]
        
        [DataType(DataType.Text)]
        [Display(Name = "Módulos que acepta")]
        public int UpsModules { get; set; }

        [Display(Name = "Baterías que acepta")]

        [Range(0, 300, ErrorMessage = "El valor debe ser de excede el límite.")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "No es un número válido")]


        
        [DataType(DataType.Text)]
        public int UpsBatteries { get; set; }

        
       


        public IEnumerable<BatteryChange>? BatteryChanges { get; set; }

    }
}
