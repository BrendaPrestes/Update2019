using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Services;
using VendasWebMvc.Models;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedores _servicoVendedores;

        public VendedoresController(ServicoVendedores servicoVendedores)
        {
            _servicoVendedores = servicoVendedores;
        }
        public IActionResult Index()//chama o controlador
        {//MVC = m 
            var list = _servicoVendedores.FindAll(); //vai retorna uma lista de servico //o controlador acessou meu model
            return View(list); //dps ele encaminha os dados na view
        }
        public IActionResult Create()
        {
            return View();
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
