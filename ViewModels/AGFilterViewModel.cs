using bs.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bs.ViewModels
{
    public class AGFilterViewModel
    {
        public IEnumerable<Agency> Agencies { get; set; }
        public string SearchString { get; set; }
        public string Filter { get; set; }
        public List<SelectListItem> Columns { get; } = new List<SelectListItem>
        {

            new SelectListItem { Value = "location", Text = "Localidad" },
            new SelectListItem { Value = "type", Text = "Tipo" },

        };
    }
}
