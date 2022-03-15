using CadastroDeVendas.Data;
using CadastroDeVendas.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeVendas.Services
{
    public class SellerServiceClass
    {
        //antes eu cadastrei uma dependencia no Data.CadastroDeVendasContext
        private readonly CadastroDeVendasContext _context; // Essa e a dependencia

        
        public SellerServiceClass(CadastroDeVendasContext context)
        {
            _context = context;
        }
        // agr criar a lista q retorne os vendedores
        public List<Seller> FindAll()
        {
            return _context.Sellers.ToList();
                   
        }

        public void insert(Seller obj) //usei para inserir o os dadosque iram criar o vendedor no banco de dados.
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
