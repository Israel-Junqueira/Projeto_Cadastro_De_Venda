using CadastroDeVendas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CadastroDeVendas.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> liste= new List<Department>();
            liste.Add(new Department{Id = 1, Name = "Eletronicos" });
            liste.Add(new Department { Id = 2, Name = "Moda" });

            return View(liste);
        }
    }
}
