using Projeto01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Controllers
{
    public class CategoriasController : Controller
    {
        public static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria()
            {
                CategoriaID = 1,
                Nome = "Notebooks"
            },
            new Categoria()
            {
                CategoriaID = 2,
                Nome = "Monitores"
            },
            new Categoria()
            {
                CategoriaID = 3,
                Nome = "Impressoras"
            },
            new Categoria()
            {
                CategoriaID = 4,
                Nome = "Mouses"
            },
            new Categoria()
            {
                CategoriaID = 5,
                Nome = "Desktops"
            }
        };
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias.OrderBy(c => c.Nome));
        }

        // GET: Create        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {            
            categoria.CategoriaID = categorias.Select(c => c.CategoriaID).Max() + 1;
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        // GET: Edit
        public ActionResult Edit(long id)
        {
            return View(categorias.Where(c => c.CategoriaID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaID == categoria.CategoriaID).First());            
            categorias.Add(categoria);
            //Alternativa para a possibilidade acima, remover o iten e depois adicionar
            //categorias[categorias.IndexOf(categorias.Where(c => c.CategoriaID == categoria.CategoriaID).First())] = categoria;
            return RedirectToAction("Index");
        }

        // GET: Detail
        public ActionResult Details(long id)
        {
            return View(categorias.Where(c => c.CategoriaID == id).First());
        }

        // GET: Delete
        public ActionResult Delete(long id)
        {
            //return View(categorias.Where(c => c.CategoriaID == id).First());
            return View(categorias.First(c => c.CategoriaID == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaID == categoria.CategoriaID).First());
            return RedirectToAction("Index");
        }
    }
}