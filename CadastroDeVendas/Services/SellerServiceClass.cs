using CadastroDeVendas.Data;
using CadastroDeVendas.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CadastroDeVendas.Services.Exceptions;

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

        public void insert(Seller obj) //usei para inserir o os dados que irão criar o vendedor no banco de dados.
        {
           // obj.Department = _context.Department.First();//pega o primeiro departamento do banco de dados e associa ao vendedor
            _context.Add(obj);
            _context.SaveChanges();
        }

        //Delete seller
        public Seller FindById(int id)
        {                               //inclui o include para bostrar o department do vendedor
                return _context.Sellers.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void remove(int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {                       //any ele procura o obj pra ve se existe 
            //leitura: Se não existir 
            if (!_context.Sellers.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("ID not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e )
            {
                throw new DbConcurrencyException(e.Message);
            }
        }  

    }
}
