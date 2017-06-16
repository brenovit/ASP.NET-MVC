using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Modelo.Tabela
{
    public class Categoria
    {
        public long? CategoriaID { get; set; }
        [DisplayName("Categoria")]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}