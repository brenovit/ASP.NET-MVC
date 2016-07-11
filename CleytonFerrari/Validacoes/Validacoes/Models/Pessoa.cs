using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Validacoes.Models
{
    public class Pessoa
    {
        //validando usando data Annotation
        [Required(ErrorMessage = "Nome não foi preenchido, retardado")]
        public string Nome { get; set; }

        [StringLength(50,MinimumLength =5,ErrorMessage = "Digite entre 5 e 50 letras")]
        public string Observacao { get; set; }

        [Range(18,50,ErrorMessage = "Você é jovem ou velho demais para usar este sistema")]
        public int Idade { get; set; }
        
        //usando o rejex como validação
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$", ErrorMessage = "O E-mail esta errado, conserte")]
        public string Email { get; set; }

        [RegularExpression(@"[a-zA-Z0-9]{5,15}", ErrorMessage = "Login ta muito pequeno ou grande, só de 5 a 15")]
        [Required(ErrorMessage = "Você esqueceu de botar um Login besta")]
        [Remote("LoginUnico","Pessoa", ErrorMessage = "Este login ja esta cadastrado")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Esqueceu a senha, imbecil")]
        public string Senha { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Senha",ErrorMessage = "Ta querendo usar 2 senhas é? Arrume já")]
        public string ConfirmacaoSenha { get; set; }
    }
}