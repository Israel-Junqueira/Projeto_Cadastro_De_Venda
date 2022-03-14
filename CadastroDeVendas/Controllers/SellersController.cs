using Microsoft.AspNetCore.Mvc;

namespace CadastroDeVendas.Controllers
{
    public class SellersController : Controller 
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
