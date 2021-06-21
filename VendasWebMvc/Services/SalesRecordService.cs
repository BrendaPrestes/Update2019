using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Data;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMvc.Services
{
    public class SalesRecordService
    {

        private readonly VendasWebMvcContext _context;

        public SalesRecordService(VendasWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {//essa declaracao pega o RecordVendas q é DbSet, e construi um obj Result q é do tipo IQueryable(em cima dele posso acrescentaroutros detalhes da minha consulta
            var result = from obj in _context.RecordVendas select obj;
            if (minDate.HasValue)//ou seja, eu informei uma data min
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)//ou seja, eu informei uma data max
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result 
                .Include(x => x.Vendedor) //fiz o json
                .Include(x => x.Vendedor.Department) //fiz o json na tabela de departments
                .OrderByDescending(x => x.Data) //ordena por data
                .ToListAsync();
        }

    }
}
