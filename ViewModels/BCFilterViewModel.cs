
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bs.Models.ViewModels
{
    public class BCFilterViewModel
    {

        public IEnumerable<BatteryChange> BatteryChanges { get; set; }
        public string SearchString { get; set; }
        public string Filter { get; set; }
        public List<SelectListItem> Columns { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "agency", Text = "Agencia" },
            new SelectListItem { Value = "location", Text = "Localidad" },
            new SelectListItem { Value = "year", Text = "Año del cambio" },
            new SelectListItem { Value = "nextyear", Text = "Año del próximo cambio" },
        };
    }
}
