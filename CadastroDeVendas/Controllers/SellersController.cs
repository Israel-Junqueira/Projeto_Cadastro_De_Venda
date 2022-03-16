﻿using Microsoft.AspNetCore.Mvc;
using CadastroDeVendas.Services;
using CadastroDeVendas.Models.ViewModels;
using CadastroDeVendas.Models;

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
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
            
        }

        public IActionResult Create() //passo 2 criar o get action - 3 -proximo passo na pasta view sellers criar uma view com nome de Create
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.insert(seller);
            return RedirectToAction(nameof(Index));
        }

        //In controller, create "Delete" GET action

        public IActionResult Delete(int?id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
    }
}
