using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected ApplicationDbContext _repositorio;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext repositorio)
        {
            _repositorio = repositorio;
            _logger = logger;
        }

        public IActionResult Index()
        {

            IEnumerable<Categoria> lista = _repositorio.Categoria.ToList();

            // Create DB
            //Categoria categoria = new Categoria()
            //{
            //    Descricao = "Teste2"
            //};
            //_repositorio.Categoria.Add(categoria);

            // Update DB
            //Categoria objCategoria = _repositorio.Categoria.Where(x => x.Codigo == 2).FirstOrDefault();
            //objCategoria.Descricao = "Doces";
            //_repositorio.Entry(objCategoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            // Read DB
            //IEnumerable<Categoria> lista = _repositorio.Categoria.ToList();
            //return View(lista);

            // Delete DB
            //Categoria objCategoria = _repositorio.Categoria.Where(x => x.Codigo == 3).FirstOrDefault();
            //_repositorio.Attach(objCategoria);
            //_repositorio.Remove(objCategoria);

            //_repositorio.SaveChanges();

            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
