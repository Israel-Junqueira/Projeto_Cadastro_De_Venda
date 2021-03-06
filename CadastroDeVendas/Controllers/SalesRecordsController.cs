using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CadastroDeVendas.Services;
namespace CadastroDeVendas.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService) //lembre de usar a ferramenta ao lado gerador de contrutor
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async  Task<IActionResult> SimpleSearch(DateTime? minDate,DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year,1,1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateAsync(minDate,maxDate);
            return View(result); //se vc não colocar o result , o resultado da lista não sera enviado causando um erro na tela de visualização
        }
        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
