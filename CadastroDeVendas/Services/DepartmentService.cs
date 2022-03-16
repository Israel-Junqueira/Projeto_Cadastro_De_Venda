using CadastroDeVendas.Data;
using CadastroDeVendas.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeVendas.Services
{
    public class DepartmentService
    {
        private readonly CadastroDeVendasContext _context; // Essa e a dependencia


        public DepartmentService(CadastroDeVendasContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
