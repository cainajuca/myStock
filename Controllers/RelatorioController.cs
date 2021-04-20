using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAL;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SistemaVenda.Controllers
{
    public class RelatorioController : Controller
    {

        protected ApplicationDbContext mContext;

        public RelatorioController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Grafico()
        {

            var lista = mContext.VendaProdutos
                .Include(x => x.Produto.Categoria)
                .AsEnumerable()
                .GroupBy(x => x.CodigoProduto)
                .Select(y => new GraficoViewModel
                {
                    CodigoProduto = y.First().CodigoProduto,
                    Descricao = y.First().Produto.Descricao,
                    TotalVendido = y.Sum(z => z.Quantidade)
                }).ToList();

            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;

            var random = new Random();

            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].TotalVendido.ToString() + ",";
                labels += "'" + lista[i].Descricao.ToString() + "',";
                cores += "'" + String.Format("#{0:X6}",random.Next(0x1000000)) + "',";
            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;

            return View();
        }
    }
}
