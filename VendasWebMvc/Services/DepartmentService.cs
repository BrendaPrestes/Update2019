using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Data;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMvc.Services
{
    public class DepartmentService
    {
        private readonly VendasWebMvcContext _context;

        public DepartmentService(VendasWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> FindAllAsync()
        {//criou um servico de departamento com o metodo p retornar os departments ordenados
            //task = é um obj q encapsulao processamento assincrona deixando a rogramação mais simples
            return await _context.Department.OrderBy(x => x.Nome).ToListAsync();
        }

    }
}
