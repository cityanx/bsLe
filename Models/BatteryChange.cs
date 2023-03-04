using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bs.Models
{
    public class BatteryChange
    {

        [Key]
        public int BatteryChangeId { get; set; }

        // Clave foránea
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Agencia")]
        public int AgencyId { get; set; }

        [ForeignKey("AgencyId")]
        [Display(Name = "Agencia")]
        public Agency? Agency { get; set; }

        // Clave foránea
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "UPS")]
        public int UpsId { get; set; }

        [ForeignKey("UpsId")]
        [Display(Name = "UPS")]
        public Uninterruptible? Uninterruptible { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de cambio de baterías")]
        public DateTime BatteryChangeDate { get; set; }


        
        [Display(Name = "Comentarios")]
        [StringLength(300, ErrorMessage = "No debe tener mas de 250 caracteres.")]

        public string? BatteryChangeComments { get; set; }

        [Display(Name = "Módulos instalados")]
        [DataType(DataType.Text)]
        public int ModulesInst { get; set; }

        [Display(Name = "Baterías instaladas")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public int BatteriesInst { get; set; }


        [Display(Name = "Próximo cambio de baterías")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public DateTime BatteryChangeNext { get; set; }
    }
}
