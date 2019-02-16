using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Dominio;
using WebApplication2.Dominio.Repositorio;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private IClienteRepositorio clienteRepositorio { get; set; }


        public HomeController(IClienteRepositorio repositorio)
        {

            this.clienteRepositorio = repositorio ?? throw new ArgumentNullException(nameof(clienteRepositorio));

        }

        public Task<ActionResult> Index()
        {
            return Task.Factory.StartNew<ActionResult>(() => View());

            
        }


        [HttpPost]
       public async Task<ActionResult> Salvar (ClienteViewModel model)
        {

            if (!ModelState.IsValid)
                return await
                        Task.Factory.StartNew<ActionResult>(() => View("Index", ModelState));
            

            return await Task.Factory.StartNew<ActionResult>(() =>
            {
                Cliente cliente = new Cliente()
                {
                    Agencia = model.Agencia,
                    Conta = model.Conta,
                    Cpf = model.Cpf,
                    Estado = model.Estado,
                    Nome = model.Nome                   
                };


                this.clienteRepositorio.SaveAsync(cliente);

                ViewBag.Sucesso = 1;

                return View("Index");
            }

            );
            
        }


        [HttpGet]
        public async Task<ActionResult> List()
        {
            return await Task.Factory.StartNew<ActionResult>(() =>
            {
                var clientes = this.clienteRepositorio.GetAllAsync().Result;

                List<ClienteViewModel> result = new List<ClienteViewModel>();

                foreach (var item in clientes)
                {
                    result.Add(new ClienteViewModel()
                    {
                        Id = item.Id,
                        Agencia = item.Agencia,
                        Conta = item.Conta,
                        Cpf = item.Cpf,
                        Estado = item.Estado,
                        Nome = item.Nome
                    });
                }

                return View(result);

            });
        }


    }
}