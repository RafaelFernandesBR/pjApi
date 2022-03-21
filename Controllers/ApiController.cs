using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using pjApi.models;

namespace pjApi.Controllers
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
            dataModel tt = new dataModel();
            var final = tt.GetAll("SELECT * FROM aplicativos");
            return Json(final);
        }

        [HttpPost("[action]")]
        public IActionResult enviaDados(string nome, string descricao, string disponivel_ate, string url)
        {
            dataModel tt = new dataModel();
                //inserte data
            tt.Insert("INSERT INTO aplicativos(nome,descricao,disponivel_ate, url) VALUES('" + nome + "','" + descricao + "','" + disponivel_ate + "','" + url + "')");
            return Json(StatusCode(200));
        }

        [HttpGet("[action]")]
        public IActionResult getId([FromQuery] int id)
        {
            dataModel tt = new dataModel();
            //get data
            var final = tt.GetId("SELECT * FROM aplicativos WHERE id = " + id + ";");
            return Json(final);
        }

        [HttpDelete("[action]")]
        public IActionResult deleteId(int id)
        {
            dataModel tt = new dataModel();
            //delete data
            tt.Delete("DELETE FROM aplicativos WHERE id = " + id + ";");
            return Json(StatusCode(200));
        }
    }
}
