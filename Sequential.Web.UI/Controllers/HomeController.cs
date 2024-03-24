using Appointment.Common.Business.Abstract.Cache;
using Microsoft.AspNetCore.Mvc;

namespace Sequential.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRedisRequestDirectorateCode6 _redisRequestDirectorateCode6;
        public HomeController(IRedisRequestDirectorateCode6 redisRequestDirectorateCode6)
        {
            _redisRequestDirectorateCode6 = redisRequestDirectorateCode6;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult KimlikDogrulamaBasarili()
		{
			return View();
		}

		public IActionResult ParaAktarimOnay()
		{
			return View();
		}
	}
}
