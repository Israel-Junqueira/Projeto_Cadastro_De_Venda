﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroDeVendas.Models;

namespace CadastroDeVendas.Data
{
    public class CadastroDeVendasContext : DbContext
    {
        public CadastroDeVendasContext (DbContextOptions<CadastroDeVendasContext> options) : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
        public DbSet<Seller> Sellers { get; set; }


    }
}
