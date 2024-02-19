using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebAppMVCComboCascadeEF.Models
{
    // https://www.aspsnippets.com/Articles/3067/Cascading-Dependent-DropDownList-in-ASPNet-MVC/
    public class CascadingModel
    {
        public CascadingModel()
        {
            // COUNTRY === REGIONE
            // STATES === PROVINCIA
            // CITIES === COMUNI
            this.comboListRegioni = new List<SelectListItem>();
            this.comboListaProvince = new List<SelectListItem>();
            this.comboListaComuni = new List<SelectListItem>();
        }

        public List<SelectListItem> comboListRegioni { get; set; }
        public List<SelectListItem> comboListaProvince { get; set; }
        public List<SelectListItem> comboListaComuni { get; set; }

        public int RegioneId { get; set; }
        public int ProvinciaId { get; set; }
        public int ComuneId { get; set; }
    }
}