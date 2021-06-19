using System;
using System.Linq;
using System.Collections.Generic;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public DateTime DataNasc { get; set; }
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
