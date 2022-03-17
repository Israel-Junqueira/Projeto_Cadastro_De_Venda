using System;
namespace CadastroDeVendas.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
         public DbConcurrencyException(string message) : base(message)
        {

        }
    }
}
