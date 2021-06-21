using System;
using System.ComponentModel.DataAnnotations;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Quant { get; set; }
        public VendaStatus Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public SalesRecord()
        {

        }
        public SalesRecord(int id, DateTime data, double quant, VendaStatus status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quant = quant;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
