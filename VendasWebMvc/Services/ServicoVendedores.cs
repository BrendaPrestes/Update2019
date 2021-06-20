using VendasWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using VendasWebMvc.Data;
using System;
using Microsoft.EntityFrameworkCore;

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
        public Vendedor EncontrarId(int id)//ele recebe um id
        {//e vai ter q retorna o vendedor q possui esse id, caso n exista, retorna null
            return _context.Vendedor.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id); 
            //esse include é p ele tbm busca nas tabelas(department)
        }
        public void Remover(int id)
        {
            var obj = _context.Vendedor.Find(id); //pega o obj passando o id
            _context.Vendedor.Remove(obj); //e vai remover esse obj
            _context.SaveChanges(); //e confirma essa alteração p atualiza la no banco de dados
        }
    }
}
