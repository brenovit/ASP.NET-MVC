using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validacoes.Models;

namespace Validacoes.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()     //carregar o form para preencher os dados da pessoa
        {
            var pessoa = new Pessoa();
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Index(Pessoa pessoa)    //postar os dados neste formulario
        {
            //ValidarCampos(pessoa); <- essa validação não é aconselhavel

            if (ModelState.IsValid)                 //efetua a validação dos dados, caso estejam validos
            {
                return View("Resultado", pessoa);   //manda a pessoa para a outra action
                //formas de View
                //View("Nome da view", objeto da view); <= tornando a view tipada
            }
            return View(pessoa);                    //caso não estejam, retorna esta view com os possiveis erros
        }

        public ActionResult Resultado(Pessoa pessoa)    //action que será usada para mandar os dados consistentes para o servidor
        {
            return View(pessoa);
        }

        public void ValidarCampos (Pessoa pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.Nome))
            {
                ModelState.AddModelError("Nome", "O campo nome não foi preenchido");
                //validação de uma propriedade do modelo
            }
            if(pessoa.Senha != pessoa.ConfirmacaoSenha)
            {
                ModelState.AddModelError("", "As senhas não conferem");
                //validação do modelo
            }
        }

        public ActionResult LoginUnico(string login)
        {
            var banco = new Collection<string>
            {
                "breno",
                "Cleyton",
                "Rafael"
            };
            //se todos os usuarios presetnes no banco for diferente do login, ele retorna true, caso não o login ja existe.
            return Json(banco.All(x => x.ToLower() != login.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}