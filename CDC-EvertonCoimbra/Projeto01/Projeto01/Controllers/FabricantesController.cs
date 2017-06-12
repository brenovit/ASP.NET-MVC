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

namespace Projeto01.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();        //Objeto de cntexto para efetuar a manipulação no banco

        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(f => f.Nome));
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            context.Fabricantes.Add(fabricante); //para inserir um dado no banco, basta setarmos o tipo de dado que vamos usar, colocar um add e passar o objeto como parametro
            context.SaveChanges();  //em seguida salvamos os dados 
            return RedirectToAction("Index");   //e retornamos para a view
        }

        // GET: Read
        public ActionResult Detail(long? id)
        {
            if (id == null) //para pegar os detalhes, verifica se o ID do get é nulo
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //retorna uma visão de erro informanado uma requisição ruim
            Fabricante fabricante = context.Fabricantes.Where(f => f.FabricanteID == id).Include("Produtos.Categoria").First();   //busca e retorna um objeto fabricante que tenho o id informado
            if (fabricante == null) //se a busca retornar nulo
                return HttpNotFound();  //retorna uma visão de item não encontrado
            return View(fabricante);        //se a buscar der certo, retorna uma visão de edição com os dados do objeto separados nos campos
        }

        // GET: Update
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
                return HttpNotFound();
            return View(fabricante);
        }

        // POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid) //antes de persistir a edição, verifica se o modelo é valido (campos vazios, regras de negocios(DataAnnotations))
            {
                context.Entry(fabricante).State = EntityState.Modified;     //informa que o modelo definido sofreu alteração
                context.SaveChanges();                      //persiste a alteração de acordo com o estado dele
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
                return HttpNotFound();
            return View(fabricante);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }

    }
}