using Microsoft.AspNetCore.Mvc;
using CadastroDeVendas.Services;
using CadastroDeVendas.Models;

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

        public IActionResult Create() //passo 2 criar o get action - 3 -proximo passo na pasta view sellers criar uma view com nome de Create
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
