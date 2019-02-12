using Liceu.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liceu.WebApp.Models
{
    public class IndexPageModel
    {
        public IEnumerable<Livro> Livros { get; set; }

        public LivroFiltroModel FiltroModel { get; set; }

        public bool FiltroAplicado { get; set; }
    }
}
