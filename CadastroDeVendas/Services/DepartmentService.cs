using CadastroDeVendas.Data;
using CadastroDeVendas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace CadastroDeVendas.Services
{
    public class DepartmentService
    {
        private readonly CadastroDeVendasContext _context; // Essa e a dependencia


        public DepartmentService(CadastroDeVendasContext context)
        {
            _context = context;
        }

        public async  Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

        internal object FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
