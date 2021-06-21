using System;

namespace VendasWebMvc.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {//estamos fzd uma exception personalizada pq tem a possibilidade excluisivamente de tratar a exception  
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
