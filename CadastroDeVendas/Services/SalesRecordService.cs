using CadastroDeVendas.Data;
using CadastroDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq; //para usar o select
using Microsoft.EntityFrameworkCore; //para usar o includ
using System.Threading.Tasks; //para usar o task

namespace CadastroDeVendas.Services
{
    public class SalesRecordService
    {
        private readonly CadastroDeVendasContext _context; // Essa e a dependencia


        public SalesRecordService(CadastroDeVendasContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) //oque é operação assincrona?
        {                                                                                     // Como funciona a espressão lambda
            var result = from obj in _context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
