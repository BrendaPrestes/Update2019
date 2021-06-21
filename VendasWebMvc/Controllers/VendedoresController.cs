using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Services;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Services.Exceptions;
using System.Diagnostics;

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
        public async Task<IActionResult> Index()//chama o controlador
        {//MVC = m 
            var list = await _servicoVendedores.FindAllAsync(); //vai retorna uma lista de servico //o controlador acessou meu model
            return View(list); //dps ele encaminha os dados na view
        }
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync(); //aqui ele busca os dados de tds os departamentos
            var viewModel = new SellerFormViewModel { Departments = departments }; //instancio
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Vendedor = vendedor, Departments = departments };
                return View(viewModel);
            }
            await _servicoVendedores.InserirAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)//? = p indicar q é opcional
        {
            if (id == null)// se for null, quer dizer q a requisição foi feita de uma forma indevida
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _servicoVendedores.EncontrarIdAsync(id.Value); //pega o obj quem eu to querendo deleta
            if (obj == null) //se esse id n existi
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {//esse post é p executar e qnd aperta o delete= apaga 
            try
            {
                await _servicoVendedores.RemoverAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public async Task<IActionResult> Details(int? id)
        {//criou a ação Details no metodo get
            if (id == null)// se for null, quer dizer q a requisição foi feita de uma forma indevida
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _servicoVendedores.EncontrarIdAsync(id.Value); //pega o obj quem eu to querendo deleta
            if (obj == null) //se esse id n existi
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)// o id é obrigatorio, coloco o ?(opcional) p evitar uma excessão
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            //agr testar se esse id existe no banco de dados
            var obj = await _servicoVendedores.EncontrarIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            //agr abri a tela de edição e para isso precisa carrega meus departamentos para povoar a minha caixinha de seleção
            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Vendedor = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor) //criação edit no metodo POST
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Vendedor = vendedor, Departments = departments };
                return View(viewModel);
            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Incompatibilidade de id" });
            }
            try
            {
                await _servicoVendedores.UpdateAsync(vendedor);
                return RedirectToAction(nameof(Index)); //isso t redirecinando a minha requisição p a pg inicial q é o index
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier //esse macete é do framework p vc pegar o id interno da requisição
            };
            return View(viewModel);

        }
    }
}
