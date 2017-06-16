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
using Servico.Cadastros;

namespace Projeto01.Controllers
{
    public class FabricantesController : Controller
    {
        private FabricanteServico fabricanteServico = new FabricanteServico();
        
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(fabricanteServico.ObterClassificadosPorNome());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Read
        public ActionResult Detail(long? id)
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
        public ActionResult Create(Fabricante fabricante)
        {
            return Gravar(fabricante);
        }
        
        // POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            return Gravar(fabricante);
        }
        
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Fabricante fabricante = fabricanteServico.EliminarPorId(id);
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ObterVisaoPorId(long? id)
        {
            if(id == null) //para pegar os detalhes, verifica se o ID do get é nulo
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna uma visão de erro informanado uma requisição ruim
            }
            Fabricante fabricante = fabricanteServico.ObterPorId((long)id); //busca e retorna um objeto fabricante que tenho o id informado

            if (fabricante == null)//se a busca retornar nulo
            {
                return HttpNotFound();//retorna uma visão de item não encontrado
            }
            return View(fabricante);//se a buscar der certo, retorna uma visão de edição com os dados do objeto separados nos campos
        }

        private ActionResult Gravar(Fabricante fabricante = null)
        {
            try
            {
                if (ModelState.IsValid)//antes de persistir a edição, verifica se o modelo é valido (campos vazios, regras de negocios(DataAnnotations))
                {
                    fabricanteServico.Gravar(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch
            {
                return View(fabricante);
            }
        }

    }
}