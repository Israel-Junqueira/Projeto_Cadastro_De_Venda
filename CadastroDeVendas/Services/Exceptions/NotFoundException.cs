using System;
namespace CadastroDeVendas.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
