using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Projeto01.Models
{
    public class Categoria
    {
        public long CategoriaID { get; set; }
        [DisplayName("Categoria")]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}