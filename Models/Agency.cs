using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bs.Models
{
    public class Agency
    {
        public Agency()
        {
            Uninterruptible = new HashSet<Uninterruptible>();
        }
        [Key]
        [Range(1, 500, ErrorMessage = "El valor excede el límite.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "No es un número válido")]
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [DataType(DataType.Text)]
        [Display(Name = "Código de agencia")]
        public int AgencyId { get; set; }


        // Clave foránea
        [Display(Name = "Localidad")]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        [Display(Name = "Localidad")]
        public Location? Location { get; set; }



        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Nombre de agencia")]
        public string? AgencyName { get; set; }

        [Display(Name = "Tipo")]
        public string? AgencyType { get; set; }




        



        public ICollection<Uninterruptible> Uninterruptible { get; set; }


    }
}
