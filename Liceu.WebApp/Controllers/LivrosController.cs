using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liceu.Dominio.Entidades;
using Liceu.Dominio.Servicos;
using Liceu.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Liceu.WebApp.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ILivroServico _livroServico;

        public LivrosController(ILivroServico livroServico)
        {
            _livroServico = livroServico;
        }

        public IActionResult Index()
        {

            IndexPageModel model = new IndexPageModel()
            {
                Livros = _livroServico.BuscarLivros(),
                FiltroAplicado = false
            };
            return View(model);
        }

      
        [HttpPost]
        public IActionResult Filtrar(IndexPageModel model)
        {


            model.Livros = _livroServico.FiltrarLivros(
                model.FiltroModel.Titulo, model.FiltroModel.Autor, model.FiltroModel.Editora, model.FiltroModel.Ano);

            model.FiltroAplicado = true;
            ModelState.Clear();
            ModelState.Clear();
            return View("Index", model);

        }

        [Authorize(Policy = "SomenteBibliotecario")]
        public IActionResult Cadastro()
        {
            LivroCadastroModel model = new LivroCadastroModel()
            {
                ListaLivro = _livroServico.BuscarLivros()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "SomenteBibliotecario")]
        public IActionResult Cadastro(LivroCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                _livroServico.InserirLivro(new Livro()
                {
                    Ano = model.Ano,
                    Titulo = model.Titulo,
                    Autor = model.Autor,
                    Editora = model.Editora
                });
                ModelState.Clear();
            }
            return Cadastro();
        }


    }
}