using System.Collections.Generic;
using System.Linq;
using System;
namespace CadastroDeVendas.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Seller> sellers { get; set; } = new List<Seller>(); //pois esse departamento possui varios vendedores

        public Department()
        {
             
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void addSeller(Seller seller)
        {
            sellers.Add(seller);
        }

        public double totalSalles(DateTime inicial , DateTime final)
        {
            return sellers.Sum(seller => seller.TotalSales(inicial, final));
        }
    }
}
