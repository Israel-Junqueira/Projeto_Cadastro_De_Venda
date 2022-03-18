using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CadastroDeVendas.Services;
using CadastroDeVendas.Models.ViewModels;
using CadastroDeVendas.Models;
using CadastroDeVendas.Services.Exceptions;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CadastroDeVendas.Controllers
{
    public class SellersController : Controller 
   {
        private readonly SellerServiceClass _sellerService; //dependencia
        private readonly DepartmentService _departmentService;

        public SellersController(SellerServiceClass sellerService,DepartmentService department)
        {
            _sellerService = sellerService;
            _departmentService = department;    
        }
        public async Task<IActionResult> Index()
        {
            var list =await _sellerService.FindAllAsync();
            return View(list);
            
        }

        public async Task<IActionResult> Create() //passo 2 criar o get action - 3 -proximo passo na pasta view sellers criar uma view com nome de Create
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)  // não esqueça de usar isso para que a pessoa não desabilite o java e ainda sim consiga cadastrar
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
               
            }

           await _sellerService.insertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        //In controller, create "Delete" GET action

        public async Task<IActionResult> Delete(int?id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj =await _sellerService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
           await _sellerService.remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task <IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error),new {message = "Id not provided"});
            }
            var obj =await _sellerService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);

        }

        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj =await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Department> departments =await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj,Departments = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Seller seller)
        {
            if (!ModelState.IsValid)  // não esqueça de usar isso para que a pessoa não desabilite o java e ainda sim consiga cadastrar
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller=seller,Departments = departments };
                return View(viewModel);
            }

            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not id mismatch" });
            }
            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }catch (NotFoundException e )
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e )
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error (string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
