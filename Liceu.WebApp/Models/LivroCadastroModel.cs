using Liceu.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Liceu.WebApp.Models
{
    public class LivroCadastroModel
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Editora { get; set; }

        public IEnumerable<Livro> ListaLivro { get; set; }
    }


}
