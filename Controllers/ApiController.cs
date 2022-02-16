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
				dataModel tt=new dataModel();
	var final=tt.GetAll("SELECT * FROM aplicativos");
			return Json(final);
			}

		[HttpGet("[action]")]
			public IActionResult enviaDados([FromQuery] string nome, string descricao, string disponivel_ate)
			{
string [] disponivel_parc=disponivel_ate.Split("-");
disponivel_ate=disponivel_parc[2]+"-"+disponivel_parc[1]+"-"+disponivel_parc[0];
	dataModel tt=new dataModel();
	//inserte data
	tt.Insert("INSERT INTO aplicativos(nome,descricao,disponivel_ate) VALUES('"+nome+"','"+descricao+"','"+disponivel_ate+"')");
			return Json(StatusCode(200));
			}

		[HttpGet("[action]")]
			public IActionResult getId([FromQuery] int id)
			{
	dataModel tt=new dataModel();
	//get data
	var final=tt.GetId("SELECT * FROM aplicativos WHERE id = "+id+";");
	return Json(final);
			}

	[HttpGet("[action]")]
			public IActionResult deleteId([FromQuery] int id)
			{
	dataModel tt=new dataModel();
	//delete data
	tt.Delete("DELETE FROM aplicativos WHERE id = "+id+";");
			return Json("ok");
			}
		}
	}
