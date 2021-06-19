using System.Collections.Generic;
using System.Linq;
using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class DepartmentService
    {
        private readonly VendasWebMvcContext _context;

        public DepartmentService(VendasWebMvcContext context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        {//criou um servico de departamento com o metodo p retornar os departments ordenados
            return _context.Department.OrderBy(x => x.Nome).ToList();
        }

    }
}
