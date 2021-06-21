using VendasWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using VendasWebMvc.Data;
using System;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Services.Exceptions;
using System.Threading.Tasks;

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
        public async Task<List<Vendedor>> FindAllAsync()
        {//isso vai acessar a minha fonte de dados relacionado a tabela de vendedores e converte p uma lista

            return await _context.Vendedor.ToListAsync();
        }
        public async Task InserirAsync(Vendedor obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Vendedor> EncontrarIdAsync(int id)//ele recebe um id
        {//e vai ter q retorna o vendedor q possui esse id, caso n exista, retorna null
            return await _context.Vendedor.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
            //esse include é p ele tbm busca nas tabelas(department)
        }
        public async Task RemoverAsync(int id)
        {
            try
            {
                var obj = await _context.Vendedor.FindAsync(id); //pega o obj passando o id
                _context.Vendedor.Remove(obj); //e vai remover esse obj
                await _context.SaveChangesAsync(); //e confirma essa alteração p atualiza la no banco de dados
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não é possível excluir o vendedor porque ele/ela tem vendas");
            }
        }
        public async Task UpdateAsync(Vendedor obj)
        {//any= se existe alg registro no bancoDados c a condição p eu coloca aqui
         //ta testando se no bancoDados algum vendedor x cujo o id seja = ao id do meu obj, 
            bool hasAny = await _context.Vendedor.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {//se n existe, tem a excessão
                throw new DllNotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj); // ele atualizara=update
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {//estou interceptando uma excessão de nivel acesso a dados, e eu estou relançando essa excessão usando a minha excessão em nivel de servico, isso é importante p segregar camadas 
             //= o controlador cvs c a camada de servico, excessões de nivel acesso a dados são capturadas pelo servico e relancadas na forma de excessoes d servico p o controlador
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
