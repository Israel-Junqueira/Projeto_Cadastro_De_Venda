using Microsoft.AspNetCore.Mvc;
using CadastroDeVendas.Services;
namespace CadastroDeVendas.Controllers
{
    public class SellersController : Controller 
   {
        private readonly SellerServiceClass _sellerService; //dependencia

        public SellersController(SellerServiceClass sellerService)
        {
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
            
        }

   
    }
}
