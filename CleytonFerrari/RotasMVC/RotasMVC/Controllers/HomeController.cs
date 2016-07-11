using RotasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RotasMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<Noticia> todasAsNoticias;

        public HomeController()
        {
            todasAsNoticias = new Noticia().TodasAsNoticias().OrderByDescending(x => x.Data);
            //pega todas as noticias contidas na classe noticia, por meio do IEnumerable, 
            //ordena todos os itens de forma crescente
        }

        // GET: Home
        public ActionResult Index()
        {
            var ultimaNoticia = todasAsNoticias.Take(3);
            //pegar as ultimas 3 noticias
            var todasAsCategorias = todasAsNoticias.Select(x => x.Categoria).Distinct().ToList();
            //selecionar apenas os valores do atributo categoria presente nas noticias, de forma unica(sem ser repetido), convertendo para lista
            ViewBag.Categorias = todasAsCategorias;

            return View(ultimaNoticia);
        }

        public ActionResult TodasAsNoticias()
        {
            return View(todasAsNoticias);
        }

        public ActionResult MostraNoticia(int noticiaId, string titulo, string categoria)
        {
            return View(todasAsNoticias.FirstOrDefault(x => x.NoticiaId == noticiaId));
        }

        public ActionResult MostraCategoria(string categoria)
        {
            var categoriaEspecifica = todasAsNoticias.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();
            ViewBag.Categoria = categoria;
            return View(categoriaEspecifica);
        }
    }
}