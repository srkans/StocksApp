using Microsoft.AspNetCore.Mvc;
using StocksApp.ServiceContracts;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinnhubService _finnhubService;
        public HomeController(IFinnhubService finnhubService)
        {
            _finnhubService = finnhubService;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string,object>? response = await _finnhubService.GetStockPriceQuote("MSFT");

            return View();
        }
    }
}
