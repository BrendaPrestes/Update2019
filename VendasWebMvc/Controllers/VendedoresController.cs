using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Services;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedores _servicoVendedores;
        private readonly DepartmentService _departmentService;

        public VendedoresController(ServicoVendedores servicoVendedores, DepartmentService departmentService)
        {
            _servicoVendedores = servicoVendedores;
            _departmentService = departmentService;
        }
        public IActionResult Index()//chama o controlador
        {//MVC = m 
            var list = _servicoVendedores.FindAll(); //vai retorna uma lista de servico //o controlador acessou meu model
            return View(list); //dps ele encaminha os dados na view
        }
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll(); //aqui ele busca os dados de tds os departamentos
            var viewModel = new SellerFormViewModel { Departments = departments }; //instancio
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _servicoVendedores.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
