using System.Collections.Generic;

namespace VendasWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {//essa é a class q vai conter os dados para o formulario de casdatro de vendedor

        public Vendedor Vendedor { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
