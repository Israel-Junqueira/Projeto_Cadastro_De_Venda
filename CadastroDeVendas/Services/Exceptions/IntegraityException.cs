using System;

namespace CadastroDeVendas.Services.Exceptions
{
    public class IntegraityException : ApplicationException
    {

        public IntegraityException(string message) :base(message)
        {

        }
    }
}
