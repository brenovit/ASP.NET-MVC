﻿using Projeto01.Context;
using Projeto01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Controllers
{
    public class CategoriasController : Controller
    {
        /*public static IList<Categoria> categorias = new List<Categoria>()
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
        };*/
        private EFContext context = new EFContext();
        
        // GET: Categorias
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }

        // GET: Create        
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Read
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
                return HttpNotFound();
            return View(categoria);
        }

        // GET: Update
        public ActionResult Edit(long? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Categoria categoria = context.Categorias.Find(id);
            if(categoria == null)
                return HttpNotFound();
            return View(categoria);
        }
        // POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
                return HttpNotFound();
            return View(categoria);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}