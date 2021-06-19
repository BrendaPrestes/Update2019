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
        public IActionResult Delete(int? id)//? = p indicar q é opcional
        {
            if (id == null)// se for null, quer dizer q a requisição foi feita de uma forma indevida
            {
                return NotFound();//retorna "não encontrado"
            }
            var obj = _servicoVendedores.EncontrarId(id.Value); //pega o obj quem eu to querendo deleta
            if (obj == null) //se esse id n existi
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _servicoVendedores.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
