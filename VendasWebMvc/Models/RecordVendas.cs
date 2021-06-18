using System;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Models
{
    public class RecordVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quant { get; set; }
        public VendaStatus Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RecordVendas()
        {

        }
        public RecordVendas(int id, DateTime data, double quant, VendaStatus status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quant = quant;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
