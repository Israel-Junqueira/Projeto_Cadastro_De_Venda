using CadastroDeVendas.Data;
using CadastroDeVendas.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CadastroDeVendas.Services.Exceptions;
using System.Threading.Tasks;

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
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Sellers.ToListAsync();
                   
        }

        public async Task insertAsync(Seller obj) //usei para inserir o os dados que irão criar o vendedor no banco de dados.
        {
           // obj.Department = _context.Department.First();//pega o primeiro departamento do banco de dados e associa ao vendedor
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        //Delete seller
        public async  Task<Seller> FindByIdAsync(int id)
        {                               //inclui o include para bostrar o department do vendedor
                return await _context.Sellers.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task remove(int id)
        {
            var obj =await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(obj);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {                       //any ele procura o obj pra ve se existe 
            //leitura: Se não existir 
            bool HasAny = await _context.Sellers.AnyAsync(x => x.Id == obj.Id);
            if (!HasAny)
            {
                throw new NotFoundException("ID not found");
            }
            try
            {
                 _context.Update(obj);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e )
            {
                throw new DbConcurrencyException(e.Message);
            }
        }  

    }
}
