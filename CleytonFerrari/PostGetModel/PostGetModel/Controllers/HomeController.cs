using PostGetModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostGetModel.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //não precisa colocar o [HttpGet] pois todas as actions são get
        [HttpGet]
        public ActionResult Index()
        {
            var pessoa = new Pessoa //este objeto foi criado em models, a classe pessoa
            {
                PessoaId = 1,
                Nome = "Breno",
                Twitter = "@brenovit"
            };

            var pessoa2 = new Pessoa //este objeto foi criado em models, a classe pessoa
            {
                PessoaId = 2,
                Nome = "Cleyton",
                Twitter = "@cleyFerrari"
            };

            var pessoa3 = new Pessoa //este objeto foi criado em models, a classe pessoa
            {
                PessoaId = 3,
                Nome = "Rafael",
                Twitter = "@rafa"
            };

            //atravez do ViewData estou enviando os dados do objeto acima para minha view
            ViewData["PessoaId"] = pessoa.PessoaId; //variavei dinamica, array          
            ViewData["Twitter"] = pessoa.Twitter;
            ViewData["Nome"] = pessoa.Nome;

            ViewBag.pid = pessoa2.PessoaId; //variavei dinamica, array          
            ViewBag.ptwit = pessoa2.Twitter;
            ViewBag.pnome = pessoa2.Nome;

            return View(pessoa3);
        }

        [HttpPost]
        public ActionResult Lista(Pessoa pessoa)
        {
            /*ViewData["PessoaId"] = form["pId"];
            ViewData["Nome"] = form["pNome"];
            ViewData["Twitter"] = form["pTwitter"];*/

            /*ViewData["PessoaId"] = pessoa.PessoaId;
            ViewData["Twitter"] = pessoa.Twitter;
            ViewData["Nome"] = pessoa.Nome;*/
            
            return View(pessoa);
        }
    }
}