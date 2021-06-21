using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data Nasc")] //assim q customiza oq vai aparece no display=exibição
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }

        [Display(Name = "Salario Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalarioBase { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<RecordVendas> Vendas { get; set; } = new List<RecordVendas>();

        public Vendedor()
        {

        }
        public Vendedor(int id, string nome, string email, DateTime dataNasc, double salarioBase, Department department)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNasc = dataNasc;
            SalarioBase = salarioBase;
            Department = department;
        }

        public void AddVendas(RecordVendas rv)
        {
            Vendas.Add(rv);
        }
        public void RemoveVendas(RecordVendas rv)
        {
            Vendas.Remove(rv);
        }
        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(rv => rv.Data >= inicial && rv.Data <= final).Sum(rv => rv.Quant);
        }
    }
}
