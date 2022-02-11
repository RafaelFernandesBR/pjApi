using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testeAc.models;

namespace testeAc.Controllers
{
    public class ApiController : Controller
    {
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

	[HttpGet("[action]")]
        public IActionResult allApps()
        {
			dataModel tt=new dataModel();
var final=tt.GetAll("SELECT * FROM aplicativos");
		return Json(final);
        }

	[HttpGet("[action]")]
        public IActionResult enviaDados([FromQuery] string nome, string descricao, string disponivel_ate)
        {
dataModel tt=new dataModel();
//inserte data
tt.Insert("INSERT INTO aplicativos(nome,descricao,disponivel_ate) VALUES('"+nome+"','"+descricao+"','"+disponivel_ate+"')");
		return Json("ok");
		}
    }
}
