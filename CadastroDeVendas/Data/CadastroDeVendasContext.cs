using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroDeVendas.Models;

namespace CadastroDeVendas.Data
{
    public class CadastroDeVendasContext : DbContext
    {
        public CadastroDeVendasContext (DbContextOptions<CadastroDeVendasContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroDeVendas.Models.Department> Department { get; set; }
    }
}
