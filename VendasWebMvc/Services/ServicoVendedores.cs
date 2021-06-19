using VendasWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using VendasWebMvc.Data;

namespace VendasWebMvc.Services
{
    public class ServicoVendedores
    {//readonly = p prevenir q essa dependencia pd ser alterada
        private readonly VendasWebMvcContext _context;

        public ServicoVendedores(VendasWebMvcContext context)
        {
            _context = context;
        }

        //FindAll p retorna uma lista com tds vendedores c o bancoDados
        public List<Vendedor> FindAll()
        {//isso vai acessar a minha fonte de dados relacionado a tabela de vendedores e converte p uma lista

            return _context.Vendedor.ToList();
        }
        public void Inserir(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }

}
