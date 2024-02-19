using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using CLCommon.Models;                  // Entity Framework nella class library CLCommon
using WebAppMVCComboCascadeEF.Models;    // CascadingModel, ErrorViewModel

namespace WebAppComboCascadeEF.Controllers
{
    public class HomeController : Controller
    {
        private readonly CorsoAcademyContext _context;

        // USAGE SERILOG
        private readonly ILogger<HomeController> _logger;

        public HomeController(CorsoAcademyContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // https://www.aspsnippets.com/Articles/3067/Cascading-Dependent-DropDownList-in-ASPNet-MVC/

        public IActionResult Index()
        {
            // COUNTRY === REGIONE
            CascadingModel model = new CascadingModel();
            foreach (var reg in _context.TRegiones)
            {
                model.comboListRegioni.Add(new SelectListItem { Text = reg.Nome, Value = reg.Id.ToString() });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int? regioneId, int? provinciaId, int? comuneId)
        {
            // COUNTRY === REGIONE
            CascadingModel model = new CascadingModel();
            foreach (var reg in _context.TRegiones)
            {
                model.comboListRegioni.Add(new SelectListItem { Text = reg.Nome, Value = reg.Id.ToString() });
            }

            if (regioneId.HasValue)
            {
                // STATES === PROVINCIA
                var listProvince = (from prov in _context.TProvincia
                                    where prov.IdRegione == regioneId.Value
                                    select prov).ToList();
                foreach (var prov in listProvince)
                {
                    model.comboListaProvince.Add(new SelectListItem { Text = prov.Nome, Value = prov.Id.ToString() });
                }

                if (provinciaId.HasValue)
                {
                    // CITIES === COMUNI
                    var listComuni = (from com in _context.TComunes
                                      where com.IdProvincia == provinciaId.Value
                                      select com).ToList();
                    foreach (var com in listComuni)
                    {
                        model.comboListaComuni.Add(new SelectListItem { Text = com.Nome, Value = com.Id.ToString() });
                    }
                }
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}