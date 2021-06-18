using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Data
{
    public class ServicoSemeadura
    {
        private VendasWebMvcContext _context;
        public ServicoSemeadura(VendasWebMvcContext context)
        {
            _context = context;
        }
        public void Semente()//essa operação vai ser responsavel por popular a minha baseDados
        {
            if (_context.Department.Any() || //esse if ta testando se existe alg registro nessas tabelas
                _context.Vendedor.Any() ||
                _context.RecordVendas.Any())
            {
                return; //banco de dados ja foi populado
            }

            Department d1 = new Department(1, "Computadores");
            Department d2 = new Department(2, "Eletrônicos");
            Department d3 = new Department(3, "Moda");
            Department d4 = new Department(4, "Livros");

            Vendedor v1 = new Vendedor(1, "Bob Brown", "Bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Vendedor v2 = new Vendedor(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Vendedor v3 = new Vendedor(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Vendedor v4 = new Vendedor(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Vendedor v5 = new Vendedor(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Vendedor v6 = new Vendedor(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            RecordVendas r1 = new RecordVendas(1, new DateTime(2018, 09, 25), 11000.0, VendaStatus.Faturado, v1);
            RecordVendas r2 = new RecordVendas(2, new DateTime(2018, 09, 4), 7000.0, VendaStatus.Faturado, v5);
            RecordVendas r3 = new RecordVendas(3, new DateTime(2018, 09, 13), 4000.0, VendaStatus.Cancelado, v4);
            RecordVendas r4 = new RecordVendas(4, new DateTime(2018, 09, 1), 8000.0, VendaStatus.Faturado, v1);
            RecordVendas r5 = new RecordVendas(5, new DateTime(2018, 09, 21), 3000.0, VendaStatus.Faturado, v3);
            RecordVendas r6 = new RecordVendas(6, new DateTime(2018, 09, 15), 2000.0, VendaStatus.Faturado, v1);
            RecordVendas r7 = new RecordVendas(7, new DateTime(2018, 09, 28), 13000.0, VendaStatus.Faturado, v2);
            RecordVendas r8 = new RecordVendas(8, new DateTime(2018, 09, 11), 4000.0, VendaStatus.Faturado, v4);
            RecordVendas r9 = new RecordVendas(9, new DateTime(2018, 09, 14), 11000.0, VendaStatus.Pendente, v6);
            RecordVendas r10 = new RecordVendas(10, new DateTime(2018, 09, 7), 9000.0, VendaStatus.Faturado, v6);
            RecordVendas r11 = new RecordVendas(11, new DateTime(2018, 09, 13), 6000.0, VendaStatus.Faturado, v2);
            RecordVendas r12 = new RecordVendas(12, new DateTime(2018, 09, 25), 7000.0, VendaStatus.Pendente, v3);
            RecordVendas r13 = new RecordVendas(13, new DateTime(2018, 09, 29), 10000.0, VendaStatus.Faturado, v4);
            RecordVendas r14 = new RecordVendas(14, new DateTime(2018, 09, 4), 3000.0, VendaStatus.Faturado, v5);
            RecordVendas r15 = new RecordVendas(15, new DateTime(2018, 09, 12), 4000.0, VendaStatus.Faturado, v1);
            RecordVendas r16 = new RecordVendas(16, new DateTime(2018, 10, 5), 2000.0, VendaStatus.Faturado, v4);
            RecordVendas r17 = new RecordVendas(17, new DateTime(2018, 10, 1), 12000.0, VendaStatus.Faturado, v1);
            RecordVendas r18 = new RecordVendas(18, new DateTime(2018, 10, 24), 6000.0, VendaStatus.Faturado, v3);
            RecordVendas r19 = new RecordVendas(19, new DateTime(2018, 10, 22), 8000.0, VendaStatus.Faturado, v5);
            RecordVendas r20 = new RecordVendas(20, new DateTime(2018, 10, 15), 8000.0, VendaStatus.Faturado, v6);
            RecordVendas r21 = new RecordVendas(21, new DateTime(2018, 10, 17), 9000.0, VendaStatus.Faturado, v2);
            RecordVendas r22 = new RecordVendas(22, new DateTime(2018, 10, 24), 4000.0, VendaStatus.Faturado, v4);
            RecordVendas r23 = new RecordVendas(23, new DateTime(2018, 10, 19), 11000.0, VendaStatus.Cancelado, v2);
            RecordVendas r24 = new RecordVendas(24, new DateTime(2018, 10, 12), 8000.0, VendaStatus.Faturado, v5);
            RecordVendas r25 = new RecordVendas(25, new DateTime(2018, 10, 31), 7000.0, VendaStatus.Faturado, v3);
            RecordVendas r26 = new RecordVendas(26, new DateTime(2018, 10, 6), 5000.0, VendaStatus.Faturado, v4);
            RecordVendas r27 = new RecordVendas(27, new DateTime(2018, 10, 13), 9000.0, VendaStatus.Pendente, v1);
            RecordVendas r28 = new RecordVendas(28, new DateTime(2018, 10, 7), 4000.0, VendaStatus.Faturado, v3);
            RecordVendas r29 = new RecordVendas(29, new DateTime(2018, 10, 23), 12000.0, VendaStatus.Faturado, v5);
            RecordVendas r30 = new RecordVendas(30, new DateTime(2018, 10, 12), 5000.0, VendaStatus.Faturado, v2);

            _context.Department.AddRange(d1, d2, d3, d4); //AddRange= ele permite q vc add varios objetos so de uma vez

            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);

            _context.RecordVendas.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
                );

            _context.SaveChanges(); //salva e confirma as alterações no banco de dados
        }
    }
}
