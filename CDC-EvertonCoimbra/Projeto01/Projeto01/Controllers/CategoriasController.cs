using Persistencia.Context;
using Modelo.Tabela;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Servico.Tabelas;

namespace Projeto01.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriaServico categoriaServico = new CategoriaServico();
                    
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaServico.ObterClassificadasPorNome());
        }

        // GET: Create        
        public ActionResult Create()
        {
            return View();
        }
        
        // GET: Read
        public ActionResult Details(long? id)
        {
            return ObterVisaoPorId(id);
        }

        // GET: Update
        public ActionResult Edit(long? id)
        {           
            return ObterVisaoPorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoPorId(id);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return Gravar(categoria);
        }

        // POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return Gravar(categoria);
        }
       
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Categoria categoria = categoriaServico.EliminarPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        private ActionResult Gravar(Categoria categoria = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.Gravar(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ObterVisaoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.ObterPorId((long) id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
    }
}