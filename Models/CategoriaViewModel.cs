using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class CategoriaViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage="Informe a Descrição da Categoria!")]
        public string Descricao { get; set; }
    }
}
